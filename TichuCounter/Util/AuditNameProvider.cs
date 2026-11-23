namespace TichuCounter.Util;

public class AuditNameProvider : IAuditNameProvider
{
    private const string FallbackAuditName = "Unknown";

    public string GetAuditName()
    {
        // Nothing here yet, add username from auth when implemented
        return FallbackAuditName;
    }
}
