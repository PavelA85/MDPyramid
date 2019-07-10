using System;

namespace MDPyramid
{
    public class Program
    {
        public static void Main()
        {
            var lines = System.IO.File.ReadAllLines(@".\sampleData2.txt");

            var reult = new Pyramid(lines).FindPath();
            Console.WriteLine(reult);
        }
    }
}
