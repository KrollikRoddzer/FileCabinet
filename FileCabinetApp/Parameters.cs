namespace FileCabinetApp;

#nullable disable
#pragma warning disable SA1400 // AccessModifierMustBeDeclared
/// <summary>
/// Parameters class for CreateRecord method in class FileCabinetSurvise.
/// </summary>
public class CreateRecordParameters
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateRecordParameters"/> class.
    /// </summary>
    /// <param name="firstName"> First name of a person. </param>
    /// <param name="lastName"> Last name of a person. </param>
    /// <param name="age"> Age of a person. </param>
    /// <param name="dateOfBirth"> Birthday date of a person. </param>
    /// <param name="incomePerYear"> Salary of a person. </param>
    public CreateRecordParameters(string firstName, string lastName, short age, DateTime dateOfBirth, decimal incomePerYear)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.DateOfBirth = dateOfBirth;
        this.IncomePerYear = incomePerYear;
    }

    /// <summary>
    /// Gets First Name of a person.
    /// </summary>
    /// <value> First Name. </value>
    public string FirstName { get; }

    /// <summary>
    /// Gets Last Name of a person.
    /// </summary>
    /// <value> Last Name. </value>
    public string LastName { get; }

    /// <summary>
    /// Gets Age of person.
    /// </summary>
    /// <value> Age. </value>
    public short Age { get; }

    /// <summary>
    /// Gets Date of Birth of a person.
    /// </summary>
    /// <value> Date of Birth. </value>
    public DateTime DateOfBirth { get; }

    /// <summary>
    /// Gets Salary of a person.
    /// </summary>
    /// <value> Income per year. </value>
    public decimal IncomePerYear { get; }
}

/// <summary>
/// Parameters class for EditRecord method in FileCabinetSevise.
/// </summary>
public class EditRecordParameters : CreateRecordParameters
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EditRecordParameters"/> class.
    /// </summary>
    /// <param name="id"> Identification number. </param>
    /// <param name="firstName"> First name of a person. </param>
    /// <param name="lastName"> Last name of a person. </param>
    /// <param name="age"> Age of a person. </param>
    /// <param name="dateOfBirth"> Birthday date of a person. </param>
    /// <param name="incomePerYear"> Salary of a person. </param>
    public EditRecordParameters(int id, string firstName, string lastName, short age, DateTime dateOfBirth, decimal incomePerYear)
    : base(firstName, lastName, age, dateOfBirth, incomePerYear)
    {
        this.Id = id;
    }

    /// <summary>
    /// Gets Identification number.
    /// </summary>
    /// <value> Identificatoin number. </value>
    public int Id { get; }
}

#pragma warning restore SA1400 // AccessModifierMustBeDeclared