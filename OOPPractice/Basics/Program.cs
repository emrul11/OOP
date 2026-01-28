using Basics.Models;


Console.WriteLine("1. Add Student");
Console.WriteLine("2. Show All Students");
Console.Write("Choose option: ");
int choice = int.Parse(Console.ReadLine());

if (choice == 1)
{
    Student student = CreateStudentFromInput();
    //repository.Save(student);
    Console.WriteLine("Student saved successfully.");
}
else if (choice == 2)
{
   // List<Student> students = repository.GetAllStudents();
    //foreach (Student student in students)
    //{
    //    DisplayStudentInfo(student);
    //    Console.WriteLine("----------------------------");
    //}
}
else
{
    Console.WriteLine("Invalid choice");
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

    Console.Write("Physics:");
    student.result.physics = double.Parse( Console.ReadLine());

    Console.Write("Chemistry");
    student.result.chemistry = double.Parse( Console.ReadLine());

    Console.Write("Biology");
    student.result.biology = double.Parse( Console.ReadLine());

    

    return student;
}
   
void DisplayStudentInfo(Student student) { 
    Console.WriteLine("Name: " +student.name);
    Console.WriteLine("Email: " +student.email); 
    Console.WriteLine("Contact Number: " + student.contactNumber);
    Console.WriteLine("Physics: " + student.result.physics);
    Console.WriteLine("Chemistry: " + student.result.chemistry);
    Console.WriteLine("Biology: " + student.result.biology);
    Console.WriteLine("Average: " + student.result.GetAverage());
    Console.WriteLine("Result: " + student.result.GetPassOrFail());
}


//DisplayStudentInfo(student1 );
//Console.WriteLine("_________________________\n");
//DisplayStudentInfo(student2);

