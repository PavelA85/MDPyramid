using System;

namespace MDPyramid
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@".\sampleData2.txt");


            var reult = new Pyramid(lines).MySolve();
            Console.WriteLine(reult);
        }
    }
}
