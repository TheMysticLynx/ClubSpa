using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class EbtTypeConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is EbtType ebtType)
        {
            writer.WriteValue(ebtType switch
            {
                EbtType.Undefined => "UNDEFINED",
                EbtType.FoodStampPurchase => "FOOD_STAMP_PURCHASE",
                EbtType.FoodStampReturn => "FOOD_STAMP_RETURN",
                EbtType.FoodStampVoucherPurchase => "FOOD_STAMP_VOUCHER_PURCHASE",
                EbtType.FoodStampVoucherReturn => "FOOD_STAMP_VOUCHER_RETURN",
                EbtType.CashPurchase => "CASH_PURCHASE",
                EbtType.CashPurchaseWithCashback => "CASH_PURCHASE_WITH_CASHBACK",
                EbtType.CashWithdrawal => "CASH_WITHDRAWAL",
                EbtType.FoodStampBalanceInquiry => "FOOD_STAMP_BALANCE_INQUIRY",
                EbtType.CashBalanceInquiry => "CASH_BALANCE_INQUIRY",
                _ => throw new ArgumentOutOfRangeException(nameof(ebtType), ebtType, null)
            });
        }
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        if (reader.Value is string value)
        {
            return value switch
            {
                "UNDEFINED" => EbtType.Undefined,
                "FOOD_STAMP_PURCHASE" => EbtType.FoodStampPurchase,
                "FOOD_STAMP_RETURN" => EbtType.FoodStampReturn,
                "FOOD_STAMP_VOUCHER_PURCHASE" => EbtType.FoodStampVoucherPurchase,
                "FOOD_STAMP_VOUCHER_RETURN" => EbtType.FoodStampVoucherReturn,
                "CASH_PURCHASE" => EbtType.CashPurchase,
                "CASH_PURCHASE_WITH_CASHBACK" => EbtType.CashPurchaseWithCashback,
                "CASH_WITHDRAWAL" => EbtType.CashWithdrawal,
                "FOOD_STAMP_BALANCE_INQUIRY" => EbtType.FoodStampBalanceInquiry,
                "CASH_BALANCE_INQUIRY" => EbtType.CashBalanceInquiry,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }

        return EbtType.Undefined;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(EbtType) || objectType == typeof(EbtType?);
    }
}