﻿public class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, int pe, int maxspeed)
    {
        Name = name;
        ProductionYear = pe;
        MaxSpeed = maxspeed;
    }
    public override string ToString()
    {
        return $"{Name}, {ProductionYear}, {MaxSpeed}";
    }
}

public class CarComparer : IComparer<Car>
{
    private string criteria;

    public CarComparer(string c)
    {
        criteria = c;
    }

    public int Compare(Car x, Car y)
    {
        if (criteria.ToLower() == "name")
        {
            return x.Name.CompareTo(y.Name);
        }
        else if (criteria.ToLower() == "year")
        {
            return x.ProductionYear.CompareTo(y.ProductionYear);
        }
        else if (criteria.ToLower() == "speed")
        {
            return x.MaxSpeed.CompareTo(y.MaxSpeed);
        }
        else
        {
            throw new ArgumentException("Invalid sorting criteria");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car[] cars =
        [
            new Car("Mazda", 2020, 250),
            new Car("lada", 2015, 180),
            new Car("bmw", 2018, 240),
            new Car("Audi", 2022, 260)
        ];

        Console.WriteLine("Sorting by Name:");
        Array.Sort(cars, new CarComparer("name"));
        foreach (var car in cars)
            Console.WriteLine(car);

        Console.WriteLine("Sorting by year:");
        Array.Sort(cars, new CarComparer("year"));
        foreach (var car in cars)
            Console.WriteLine(car);

        Console.WriteLine("Sorting by speed:");
        Array.Sort(cars, new CarComparer("speed"));
        foreach (var car in cars)
            Console.WriteLine(car);
    }
}