using System;
using System.Threading.Tasks;

namespace RateBox.TestRunner
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Bot.Bot.Run();
        }
    }
}
