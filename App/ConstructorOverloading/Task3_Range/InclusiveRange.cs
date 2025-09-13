using System;

namespace App.ConstructorOverloading.Task3_Range;

public class InclusiveRange
{
    public int Start { get; private set; }
    public int End { get; private set; }

    // Конструктор (start, end)
    public InclusiveRange(int start, int end)
    {
        Start = Math.Min(start, end);
        End = Math.Max(start, end);
    }

    // Конструктор из строки "start..end"
    public InclusiveRange(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            throw new ArgumentException("Input string cannot be null or empty");

        var parts = s.Split("..", StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2)
            throw new ArgumentException("Input string must be in format 'start..end'");

        if (!int.TryParse(parts[0].Trim(), out int start))
            throw new ArgumentException("Start must be a valid integer");

        if (!int.TryParse(parts[1].Trim(), out int end))
            throw new ArgumentException("End must be a valid integer");

        Start = Math.Min(start, end);
        End = Math.Max(start, end);
    }

    // Конструктор из одного числа (диапазон из одного элемента)
    public InclusiveRange(int single)
    {
        Start = single;
        End = single;
    }
}