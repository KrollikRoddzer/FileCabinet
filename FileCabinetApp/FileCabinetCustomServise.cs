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
    : base(new CustomValidator())
    {
    }
}