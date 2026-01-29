using Basics.Models;
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
    }
}
