using ConsoleApp_PoC.SRC_BaseComponents.SRC_Factory;
using System;

class Program
{
    static async Task Main(string[] args)
    {
        // Display a welcome message
        Console.WriteLine("Welcome to My First Console App!");

        // Ask for the user's name
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        // Greet the user
        Console.WriteLine($"Hello, {name}! Nice to meet you.");

        SRC_OS_Factory src_OS_Factory = new SRC_OS_Factory();
        var systemsType =  src_OS_Factory.SystemsTypeFun(name);
        await systemsType.StartReadingSystemPlugins();

        // Wait for user input before closing
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
