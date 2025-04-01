using System.Globalization;
using System.Text;

namespace WorldnetApi;

public class SearchTransactionsQuery
{
    public string? Terminal { get; private set; }
    public DateTime? AfterDate { get; private set; }
    public DateTime? BeforeDate { get; private set; }
    public BatchType? BatchType { get; private set; }
    public DateTime? SettlementDate { get; private set; }
    public ResourceType? ResourceType { get; private set; }
    public string? OrderId { get; private set; }
    public string? UniqueReference { get; private set; }
    public string? Operator { get; private set; }
    public string? CustomerName { get; private set; }
    public string? PanFirstSix { get; private set; }
    public string? PanLastFour { get; private set; }
    public StatusGroup? StatusGroup { get; private set; }
    public TenderType? TenderType { get; private set; }
    public TipMode? TipMode { get; private set; }
    public int? PageSize { get; private set; }
    public string? Next { get; private set; }
    
    public SearchTransactionsQuery WithTerminal(string terminal)
    {
        Terminal = terminal;
        return this;
    }
    
    public SearchTransactionsQuery WithAfterDate(DateTime afterDate)
    {
        AfterDate = afterDate;
        return this;
    }
    
    public SearchTransactionsQuery WithBeforeDate(DateTime beforeDate)
    {
        BeforeDate = beforeDate;
        return this;
    }
    
    public SearchTransactionsQuery WithBatchType(BatchType batchType)
    {
        BatchType = batchType;
        return this;
    }
    
    public SearchTransactionsQuery WithSettlementDate(DateTime settlementDate)
    {
        SettlementDate = settlementDate;
        return this;
    }
    
    public SearchTransactionsQuery WithResourceType(ResourceType resourceType)
    {
        ResourceType = resourceType;
        return this;
    }
    
    public SearchTransactionsQuery WithOrderId(string orderId)
    {
        OrderId = orderId;
        return this;
    }
    
    public SearchTransactionsQuery WithUniqueReference(string uniqueReference)
    {
        UniqueReference = uniqueReference;
        return this;
    }
    
    public SearchTransactionsQuery WithOperator(string @operator)
    {
        Operator = @operator;
        return this;
    }
    
    public SearchTransactionsQuery WithCustomerName(string customerName)
    {
        CustomerName = customerName;
        return this;
    }
    
    public SearchTransactionsQuery WithPanFirstSix(string panFirstSix)
    {
        PanFirstSix = panFirstSix;
        return this;
    }
    
    public SearchTransactionsQuery WithPanLastFour(string panLastFour)
    {
        PanLastFour = panLastFour;
        return this;
    }
    
    public SearchTransactionsQuery WithStatusGroup(StatusGroup statusGroup)
    {
        StatusGroup = statusGroup;
        return this;
    }
    
    public SearchTransactionsQuery WithTenderType(TenderType tenderType)
    {
        TenderType = tenderType;
        return this;
    }
    
    public SearchTransactionsQuery WithTipMode(TipMode tipMode)
    {
        TipMode = tipMode;
        return this;
    }
    
    public SearchTransactionsQuery WithPageSize(int pageSize)
    {
        PageSize = pageSize;
        return this;
    }
    
    public SearchTransactionsQuery WithNext(string next)
    {
        Next = next;
        return this;
    }

    public string GetQuery()
    {
        return ToQueryString(QueryParametersDictionary());
    }
    
    private Dictionary<string, string> QueryParametersDictionary()
    {
        var dictionary = new Dictionary<string, string>();
        if (Terminal != null) dictionary.Add("terminal", Terminal);
        if (AfterDate != null) dictionary.Add("afterDate", AfterDate.Value.ToString("o", CultureInfo.InvariantCulture));
        if (BeforeDate != null) dictionary.Add("beforeDate", BeforeDate.Value.ToString("o", CultureInfo.InvariantCulture));
        if (BatchType != null) dictionary.Add("batchType", BatchType.Value.AsString());
        if (SettlementDate != null) dictionary.Add("settlementDate", SettlementDate.Value.ToString("o", CultureInfo.InvariantCulture));
        if (ResourceType != null) dictionary.Add("resourceType", ResourceType.Value.AsString());
        if (OrderId != null) dictionary.Add("orderId", OrderId);
        if (UniqueReference != null) dictionary.Add("uniqueReference", UniqueReference);
        if (Operator != null) dictionary.Add("operator", Operator);
        if (CustomerName != null) dictionary.Add("customerName", CustomerName);
        if (PanFirstSix != null) dictionary.Add("panFirstSix", PanFirstSix);
        if (PanLastFour != null) dictionary.Add("panLastFour", PanLastFour);
        if (StatusGroup != null) dictionary.Add("statusGroup", StatusGroup.Value.AsString());
        if (TenderType != null) dictionary.Add("tenderType", TenderType.Value.AsString());
        if (TipMode != null) dictionary.Add("tipMode", TipMode.Value.AsString());
        if (PageSize != null) dictionary.Add("pageSize", PageSize.Value.ToString());
        if (Next != null) dictionary.Add("next", Next);

        return dictionary;
    }

    public static string ToQueryString(Dictionary<string, string> nvc)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("?");

        bool first = true;

        foreach (KeyValuePair<string, string> pair in nvc)
        {
            if (!first)
            {
                sb.Append("&");
            }

            sb.AppendFormat("{0}={1}", Uri.EscapeDataString(pair.Key), Uri.EscapeDataString(pair.Value));

            first = false;
        }

        return sb.ToString();
    }
}