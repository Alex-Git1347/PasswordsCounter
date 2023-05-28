using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestCounter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Input path of file:");
            var path = Console.ReadLine();

            ValidPasswordsCounter counter = new ValidPasswordsCounter();
            var count = await counter.CountValidPasswords(path);

            Console.WriteLine("Count valid passwords:" + count);
            Console.ReadKey();
        }
    }
}
