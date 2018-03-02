using System.Collections.Generic;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Repositories.Interfaces
{
    public interface IInMemoryCityRepository
    {
        IList<City> GetAll();
        City Single(int id);
        City Single(string name);
    }
}
 