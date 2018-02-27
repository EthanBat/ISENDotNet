using System;

namespace Isen.DotNet.Library
{
    public class Hello
    {
        //Renvoi des salutations
        public static string Greet(string name)
        {
            string message = "Hello, " + name;
            return message;
        }
    }
}
