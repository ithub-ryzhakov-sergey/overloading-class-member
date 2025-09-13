using System;

namespace App.IndexerOverloading.Task4_ArrayWrapper;

public class ArrayWrapper<T>
{
    private readonly T[] _items;

    // Конструктор принимает массив; при null кидает ArgumentNullException
    public ArrayWrapper(T[] items)
    {
        _items = items ?? throw new ArgumentNullException(nameof(items));
    }

    // Длина массива
    public int Length => _items.Length;

    // Индексатор для чтения/записи с проверкой границ
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _items.Length)
                throw new IndexOutOfRangeException($"Index {index} is out of range [0, {_items.Length - 1}]");

            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _items.Length)
                throw new IndexOutOfRangeException($"Index {index} is out of range [0, {_items.Length - 1}]");

            _items[index] = value;
        }
    }
}