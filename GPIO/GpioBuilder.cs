namespace GPIO;

public class GpioBuilder
{
    public string BasePath { get; set; } = "/sys/class/gpio";
    public int Pin { get; set; }
    
    public ActiveLow? ActiveLow { get; set; }
    public Direction? Direction { get; set; }
    public Edge? Edge { get; set; }
    public Value? Value { get; set; }
    
    public GpioBuilder WithBasePath(string basePath)
    {
        BasePath = basePath;
        return this;
    }
    
    public GpioBuilder WithPin(int pin)
    {
        Pin = pin;
        return this;
    }
    
    public GpioBuilder WithActiveLow(ActiveLow activeLow)
    {
        ActiveLow = activeLow;
        return this;
    }
    
    public GpioBuilder WithDirection(Direction direction)
    {
        Direction = direction;
        return this;
    }
    
    public GpioBuilder WithEdge(Edge edge)
    {
        Edge = edge;
        return this;
    }
    
    public GpioBuilder WithValue(Value value)
    {
        Value = value;
        return this;
    }
    
    public Gpio Build()
    {
        var gpio = new Gpio(BasePath, Pin);
        
        if (ActiveLow.HasValue)
        {
            gpio.WriteActiveLow(ActiveLow.Value);
        }
        
        if (Direction.HasValue)
        {
            gpio.WriteDirection(Direction.Value);
        }
        
        if (Edge.HasValue)
        {
            gpio.WriteEdge(Edge.Value);
        }
        
        if (Value.HasValue)
        {
            gpio.WriteValue(Value.Value);
        }
        
        return gpio;
    }
}