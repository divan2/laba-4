public class Car
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

public class CarCatalog
{
    private Car[] cars;

    public CarCatalog(Car[] c)
    {
        cars = c;
    }

    public IEnumerable<Car> GetCars()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            yield return cars[i];
        }
    }

    public IEnumerable<Car> GetCarsReversed()
    {
        for (int i = cars.Length - 1; i >= 0; i--)
        {
            yield return cars[i];
        }
    }

    public IEnumerable<Car> GetCarsByYear(int year)
    {
        foreach (Car car in cars)
        {
            if (car.ProductionYear == year)
            {
                yield return car;
            }
        }
    }

    public IEnumerable<Car> GetCarsBySpeed(int speed)
    {
        foreach (Car car in cars)
        {
            if (car.MaxSpeed >= speed)
            {
                yield return car;
            }
        }
    }
}



class Program
{
    static void Main(string[] args)
    {
        Car[] cars =
        [
            new Car("Tesla", 2020, 250),
            new Car("lada", 2015, 180),
            new Car("BMW", 2018, 240),
            new Car("Audi", 2022, 260)
        ];


        CarCatalog catalog = new CarCatalog(cars);

        Console.WriteLine("first - last");
        foreach (Car car in catalog.GetCars())
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("last - first");
        foreach (Car car in catalog.GetCarsReversed())
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("year 2020:");
        foreach (Car car in catalog.GetCarsByYear(2020))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("speed >= 240:");
        foreach (Car car in catalog.GetCarsBySpeed(240))
        {
            Console.WriteLine(car);
        }
    }

}

