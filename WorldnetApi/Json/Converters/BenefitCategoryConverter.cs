using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class BenefitCategoryConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is not BenefitCategory benefitCategory) return;
        writer.WriteValue(benefitCategory switch
        {
            BenefitCategory.Cash => "CASH",
            BenefitCategory.FoodStamp => "FOOD_STAMP",
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
        return objectType == typeof(BenefitCategory);
    }
}