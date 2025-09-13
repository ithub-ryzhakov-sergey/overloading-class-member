// Задача: Перегрузка методов — Sum
// Реализуйте набор перегруженных методов Sum согласно описанию в README.
// Подсказка: обратите внимание на конфликт между перегрузками с массивом и params.

namespace App.MethodOverloading.Task1_SumOverloads;

public static class SumUtil
{
    // Складывает два int
    public static int Sum(int a, int b)
    {
        return a + b;
    }

    // Складывает три int
    public static int Sum(int a, int b, int c)
    {
        return a + b + c;
    }

    // Складывает произвольное количество значений
    public static int Sum(params int[] values)
    {
        if (values == null) return 0;

        int result = 0;
        foreach (int value in values)
        {
            result += value;
        }
        return result;
    }

    public static int Sum()
    {
        return 0;
    }
}