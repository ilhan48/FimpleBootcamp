
enum Days
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

class Program
{
    static void Main()
    {
        Days day = Days.Monday;
        Console.WriteLine(day);
        Console.WriteLine((int)day);

        day = Days.Friday;
        Console.WriteLine(day);
        Console.WriteLine((int)day);

        day = Days.Sunday;
        Console.WriteLine(day);
        Console.WriteLine((int)day);

        
    }
}