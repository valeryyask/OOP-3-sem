using System;
using System.Collections.Generic;
using System.Linq;

public class Vector
{
    private List<int> elements;
    public readonly int ID;
    public List<int> Elements
    {
        get { return elements; }
    }
    public Production ProductionInfo { get; set; }
    public class Developer
    {
        public string FullName { get; set; }
        public int ID { get; set; }
        public string Department { get; set; }

        public Developer(string fullName, int id, string department)
        {
            FullName = fullName;
            ID = id;
            Department = department;
        }
    }
    public Developer DeveloperInfo { get; set; }
    public Vector()
    {
        elements = new List<int>();
        ID = GetHashCode();
    }
    public Vector(IEnumerable<int> initialElements)
    {
        elements = new List<int>(initialElements);
        ID = GetHashCode();
    }
    public int this[int index]
    {
        get { return elements[index]; }
        set { elements[index] = value; }
    }
    public void AddElement(int element)
    {
        elements.Add(element);
    }
    public static Vector operator +(Vector v1, Vector v2)
    {
        var result = new Vector(v1.elements);
        result.elements.AddRange(v2.elements);
        return result;
    }
    public static Vector operator -(Vector v1, Vector v2)
    {
        var result = new Vector(v1.elements);
        foreach (var element in v2.elements)
        {
            result.elements.Remove(element);
        }
        return result;
    }
    public static bool operator >(Vector v1, Vector v2)
    {
        return v1.elements.Sum() > v2.elements.Sum();
    }
    public static bool operator <(Vector v1, Vector v2)
    {
        return v1.elements.Sum() < v2.elements.Sum();
    }
    public static bool operator true(Vector v)
    {
        return v.elements.Count == 0;
    }
    public static bool operator false(Vector v)
    {
        return v.elements.Count != 0;
    }
    public static Vector operator ==(Vector v1, Vector v2)
    {
        return new Vector(v1.elements); 
    }
    public static Vector operator !=(Vector v1, Vector v2)
    {
        return new Vector(v2.elements); 
    }
    public override bool Equals(object obj)
    {
        if (obj is Vector other)
        {
            return this.ID == other.ID;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return elements.Count * 397;
    }
    public override string ToString()
    {
        return $"Вектор (ID: {ID}): {string.Join(", ", elements)}";
    }
    public class Production
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public Production(int id, string organizationName)
        {
            Id = id;
            OrganizationName = organizationName;
        }
    }
}
public static class StatisticOperation
{
    public static int Sum(Vector vector)
    {
        return vector.Elements.Sum();
    }
    public static int Difference(Vector vector)
    {
        return vector.Elements.Max() - vector.Elements.Min();
    }
    public static int Count(Vector vector)
    {
        return vector.Elements.Count;
    }
    public static string TruncateStart(this string str, int length)
    {
        if (string.IsNullOrEmpty(str) || length >= str.Length)
            return string.Empty;
        return str.Substring(length);
    }
    public static Vector RemovePositiveElements(this Vector vector)
    {
        return new Vector(vector.Elements.Where(e => e <= 0));
    }
}

class Program
{
    static void Main(string[] args)
    {
        var production = new Vector.Production(1, "eeeee");
        var developer = new Vector.Developer("mmmmm", 101, "llllll");

        Vector vector1 = new Vector(new int[] { -11, -23, 31, 54 });
        vector1.ProductionInfo = production;
        vector1.DeveloperInfo = developer;
        Vector vector2 = new Vector(new int[] { -1, -2, -3 });
       
        Vector sumVector = vector1 + vector2;
        Vector differenceVector = vector2 - vector1;
        bool isVector1Greater = vector1 > vector2;

        Console.WriteLine("Сумма векторов: " + sumVector);
        Console.WriteLine("Разность векторов: " + differenceVector);
        Console.WriteLine("Вектор 1 больше вектора 2? " + isVector1Greater);

        int sum = StatisticOperation.Sum(vector1);
        int difference = StatisticOperation.Difference(vector1);
        int count = StatisticOperation.Count(vector1);

        Console.WriteLine($"Сумма элементов вектора: {sum}");
        Console.WriteLine($"Разница между макс и мин элементами: {difference}");
        Console.WriteLine($"Количество элементов: {count}");

        string example = "llllll eeeeeee";
        string truncated = example.TruncateStart(7);

        Console.WriteLine("Усеченная строка: " + truncated);
        Vector vectorWithoutPositives = vector1.RemovePositiveElements();
        Console.WriteLine("Вектор без положительных элементов: " + vectorWithoutPositives);
    }
}
