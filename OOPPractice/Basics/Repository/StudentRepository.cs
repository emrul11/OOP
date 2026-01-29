using Basics.Models;
using Basics.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Repository
{
    public class StudentRepository
    {
        private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "students.csv");

        public StudentRepository()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "name,email,contactNumber,physics,chemistry,biology\n");
            }
        }

        public void Add(Student student)
        {
            string line = $"{student.name},{student.email},{student.contactNumber}," +
                $"{student.result.physics},{student.result.chemistry},{student.result.biology}";
            File.AppendAllLines(_filePath, new[] { line });
        }

        public List<Student> GetAll()
        {
            var students = new List<Student>();
            if (!File.Exists(_filePath))
                return students;

           
            var lines = File.ReadAllLines(_filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if(string.IsNullOrWhiteSpace(line)) 
                    continue;
                var parts = line.Split(',');
                if(parts.Length <6)
                    continue;

                if(!double.TryParse(parts[3], out double physics)) continue;
                if (!double.TryParse(parts[4], out double chemistry)) continue;
                if (!double.TryParse(parts[5], out double biology)) continue;

                var student = new Student()
                {
                    name = parts[0],
                    email = parts[1],
                    contactNumber = parts[2],
                    result = new Result
                    {
                        physics = physics,
                        chemistry = chemistry,
                        biology = biology
                    }
                };

                var validation = new StudentValidator().Validate(student);
                if (!validation.IsValid)
                    continue; 
                
                students.Add(student); 
            }

           

            return students;
        }
    }
}
