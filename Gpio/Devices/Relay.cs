using System.Device.Gpio;

namespace GPIO.Devices;

public class Relay
{
    private Gpio _gpio;

    private readonly bool _useHigh;

    public Relay(int pin, GpioController controller, bool useHigh = true)
    {
        _useHigh = useHigh;
        _gpio = new Gpio(pin, controller);
        _gpio.SetDirection(PinMode.Output);
    }

    public void Open() => _gpio.WriteValue(_useHigh ? PinValue.High : PinValue.Low);
    
    public void Close() => _gpio.WriteValue(_useHigh ? PinValue.Low : PinValue.High);
}