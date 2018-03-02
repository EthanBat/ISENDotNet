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

            //Etat initial des villes
            foreach(var c in cityRepository.GetAll()) Console.WriteLine(c);
            Console.WriteLine("- - - - - - - -");
            // Ajouter une ville
            var cannes = new City { Name = "Cannes" };
            cityRepository.Update(cannes);
            foreach(var c in cityRepository.GetAll()) Console.WriteLine(c);
            Console.WriteLine("- - - - - - - -");
            //Mettre à jour une ville
            var epinal = cityRepository.Single("Epinal");
            if (epinal != null)
            {
            epinal.Name+= " sur mer";
            cityRepository.Update(epinal);
            foreach(var c in cityRepository.GetAll()) Console.WriteLine(c);
            Console.WriteLine("- - - - - - - -");   
            }         
        }
    }
}
