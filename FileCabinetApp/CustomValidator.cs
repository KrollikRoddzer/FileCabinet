using System.Globalization;

namespace FileCabinetApp;

/// <summary>
/// Custom validation rules class.
/// </summary>
public class CustomValidator : IRecordValidator<CreateRecordParameters>
{
    /// <summary>
    /// Validation method with default rules.
    /// </summary>
    /// <param name="parameters"> Parameter for creating record. </param>
    public void ValidateParameters(CreateRecordParameters parameters)
    {
        this.CheckForNullInFirstName(parameters.FirstName);
        this.CheckForValidDataInFirstName(parameters.FirstName);
        this.CheckForNullInLastName(parameters.LastName);
        this.CheckForValidDataInLastName(parameters.LastName);
        this.CheckForValidDataInAge(parameters.Age);
        this.CheckForValidDataInIncomePerYear(parameters.IncomePerYear);
    }

    /// <summary>
    /// Checks first name parameter for null.
    /// </summary>
    /// <param name="firstName"> First name parameter. </param>
    private void CheckForNullInFirstName(string firstName)
    {
        if (firstName is null)
        {
            throw new ArgumentNullException(nameof(firstName), "First name should be from 2 to 60 letters length.");
        }
    }

    /// <summary>
    /// Checks first name parameter for valid data.
    /// </summary>
    /// <param name="firstName"> First name parameter. </param>
    private void CheckForValidDataInFirstName(string firstName)
    {
        if (firstName.Length <= 0)
        {
            throw new ArgumentException("First name should be one or greater letters length.", nameof(firstName));
        }
    }

    /// <summary>
    /// Checks last name parameter for null.
    /// </summary>
    /// <param name="lastName"> Last name parameter. </param>
    private void CheckForNullInLastName(string lastName)
    {
        if (lastName is null)
        {
            throw new ArgumentNullException(nameof(lastName), "First name should be from 2 to 60 letters length.");
        }
    }

    /// <summary>
    /// Checks last name parameter for valid data.
    /// </summary>
    /// <param name="lastName"> Last name parameter. </param>
    private void CheckForValidDataInLastName(string lastName)
    {
        if (lastName.Length <= 0)
        {
            throw new ArgumentException("First name should be one or greater letters length.", nameof(lastName));
        }
    }

    /// <summary>
    /// Checks age parameter for valid data.
    /// </summary>
    /// <param name="age"> Age parameter. </param>
    private void CheckForValidDataInAge(short age)
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
    private void CheckForValidDataInIncomePerYear(decimal incomePerYear)
    {
        if (incomePerYear < 0)
        {
            throw new ArgumentException("Income must be a real number greater than zero.");
        }
    }
}