namespace GPIO;

public class GpioFactory
{
    public string BasePath { get; set; } = "/sys/class/gpio";

    public GpioFactory(string basePath)
    {
        BasePath = basePath;
    }

    public GpioFactory()
    {
    }

    public GpioFactory WithBasePath(string basePath)
    {
        BasePath = basePath;
        return this;
    }
    
    public GpioBuilder WithPin(int pin)
    {
        return new GpioBuilder
        {
            BasePath = BasePath,
            Pin = pin
        };
    }
    
    public GpioBuilder WithActiveLow(int pin, ActiveLow activeLow)
    {
        return new GpioBuilder
        {
            BasePath = BasePath,
            Pin = pin,
            ActiveLow = activeLow
        };
    }
    
    public GpioBuilder WithDirection(int pin, Direction direction)
    {
        return new GpioBuilder
        {
            BasePath = BasePath,
            Pin = pin,
            Direction = direction
        };
    }
    
    public GpioBuilder WithEdge(int pin, Edge edge)
    {
        return new GpioBuilder
        {
            BasePath = BasePath,
            Pin = pin,
            Edge = edge
        };
    }
    
    public GpioBuilder WithValue(int pin, Value value)
    {
        return new GpioBuilder
        {
            BasePath = BasePath,
            Pin = pin,
            Value = value
        };
    }
}