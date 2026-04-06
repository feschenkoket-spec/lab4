using System;
using System.Text;

class RepairOrder
{
    private readonly int code;
    private string description;
    private double price;

    private static int count = 0;

    public RepairOrder(int code, string description, double price)
    {
        this.code = code;
        this.description = description;
        this.price = price;
        count++;
    }

    public double GetPrice()
    {
        return price;
    }

    public static int GetCount()
    {
        return count;
    }

    public bool IsExpensive()
    {
        return price > 2500;
    }

    public virtual string GetInfo()
    {
        return "Код: " + code + ", Опис: " + description + ", Ціна: " + price;
    }
}

class PhoneRepair : RepairOrder
{
    private string brand;

    public PhoneRepair(int code, string description, double price, string brand)
        : base(code, description, price)
    {
        this.brand = brand;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + ", Бренд: " + brand;
    }
}

class LaptopRepair : RepairOrder
{
    private string problemType;

    public LaptopRepair(int code, string description, double price, string problemType)
        : base(code, description, price)
    {
        this.problemType = problemType;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + ", Тип поломки: " + problemType;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;

            RepairOrder[] orders = new RepairOrder[3];

            orders[0] = new PhoneRepair(1, "не вмикається", 2000, "Samsung");
            orders[1] = new LaptopRepair(2, "зламаний екран", 3000, "екран");
            orders[2] = new PhoneRepair(3, "не заряджається", 2800, "iPhone");

            double total = 0;
            int expensiveCount = 0;

            for (int i = 0; i < orders.Length; i++)
            {
                Console.WriteLine(orders[i].GetInfo());
                total += orders[i].GetPrice();

                if (orders[i].IsExpensive())
                {
                    expensiveCount++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Загальна сума: " + total);
            Console.WriteLine("Кількість дорогих ремонтів: " + expensiveCount);
            Console.WriteLine("Всього заявок: " + RepairOrder.GetCount());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }

        Console.ReadKey();
    }
}