using System;
using System.Globalization;
using System.Linq;

#nullable disable

namespace FileCabinetApp;

public class FileCabinetService
{
    private readonly List<FileCabinetRecord> list = new List<FileCabinetRecord>();

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

    public int CreateRecord(string firstName, string lastName, short age, DateTime dateOfBirth, decimal incomePerYear)
    {
        if (firstName is null)
        {
            throw new ArgumentNullException(nameof(firstName), "First name should be from 2 to 60 letters length.");
        }

        if (firstName.Length < 2 || firstName.Length > 60)
        {
            throw new ArgumentException("First name should be from 2 to 60 letters length.", nameof(firstName));
        }

        if (lastName is null)
        {
            throw new ArgumentNullException(nameof(lastName), "First name should be from 2 to 60 letters length.");
        }

        if (lastName.Length < 2 || lastName.Length > 60)
        {
            throw new ArgumentException("First name should be from 2 to 60 letters length.", nameof(lastName));
        }

        if (age < 0 || age > 75)
        {
            throw new ArgumentException("Age shout be an integer number from 0 to 75.", nameof(age));
        }

        if (dateOfBirth.CompareTo(new DateTime(1950, 1, 1)) < 0 || dateOfBirth.CompareTo(DateTime.Now) > 0)
        {
            throw new ArgumentException($"Date of birth must be from {new DateTime(1950, 1, 1).ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US"))} to {DateTime.Now.ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US"))}.");
        }

        if (incomePerYear < 0)
        {
            throw new ArgumentException("Income must be a real number greater than zero.");
        }

        var record = new FileCabinetRecord
        {
            Id = this.list.Count + 1,
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            DateOfBirth = dateOfBirth,
            IncomePerYear = incomePerYear,
        };

        this.list.Add(record);

        return record.Id;
    }

    public void EditRecord(int id, string firstName, string lastName, short age, DateTime dateOfBirth, decimal incomePerYear)
    {
        if (firstName is null)
        {
            throw new ArgumentNullException(nameof(firstName), "First name should be from 2 to 60 letters length.");
        }

        if (firstName.Length < 2 || firstName.Length > 60)
        {
            throw new ArgumentException("First name should be from 2 to 60 letters length.", nameof(firstName));
        }

        if (lastName is null)
        {
            throw new ArgumentNullException(nameof(lastName), "First name should be from 2 to 60 letters length.");
        }

        if (lastName.Length < 2 || lastName.Length > 60)
        {
            throw new ArgumentException("First name should be from 2 to 60 letters length.", nameof(lastName));
        }

        if (age < 0 || age > 75)
        {
            throw new ArgumentException("Age shout be an integer number from 0 to 75.", nameof(age));
        }

        if (dateOfBirth.CompareTo(new DateTime(1950, 1, 1)) < 0 || dateOfBirth.CompareTo(DateTime.Now) > 0)
        {
            throw new ArgumentException($"Date of birth must be from {new DateTime(1950, 1, 1).ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US"))} to {DateTime.Now.ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US"))}.");
        }

        if (incomePerYear < 0)
        {
            throw new ArgumentException("Income must be a real number greater than zero.");
        }

        this.list[id - 1] = new FileCabinetRecord
        {
            Id = this.list.Count + 1,
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            DateOfBirth = dateOfBirth,
            IncomePerYear = incomePerYear,
        };
    }

    public FileCabinetRecord[] GetRecords()
    {
        return this.list.ToArray();
    }

    public int GetStat()
    {
        return this.list.Count;
    }
}