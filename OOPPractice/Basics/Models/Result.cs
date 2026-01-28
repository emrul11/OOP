using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Models
{
    public class Result
    {
        public double physics;
        public double chemistry;
        public double biology;

        int numberOfSubjects = 3;
        int passingAverage = 80;
        public double GetAverage() {
            return (physics + chemistry + biology) / numberOfSubjects;
        }
        public string GetPassOrFail()
        {
            if (GetAverage() >= passingAverage)
            {
                return "Pass";
            }
            else
            {
                return "Fail";
            }
        }
    }
}
