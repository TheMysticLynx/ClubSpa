using Newtonsoft.Json;

namespace WorldnetApi.Json;

public class EbtDetails(BenefitCategory benefitCategory)
{
    [JsonProperty("benefitCategory")] public BenefitCategory BenefitCategory { get; set; } = benefitCategory;

    [JsonProperty("withdrawal")] public bool? Withdrawal { get; set; }
}