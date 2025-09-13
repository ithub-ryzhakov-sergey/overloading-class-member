using System;

namespace App.ConstructorOverloading.Task2_Matrix;

public class IntMatrix
{
    // Размеры матрицы
    public int RowCount { get; }
    public int ColCount { get; }

    private readonly int[,] _data;

    // Индексатор для проверки значений в тестах
    public int this[int row, int col]
    {
        get => _data[row, col];
    }

    // Основной конструктор (rows, cols) — заполняет нулями
    public IntMatrix(int rows, int cols)
    {
        if (rows <= 0) throw new ArgumentException("Rows must be positive", nameof(rows));
        if (cols <= 0) throw new ArgumentException("Columns must be positive", nameof(cols));

        RowCount = rows;
        ColCount = cols;
        _data = new int[rows, cols];
        // Массив уже заполнен нулями по умолчанию
    }

    // Конструктор из прямоугольного массива - вызывает основной конструктор
    public IntMatrix(int[,] data) : this(data?.GetLength(0) ?? throw new ArgumentNullException(nameof(data)),
                                        data.GetLength(1))
    {
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColCount; j++)
            {
                _data[i, j] = data[i, j];
            }
        }
    }

    // Конструктор из ступенчатого массива - вызывает основной конструктор
    public IntMatrix(int[][] data) : this(data?.Length ?? throw new ArgumentNullException(nameof(data)),
                                         data.Length > 0 ? data[0]?.Length ?? throw new ArgumentException("First row cannot be null") : 0)
    {
        if (data.Length == 0) throw new ArgumentException("Array cannot be empty", nameof(data));

        // Проверяем, что все строки имеют одинаковую длину
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] == null) throw new ArgumentException($"Row {i} cannot be null", nameof(data));
            if (data[i].Length != ColCount) throw new ArgumentException("All rows must have the same length", nameof(data));
        }

        // Копируем данные
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColCount; j++)
            {
                _data[i, j] = data[i][j];
            }
        }
    }
}