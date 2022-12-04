using System.Globalization;

namespace FileCabinetApp;

/// <summary>
/// Custom validation rules class.
/// </summary>
public class CustomValidator : IRecordValidator<CreateRecordParameters>
{
    /// <inheritdoc/>
    public Tuple<bool, string> ValidateFirstName(string value)
    {
        try
        {
            this.CheckFirstName(value);
            return new Tuple<bool, string>(true, string.Empty);
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string>(false, ex.Message);
        }
    }

    /// <inheritdoc/>
    public Tuple<bool, string> ValidateLastName(string value)
    {
        try
        {
            this.CheckLastName(value);
            return new Tuple<bool, string>(true, string.Empty);
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string>(false, ex.Message);
        }
    }

    /// <inheritdoc/>
    public Tuple<bool, string> ValidateAge(short value)
    {
        try
        {
            this.CheckAge(value);
            return new Tuple<bool, string>(true, string.Empty);
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string>(false, ex.Message);
        }
    }

    /// <inheritdoc/>
    public Tuple<bool, string> ValidateDate(DateTime value)
    {
        try
        {
            return new Tuple<bool, string>(true, string.Empty);
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string>(false, ex.Message);
        }
    }

    /// <inheritdoc/>
    public Tuple<bool, string> ValidateIncome(decimal value)
    {
        try
        {
            this.CheckIncome(value);
            return new Tuple<bool, string>(true, string.Empty);
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string>(false, ex.Message);
        }
    }

    /// <summary>
    /// Validation method with default rules.
    /// </summary>
    /// <param name="parameters"> Parameter for creating record. </param>
    public void ValidateParameters(CreateRecordParameters parameters)
    {
        this.CheckFirstName(parameters.FirstName);
        this.CheckLastName(parameters.LastName);
        this.CheckAge(parameters.Age);
        this.CheckIncome(parameters.IncomePerYear);
    }

    /// <summary>
    /// Checks FirstName parameter to be suitable.
    /// </summary>
    /// <param name="firstName"> First name parameter. </param>
    private void CheckFirstName(string? firstName)
    {
        if (firstName is null)
        {
            throw new ArgumentNullException(nameof(firstName), "First name should be one or greater letters length.");
        }
        else if (firstName.Length <= 0)
        {
            throw new ArgumentException("First name should be one or greater letters length.", nameof(firstName));
        }
    }

    /// <summary>
    /// Checks last name parameter for null.
    /// </summary>
    /// <param name="lastName"> Last name parameter. </param>
    private void CheckLastName(string? lastName)
    {
        if (lastName is null)
        {
            throw new ArgumentNullException(nameof(lastName), "Last name should be one or greater letters length.");
        }
        else if (lastName.Length <= 0)
        {
            throw new ArgumentException("Last name should be one or greater letters length.", nameof(lastName));
        }
    }

    /// <summary>
    /// Checks age parameter for valid data.
    /// </summary>
    /// <param name="age"> Age parameter. </param>
    private void CheckAge(short age)
    {
        if (age < 0)
        {
            throw new ArgumentException("Age should be a positive integer or zero.", nameof(age));
        }
    }

    /// <summary>
    /// Checks income parameter for valid data.
    /// </summary>
    /// <param name="incomePerYear"> Income parameter. </param>
    private void CheckIncome(decimal incomePerYear)
    {
        if (incomePerYear < 0)
        {
            throw new ArgumentException("Income must be a real number greater than zero.");
        }
    }
}