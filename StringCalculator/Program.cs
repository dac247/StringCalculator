using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    class Program
    {
        static int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }

            string[] test = numbers.Split(',');

            int sum = 0;
            foreach(string s in test)
            {
                sum += Convert.ToInt32(s);
            }

            return sum;
        }

        static void Main(string[] args)
        {
            var numberString = Convert.ToString(Console.ReadLine());
            int sum = Add(numberString);

            Console.WriteLine("The sum is: {0}", sum);
            Console.ReadLine();
        }
    }
}
