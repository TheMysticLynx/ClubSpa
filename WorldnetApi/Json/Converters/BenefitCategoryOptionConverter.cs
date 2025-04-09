#region

using Newtonsoft.Json;
using static WorldnetApi.Json.PostPaymentInstructionsBodyJson.OrderJson.CustomizationOptionsJson;
using static WorldnetApi.Json.PostPaymentInstructionsBodyJson.OrderJson.CustomizationOptionsJson.EbtDetailsJson.
    BenefitCategoryOption;

#endregion

namespace WorldnetApi.Json.Converters;

public class BenefitCategoryOptionConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(EbtDetailsJson.BenefitCategoryOption);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        return null;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is not EbtDetailsJson.BenefitCategoryOption benefitCategory) return;
        writer.WriteValue(benefitCategory switch
        {
            Cash => "CASH",
            FoodStamp => "FOOD_STAMP",
            _ => throw new ArgumentOutOfRangeException()
        });
    }
}