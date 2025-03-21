using Serilog;

namespace GPIO;

public class Gpio
{
    private readonly ILogger _log = Log.ForContext<Gpio>();
    
    public string BasePath { get; private set; }
    public int Pin { get; private set; }

    public Gpio(string basePath, int pin)
    {
        BasePath = basePath;
        Pin = pin;
    }
    
    public bool SupportsDirection()
    {
        return File.Exists($"{BasePath}/gpio{Pin}/direction");
    }
    
    public bool SupportsValue()
    {
        return File.Exists($"{BasePath}/gpio{Pin}/value");
    }
    
    public bool SupportsEdge()
    {
        return File.Exists($"{BasePath}/gpio{Pin}/edge");
    }
    
    public bool SupportsActiveLow()
    {
        return File.Exists($"{BasePath}/gpio{Pin}/active_low");
    }
    
    public void WriteDirection(Direction direction)
    {
        if (!SupportsDirection())
        {
            _log.Error("Direction not supported for pin {Pin}", Pin);
            return;
        }
        
        var output = direction switch {
            Direction.In => "in",
            Direction.Out => "out",
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
        File.WriteAllText($"{BasePath}/gpio{Pin}/direction", output);
    }
    
    public void WriteValue(Value value)
    {
        if (!SupportsValue())
        {
            _log.Error("Value not supported for pin {Pin}", Pin);
            return;
        }
        
        var output = value switch {
            Value.Low => "0",
            Value.High => "1",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
        File.WriteAllText($"{BasePath}/gpio{Pin}/value", output);
    }
    
    public void WriteEdge(Edge edge)
    {
        if (!SupportsEdge())
        {
            _log.Error("Edge not supported for pin {Pin}", Pin);
            return;
        }
        
        var output = edge switch {
            Edge.None => "none",
            Edge.Rising => "rising",
            Edge.Falling => "falling",
            Edge.Both => "both",
            _ => throw new ArgumentOutOfRangeException(nameof(edge), edge, null)
        };
        File.WriteAllText($"{BasePath}/gpio{Pin}/edge", output);
    }
    
    public void WriteActiveLow(ActiveLow activeLow)
    {
        if (!SupportsActiveLow())
        {
            _log.Error("ActiveLow not supported for pin {Pin}", Pin);
            return;
        }
        
        var output = activeLow switch {
            ActiveLow.Off => "0",
            ActiveLow.On => "1",
            _ => throw new ArgumentOutOfRangeException(nameof(activeLow), activeLow, null)
        };
        File.WriteAllText($"{BasePath}/gpio{Pin}/active_low", output);
    }
    
    public Direction ReadDirection()
    {
        if (!SupportsDirection())
        {
            _log.Error("Direction not supported for pin {Pin}", Pin);
            return Direction.In;
        }
        
        var input = File.ReadAllText($"{BasePath}/gpio{Pin}/direction");
        return input switch {
            "in" => Direction.In,
            "out" => Direction.Out,
            _ => Direction.In
        };
    }
    
    public Value ReadValue()
    {
        if (!SupportsValue())
        {
            _log.Error("Value not supported for pin {Pin}", Pin);
            return Value.Low;
        }
        
        var input = File.ReadAllText($"{BasePath}/gpio{Pin}/value");
        return input switch {
            "0" => Value.Low,
            "1" => Value.High,
            _ => Value.Low
        };
    }
    
    public Edge ReadEdge()
    {
        if (!SupportsEdge())
        {
            _log.Error("Edge not supported for pin {Pin}", Pin);
            return Edge.None;
        }
        
        var input = File.ReadAllText($"{BasePath}/gpio{Pin}/edge");
        return input switch {
            "none" => Edge.None,
            "rising" => Edge.Rising,
            "falling" => Edge.Falling,
            "both" => Edge.Both,
            _ => Edge.None
        };
    }
    
    public ActiveLow ReadActiveLow()
    {
        if (!SupportsActiveLow())
        {
            _log.Error("ActiveLow not supported for pin {Pin}", Pin);
            return ActiveLow.Off;
        }
        
        var input = File.ReadAllText($"{BasePath}/gpio{Pin}/active_low");
        return input switch {
            "0" => ActiveLow.Off,
            "1" => ActiveLow.On,
            _ => ActiveLow.Off
        };
    }
}