using Newtonsoft.Json;
using WorldnetApi.Json.Converters;

namespace WorldnetApi.Json;

public class PostPaymentInstructionsBody(string terminal, PostPaymentInstructionsBody.OrderJson order)
{
    [JsonProperty("terminal")] public string Terminal { get; set; } = terminal;

    [JsonProperty("operator")] public string? Operator { get; set; }

    [JsonProperty("order")] public OrderJson Order { get; set; } = order;

    public string Serialize()
    {
        return JsonConvert.SerializeObject(this, new TipOptionsConverter(),
            new AlternativeTenderConverter(), new UsageAgreementConverter());
    }
    
    public class OrderJson(string orderId, string currency, double totalAmount)
    {
        [JsonProperty("orderId")] public string OrderId { get; set; } = orderId;

        [JsonProperty("description")] public string? Description { get; set; }

        [JsonProperty("currency")] public string Currency { get; set; } = currency;

        [JsonProperty("totalAmount")] public double TotalAmount { get; set; } = totalAmount;

        [JsonProperty("orderBreakdown")] public OrderBreakdownJson? OrderBreakdown { get; set; }

        [JsonProperty("customer")] public CustomerJson? Customer { get; set; }

        [JsonProperty("ipAddress")] public IpAddressJson? IpAddress { get; set; }

        [JsonProperty("credentialOnFile")] public CredentialOnFileJson? CredentialOnFile { get; set; }

        [JsonProperty("customizationOptions")]
        public CustomizationOptions? CustomizationOptions { get; set; }
        
        public class OrderBreakdownJson
        {
            [JsonProperty("subtotalAmount")] public double SubTotalAmount { get; set; }

            [JsonProperty("cashbackAmount")] public double? CashbackAmount { get; set; }

            [JsonProperty("tip")] public TipOptionsJson? TipOptions { get; set; }

            [JsonProperty("taxes")] public List<TaxJson>? Taxes { get; set; }

            [JsonProperty("surcharge")] public SurchargeJson? Surcharge { get; set; }

            [JsonProperty("dualPricing")] public DualPricingJson? DualPricing { get; set; }
            
            public class TipOptionsJson(TipOptionsJson.TipTypeJson typeJson, double amount)
            {
                public TipTypeJson TypeJson { get; set; } = typeJson;

                public double Amount { get; set; } = amount;
    
                public enum TipTypeJson
                {
                    Percentage,
                    FixedAmount
                }
            }
            
            public class TaxJson(string name, double rate)
            {
                [JsonProperty("name")] public string Name { get; set; } = name;

                [JsonProperty("rate")] public double Rate { get; set; } = rate;
            }
            
            public class SurchargeJson
            {
                [JsonProperty("bypass")] public bool? Bypass { get; set; }
            }
            
            public class DualPricingJson(bool offered, DualPricingJson.AlternativeTenderJson alternativeTender)
            {
                [JsonProperty("offered")] public bool Offered { get; set; } = offered;

                [JsonProperty("alternativeTender")] public AlternativeTenderJson AlternativeTender { get; set; } = alternativeTender;
    
                public enum AlternativeTenderJson
                {
                    Card,
                    Cash,
                    BankTransfer,
                }
            }
        }
        
        public class CustomerJson
        {
            [JsonProperty("name")] public string? Name { get; set; }

            [JsonProperty("phone")] public string? Phone { get; set; }

            [JsonProperty("email")] public string? Email { get; set; }

            [JsonProperty("dateOfBirth")] public DateOnly? DateOfBirth { get; set; }

            [JsonProperty("referenceNumber")] public string? ReferenceNumber { get; set; }

            [JsonProperty("notificationLanguage")] public string? NotificationLanguage { get; set; }

            [JsonProperty("billingAddress")] public BillingAddress? BillingAddress { get; set; }

            [JsonProperty("shippingAddress")] public ShippingAddress? ShippingAddress { get; set; }
        }
        
        public class IpAddressJson
        {
            [JsonProperty("ipv4")] public string? Ipv4 { get; set; }

            [JsonProperty("ipv6")] public string? Ipv6 { get; set; }
        }
        
        public class CredentialOnFileJson
        {
            [JsonProperty("externalVault")] public bool? ExternalVault { get; set; }

            [JsonProperty("tokenize")] public bool? Tokenize { get; set; }

            [JsonProperty("merchantReference")] public string? MerchantReference { get; set; }

            [JsonProperty("usageAgreement")] public UsageAgreement? UsageAgreement { get; set; }
        }
    }
}