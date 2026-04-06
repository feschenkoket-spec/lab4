using System;

class Hour
{
    public int value;

    public Hour(int value)
    {
        Console.WriteLine("викликано конструктор Hour");
        this.value = value;
    }

    public override string ToString()
    {
        Console.WriteLine("викликано Hour.ToString()");
        return value.ToString("D2");
    }

    public override bool Equals(object obj)
    {
        Console.WriteLine("викликано Hour.Equals()");
        if (obj is Hour h)
            return h.value == value;
        return false;
    }

    public override int GetHashCode()//повертає хеш код обєкта хаур
    {
        Console.WriteLine("викликано Hour.GetHashCode()");
        return value.GetHashCode();//повертає хеш код числа години // щоб код залежав від знач години
    }
}

class Minute
{
    public int value;

    public Minute(int value)
    {
        Console.WriteLine("викликано конструктор Minute");
        this.value = value;
    }

    public override string ToString()
    {
        Console.WriteLine("викликано Minute.ToString()");
        return value.ToString("D2");
    }

    public override bool Equals(object obj)
    {
        Console.WriteLine("викликано Minute.Equals()");
        if (obj is Minute m)
            return m.value == value;
        return false;
    }

    public override int GetHashCode()
    {
        Console.WriteLine("викликано Minute.GetHashCode()");
        return value.GetHashCode();
    }
}

class Time
{
    public Hour hour;
    public Minute minute;

    public Time(Hour h, Minute m)
    {
        Console.WriteLine("викликано конструктор Time");
        hour = h; //записуємо переданий обєкт у поле
        minute = m;
    }

    public void PrintTime()
    {
        Console.WriteLine("викликано Time.PrintTime()");
        Console.WriteLine("поточний час: " + hour.ToString() + ":" + minute.ToString());
    }

    public override string ToString()
    {
        Console.WriteLine("викликано Time.ToString()");
        return hour.ToString() + ":" + minute.ToString();
    }

    public override bool Equals(object obj)
    {
        Console.WriteLine("викликано Time.Equals()");
        if (obj is Time t)
            return hour.Equals(t.hour) && minute.Equals(t.minute);
        return false;
    }

    public override int GetHashCode()
    {
        Console.WriteLine("викликано Time.GetHashCode()");
        return hour.GetHashCode() + minute.GetHashCode();
    }
}

class Doba
{
    public Time time;

    public Doba(Time t)
    {
        Console.WriteLine("викликано конструктор Doba");
        time = t;
    }

    public void ShowPartOfDay()
    {
        Console.WriteLine("викликано Doba.ShowPartOfDay()");
        Console.WriteLine("час: " + time.ToString());//виводить час який міститься в обєкті доба

        int h = time.hour.value;//створюємо змінну і записуємо в неї число години

        if (h >= 6 && h < 12)
            Console.WriteLine("частина доби: ранок");
        else if (h >= 12 && h < 18)
            Console.WriteLine("частина доби: день");
        else if (h >= 18 && h < 23)
            Console.WriteLine("частина доби: вечір");
        else
            Console.WriteLine("частина доби: ніч");
    }

    public override string ToString()
    {
        Console.WriteLine("викликано Doba.ToString()");
        return "час: " + time.ToString();
    }

    public override bool Equals(object obj)
    {
        Console.WriteLine("викликано Doba.Equals()");
        if (obj is Doba d)
            return time.Equals(d.time);
        return false;
    }

    public override int GetHashCode()
    {
        Console.WriteLine("викликано Doba.GetHashCode()");
        return time.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            DateTime now = DateTime.Now;

            Hour h = new Hour(now.Hour);
            Minute m = new Minute(now.Minute);

            Time t = new Time(h, m);
            Doba d = new Doba(t);

            t.PrintTime();
            d.ShowPartOfDay();

            Console.WriteLine(d.ToString());
            Console.WriteLine("hash code: " + d.GetHashCode());
            Console.WriteLine("equals: " + d.Equals(new Doba(t)));
        }
        catch (Exception ex)
        {
            Console.WriteLine("помилка: " + ex.Message);
        }

        Console.ReadKey();
    }
}