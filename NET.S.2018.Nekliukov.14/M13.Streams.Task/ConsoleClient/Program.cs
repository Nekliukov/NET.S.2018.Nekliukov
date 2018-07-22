using System;
using System.Configuration;
using static StreamsDemo.StreamsExtension;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "SourceText.txt",
              destination = "OutputText.txt";

            Console.WriteLine($"ByteCopy() done. Total bytes: {ByByteCopy(source, destination)}");
            Console.WriteLine($"InMemoryByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destination)}");
            Console.ReadLine();
            // Console.WriteLine(IsContentEquals(source, destination));

            //etc
        }
    }
}
