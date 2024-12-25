using System;

namespace MarineTransport
{
    interface IVehicleOperations
    {
        void Start();
        void Stop();
        void Accelerate();
    }
    interface IIsRunning
    {
        void IsRunning();
    }

    abstract class TransportVehicle : IVehicleOperations
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public abstract void Sail();

        public abstract void IsRunning();
        public virtual void Start() => Console.WriteLine($"{Name} начинает движение.");
        public virtual void Stop() => Console.WriteLine($"{Name} останавливается.");
        public virtual void Accelerate() => Console.WriteLine($"{Name} ускоряется.");

        public override string ToString() => $"Транспортное средство: {Name}, Вместимость: {Capacity}";
    }

    class Ship : TransportVehicle
    {
        public override void Sail() => Console.WriteLine($"{Name} плывет.");
        public override string ToString() => $"Корабль: {Name}, Вместимость: {Capacity}";
        public override void IsRunning() => Console.WriteLine("Это из интерфейса.");
    }

    class Steamship : Ship
    {
        public override void Sail() => Console.WriteLine($"{Name} движется на паровом двигателе.");
        public override string ToString() => $"Пароход: {Name}, Вместимость: {Capacity}";
        public override void IsRunning() => Console.WriteLine($"{Name} пригоден");

    }

    class Sailboat : Ship
    {
        public override void Sail() => Console.WriteLine($"{Name} движется под парусами.");
        public override string ToString() => $"Парусник: {Name}, Вместимость: {Capacity}";
        public override void IsRunning() => Console.WriteLine($"{Name} пригоден");

    }

    class Corvette : Ship
    {
        public override void Sail() => Console.WriteLine($"{Name} плывет в боевом режиме.");
        public override string ToString() => $"Корвет: {Name}, Вместимость: {Capacity}";
        public override void IsRunning() => Console.WriteLine($"{Name} пригоден");
    }

    class Captain
    {
        public string Name { get; set; }

        public Captain(string name) => Name = name;

        public override string ToString() => $"Капитан: {Name}";
    }

    internal sealed class Boat : TransportVehicle, IIsRunning
    {
        public override void Sail() => Console.WriteLine($"{Name} движется на веслах.");
        public override string ToString() => $"Лодка: {Name}, Вместимость: {Capacity}";
        public override void IsRunning()=> Console.WriteLine($"{Name} пригоден");
        void IIsRunning.IsRunning()
        {
            Console.WriteLine("Это из интерфейса.");
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode() => base.GetHashCode();
        public new Type GetType() => base.GetType();
        public Boat Clone()
        {
            return (Boat)this.MemberwiseClone();
        }
    }

    class Printer
    {
        public void IAmPrinting(TransportVehicle obj) => Console.WriteLine(obj.ToString());
    }

    class Program
    {
        static void Main(string[] args)
        {
            TransportVehicle[] vehicles = {
                new Ship { Name = "Корабль", Capacity = 300 },
                new Steamship { Name = "Пароход", Capacity = 120 },
                new Sailboat { Name = "Парусник", Capacity = 10 },
                new Corvette { Name = "Корвет", Capacity = 70 },
                new Boat { Name = "Лодка", Capacity = 4 }
            };

            Printer printer = new Printer();

            foreach (var vehicle in vehicles)
            {
                printer.IAmPrinting(vehicle);
                vehicle.Sail();
                vehicle.Start();
                vehicle.Accelerate();
                vehicle.Stop();
                vehicle.IsRunning();
                if (vehicle is Boat boat)
                {
                    ((IIsRunning)boat).IsRunning();
                    Console.WriteLine(boat.ToString());
                }
                Console.WriteLine();
            }

        }
    }
}
