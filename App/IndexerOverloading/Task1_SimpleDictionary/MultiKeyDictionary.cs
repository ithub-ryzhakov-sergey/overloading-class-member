using System;
using System.Collections.Generic;

namespace App.IndexerOverloading.Task1_SimpleDictionary;

public class MultiKeyDictionary
{
    private readonly Dictionary<string, int> _simpleDictionary = new();
    private readonly Dictionary<string, Dictionary<string, int>> _categorizedDictionary = new();

    // Индексатор по одному ключу
    public int this[string key]
    {
        get
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (_simpleDictionary.TryGetValue(key, out int value))
                return value;

            throw new KeyNotFoundException($"Key '{key}' not found");
        }
        set
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            _simpleDictionary[key] = value;
        }
    }

    // Индексатор по категории и ключу
    public int this[string category, string key]
    {
        get
        {
            if (string.IsNullOrEmpty(category))
                throw new ArgumentNullException(nameof(category));
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (_categorizedDictionary.TryGetValue(category, out var categoryDict) &&
                categoryDict.TryGetValue(key, out int value))
            {
                return value;
            }

            throw new KeyNotFoundException($"Key '{key}' not found in category '{category}'");
        }
        set
        {
            if (string.IsNullOrEmpty(category))
                throw new ArgumentNullException(nameof(category));
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (!_categorizedDictionary.ContainsKey(category))
            {
                _categorizedDictionary[category] = new Dictionary<string, int>();
            }

            _categorizedDictionary[category][key] = value;
        }
    }
}