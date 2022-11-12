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
    /// Validator field that validates parameters in methods.
    /// </summary>
    private readonly IRecordValidator<CreateRecordParameters> validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileCabinetService"/> class.
    /// </summary>
    /// <param name="validator"> Validator for parameters. </param>
    public FileCabinetService(IRecordValidator<CreateRecordParameters> validator)
    {
        this.validator = validator;
    }

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
        this.validator.ValidateParameters(parameters);

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
        this.validator.ValidateParameters(parameters);

        this.list[parameters.Id - 1] = new FileCabinetRecord
        {
            Id = parameters.Id,
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