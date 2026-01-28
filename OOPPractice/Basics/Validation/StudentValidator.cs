using Basics.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Basics.Validation
{
    public class StudentValidator
    {
        public ValidationResult Validate(Student student) 
        { 
            ValidationResult result = new ValidationResult();
            if (string.IsNullOrWhiteSpace(student.name))
                result.Errors.Add("Name is required");
            if (string.IsNullOrWhiteSpace(student.email))
                result.Errors.Add("Email is required");
            else if(!IsValidEmail(student.email))
                result.Errors.Add($"Invalid email Format: {student.email}");

            if (student.result == null)
                result.Errors.Add("Result is missing");
            else
            {
                ValidateMark(student.result.physics, "Physics", result);
                ValidateMark(student.result.chemistry, "Chemistry", result);
                ValidateMark(student.result.biology, "Biology",result);
                
            }

            return result;
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email ?? "", pattern);
        }

        public void ValidateMark(double value, string subject, ValidationResult result)
        {
            if (value < 0 || value > 100)
                result.Errors.Add($"{subject} marks must be between 0 and 100");
        }
    }
}
