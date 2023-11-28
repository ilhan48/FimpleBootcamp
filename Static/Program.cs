

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Student Count: {0}", Student.studentCount);
        Student student1 = new Student("Ilhan", "Odun", 20);
        Student student2 = new Student("Hasan", "Odun", 21);
        student1.PrintStudentInfo();
        student2.PrintStudentInfo();
        Console.WriteLine("Student Count: {0}", Student.studentCount);

        Console.WriteLine("Add: {0}", Math.Add(5, 6));
        Console.WriteLine("Subtract: {0}", Math.Subtract(50, 6));
        Console.WriteLine("Multiply: {0}", Math.Multiply(5, 6));
        Console.WriteLine("Divide: {0}", Math.Divide(54, 6));
    
    }
}
class Student {

    public static int studentCount;

    private string name;
    private string lastName;
    private int age;

    public Student(string name, string lastName, int age) {
        this.name = name;
        this.lastName = lastName;
        this.age = age;
        studentCount++;
    }

    static Student() {
        studentCount = 0;
    }

    public void PrintStudentInfo() {
        Console.WriteLine("Name: {0}", this.name);
        Console.WriteLine("Last Name: {0}", this.lastName);
        Console.WriteLine("Age: {0}", this.age);
    }
}

static class Math {
    public static int Add(int a, int b) {
        return a + b;
    }
    public static int Subtract(int a, int b) {
        return a - b;
    }
    public static int Multiply(int a, int b) {
        return a * b;
    }
    public static int Divide(int a, int b) {
        return a / b;
    }
}