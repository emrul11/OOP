using Basics;

Student student1 = new Student();
student1.name = "Alice";
student1.email = "Alice@gmail.com";
student1.contactNumber = "1234567";

Student student2 = new Student();
student2.name = "Bob";
student2.email = "Bob@gmail.com";
student2.contactNumber = "87654321";


Result result1 = new Result();
result1.physics = 90;
result1.chemistry = 75;
result1.biology = 85;

Result result2 = new Result();
result2.physics = 100;
result2.chemistry = 80;
result2.biology = 55;

student1.result = result1;
student2.result = result2;

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


DisplayStudentInfo(student1 );
Console.WriteLine("_________________________\n");
DisplayStudentInfo(student2);

