using System;
using Isen.DotNet.Library;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           var world = Hello.world;
           Console.WriteLine(world);
           var greet = Hello.Greet("Ethan");
           Console.WriteLine(greet);
           var greetUpper = Hello.GreetUpper("Ethan");
           Console.WriteLine(greetUpper);
        }
    }
}
