using System;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Models.Implementation;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           var me = new Person()
           {
               FirstName = "Ethan",
               LastName = "Batarsé",
               BirthDate = new DateTime(1995,6,23),
               City = new City { Name = "Toulon" },
           };
           Console.WriteLine(me);
        }
    }
}
