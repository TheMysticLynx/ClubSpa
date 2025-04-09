#region

using System.Device.Gpio;

#endregion

namespace GPIO.Devices;

public class Relay
{
    private readonly bool _useHigh;
    private Gpio.Gpio _gpio;

    public Relay(int pin, GpioController controller, bool useHigh = true)
    {
        _useHigh = useHigh;
        _gpio = new Gpio.Gpio(pin, PinMode.Output, controller);
    }

    public void Close()
    {
        _gpio.WriteValue(_useHigh ? PinValue.Low : PinValue.High);
    }

    public void Open()
    {
        _gpio.WriteValue(_useHigh ? PinValue.High : PinValue.Low);
    }
}