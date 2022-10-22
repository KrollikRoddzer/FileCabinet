using System;
using System.Globalization;
using System.Linq;

#nullable disable

namespace FileCabinetApp;

/// <summary>
/// Class that holds every command in application.
/// </summary>
public class FileCabinetService
{
    /// <summary>
    /// List that holds every record.
    /// </summary>
    private readonly List<FileCabinetRecord> list = new List<FileCabinetRecord>();

    /// <summary>
    /// Finds records in list accoarding to criteria.
    /// </summary>
    /// <param name="criteria"> Criteria according to is searched record. </param>
    /// <param name="parameter"> Parameter we use to compare records. </param>
    /// <returns> Returns array of found records. </returns>
    public FileCabinetRecord[] Find(EFindCriteria criteria, string parameter)
    {
        switch (criteria)
        {
            case EFindCriteria.FirstName:
                return this.list.Where((record) => record.FirstName.ToLower().Equals(parameter)).ToArray();
            case EFindCriteria.LastName:
                return this.list.Where(record => record.LastName.ToLower().Equals(parameter)).ToArray();
            case EFindCriteria.Age:
                return this.list.Where(record => record.Age.Equals(Convert.ToInt16(parameter))).ToArray();
            case EFindCriteria.DataOfBirth:
                return this.list.Where(record => record.DateOfBirth.Equals(DateTime.Parse(parameter, CultureInfo.CreateSpecificCulture("en-US")))).ToArray();
            case EFindCriteria.IncomePerYear:
                return this.list.Where(record => record.IncomePerYear.Equals(Convert.ToDecimal(parameter))).ToArray();
            case EFindCriteria.Id:
                return this.list.Where(record => record.Id.Equals(Convert.ToInt32(parameter))).ToArray();
            default:
                throw new ArgumentException("Something wrong with the criteria.");
        }
    }

    /// <summary>
    /// Creates record.
    /// </summary>
    /// <param name="parameters"> Class used for parametes of this method. </param>
    /// <returns> Id of record. </returns>
    public int CreateRecord(CreateRecordParameters parameters)
    {
        if (parameters.FirstName is null)
        {
            throw new ArgumentNullException(nameof(parameters.FirstName), "First name should be from 2 to 60 letters length.");
        }

        if (parameters.FirstName.Length < 2 || parameters.FirstName.Length > 60)
        {
            throw new ArgumentException("First name should be from 2 to 60 letters length.", nameof(parameters.FirstName));
        }

        if (parameters.LastName is null)
        {
            throw new ArgumentNullException(nameof(parameters.LastName), "First name should be from 2 to 60 letters length.");
        }

        if (parameters.LastName.Length < 2 || parameters.LastName.Length > 60)
        {
            throw new ArgumentException("First name should be from 2 to 60 letters length.", nameof(parameters.LastName));
        }

        if (parameters.Age < 0 || parameters.Age > 75)
        {
            throw new ArgumentException("parameters.Age shout be an integer number from 0 to 75.", nameof(parameters.Age));
        }

        if (parameters.DateOfBirth.CompareTo(new DateTime(1950, 1, 1)) < 0 || parameters.DateOfBirth.CompareTo(DateTime.Now) > 0)
        {
            throw new ArgumentException($"Date of birth must be from {new DateTime(1950, 1, 1).ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US"))} to {DateTime.Now.ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US"))}.");
        }

        if (parameters.IncomePerYear < 0)
        {
            throw new ArgumentException("Income must be a real number greater than zero.");
        }

        var record = new FileCabinetRecord
        {
            Id = this.list.Count + 1,
            FirstName = parameters.FirstName,
            LastName = parameters.LastName,
            Age = parameters.Age,
            DateOfBirth = parameters.DateOfBirth,
            IncomePerYear = parameters.IncomePerYear,
        };

        this.list.Add(record);

        return record.Id;
    }

    /// <summary>
    /// Edits record.
    /// </summary>
    /// <param name="parameters"> Class used for parametes of this method. </param>
    public void EditRecord(EditRecordParameters parameters)
    {
        if (parameters.FirstName is null)
        {
            throw new ArgumentNullException(nameof(parameters.FirstName), "First name should be from 2 to 60 letters length.");
        }

        if (parameters.FirstName.Length < 2 || parameters.FirstName.Length > 60)
        {
            throw new ArgumentException("First name should be from 2 to 60 letters length.", nameof(parameters.FirstName));
        }

        if (parameters.LastName is null)
        {
            throw new ArgumentNullException(nameof(parameters.LastName), "First name should be from 2 to 60 letters length.");
        }

        if (parameters.LastName.Length < 2 || parameters.LastName.Length > 60)
        {
            throw new ArgumentException("First name should be from 2 to 60 letters length.", nameof(parameters.LastName));
        }

        if (parameters.Age < 0 || parameters.Age > 75)
        {
            throw new ArgumentException("parameters.Age shout be an integer number from 0 to 75.", nameof(parameters.Age));
        }

        if (parameters.DateOfBirth.CompareTo(new DateTime(1950, 1, 1)) < 0 || parameters.DateOfBirth.CompareTo(DateTime.Now) > 0)
        {
            throw new ArgumentException($"Date of birth must be from {new DateTime(1950, 1, 1).ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US"))} to {DateTime.Now.ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US"))}.");
        }

        if (parameters.IncomePerYear < 0)
        {
            throw new ArgumentException("Income must be a real number greater than zero.");
        }

        this.list[parameters.Id - 1] = new FileCabinetRecord
        {
            Id = this.list.Count + 1,
            FirstName = parameters.FirstName,
            LastName = parameters.LastName,
            Age = parameters.Age,
            DateOfBirth = parameters.DateOfBirth,
            IncomePerYear = parameters.IncomePerYear,
        };
    }

    /// <summary>
    /// Method that return array of records.
    /// </summary>
    /// <returns> Returns recods array. </returns>
    public FileCabinetRecord[] GetRecords()
    {
        return this.list.ToArray();
    }

    /// <summary>
    /// Returns stat of list.
    /// </summary>
    /// <returns> Returns number of records. </returns>
    public int GetStat()
    {
        return this.list.Count;
    }
}