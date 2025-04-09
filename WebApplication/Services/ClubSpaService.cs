#region

using System.Device.Gpio;
using GPIO.Devices;
using Serilog;

#endregion

namespace WebApplication.Services;

public class ClubSpaService(ClubSpaServiceConfiguration configuration, GpioController _controller)
{
    private CancellationTokenSource _cycleCancellationTokenSource = new();
    private FloatValve _floatValve = configuration.FloatValve;
    private SemaphoreSlim _lock = new(1);
    private Relay _relay = configuration.StartRelay;
    private ClubSpaState _state = new();

    public void ThrowIfCantStart()
    {
        if (_state.IsRunning)
        {
            Log.Verbose("Already running");
            throw new InvalidOperationException("The spa is already running");
        }

        if (!_floatValve.IsOpen) return;
        Log.Verbose("Float valve is open");
        throw new InvalidOperationException("The float valve is open");
    }
    
    public async Task Start(TimeSpan interval)
    {
        try
        {
            _cycleCancellationTokenSource = new CancellationTokenSource();
            ThrowIfCantStart();

            _state.IsRunning = true;
            _state.EndTime = DateTime.Now.Add(interval);
            Log.Verbose("Starting spa with interval {interval}", interval);
            _relay.Open();

            // wait for end of cycle or cancellation
            Log.Verbose("Waiting for cycle to end");
            await Task.Delay(interval, _cycleCancellationTokenSource.Token);
            Log.Verbose("Cycle ended");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error starting spa");
            throw;
        }
        finally
        {
            Log.Verbose("Releasing lock");
            _state.IsRunning = false;
            _state.EndTime = DateTime.MinValue;
            _relay.Close();
        }
    }

    public async Task Stop()
    {
        await _lock.WaitAsync();
        try
        {
            _cycleCancellationTokenSource.Cancel();
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task FloatValveTest()
    {
        while (true)
        {
            Console.WriteLine("{0}", _floatValve.IsOpen);
        }
    }
}

public class TransactionTracker
{
}