using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class EntryMethodConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is not EntryMethod entryMethod) return;
        writer.WriteValue(entryMethod switch
        {
            EntryMethod.DeviceRead => "DEVICE_READ",
            EntryMethod.ManualEntry => "MANUAL_ENTRY",
            _ => throw new ArgumentOutOfRangeException()
        });
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        return null;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(EntryMethod);
    }
}