namespace FileCabinetApp;

/// <summary>
/// Criteria used in Find meethod in FileCabinetSetvise.
/// </summary>
public enum EFindCriteria
{
    /// <summary>
    /// Searching by first name.
    /// </summary>
    FirstName,

    /// <summary>
    /// Searching by last name.
    /// </summary>
    LastName,

    /// <summary>
    /// Searching by age.
    /// </summary>
    Age,

    /// <summary>
    /// Searching by date of birth.
    /// </summary>
    DataOfBirth,

    /// <summary>
    /// Searching by income per year.
    /// </summary>
    IncomePerYear,

    /// <summary>
    /// Searching by id.
    /// </summary>
    Id,
}
