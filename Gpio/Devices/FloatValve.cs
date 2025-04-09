#region

using System.Device.Gpio;

#endregion

namespace GPIO.Devices;

public class FloatValve
{
    // Whether to use high or low to indicate the valve is open
    private readonly bool _useHigh;
    private Gpio.Gpio _gpio;

    public FloatValve(int pin, GpioController controller, bool useHigh = true)
    {
        _useHigh = useHigh;
        _gpio = new Gpio.Gpio(pin, PinMode.InputPullUp, controller);
    }

    public bool IsOpen => _gpio.ReadValue() == (_useHigh ? PinValue.High : PinValue.Low);
}