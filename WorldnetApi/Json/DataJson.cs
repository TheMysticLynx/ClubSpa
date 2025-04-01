using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class DataJson
{
    [JsonProperty("uniqueReference")] public string UniqueReference = null!;

    [JsonProperty("terminal")] public string Terminal = null!;

    [JsonProperty("operator")] public string? Operator;

    [JsonProperty("orderId")] public string OrderId = null!;

    [JsonProperty("dateTime")] public DateTime? DateTime;

    [JsonProperty("description")] public string? Description;

    [JsonProperty("customerName")] public string? CustomerName;

    [JsonProperty("cardType")] public string? CardType;

    [JsonProperty("maskedPan")] public string? MaskedPan;

    [JsonProperty("type")] public string? Type;

    [JsonProperty("ebtType")] public EbtType? EbtType;

    [JsonProperty("resultCode")] public ResultCode? ResultCode;

    [JsonProperty("status")] public string? Status;

    [JsonProperty("currency")] public string Currency = null!;

    [JsonProperty("amount")] public double Amount;

    [JsonProperty("tipAmount")] public double? TipAmount;

    [JsonProperty("taxAmount")] public double? TaxAmount;

    [JsonProperty("cashbackAmount")] public double? CashbackAmount;

    [JsonProperty("surchargeAmount")] public double? SurchargeAmount;

    [JsonProperty("dualPricingAmount")] public double? DualPricingAmount;

    [JsonProperty("convenienceFeeAmount")] public double? ConvenienceFeeAmount;

    [JsonProperty("batchStatus")] public BatchStatus? BatchStatus;
    
    [JsonProperty("supportedOperations", ItemConverterType = typeof(SupportedOperationsConverter))] public List<SupportedOperations>? SupportedOperations;

    [JsonProperty("links")] public List<LinkJson>? Links;
}