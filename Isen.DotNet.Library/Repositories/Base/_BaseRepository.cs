using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Base;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseModel
    {
        // Liste des objets du modèle
        public abstract IQueryable<T> ModelCollection { get; }
        // Méthodes de listes (tout et query)
        public virtual IEnumerable<T> GetAll() => ModelCollection;
        public virtual IEnumerable<T> Find(
            Func<T, bool> predicate)
        {
            var queryable = ModelCollection;
            // filter
            queryable = queryable
                .Where(m => predicate(m));
            return queryable;
        }
        // Méthodes pour renvoyer 1 élément
        public virtual T Single(int id) => 
            ModelCollection.SingleOrDefault(c => c.Id == id);
        public virtual T Single(string name) => 
            ModelCollection.FirstOrDefault(c => c.Name == name);
        // Méthodes de delete
        public virtual void Delete(int id) { }
        public virtual void Delete(T model) => 
            Delete(model.Id);
    }
}