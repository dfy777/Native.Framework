using System;

namespace Operation
{
    class Program
    {
        public delegate void GreetingDelegate(string name);

        static void CnGreeting(string name)
        {
            Console.WriteLine("你好, " + name);
        }

        static void EnGreeting(string name)
        {
            Console.WriteLine("Hello, " + name);
        }

        static void Greeting(string name, GreetingDelegate greetingDelegate)
        {
            greetingDelegate(name);
        }

        static void Main(string[] args)
        {
            Greeting("啊", CnGreeting);
            Greeting("a", EnGreeting);

        }
    }
}
