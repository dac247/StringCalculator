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

            List<string> separatorList = new List<string>();
            separatorList.Add(",");
            separatorList.Add("\n");

            List<string> splitString = new List<string>();
            if (numbers.Substring(0,2) == "//")
            {
                int k = numbers.IndexOf('\n');

                separatorList.Add(numbers.Substring(2, k - 2));

                string cutnumbers = numbers.Substring(k, numbers.Length - k); 
                splitString = cutnumbers.Split(separatorList.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            else
            {
                splitString = numbers.Split(separatorList.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            int sum = 0;
            foreach(string s in splitString)
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
