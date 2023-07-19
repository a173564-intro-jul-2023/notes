using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    internal class StringCalculator
    {
        public int Add(string numbers)
        {
            //if(numbers.Contains(","))
            //{
                //var seperatorlocation = numbers.IndexOf(",");
                //var lhs = int.Parse(numbers.Substring(0, seperatorlocation));
                //var rhs = int.Parse(numbers.Substring(seperatorlocation + 1));
                //return lhs + rhs;

                //var stringDigits = numbers.Split(',');
                //int sum = 0;
                //foreach(var number in stringDigits)
                //{
                //    sum += int.Parse(number);
                //}
                //return sum;

            //}

            if (numbers == "")
                return 0;
            
            return numbers.Split(',')
                    .Select(int.Parse)
                    .Sum();
        }
    }
}
