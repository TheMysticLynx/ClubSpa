#region

using System.Device.Gpio;
using Serilog;

#endregion

namespace GPIO.Gpio;

public class Gpio
{
    private readonly ILogger _log = Log.ForContext<Gpio>();

    private readonly int _pin;
    private GpioController _controller;

    public Gpio(int pin, PinMode mode, GpioController controller)
    {
        _pin = pin;
        _controller = controller;
        controller.OpenPin(pin, mode);
    }

    ~Gpio()
    {
        _controller.ClosePin(_pin);
    }

    public PinMode GetDirection()
    {
        var mode = _controller.GetPinMode(_pin);
        _log.Information("Getting direction {Mode} for pin {Pin}", mode, _pin);
        return mode;
    }

    public PinValue ReadValue()
    {
        var value = _controller.Read(_pin);
        _log.Information("Reading value {Value} from pin {Pin}", value, _pin);
        return value;
    }

    public void SetDirection(PinMode mode)
    {
        _log.Information("Setting direction {Mode} for pin {Pin}", mode, _pin);
        _controller.SetPinMode(_pin, mode);
    }

    public void WriteValue(PinValue value)
    {
        _log.Information("Writing value {Value} to pin {Pin}", value, _pin);
        _controller.Write(_pin, value);
    }
}