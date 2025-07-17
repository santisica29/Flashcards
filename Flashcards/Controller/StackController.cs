using Flashcards.Data;
using Flashcards.Models;
using Spectre.Console;

namespace Flashcards.Controller;
internal class StackController
{
    private readonly DatabaseManager _databaseManager = new();
    internal void ViewStacks()
    {
        var list = _databaseManager.GetAllStacks();

        if (list.Count == 0)
        {
            AnsiConsole.MarkupLine("No data found.");
        }

        foreach (var stack in list)
        {
            AnsiConsole.MarkupLine($"{stack}");
        }
    }

    internal void AddStack()
    {
        Console.WriteLine("Enter the name of the new stack");
        var name = Console.ReadLine();

        while (String.IsNullOrEmpty(name))
        {
            Console.WriteLine("Enter the name of the new stack");
            name = Console.ReadLine();
        }

        StackOfFlashcards newStack = new(name);

        var affectedRows = _databaseManager.CreateStack(newStack);

        if (affectedRows > 0) Console.WriteLine("it worked");
        else Console.WriteLine("something went wrong");
    }
}
