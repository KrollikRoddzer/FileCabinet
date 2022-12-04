using System.Globalization;

namespace FileCabinetApp;

/// <summary>
/// Class for converting input to record parameters.
/// </summary>
public static class Converter
{
    /// <summary>
    /// Method for converting data.
    /// </summary>
    /// <param name="value"> Value to convert. </param>
    /// <returns>
    /// Returns a tuple that contains bool value: true if converted otherwise false.
    /// String value contains message.
    /// String value contains converted value.
    /// </returns>
    public static Tuple<bool, string, string> ConvertFirstNameAndLastName(string value)
    {
        return new Tuple<bool, string, string>(true, string.Empty, value);
    }

    /// <summary>
    /// Method for converting data.
    /// </summary>
    /// <param name="value"> Value to convert. </param>
    /// <returns>
    /// Returns a tuple that contains bool value: true if converted otherwise false.
    /// String value contains message.
    /// Short value contains converted value.
    /// </returns>
    public static Tuple<bool, string, short> ConvertAge(string value)
    {
        short result;
        if (short.TryParse(value, out result))
        {
            return new Tuple<bool, string, short>(true, string.Empty, result);
        }
        else
        {
            return new Tuple<bool, string, short>(false, "This argument must be an integer.", 0);
        }
    }

    /// <summary>
    /// Method for converting data.
    /// </summary>
    /// <param name="value"> Value to convert. </param>
    /// <returns>
    /// Returns a tuple that contains bool value: true if converted otherwise false.
    /// String value contains message.
    /// DateTime value contains converted value.
    /// </returns>
    public static Tuple<bool, string, DateTime> ConvertDate(string value)
    {
        DateTime result;
        if (DateTime.TryParse(value, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out result))
        {
            return new Tuple<bool, string, DateTime>(true, string.Empty, result);
        }
        else
        {
            return new Tuple<bool, string, DateTime>(false, "Correct  format for date: mm/dd/yyyy.", DateTime.Now);
        }
    }

    /// <summary>
    /// Method for converting data.
    /// </summary>
    /// <param name="value"> Value to convert. </param>
    /// <returns>
    /// Returns a tuple that contains bool value: true if converted otherwise false.
    /// String value contains message.
    /// Decimal value contains converted value.
    /// </returns>
    public static Tuple<bool, string, decimal> ConvertIncome(string value)
    {
        decimal result;
        if (decimal.TryParse(value, out result))
        {
            return new Tuple<bool, string, decimal>(true, string.Empty, result);
        }
        else
        {
            return new Tuple<bool, string, decimal>(false, "Income must be a real number.", 0m);
        }
    }
}