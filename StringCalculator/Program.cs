using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Program
    {
        public static int Add(string numbers)
        {
            // if empty string, we done
            if (numbers == "")
            {
                return 0;
            }

            // build a separator list
            List<string> separatorList = new List<string>();
            separatorList.Add(",");
            separatorList.Add("\n");

            // if - operator included any new delimiters, then extract them and then split the string apart
            // else - just split the string apart
            List<string> splitString = new List<string>();
            if (numbers.Substring(0,2) == "//")
            {
                int k = numbers.IndexOf('\n');

                string delimiters = numbers.Substring(2, k - 2);
                string[] newdelimiters = delimiters.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string nd in newdelimiters)
                {
                    separatorList.Add(nd);
                }

                string cutnumbers = numbers.Substring(k, numbers.Length - k); 
                splitString = cutnumbers.Split(separatorList.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            else
            {
                splitString = numbers.Split(separatorList.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            // loop through all of the numbers
            //      if - any are negative, add to a separate list (throw exception later, so we can display all negatives)
            //      else - add integer to sum but discard integer if greater than 1000
            int sum = 0;
            List<int> negs = new List<int>();
            foreach(string s in splitString)
            {
                int x = Convert.ToInt32(s);

                if (x < 0)
                {
                    negs.Add(x);
                }
                else
                {
                    if (x <= 1000)
                    {
                        sum += x;
                    }
                }
            }

            // if we found any negatives, then build an exception message and throw the exception
            if (negs.Count > 0)
            {
                string joinednegs = string.Join(",", negs);
                string exmessage = "negatives not allowed: " + joinednegs;
                throw new Exception(exmessage);
            }

            // done
            return sum;
        }

        static void Main(string[] args)
        {
            // test an input string here
            int sum = Add("//[;][***][%]" + '\n' + "1,2;3" + '\n' + "4,5,1000, 1001%5***2");

            Console.WriteLine("The sum is: {0}", sum);
            Console.ReadLine();
        }
    }
}
