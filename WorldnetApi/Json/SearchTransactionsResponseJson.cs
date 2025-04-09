// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

#region

using Newtonsoft.Json;
using WorldnetApi.Json.Converters;

#endregion

namespace WorldnetApi.Json;

public class SearchTransactionsResponseJson
{
    [JsonProperty("data")] public List<DataJson> Data;

    public static SearchTransactionsResponseJson FromJson(string json)
    {
        return JsonConvert.DeserializeObject<SearchTransactionsResponseJson>(
            json, new EbtTypeOptionConverter(), new ResultCodeOptionConverter())!;
    }

    public class DataJson
    {
        [JsonProperty("amount")] public double Amount;

        [JsonProperty("batchStatus")] [JsonConverter(typeof(BatchStatusOptionConverter))]
        public BatchStatusOption? BatchStatus;

        [JsonProperty("cardType")] public string? CardType;

        [JsonProperty("cashbackAmount")] public double? CashbackAmount;

        [JsonProperty("convenienceFeeAmount")] public double? ConvenienceFeeAmount;

        [JsonProperty("currency")] public string Currency = null!;

        [JsonProperty("customerName")] public string? CustomerName;

        [JsonProperty("dateTime")] public DateTime? DateTime;

        [JsonProperty("description")] public string? Description;

        [JsonProperty("dualPricingAmount")] public double? DualPricingAmount;

        [JsonProperty("ebtType")] [JsonConverter(typeof(EbtTypeOptionConverter))]
        public EbtTypeOption? EbtType;

        [JsonProperty("links")] public List<LinkJson>? Links;

        [JsonProperty("maskedPan")] public string? MaskedPan;

        [JsonProperty("operator")] public string? Operator;

        [JsonProperty("orderId")] public string OrderId = null!;

        [JsonProperty("resultCode")] [JsonConverter(typeof(ResultCodeOptionConverter))]
        public ResultCodeOption? ResultCode;

        [JsonProperty("status")] [JsonConverter(typeof(StatusOptionConverter))]
        public StatusOption? Status;

        [JsonProperty("supportedOperations", ItemConverterType = typeof(SupportedOperationsOptionConverter))]
        public List<SupportedOperationOption>? SupportedOperations;

        [JsonProperty("surchargeAmount")] public double? SurchargeAmount;

        [JsonProperty("taxAmount")] public double? TaxAmount;

        [JsonProperty("terminal")] public string Terminal = null!;

        [JsonProperty("tipAmount")] public double? TipAmount;

        [JsonProperty("type")] public string? Type;
        [JsonProperty("uniqueReference")] public string UniqueReference = null!;

        public enum BatchStatusOption
        {
            Sent,
            Complete,
            Rejected,
            Reverted,
            Restored,
            Admin,
            InProgress
        }

        public enum EbtTypeOption
        {
            Undefined,
            FoodStampPurchase,
            FoodStampReturn,
            FoodStampVoucherPurchase,
            FoodStampVoucherReturn,
            CashPurchase,
            CashPurchaseWithCashback,
            CashWithdrawal,
            FoodStampBalanceInquiry,
            CashBalanceInquiry
        }

        public enum ResultCodeOption
        {
            Approved,
            Declined,
            AcceptedForLaterProcessing,
            PartialApproval,
            ContactCardIssuer,
            RetainCard
        }

        public enum StatusOption
        {
            Ready,
            Pending,
            Void,
            Declined,
            Complete,
            Referral,
            Pickup,
            Reversal,
            Sent,
            Admin,
            Expired,
            Accepted,
            Review,
            Other
        }

        public enum SupportedOperationOption
        {
            Capture,
            Refund,
            FullyReverse,
            PartiallyReverse,
            IncrementAuthorization,
            AdjustTip,
            AddSignature,
            SetAsReady,
            SetAsPending,
            SetAsDeclined
        }

        public class LinkJson
        {
            [JsonProperty("href")] public string? Href;

            [JsonProperty("method")] public string? Method;
            [JsonProperty("rel")] public string? Rel;
        }
    }
}