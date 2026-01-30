using Basics.Models;
using Basics.Repository;
using Basics.Validation;


StudentRepository _repository = new StudentRepository();
 
StudentValidator _validation = new StudentValidator();

while (true)
{
    ShowMenu();
    string choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            AddStudent();
            break;
        case "2":
            ShowAllStudents();
            break;
        case "0":
            Console.WriteLine("Exiting Application...");
            return;
        default:
            Console.WriteLine("Invalid Choice.");
            break;

    }
}


static void ShowMenu()
{
    Console.WriteLine("===== Student Management =====");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Show All Student");
    Console.WriteLine("0. Exit");
    Console.Write("Choose Options: ");
}

void AddStudent()
{
    Student student = CreateStudentFromInput();

    ValidationResult result = _validation.Validate(student);

    if (!result.IsValid)
    {
        Console.WriteLine("\nValidation Errors:");
        foreach (string error in result.Errors)
            Console.WriteLine("- "+ error);
        return;
    }

    _repository.Add(student);
    Console.WriteLine("Student Saved Successfully\n\n");
}

void ShowAllStudents()
{
    List<Student> students = new List<Student>(); 
    students = _repository.GetAll();

    foreach (Student student in students)
    {
        DisplayStudent(student);
        Console.WriteLine("____________________");
    }
}
    
static Student CreateStudentFromInput() { 

    Student student = new Student();

    Console.Write("Name:");
    student.name = Console.ReadLine();

    Console.Write("Email:");
    student.email = Console.ReadLine();

    Console.Write("Contact Number:");
    student.contactNumber = Console.ReadLine();
   

    Result result = new Result();
    
    student.result = result;


    student.result.physics = ReadMark("Physics");
    student.result.chemistry = ReadMark("Chemistry");
    student.result.biology = ReadMark("Biology");

    return student;
}

static double ReadMark(string subject)
{
    while (true)
    {
        Console.Write($"{subject}: ");
        if (double.TryParse(Console.ReadLine(), out double mark) &&
            mark >= 0 && mark <= 100)
            return mark;

        Console.WriteLine($"{subject} must be a number between 0 and 100.");
    }
}


void DisplayStudent(Student s)
{
    Console.WriteLine($"Name: {s.name}");
    Console.WriteLine($"Email: {s.email}");
    Console.WriteLine($"Contact: {s.contactNumber}");
    Console.WriteLine($"Average: {s.result.GetAverage()}");
    Console.WriteLine($"Result: {s.result.GetPassOrFail()}");
}

