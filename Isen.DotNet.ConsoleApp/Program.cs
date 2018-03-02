using System;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.InMemory;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICityRepository cityRepository = 
                new InMemoryCityRepository();
            IPersonRepository personRepository = 
                new InMemoryPersonRepository(cityRepository);
            
            // Toutes les villes
            foreach(var c in cityRepository.GetAll())
                Console.WriteLine(c);
            Console.WriteLine("- - - - - - - -");

            // Toutes les personnes
            foreach(var p in personRepository.GetAll())
                Console.WriteLine(p);
            Console.WriteLine("- - - - - - - -");

            // Toutes les personnes nées après 1970
            var personsBornAfter = personRepository
                .Find(p => 
                    p.BirthDate.HasValue &&
                    p.BirthDate.Value.Year >= 1970);
            foreach(var p in personsBornAfter)
                Console.WriteLine(p);
            Console.WriteLine("- - - - - - - -");

            // Trouver toutes les personnes avec age > 40
            var personsOlderThan = personRepository
                .Find(p =>
                    p.Age.HasValue &&
                    p.Age.Value >= 40);
            foreach(var p in personsOlderThan)
                Console.WriteLine(p);
            Console.WriteLine("- - - - - - - -");

            // Toutes les villes qui contiennent un e
            var citiesWithE = cityRepository
                .Find(c => 
                    // IndexOf : équivalent de Contains()
                    // Mais avec paramètre CurrentCultureIgnoreCase
                    c.Name.IndexOf("e", 
                        StringComparison.CurrentCultureIgnoreCase) >= 0);
            foreach(var c in citiesWithE)
                Console.WriteLine(c);
            Console.WriteLine("- - - - - - - -");

            // Effacer une ville
            var epinal = cityRepository.Single("Epinal");
            cityRepository.Delete(epinal);
            foreach(var c in cityRepository.GetAll())
                Console.WriteLine(c);
            Console.WriteLine("- - - - - - - -");
                        
            /*//Effacer une personne
            personRepository.Delete();
            foreach( var p in personRepository.GetAll())
                Console.WriteLine(p);
                System.Console.WriteLine("- - - - - -");
            */
        }
    }
}
