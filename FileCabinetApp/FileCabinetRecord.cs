using System.Globalization;

namespace FileCabinetApp;

public class FileCabinetRecord
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public short Age { get; set; }

    public DateTime DateOfBirth { get; set; }

    public decimal IncomePerYear { get; set; }

    public override string ToString()
    {
        return $"#{this.Id}, {this.FirstName}, {this.LastName}, Age: {this.Age}, {this.DateOfBirth.ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US"))}, Income per year: {this.IncomePerYear:0.00}$";
    }
}