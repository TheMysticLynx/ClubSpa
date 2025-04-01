namespace WorldnetApi.Json;

public enum SupportedOperations
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