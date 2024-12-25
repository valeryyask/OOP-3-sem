using System;
using System.Collections.Generic;
using System.Diagnostics;

public enum TransportType
{
    Ship,
    Steamship,
    Sailboat,
    Corvette,
    Boat
}

public class TransportException : Exception
{
    public TransportException(string message) : base(message) { }
}

public class CapacityExceededException : TransportException
{
    public CapacityExceededException(string message) : base(message) { }
}

public class InvalidTransportTypeException : TransportException
{
    public InvalidTransportTypeException(string message) : base(message) { }
}

public struct TransportInfo
{
    public string Name;
    public int Capacity;
    public TransportType Type;

    public TransportInfo(string name, int capacity, TransportType type)
    {
        Name = name;
        Capacity = capacity;
        Type = type;
    }
}

public interface IVehicleOperations
{
    void Start();
    void Stop();
    void Accelerate();
}

public interface IIsRunning
{
    void IsRunning();
}

public abstract class TransportVehicle : IVehicleOperations, IComparable, ICloneable
{
    public string Name { get; set; }
    public int Capacity { get; set; }

    public abstract void Sail();
    public abstract void IsRunning();

    public int CompareTo(object obj)
    {
        if (obj is TransportVehicle otherVehicle)
        {
            return this.Capacity.CompareTo(otherVehicle.Capacity);
        }
        throw new ArgumentException("Object is not a TransportVehicle");
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public void Start() => Console.WriteLine($"{Name} начинает движение.");
    public void Stop() => Console.WriteLine($"{Name} останавливается.");
    public void Accelerate() => Console.WriteLine($"{Name} ускоряется.");
}

public class Ship : TransportVehicle
{
    public override void Sail() => Console.WriteLine($"{Name} плывет.");
    public override void IsRunning() => Console.WriteLine($"{Name} работает.");
}

public class Steamship : Ship
{
    public override void Sail() => Console.WriteLine($"{Name} движется на паровом двигателе.");
}

public class Sailboat : Ship
{
    public override void Sail() => Console.WriteLine($"{Name} движется под парусами.");
}

public class Corvette : Ship
{
    public override void Sail() => Console.WriteLine($"{Name} плывет в боевом режиме.");
}

public class Boat : TransportVehicle, IIsRunning
{
    public override void Sail() => Console.WriteLine($"{Name} движется на веслах.");
    public override void IsRunning() => Console.WriteLine($"{Name} пригоден.");
}

public class TransportContainer
{
    private List<TransportVehicle> vehicles = new List<TransportVehicle>();

    public void AddVehicle(TransportVehicle vehicle)
    {
        if (vehicle.Capacity < 0)
            throw new CapacityExceededException("Вместимость не может быть отрицательной.");

        vehicles.Add(vehicle);
    }

    public void RemoveVehicle(TransportVehicle vehicle) => vehicles.Remove(vehicle);
    public TransportVehicle GetVehicle(int index) => vehicles.ElementAtOrDefault(index);
    public void PrintVehicles()
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }
    }

    public void SortVehicles() => vehicles.Sort();
}

public class TransportController
{
    private TransportContainer container;

    public TransportController(TransportContainer transportContainer)
    {
        container = transportContainer;
    }

    public void DisplayAllVehicles() => container.PrintVehicles();
    public void AddTransport(TransportVehicle vehicle) => container.AddVehicle(vehicle);
    public void SortTransport() => container.SortVehicles();
}

public class Logger
{
    public void Log(string message, string logType)
    {
        Console.WriteLine($"{DateTime.Now}, {logType}: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger logger = new Logger();
        TransportContainer transportContainer = new TransportContainer();
        TransportController controller = new TransportController(transportContainer);

        try
        {
            controller.AddTransport(new Ship { Name = "Корабль", Capacity = 300 });
            controller.AddTransport(new Steamship { Name = "Пароход", Capacity = 120 });
            controller.AddTransport(new Sailboat { Name = "Парусник", Capacity = 10 });
            controller.AddTransport(new Corvette { Name = "Корвет", Capacity = 70 });
            controller.AddTransport(new Boat { Name = "Лодка", Capacity = 4 });

            controller.AddTransport(new Boat { Name = "Неверная лодка", Capacity = -5 });

        }
        catch (CapacityExceededException ex)
        {
            logger.Log(ex.Message, "ERROR");
        }
        catch (Exception ex)
        {
            logger.Log(ex.Message, "ERROR");
        }
        finally
        {
            Console.WriteLine("Завершение работы программы.");
        }

        Console.WriteLine("Список всех транспортных средств:");
        controller.DisplayAllVehicles();

        controller.SortTransport();
        Console.WriteLine("\nСписок всех транспортных средств после сортировки по вместимости:");
        controller.DisplayAllVehicles();
    }
}