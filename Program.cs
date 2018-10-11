using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Book test = new Book("Autobiografia Andrzeja Goloty", "Andrzej Golota");
            Console.WriteLine(test.getTitle());
            Console.WriteLine(test.getAuthor());


            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
