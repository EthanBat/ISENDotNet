using System;

namespace Isen.DotNet.Library
{
    public class Hello
    {
        /* 
        private static string _world = "Hello, World";
        public static string World 
        {
            get { return _world; }
            set { _world = value; }
        }*/

       public static string World { get; set; }
            = "Hello, World";

        //Renvoi des salutations
        public static string Greet(string name)
        {
            var time = DateTime.Now.ToString("HH:mm");
            var message = $"Hello {name} it is {time}.";
            //var message = "Hello, " + name + " it is " + time + ".";
            //var old Message = String.Format("Hello {0} it is {1}.", name, time);
            return message;
        }

        public static string GreetUpper(string name)
            => Greet(name.ToUpper());
    }
}
