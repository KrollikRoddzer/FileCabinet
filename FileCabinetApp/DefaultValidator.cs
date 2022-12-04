using System.Globalization;

namespace FileCabinetApp;

/// <summary>
/// Default validation rules class.
/// </summary>
public class DefaultValidator : IRecordValidator<CreateRecordParameters>
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
            this.CheckDate(value);
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
        this.CheckDate(parameters.DateOfBirth);
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
            throw new ArgumentNullException(nameof(firstName), "First name should be from 2 to 60 letters length.");
        }
        else if (firstName.Length < 2 || firstName.Length > 60)
        {
            throw new ArgumentException("First name should be from 2 to 60 letters length.", nameof(firstName));
        }
    }

    /// <summary>
    /// Checks LastName parameter to be suitable.
    /// </summary>
    /// <param name="lastName"> Last name parameter. </param>
    private void CheckLastName(string? lastName)
    {
        if (lastName is null)
        {
            throw new ArgumentNullException(nameof(lastName), "Last name should be from 2 to 60 letters length.");
        }
        else if (lastName.Length < 2 || lastName.Length > 60)
        {
            throw new ArgumentException("Last name should be from 2 to 60 letters length.", nameof(lastName));
        }
    }

    /// <summary>
    /// Checks age parameter for valid data.
    /// </summary>
    /// <param name="age"> Age parameter. </param>
    private void CheckAge(short age)
    {
        if (age < 0 || age > 75)
        {
            throw new ArgumentException("Age shout be an integer number from 0 to 75.", nameof(age));
        }
    }

    /// <summary>
    /// Checks birthday parameter for valid data.
    /// </summary>
    /// <param name="dateOfBirth"> Birthday parameter. </param>
    private void CheckDate(DateTime dateOfBirth)
    {
        if (dateOfBirth.CompareTo(new DateTime(1950, 1, 1)) < 0 || dateOfBirth.CompareTo(DateTime.Now) > 0)
        {
            throw new ArgumentException($"Date of birth must be from {new DateTime(1950, 1, 1).ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US"))} to {DateTime.Now.ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US"))}.");
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