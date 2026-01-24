using System;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    public class Result
    {
        public double physics;
        public double chemistry;
        public double biology;

        public double GetAverage() {
            return (physics + chemistry + biology) / 3;
        }
        public string GetPassOrFail()
        {
            if (GetAverage() >= 80)
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
