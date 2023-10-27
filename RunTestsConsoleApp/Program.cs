
using System;
using Common;
using static System.Net.Mime.MediaTypeNames;

namespace RunTestsConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string teamId = "borjafdezgauna";

            Console.WriteLine("## Testing IntList class");
            if (!IntTests.IntListTest(new IntList()))
                return;

            Console.WriteLine("\n\n## Testing ArrayList class");
            if (!IntTests.IntListTest(new IntArrayList(1000000)))
                return;
            
            Console.WriteLine("## Testing GenericList class");
            if (!IntTests.GenericListTest(new GenericList<int>()))
                return;
            
            Console.WriteLine("\n\n## Testing GenericArrayList class");
            if (!IntTests.GenericListTest(new GenericArrayList<int>(1000000)))
                return;
            
            //Console.WriteLine("\n\n## Testing GenericStack class");
            int[] testIntValues = new int[] { 3, 2, 6, 1, 2 };
            
            string[] testStringValues = new string[] { "aB", "0x0", "ro", "123", "hitza" };
            /*
            if (!StackAndQueuesTests.Test(new GenericStack<int>(), testIntValues))
                return;

            if (!StackAndQueuesTests.Test(new GenericStack<string>(), testStringValues))
                return;

            StackAndQueuesTests.MeasurePerformance(new GenericStack<int>(), testIntValues);
            
            */
            Console.WriteLine("\n\n## Testing GenericQueue class");
            if (!StackAndQueuesTests.Test(new GenericQueue<int>(), testIntValues, true))
                return;

            if (!StackAndQueuesTests.Test(new GenericQueue<string>(), testStringValues, true))
                return;

            StackAndQueuesTests.MeasurePerformance(new GenericQueue<int>(), testIntValues);
            
        }
    }
}