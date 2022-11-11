namespace FileCabinetApp;

/// <summary>
/// Inerface for realisation parameter validation.
/// </summary>
/// <typeparam name="TValue"> The type of parameters in ValidateParameters method. </typeparam>
public interface IRecordValidator<TValue>
{
    /// <summary>
    /// Validates parameters.
    /// </summary>
    /// <param name="parameters"> Parameters to validate. </param>
    public void ValidateParameters(TValue parameters);
}
