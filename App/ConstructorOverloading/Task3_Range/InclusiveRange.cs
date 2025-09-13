// Задача: Перегрузка конструкторов — InclusiveRange
// Реализуйте класс InclusiveRange согласно README. Диапазон включительный.

namespace App.ConstructorOverloading.Task3_Range;

public class InclusiveRange
{
    public int Start { get; private set; }
    public int End { get; private set; }

    // Конструктор (start, end)
    public InclusiveRange(int start, int end)
    {
        if (start > end)
        {
            throw new ArgumentOutOfRangeException();
        }
        this.Start = start;
        this.End = end;
    }

    // Конструктор из строки "start..end"
    public InclusiveRange(string s)
    {
        string[] tmp = s.Split("..");
        if (tmp.Length != 2)
        {
            throw new FormatException();
        }
        if (Convert.ToInt32(tmp[0]) > Convert.ToInt32(tmp[1])){
            throw new ArgumentOutOfRangeException(); 
        }
        this.Start = Convert.ToInt32(tmp[0]);
        this.End = Convert.ToInt32(tmp[1]);        
    }

    // Конструктор из одного числа
    public InclusiveRange(int single)
    {
        this.Start = single;
        this.End = single;
    }
}