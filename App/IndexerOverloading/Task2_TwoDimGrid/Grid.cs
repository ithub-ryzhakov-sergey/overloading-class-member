using System;

namespace App.IndexerOverloading.Task2_TwoDimGrid;

public readonly struct Cell
{
    public int Row { get; }
    public int Col { get; }
    public Cell(int row, int col)
    {
        Row = row;
        Col = col;
    }
}

public class Grid<T>
{
    public int Rows { get; }
    public int Cols { get; }

    private readonly T[,] _data;

    public Grid(int rows, int cols)
    {
        if (rows <= 0) throw new ArgumentException("Rows must be positive", nameof(rows));
        if (cols <= 0) throw new ArgumentException("Columns must be positive", nameof(cols));

        Rows = rows;
        Cols = cols;
        _data = new T[rows, cols];
    }

    // Индексатор по строке и столбцу [row, col]
    public T this[int row, int col]
    {
        get
        {
            ValidateIndices(row, col);
            return _data[row, col];
        }
        set
        {
            ValidateIndices(row, col);
            _data[row, col] = value;
        }
    }

    // Индексатор по структуре Cell
    public T this[Cell cell]
    {
        get
        {
            ValidateIndices(cell.Row, cell.Col);
            return _data[cell.Row, cell.Col];
        }
        set
        {
            ValidateIndices(cell.Row, cell.Col);
            _data[cell.Row, cell.Col] = value;
        }
    }

    // Индексатор по одномерному индексу [index] (row-major порядок)
    public T this[int index]
    {
        get
        {
            ValidateIndex(index);
            var (row, col) = ConvertIndexTo2D(index);
            return _data[row, col];
        }
        set
        {
            ValidateIndex(index);
            var (row, col) = ConvertIndexTo2D(index);
            _data[row, col] = value;
        }
    }

    private void ValidateIndices(int row, int col)
    {
        if (row < 0 || row >= Rows)
            throw new IndexOutOfRangeException($"Row index {row} is out of range [0, {Rows - 1}]");
        if (col < 0 || col >= Cols)
            throw new IndexOutOfRangeException($"Column index {col} is out of range [0, {Cols - 1}]");
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= Rows * Cols)
            throw new IndexOutOfRangeException($"Index {index} is out of range [0, {Rows * Cols - 1}]");
    }

    private (int row, int col) ConvertIndexTo2D(int index)
    {
        int row = index / Cols;
        int col = index % Cols;
        return (row, col);
    }
}