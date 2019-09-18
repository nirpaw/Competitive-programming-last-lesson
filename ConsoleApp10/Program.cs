using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine()); // Not in use
            string line = Console.ReadLine();
            List<string> listStrLineElements = line.Split(' ').ToList();
            List<int> lst = listStrLineElements.Select(int.Parse).ToList();

            int[] arr = lst.ToArray();

            int prevStart = 0,  prevEnd = arr.Length, prevDef = arr.Length, start, end;
            int maxValue = arr.Max();
            int minalue = arr.Min();



            // get the start   
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == minalue)
                {
                    prevStart = i; 
                    break;
                    
                }

            }
            // get the end 
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == maxValue)
                {
                    prevEnd = i;
                    break;

                }

            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == minalue)
                {
                    start = i;
                    if (Math.Abs(start - prevEnd) <= prevDef)
                    {
                        prevDef = Math.Abs(start - prevEnd);
                        prevStart = start;
                    }
                }
                if (arr[i] == maxValue)
                {
                    end = i;
                    if (Math.Abs(end - prevStart) <= prevDef)
                    {
                        prevDef = Math.Abs(end - prevStart);
                        prevEnd = end;
                    }
                }

            }

            Console.WriteLine("Sub array size: " + (prevDef + 1));
            Console.WriteLine("------------------------------------" );

            int a = prevDef, b = minalue, c = maxValue;

            int d = fib(c);

            int e = (b * d) % c;

            int answer = e % a;



            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.WriteLine("c = {0}", c);
            Console.WriteLine("d = {0}", d);
            Console.WriteLine("e = {0}", e);
            Console.WriteLine("answer: e % a = {0}", answer);
            Console.WriteLine("updated array: ");
            lst.Add(answer);
            WriteToConsole(lst);
            Console.WriteLine("\n----------------------------");


             
        }

        public static void WriteToConsole(IEnumerable items)
        {
            foreach (object o in items)
            {
                Console.Write(o);
                Console.Write(" ");
            }
        }


        public static int fib(int index)
        {
            int first = 0, seconed = 1, ans = 0;
            for (int i = 2; i < index; i++)
            {
                ans = first + seconed;
                first = seconed;
                seconed = ans;
            }

            return ans; 
        }
    }
}
