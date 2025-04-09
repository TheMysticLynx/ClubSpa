#region

using Newtonsoft.Json;
using static WorldnetApi.Json.SearchTransactionsResponseJson.DataJson;
using static WorldnetApi.Json.SearchTransactionsResponseJson.DataJson.EbtTypeOption;

#endregion

namespace WorldnetApi.Json.Converters;

public class EbtTypeOptionConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(EbtTypeOption) ||
               objectType == typeof(EbtTypeOption?);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        if (reader.Value is string value)
            return value switch
            {
                "UNDEFINED" => Undefined,
                "FOOD_STAMP_PURCHASE" => FoodStampPurchase,
                "FOOD_STAMP_RETURN" => FoodStampReturn,
                "FOOD_STAMP_VOUCHER_PURCHASE" => FoodStampVoucherPurchase,
                "FOOD_STAMP_VOUCHER_RETURN" => FoodStampVoucherReturn,
                "CASH_PURCHASE" => CashPurchase,
                "CASH_PURCHASE_WITH_CASHBACK" => CashPurchaseWithCashback,
                "CASH_WITHDRAWAL" => CashWithdrawal,
                "FOOD_STAMP_BALANCE_INQUIRY" => FoodStampBalanceInquiry,
                "CASH_BALANCE_INQUIRY" => CashBalanceInquiry,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };

        return Undefined;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is EbtTypeOption ebtType)
            writer.WriteValue(ebtType switch
            {
                Undefined => "UNDEFINED",
                FoodStampPurchase => "FOOD_STAMP_PURCHASE",
                FoodStampReturn => "FOOD_STAMP_RETURN",
                FoodStampVoucherPurchase => "FOOD_STAMP_VOUCHER_PURCHASE",
                FoodStampVoucherReturn => "FOOD_STAMP_VOUCHER_RETURN",
                CashPurchase => "CASH_PURCHASE",
                CashPurchaseWithCashback => "CASH_PURCHASE_WITH_CASHBACK",
                CashWithdrawal => "CASH_WITHDRAWAL",
                FoodStampBalanceInquiry => "FOOD_STAMP_BALANCE_INQUIRY",
                CashBalanceInquiry => "CASH_BALANCE_INQUIRY",
                _ => throw new ArgumentOutOfRangeException(nameof(ebtType), ebtType, null)
            });
    }
}