using System;

class Program
{
    static void Main()
    {
        Student student = new Student("Ilhan", 20, 1);
        student.PrintStudentInfo();
        student.ClassUp();
        student.PrintStudentInfo();
        student.ClassDown();
        student.PrintStudentInfo();

        Student student2 = new Student("Hasan", 21, 2);
        student2.PrintStudentInfo();
        student2.ClassDown();
        student2.ClassDown();
        student2.PrintStudentInfo();
    }
}


class Student
{
    private string name;
    private int age;
    private int classNumber;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public int ClassNumber
    {
        get { return this.classNumber; }
        set 
        { 
            if (value < 1)
            {
                Console.WriteLine("Class number cannot be less than 1.");
                classNumber = 1;
            }
        }
    }

    public Student(string name, int age, int classNumber)
    {
        this.Name = name;
        this.Age = age;
        this.ClassNumber = classNumber;
    }

    public void PrintStudentInfo()
    {
        Console.WriteLine("Name: {0}, Age: {1}, Class number: {2}", this.Name, this.Age, this.ClassNumber);
    }

    public void ClassUp()
    {
        this.ClassNumber++;
    }

    public void ClassDown()
    {
        this.ClassNumber--;
    }
}