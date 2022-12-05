using System.Xml;

namespace FileCabinetApp;

/// <summary>
/// Class for writing data in xml file.
/// </summary>
public class FileCabinetRecordXmlWriter
{
    private XmlWriter writer;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileCabinetRecordXmlWriter"/> class.
    /// </summary>
    /// <param name="writer"> Object that writes data in file. </param>
    public FileCabinetRecordXmlWriter(XmlWriter writer)
    {
        this.writer = writer;
    }

    /// <summary>
    /// Writes one record in file.
    /// </summary>
    /// <param name="record"> Object representing one record. </param>
    public void Write(FileCabinetRecord record)
    {
        this.writer.WriteStartElement("record");
        this.writer.WriteAttributeString("id", record.Id.ToString());

        this.writer.WriteStartElement("name");
        this.writer.WriteAttributeString("first", record.FirstName);
        this.writer.WriteAttributeString("last", record.LastName);
        this.writer.WriteEndElement();

        this.writer.WriteStartElement("age");
        this.writer.WriteValue(record.Age);
        this.writer.WriteEndElement();

        this.writer.WriteStartElement("dateOfBirth");
        this.writer.WriteValue(record.DateOfBirth.ToShortDateString().Replace('.', '/'));
        this.writer.WriteEndElement();

        this.writer.WriteStartElement("incomePerYear");
        this.writer.WriteValue(record.IncomePerYear);
        this.writer.WriteEndElement();

        this.writer.WriteEndElement();
    }
}