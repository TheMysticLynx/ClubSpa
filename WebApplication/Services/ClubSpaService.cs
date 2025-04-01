using System.Device.Gpio;
using GPIO;
using GPIO.Devices;
using Serilog;

namespace ClubSpaApi.Services;

public class ClubSpaService(ClubSpaServiceConfiguration configuration, GpioController _controller)
{
    private ClubSpaState _state = new();
    private SemaphoreSlim _lock = new SemaphoreSlim(1);
    private FloatValve _floatValve = new(configuration.FloatValvePin, _controller, false);
    private Relay _relay = new(configuration.StartPin, _controller);
    
    private CancellationTokenSource _cycleCancellationTokeSource = new();

    public async Task Start(TimeSpan interval)
    {
        Log.Verbose("Waiting for lock");
        await _lock.WaitAsync();
        Log.Verbose("Obtained lock");
        _cycleCancellationTokeSource = new CancellationTokenSource();
        try
        {
            if (_floatValve.IsOpen) 
            {
                Log.Verbose("Float valve is open");
                throw new InvalidOperationException("The float valve is open");
            }
            
            if (_state.IsRunning)
            {
                Log.Verbose("Already running");
                throw new InvalidOperationException("The spa is already running");
            }

            _state.IsRunning = true;
            _state.EndTime = DateTime.Now.Add(interval);
            Log.Verbose("Starting spa with interval {interval}", interval);
            _relay.Open();
            
            // wait for end of cycle or cancellation
            Log.Verbose("Waiting for cycle to end");
            Task.Delay(interval, _cycleCancellationTokeSource.Token).Wait();
            Log.Verbose("Cycle ended");
        } catch (Exception ex)
        {
            Log.Error(ex, "Error starting spa");
            throw;
        } finally
        {
            Log.Verbose("Releasing lock");
            _state.IsRunning = false;
            _state.EndTime = DateTime.MinValue;
            _lock.Release();
            _relay.Close();
        }
    }
    
    public async Task Stop()
    {
        await _lock.WaitAsync();
        try
        {
            _cycleCancellationTokeSource.Cancel();
        } finally
        {
            _lock.Release();
        }
    }

    public void FloatTest()
    {
        while (true)
        {
            Log.Information("Float valve is open: {IsOpen}", _floatValve.IsOpen);
            Task.Delay(500).Wait();
        }
    }
}