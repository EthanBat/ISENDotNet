namespace Isen.DotNet.Library.Models.Base
{
    public abstract class BaseModel
    {
        public int Id { get;set; }
        public virtual string Name { get;set; }

        public virtual string Display =>
            $"[Id={Id}]|{Name}";

        public override string ToString() => Display; 

        public bool IsNew => Id <= 0;
        /*public bool IsNew2
        {
            get { return Id <= 0; }
        }
        */
    }
}