using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

public partial class Set
{
    // Поля
    private List<int> elements;  
    public readonly int ID;  
    private static int objectCount = 0;  

    public const int MaxElements = 100;  

    // Свойства
    public int ElementCount
    {
        get { return elements.Count; }
        private set { /* ограничим доступ на запись */ }
    }

    public List<int> Elements
    {
        get { return elements; }
    }

    // Статический конструктор
    static Set()
    {
        Console.WriteLine("Статический конструктор вызван.");
    }

    // Закрытый конструктор
    private Set()
    {
        elements = new List<int>();
        ID = GetHashCode();
        objectCount++;
    }

    public static Set CreateEmptySet(IEnumerable<int>? initialElements = null)
    {
        Set set = new Set();
        if (initialElements != null)
        {
            foreach (var element in initialElements)
            {
                set.AddElement(element);
            }
        }
        return set;
    }

    // Универсальный конструктор для List<int> и int[]
    public Set(IEnumerable<int>? initialElements = null)
    {
        elements = initialElements != null ? new List<int>(initialElements) : new List<int>();
        ID = GetHashCode();
        objectCount++;
        Console.WriteLine($"Создано множество с ID: {ID}");
    }

    // Методы
    public void AddElement(int element)
    {
        if (elements.Count < MaxElements)
        {
            elements.Add(element);
            Console.WriteLine($"Элемент {element} добавлен.");
        }
        else
        {
            Console.WriteLine("Невозможно добавить элемент: превышен максимум.");
        }
    }

    public void RemoveElement(int element)
    {
        if (elements.Contains(element))
        {
            elements.Remove(element);
            Console.WriteLine($"Элемент {element} удален.");
        }
        else
        {
            Console.WriteLine($"Элемент {element} не найден.");
        }
    }
    public static void DisplayClassInfo()
    {
        Console.WriteLine($"Количество созданных объектов: {objectCount}");
    }

    // Метод с ref и out
    public void FindElement(int index, ref int element, out bool found)
    {
        if (index >= 0 && index < elements.Count)
        {
            element = elements[index];
            found = true;
        }
        else
        {
            element = -1;
            found = false;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is Set otherSet)
        {
            return this.ID == otherSet.ID;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return elements.Count * 397;
    }

    public override string ToString()
    {
        return $"Множество ID: {ID}, количество элементов: {elements.Count}";
    }
}

public partial class Set
{
    
}
class Program
{
    static void Main(string[] args)
    {
        Set emptySet = Set.CreateEmptySet();
        Set setElem = Set.CreateEmptySet(new List<int> { 1, 2, 3, 4, 5 });

        // Создание объектов множества с вводом данных с консоли
        Set set1 = CreateSetFromConsole("Введите элементы для множества 1:");
        Set set2 = CreateSetFromConsole("Введите элементы для множества 2:");
        Set set3 = CreateSetFromConsole("Введите элементы для множества 3:");

        // Использование методов и свойств
        emptySet.RemoveElement(0);
        set1.AddElement(5);
        set2.RemoveElement(2);
        set3.AddElement(-5);

        // Поиск элемента с использованием ref и out
        int foundElement = 0;
        bool found;
        set2.FindElement(1, ref foundElement, out found);
        if (found)
        {
            Console.WriteLine($"Найден элемент: {foundElement}");
        }
        else
        {
            Console.WriteLine("Элемент не найден.");
        }

        Set.DisplayClassInfo();

        Console.WriteLine(set1.Equals(set2));
        Console.WriteLine(set1.GetHashCode());
        Console.WriteLine(set1.ToString());

        // Создание массива объектов множества
        Set[] sets = new Set[] { set1, set2, set3 };

        FindMinMaxSets(sets);

        DisplaySetsWithNegativeElements(sets);
    }

    // Метод для создания множества с вводом элементов с консоли
    static Set CreateSetFromConsole(string prompt)
    {
        Console.WriteLine(prompt);
        List<int> elements = new List<int>();

        while (true)
        {
            Console.Write("Введите элемент (или пустую строку для завершения): ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input)) 
            {
                break;
            }

            if (int.TryParse(input, out int element)) 
            {
                elements.Add(element);
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
            }
        }

        return new Set(elements); 
    }

    // Метод для поиска множеств с минимальной и максимальной суммой элементов
    static void FindMinMaxSets(Set[] sets)
    {
        Set minSet = sets[0];
        Set maxSet = sets[0];
        foreach (var set in sets)
        {
            if (SumElements(set) < SumElements(minSet))
            {
                minSet = set;
            }
            if (SumElements(set) > SumElements(maxSet))
            {
                maxSet = set;
            }
        }
        Console.WriteLine($"Множество с минимальной суммой элементов: {minSet}");
        Console.WriteLine($"Множество с максимальной суммой элементов: {maxSet}");
    }

    // Метод для подсчета суммы элементов множества
    static int SumElements(Set set)
    {
        int sum = 0;
        foreach (var element in set.Elements)
        {
            sum += element;
        }
        return sum;
    }

    // Метод для вывода множеств с отрицательными элементами
    static void DisplaySetsWithNegativeElements(Set[] sets)
    {
        Console.WriteLine("Множества с отрицательными элементами:");
        foreach (var set in sets)
        {
            foreach (var element in set.Elements)
            {
                if (element < 0)
                {
                    Console.WriteLine(set);
                    break;
                }
            }
        }
    }
}
