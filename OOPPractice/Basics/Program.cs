using Basics;

//Student student1 = new Student();
//student1.name = "Alice";
//student1.email = "Alice@gmail.com";
//student1.contactNumber = "1234567";

//Student student2 = new Student();
//student2.name = "Bob";
//student2.email = "Bob@gmail.com";
//student2.contactNumber = "87654321";


//Result result1 = new Result();
//result1.physics = 90;
//result1.chemistry = 75;
//result1.biology = 85;

//Result result2 = new Result();
//result2.physics = 100;
//result2.chemistry = 80;
//result2.biology = 55;

//student1.result = result1;
//student2.result = result2;


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
    

    static Student CreateStudentFromInput()
{
    Student student = new Student();

    Console.Write("Name: ");
    student.name = Console.ReadLine();

    Console.Write("Email: ");
    student.email = Console.ReadLine();

    Console.Write("Contact Number: ");
    student.contactNumber = Console.ReadLine();

    Result result = new Result();

    Console.Write("Physics: ");
    result.physics = double.Parse(Console.ReadLine());

    Console.Write("Chemistry: ");
    result.chemistry = double.Parse(Console.ReadLine());

    Console.Write("Biology: ");
    result.biology = double.Parse(Console.ReadLine());

    student.result = result;

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

