using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace App.IndexerOverloading.Task3_RangeSlice;

public class SliceableList<T> : IEnumerable<T>
{
    private readonly List<T> _items;

    public SliceableList()
    {
        _items = new List<T>();
    }

    public SliceableList(IEnumerable<T> source)
    {
        _items = source?.ToList() ?? throw new ArgumentNullException(nameof(source));
    }

    public int Count => _items.Count;

    // Индексатор по целочисленному индексу
    public T this[int index]
    {
        get => _items[index];
        set => _items[index] = value;
    }

    // Индексатор по структуре Index (поддержка ^1, ^2 и т.д.)
    public T this[Index index]
    {
        get => _items[index];
        set => _items[index] = value;
    }

    // Индексатор по Range для срезов (поддержка .., 1.., ..^1 и т.д.)
    public SliceableList<T> this[Range range]
    {
        get
        {
            var (start, length) = range.GetOffsetAndLength(_items.Count);
            var slicedItems = _items.GetRange(start, length);
            return new SliceableList<T>(slicedItems);
        }
    }

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}