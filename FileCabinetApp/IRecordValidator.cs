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

    /// <summary>
    /// Method for first name validation.
    /// </summary>
    /// <param name="value"> Value to validate. </param>
    /// <returns>
    /// Returns tuple with two values:
    /// Bool value, is true if value is validated, otherwise false.
    /// String value contains validation message.
    /// </returns>
    public Tuple<bool, string> ValidateFirstName(string value);

    /// <summary>
    /// Method for last name validation.
    /// </summary>
    /// <param name="value"> Value to validate. </param>
    /// <returns>
    /// Returns tuple with two values:
    /// Bool value, is true if value is validated, otherwise false.
    /// String value contains validation message.
    /// </returns>
    public Tuple<bool, string> ValidateLastName(string value);

    /// <summary>
    /// Method for age validation.
    /// </summary>
    /// <param name="value"> Value to validate. </param>
    /// <returns>
    /// Returns tuple with two values:
    /// Bool value, is true if value is validated, otherwise false.
    /// String value contains validation message.
    /// </returns>
    public Tuple<bool, string> ValidateAge(short value);

    /// <summary>
    /// Method for date validation.
    /// </summary>
    /// <param name="value"> Value to validate. </param>
    /// <returns>
    /// Returns tuple with two values:
    /// Bool value, is true if value is validated, otherwise false.
    /// String value contains validation message.
    /// </returns>
    public Tuple<bool, string> ValidateDate(DateTime value);

    /// <summary>
    /// Method for income validation.
    /// </summary>
    /// <param name="value"> Value to validate. </param>
    /// <returns>
    /// Returns tuple with two values:
    /// Bool value, is true if value is validated, otherwise false.
    /// String value contains validation message.
    /// </returns>
    public Tuple<bool, string> ValidateIncome(decimal value);
}
