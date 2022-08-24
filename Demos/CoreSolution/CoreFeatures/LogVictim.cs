using Microsoft.Extensions.Logging;

namespace CoreFeatures;

public class LogVictim
{
    private readonly ILogger<LogVictim> _logger;

    public LogVictim(ILogger<LogVictim> logger)
    {
        _logger = logger;
    }

    public void DoSomeStuff()
    {
        _logger.LogCritical("Critical (5)");
        _logger.LogError("Error (4)");
        _logger.LogWarning("Warning (3)");
        _logger.LogInformation("Information (2)");
        _logger.LogDebug("Debug (1)");
        _logger.LogTrace("Trace (0)");
        // None (6)
        
    }
}