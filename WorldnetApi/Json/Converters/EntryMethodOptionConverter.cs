#region

using Newtonsoft.Json;
using static WorldnetApi.Json.PostPaymentInstructionsBodyJson.OrderJson.CustomizationOptionsJson;

#endregion

namespace WorldnetApi.Json.Converters;

public class EntryMethodOptionConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(EntryMethodOption);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        return null;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is not EntryMethodOption entryMethod) return;
        writer.WriteValue(entryMethod switch
        {
            EntryMethodOption.DeviceRead => "DEVICE_READ",
            EntryMethodOption.ManualEntry => "MANUAL_ENTRY",
            _ => throw new ArgumentOutOfRangeException()
        });
    }
}