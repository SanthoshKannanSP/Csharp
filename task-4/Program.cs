class Program
{
    public static List<Student> Students = new List<Student>();
    public static void Main(string[] args)
    {
        void AddStudent()
        {
            Console.Write("Enter the name of the student: ");
            var name = Console.ReadLine().Trim();
            Console.Write("Enter the grade of the student: ");
            var grade = float.Parse(Console.ReadLine());
            Console.Write("Enter the age of the student: ");
            var age = int.Parse(Console.ReadLine());
    
            Student newStudent = new Student(name, grade, age);
            Students.Add(newStudent);
            Console.WriteLine("Student added!");
        }

        void ViewAllStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("There are no students!");
                return;
            }

            foreach (var student in Students)
            {
                Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}, Age: {student.Age}");
            }
        }
        
        void FilterAndSortStudents()
        {
            Console.Write("Enter the grade threshold: ");
            var threshold = float.Parse(Console.ReadLine());
            var filteredStudents = 
                from student in Students
                where student.Grade >= threshold
                select student;

            var sortedStudents = filteredStudents.OrderBy(student => student.Grade).Reverse();

            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}, Age: {student.Age}");
            }
        }

        void PrintInstructions()
        {
            Console.WriteLine("[A]dd a student");
            Console.WriteLine("[V]iew all students");
            Console.WriteLine("[F]ilter and sort students");
            Console.WriteLine("[E]xit the program");
        }
        
        Console.WriteLine("Student Management Portal");
        PrintInstructions();
        var userInput = Console.ReadLine().Trim().ToLower();
        do
        {
            switch (userInput)
            {
                case "a":
                    AddStudent();
                    break;
                case "v":
                    ViewAllStudents();
                    break;
                case "f":
                    FilterAndSortStudents();
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
            PrintInstructions();
            userInput = Console.ReadLine().Trim().ToLower();
        } while (userInput != "e");
    }
}

class Student
{
    public string Name;
    public float Grade;
    public int Age;
    
    public Student(String name, float grade, int age)
    {
        Name = name;
        Grade = grade;
        Age = age;
    }
}

