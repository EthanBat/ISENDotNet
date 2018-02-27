using System;
using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class Person : BaseModel
    {
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public DateTime? BirthDate { get;set; }
        public City City { get;set; }

        private string _name;
        public override string Name
        {
            get { return _name ?? $"{FirstName} {LastName}"; }
            set { _name = value; }
        }

        public int? Age => BirthDate.HasValue ?
            (int?)(DateTime.Now - BirthDate.Value).Days / 365 :
            null;

        public override string Display =>
            $"{base.Display}|Age={Age}|City={City}";
    }
}