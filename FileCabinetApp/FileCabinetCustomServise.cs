namespace FileCabinetApp;

/// <summary>
/// Class that holds every command in application with custom validation.
/// </summary>
public class FileCabinetCustomServise : FileCabinetService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileCabinetCustomServise"/> class.
    /// </summary>
    public FileCabinetCustomServise()
    : base()
    {
    }

    /// <summary>
    /// Validation method with custom rules.
    /// </summary>
    /// <param name="parameters"> Parameter for creating record. </param>
    protected override void ValidateParameters(CreateRecordParameters parameters)
    {
        this.CheckForNullInFirstName(parameters.FirstName);
        this.CheckForValidDataInFirstName(parameters.FirstName);
        this.CheckForNullInLastName(parameters.LastName);
        this.CheckForValidDataInLastName(parameters.LastName);
        this.CheckForValidDataInAge(parameters.Age);
        this.CheckForValidDataInIncomePerYear(parameters.IncomePerYear);
    }

    /// <summary>
    /// Checks first name parameter for valid data.
    /// </summary>
    /// <param name="firstName"> First name parameter. </param>
    protected override void CheckForValidDataInFirstName(string firstName)
    {
        if (firstName.Length <= 0)
        {
            throw new ArgumentException("First name should be one or greater letters length.", nameof(firstName));
        }
    }

    /// <summary>
    /// Checks last name parameter for valid data.
    /// </summary>
    /// <param name="lastName"> Last name parameter. </param>
    protected override void CheckForValidDataInLastName(string lastName)
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
    protected override void CheckForValidDataInAge(short age)
    {
        if (age < 0)
        {
            throw new ArgumentException("Age should be a positive integer or zero.", nameof(age));
        }
    }
}