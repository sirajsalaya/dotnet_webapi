namespace ProjexHR.Shared;

/// <summary>
/// Represents configuration settings for the application.
/// </summary>
public class Config
{
    public string ApplicationBasePath { get; set; }
    public CloudSQL CloudSQL { get; set; }
}

public class CloudSQL
{
    public string Database { get; set; }
    public string SQLVersion { get; set; }
    public string ConnectionString { get; set; }
}
