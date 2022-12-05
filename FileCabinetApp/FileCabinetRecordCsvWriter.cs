namespace FileCabinetApp;

/// <summary>
/// Class for writing data into csv file.
/// </summary>
public class FileCabinetRecordCsvWriter
{
    private TextWriter writer;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileCabinetRecordCsvWriter"/> class.
    /// </summary>
    /// <param name="writer"> Object that writes data in file. </param>
    public FileCabinetRecordCsvWriter(TextWriter writer)
    {
        this.writer = writer;
        this.writer.WriteLine("Id, First Name, Last Name, Age, Date of Birth, Income");
    }

    /// <summary>
    /// Writes one record in file.
    /// </summary>
    /// <param name="record"> Object representing one record. </param>
    public void Write(FileCabinetRecord record)
    {
        this.writer.WriteLine(record);
    }
}