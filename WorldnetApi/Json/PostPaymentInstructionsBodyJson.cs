#region

using Newtonsoft.Json;
using WorldnetApi.Json.Converters;

#endregion

namespace WorldnetApi.Json;

public class PostPaymentInstructionsBodyJson(string terminal, PostPaymentInstructionsBodyJson.OrderJson order)
{
    [JsonProperty("operator")] public string? Operator { get; set; }

    [JsonProperty("order")] public OrderJson Order { get; set; } = order;
    [JsonProperty("terminal")] public string Terminal { get; set; } = terminal;

    public string Serialize()
    {
        return JsonConvert.SerializeObject(this, new TipOptionsConverter(),
            new AlternativeTenderOptionConverter(), new UsageAgreementOptionsConverter());
    }

    public class OrderJson(string orderId, string currency, double totalAmount)
    {
        [JsonProperty("credentialOnFile")] public CredentialOnFileJson? CredentialOnFile { get; set; }

        [JsonProperty("currency")] public string Currency { get; set; } = currency;

        [JsonProperty("customer")] public CustomerJson? Customer { get; set; }

        [JsonProperty("customizationOptions")] public CustomizationOptionsJson? CustomizationOptions { get; set; }

        [JsonProperty("description")] public string? Description { get; set; }

        [JsonProperty("ipAddress")] public IpAddressJson? IpAddress { get; set; }

        [JsonProperty("orderBreakdown")] public OrderBreakdownJson? OrderBreakdown { get; set; }
        [JsonProperty("orderId")] public string OrderId { get; set; } = orderId;

        [JsonProperty("totalAmount")] public double TotalAmount { get; set; } = totalAmount;

        public class CredentialOnFileJson
        {
            public enum UsageAgreementOption
            {
                Unscheduled,
                Recurring,
                Installment
            }

            [JsonProperty("externalVault")] public bool? ExternalVault { get; set; }

            [JsonProperty("merchantReference")] public string? MerchantReference { get; set; }

            [JsonProperty("tokenize")] public bool? Tokenize { get; set; }

            [JsonProperty("usageAgreement", ItemConverterType = typeof(UsageAgreementOptionsConverter))]
            public UsageAgreementOption? UsageAgreement { get; set; }
        }

        public class CustomerJson
        {
            [JsonProperty("billingAddress")] public BillingAddressJson? BillingAddress { get; set; }

            [JsonProperty("dateOfBirth")] public DateOnly? DateOfBirth { get; set; }

            [JsonProperty("email")] public string? Email { get; set; }
            [JsonProperty("name")] public string? Name { get; set; }

            [JsonProperty("notificationLanguage")] public string? NotificationLanguage { get; set; }

            [JsonProperty("phone")] public string? Phone { get; set; }

            [JsonProperty("referenceNumber")] public string? ReferenceNumber { get; set; }

            [JsonProperty("shippingAddress")] public ShippingAddressJson? ShippingAddress { get; set; }

            public class BillingAddressJson
            {
                [JsonProperty("city")] public string? City { get; set; }

                [JsonProperty("country")] public string? Country { get; set; }
                [JsonProperty("line1")] public string? Line1 { get; set; }

                [JsonProperty("line2")] public string? Line2 { get; set; }

                [JsonProperty("postalCode")] public string? PostalCode { get; set; }

                [JsonProperty("state")] public string? State { get; set; }
            }

            public class ShippingAddressJson
            {
                [JsonProperty("city")] public string? City { get; set; }

                [JsonProperty("country")] public string? Country { get; set; }

                [JsonProperty("line1")] public string? Line1 { get; set; }

                [JsonProperty("line2")] public string? Line2 { get; set; }
                [JsonProperty("name")] public string? Name { get; set; }

                [JsonProperty("postalCode")] public string? PostalCode { get; set; }

                [JsonProperty("state")] public string? State { get; set; }
            }
        }

        public class CustomizationOptionsJson
        {
            public enum EntryMethodOption
            {
                DeviceRead,
                ManualEntry
            }

            [JsonProperty("ebtDetails")] public EbtDetailsJson? EbtDetails { get; set; }

            [JsonProperty("entryMethod", ItemConverterType = typeof(EntryMethodOptionConverter))]
            public EntryMethodOption? EntryMethod { get; set; }

            public class EbtDetailsJson(EbtDetailsJson.BenefitCategoryOption benefitCategory)
            {
                public enum BenefitCategoryOption
                {
                    Cash,
                    FoodStamp
                }

                [JsonProperty("benefitCategory")]
                public BenefitCategoryOption BenefitCategory { get; set; } = benefitCategory;

                [JsonProperty("withdrawal")] public bool? Withdrawal { get; set; }
            }
        }

        public class IpAddressJson
        {
            [JsonProperty("ipv4")] public string? Ipv4 { get; set; }

            [JsonProperty("ipv6")] public string? Ipv6 { get; set; }
        }

        public class OrderBreakdownJson
        {
            [JsonProperty("cashbackAmount")] public double? CashbackAmount { get; set; }

            [JsonProperty("dualPricing")] public DualPricingJson? DualPricing { get; set; }
            [JsonProperty("subtotalAmount")] public double SubTotalAmount { get; set; }

            [JsonProperty("surcharge")] public SurchargeJson? Surcharge { get; set; }

            [JsonProperty("taxes")] public List<TaxJson>? Taxes { get; set; }

            [JsonProperty("tip")] public TipOptionsJson? TipOptions { get; set; }

            public class DualPricingJson(bool offered, DualPricingJson.AlternativeTenderOption alternativeTender)
            {
                public enum AlternativeTenderOption
                {
                    Card,
                    Cash,
                    BankTransfer
                }

                [JsonProperty("alternativeTender", ItemConverterType = typeof(AlternativeTenderOptionConverter))]
                public AlternativeTenderOption AlternativeTender { get; set; } = alternativeTender;

                [JsonProperty("offered")] public bool Offered { get; set; } = offered;
            }

            public class SurchargeJson
            {
                [JsonProperty("bypass")] public bool? Bypass { get; set; }
            }

            public class TaxJson(string name, double rate)
            {
                [JsonProperty("name")] public string Name { get; set; } = name;

                [JsonProperty("rate")] public double Rate { get; set; } = rate;
            }

            public class TipOptionsJson(TipOptionsJson.TipTypeJson typeJson, double amount)
            {
                public enum TipTypeJson
                {
                    Percentage,
                    FixedAmount
                }

                public double Amount { get; set; } = amount;
                public TipTypeJson TypeJson { get; set; } = typeJson;
            }
        }
    }
}