using GPIO.Devices;

namespace WebApplication.Services;

public class ClubSpaServiceConfiguration
{
    public FloatValve FloatValve { get; set; }
    public Relay StartRelay { get; set; }
}