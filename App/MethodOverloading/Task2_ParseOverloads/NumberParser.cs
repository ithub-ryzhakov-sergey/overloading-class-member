// Задача: Перегрузка методов — Parse
// Реализуйте несколько перегруженных методов Parse согласно README.
// Подсказки:
// - используйте int.Parse / int.TryParse
// - учитывайте культуру и NumberStyles

using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace App.MethodOverloading.Task2_ParseOverloads;

public static class NumberParser
{
    /// Разбирает строку в int. При неверном формате должен кидать FormatException
    public static int Parse(string s)
    {
        try
        {
            return Convert.ToInt32(s);
        }
        catch
        {
            throw new FormatException();
        }
    }

    /// Разбирает строку в int. При неверном формате возвращает defaultValue
    public static int Parse(string s, int defaultValue)
    {
        try
        {
            return Convert.ToInt32(s);
        }
        catch
        {
            return defaultValue;
        }
    }

    /// Разбирает строку с учётом стиля и культуры
    /// ВАЖНО: Эта перегрузка считается дополнительной (*) повышенной сложности (работа с культурами/стилями).
    public static int Parse(string s, NumberStyles style, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }
}