using System.Collections.ObjectModel;

namespace FileCabinetApp;

/// <summary>
/// Interface for realisation FileCabietServises.
/// </summary>
/// <typeparam name="TValue"> Value that stores in file cabinet servise. </typeparam>
public interface IFileCabinetServise<TValue>
{
    /// <summary>
    /// Method that return array of records.
    /// </summary>
    /// <returns> Returns recods array. </returns>
    public ReadOnlyCollection<TValue> GetRecords();

    /// <summary>
    /// Returns stat of list.
    /// </summary>
    /// <returns> Returns number of records. </returns>
    public int GetStat();
}