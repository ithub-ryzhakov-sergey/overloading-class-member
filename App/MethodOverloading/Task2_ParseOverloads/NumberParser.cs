using System.Globalization;
using System;

namespace App.MethodOverloading.Task2_ParseOverloads;

public static class NumberParser
{
    /// Разбирает строку в int. При неверном формате должен кидать FormatException
    public static int Parse(string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new FormatException("Input string was not in a correct format.");

        return int.Parse(s);
    }

    /// Разбирает строку в int. При неверном формате возвращает defaultValue
    public static int Parse(string s, int defaultValue)
    {
        if (int.TryParse(s, out int result))
        {
            return result;
        }
        return defaultValue;
    }

    /// Разбирает строку с учётом стиля и культуры
    /// ВАЖНО: Эта перегрузка считается дополнительной (*) повышенной сложности (работа с культурами/стилями).
    public static int Parse(string s, NumberStyles style, IFormatProvider provider)
    {
        if (string.IsNullOrEmpty(s))
            throw new FormatException("Input string was not in a correct format.");

        return int.Parse(s, style, provider);
    }
}