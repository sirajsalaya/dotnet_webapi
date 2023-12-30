namespace ProjexHR.Shared;

/// <summary>
/// Represents a generic response object with success status, code, message, data, count, and error information.
/// </summary>
/// <typeparam name="T">Type of the data property.</typeparam>
public class BaseReturn<T>
{
    /// <summary>
    /// Gets or sets a value indicating whether the operation was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the status code of the operation.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Gets or sets a message associated with the operation.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the data associated with the operation.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Gets or sets the count or quantity associated with the data.
    /// </summary>
    public int ItemCount { get; set; }

    /// <summary>
    /// Gets or sets an error message in case of failure.
    /// </summary>
    public string Error { get; set; }

}
