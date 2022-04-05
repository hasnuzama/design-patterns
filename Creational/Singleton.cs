using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    /*
     * Singleton is a creational design pattern, which ensures that only one object of its kind exists and provides a single point of access to it for any other code.
     */

    public sealed class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }


    public class SingletonThreadSafe
    {
        private SingletonThreadSafe() { }

        private static SingletonThreadSafe _instance;

        private static readonly object _lock = new object();

        public string Value { get; set; }

        public static SingletonThreadSafe GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonThreadSafe();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }
    }

    public class Program
    {
        public static void Run()
        {
            Thread t1 = new Thread(() =>
            {
                var obj = SingletonThreadSafe.GetInstance("1");
                Console.WriteLine(obj.Value);
            });
            Thread t2 = new Thread(() =>
            {
                var obj = SingletonThreadSafe.GetInstance("2");
                Console.WriteLine(obj.Value);
            });
            t1.Start();
            t2.Start();
        }
    }
}
