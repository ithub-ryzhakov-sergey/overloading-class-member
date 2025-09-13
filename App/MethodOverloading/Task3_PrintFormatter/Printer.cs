using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace App.MethodOverloading.Task3_PrintFormatter;

public static class Printer
{
    public static string Print(int value)
    {
        return value.ToString();
    }

    public static string Print(double value, int decimals)
    {
        // Используем InvariantCulture и округление
        return value.ToString($"F{decimals}", CultureInfo.InvariantCulture);
    }

    public static string Print(params int[] values)
    {
        if (values == null || values.Length == 0)
            return "<empty>";

        return string.Join(",", values);
    }

    public static string Print<T>(IEnumerable<T> values)
    {
        if (values == null)
            return "<empty>";

        if (!values.Any())
            return "<empty>";

        return string.Join(",", values);
    }
    public static string Print1(double value, int decimals)
    {
        // Используем InvariantCulture и округление
        return value.ToString($"F{decimals}", CultureInfo.InvariantCulture);
    }
}