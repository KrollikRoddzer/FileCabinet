using System.Xml;

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

    /// <summary>
    /// Saves data into xml file.
    /// </summary>
    /// <param name="streamWriter"> <see cref="StreamWriter"/> object that writes data in file. </param>
    public void SaveToXml(StreamWriter streamWriter)
    {
        using XmlWriter writer = XmlWriter.Create(streamWriter, new XmlWriterSettings()
        {
            Indent = true,
        });
        var fileCabinetRecordXmlWriter = new FileCabinetRecordXmlWriter(writer);
        writer.WriteStartDocument();
        writer.WriteStartElement("records");
        foreach (var record in this.records)
        {
            fileCabinetRecordXmlWriter.Write(record);
        }

        writer.WriteEndElement();
        writer.WriteEndDocument();
    }
}