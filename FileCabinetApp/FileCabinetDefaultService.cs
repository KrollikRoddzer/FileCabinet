namespace FileCabinetApp;

/// <summary>
/// Class that holds every command in application with default validation.
/// </summary>
public class FileCabinetDeafaultServise : FileCabinetService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileCabinetDeafaultServise"/> class.
    /// </summary>
    public FileCabinetDeafaultServise()
    : base(new DefaultValidator())
    {
    }
}