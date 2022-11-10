namespace FileCabinetApp;

public class FileCabinetCustomServise : FileCabinetService
{
    public FileCabinetCustomServise() : base() {}

    protected override void ValidateParameters(CreateRecordParameters parameters)
    {
        this.CheckForNullInFirstName(parameters.FirstName);
        this.CheckForValidDataInFirstName(parameters.FirstName);
        this.CheckForNullInLastName(parameters.LastName);
        this.CheckForValidDataInLastName(parameters.LastName);
        this.CheckForValidDataInAge(parameters.Age);
        this.CheckForValidDataInIncomePerYear(parameters.IncomePerYear);
    }

    protected override void CheckForValidDataInFirstName(string firstName)
    {
        if (firstName.Length <= 0)
        {
            throw new ArgumentException("First name should be one or greater letters length.", nameof(firstName));
        }
    }

    protected override void CheckForValidDataInLastName(string lastName)
    {
        if (lastName.Length <= 0)
        {
            throw new ArgumentException("First name should be one or greater letters length.", nameof(lastName));
        }
    }

    protected override void CheckForValidDataInAge(short age)
    {
        if (age < 0)
        {
            throw new ArgumentException("Age should be a positive integer or zero.", nameof(age));
        }
    }
}