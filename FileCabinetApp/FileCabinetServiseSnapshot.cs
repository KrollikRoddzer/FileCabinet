namespace FileCabinetApp;

/// <summary>
/// Class for storing history of added records in <see cref="FileCabinetService"/>.
/// </summary>
public class FileCabinetServiseSnapshot
{
    private FileCabinetRecord[] records;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileCabinetServiseSnapshot"/> class.
    /// </summary>
    /// <param name="records"> Osbject that holds each record. </param>
    public FileCabinetServiseSnapshot(FileCabinetRecord[] records)
    {
        this.records = records;
    }

    /// <summary>
    /// Saves data into svc file.
    /// </summary>
    /// <param name="streamWriter"> <see cref="StreamWriter"/> object that writes data in file. </param>
    public void SaveToCsv(StreamWriter streamWriter)
    {
        var writer = new FileCabinetRecordCsvWriter(streamWriter);
        foreach (var record in this.records)
        {
            writer.Write(record);
        }
    }
}