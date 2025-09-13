// Задача: Перегрузка конструкторов — Point2D
// Реализуйте класс Point2D с несколькими конструкторами согласно README.

namespace App.ConstructorOverloading.Task1_Point;

public class Point2D
{
    // Координаты точки. Сделаны только для чтения снаружи.
    public int X { get; private set; }
    public int Y { get; private set; }

    // Конструктор по умолчанию: (0,0)
    public Point2D()
    {
        this.X = 0;
        this.Y = 0;
    }

    // Конструктор координат
    public Point2D(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    // Конструктор из строки "x;y" (пробелы допустимы)
    public Point2D(string s)
    {
        if (s == null || s == "") {
            throw new FormatException();
        }
        string[] tmp = s.Split(';');
        if (tmp.Length > 2)
        {
            throw new FormatException();
        }
        this.X = Convert.ToInt32(tmp[0]);
        this.Y = Convert.ToInt32(tmp[1]);
    }

    // Конструктор копирования
    public Point2D(Point2D other)
    {
        this.X = other.X;
        this.Y = other.Y;
    }
}