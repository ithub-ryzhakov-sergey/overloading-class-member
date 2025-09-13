using System;

namespace App.ConstructorOverloading.Task1_Point;

public class Point2D
{
    // Координаты точки. Сделаны только для чтения снаружи.
    public int X { get; private set; }
    public int Y { get; private set; }

    // Конструктор по умолчанию: (0,0)
    public Point2D()
    {
        X = 0;
        Y = 0;
    }

    // Конструктор координат
    public Point2D(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Конструктор из строки "x;y" (пробелы допустимы)
    public Point2D(string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new FormatException("Input string cannot be null or empty");

        var parts = s.Split(';');
        if (parts.Length != 2)
            throw new FormatException("Input string must be in format 'x;y'");

        if (!int.TryParse(parts[0].Trim(), out int x))
            throw new FormatException("X coordinate must be a valid integer");

        if (!int.TryParse(parts[1].Trim(), out int y))
            throw new FormatException("Y coordinate must be a valid integer");

        X = x;
        Y = y;
    }

    // Конструктор копирования
    public Point2D(Point2D other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        X = other.X;
        Y = other.Y;
    }
}