using System.Globalization;

namespace FileCabinetApp;

/// <summary>
/// Class for creating records in FileCabinetServise.
/// </summary>
public class FileCabinetRecord
{
    /// <summary>
    /// Gets or sets Id of a person.
    /// </summary>
    /// <value> Id. </value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets First name of a person.
    /// </summary>
    /// <value> First name. </value>
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets Last name of a person.
    /// </summary>
    /// <value> Last name. </value>
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets Age of a person.
    /// </summary>
    /// <value> Age. </value>
    public short Age { get; set; }

    /// <summary>
    /// Gets or sets Date of birthday of a person.
    /// </summary>
    /// <value> Birthday date. </value>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets Salary of a person.
    /// </summary>
    /// <value> Income every year. </value>
    public decimal IncomePerYear { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        string income = this.IncomePerYear.ToString("C2", new CultureInfo("en-US")).Replace(",", string.Empty);
        return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", this.Id, this.FirstName, this.LastName, this.Age, this.DateOfBirth.ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US")), income);
    }
}