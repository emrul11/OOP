using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Basics.Validation
{
    public class ValidationResult
    {        
        public List<string> Errors { get; } = new List<string>();
        public bool IsValid => Errors.Count == 0;
    }
}
