class Person
{
    private string Name { get; set; }
    private int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    public void Introduce()
    {
        Console.WriteLine($"Hello, {Name}!");
    }
}

class Program
{
    private static void Main(string[] args)
    {
        var ram = new Person("ram",22);
        var santhosh = new Person("santhosh", 23);
        var varun = new Person("varun", 24);

        ram.Introduce();
        santhosh.Introduce();
        varun.Introduce();
    }
}
