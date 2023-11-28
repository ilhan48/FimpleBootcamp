
class Student
{
    protected string Name;
    public int Age { get; set; }
    private int height;
    internal void SetName(string name)
    {
        Name = name;
    }
    internal string GetInfo()
    {
        return $"Name: {Name}, Age: {Age}. Height: {height}";

    }

    public Student(string name, int age, int height)
    {
        Name = name;
        Age = age;
        this.height = height;
    }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public Student()
    {
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        Student student = new Student();
        student.SetName("John");
        student.Age = 20;
        //student.height = 180;
        Console.WriteLine(student.GetInfo());
    }
}

