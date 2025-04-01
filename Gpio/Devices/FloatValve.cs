using System.Device.Gpio;

namespace GPIO.Devices;

public class FloatValve
{
    private Gpio _gpio;

    private readonly bool _useHigh;

    public FloatValve(int pin, GpioController controller, bool useHigh = true)
    {
        _useHigh = useHigh;
        _gpio = new Gpio(pin, controller);
        _gpio.SetDirection(PinMode.InputPullDown);
    }

    public bool IsOpen => _gpio.ReadValue() == (_useHigh ? PinValue.High : PinValue.Low);
}