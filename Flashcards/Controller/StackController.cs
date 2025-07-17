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
            AnsiConsole.MarkupLine($"{stack.Id} {stack.Name}");
        }

        Console.ReadKey();

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

        CardStack newStack = new(name);

        var affectedRows = _databaseManager.CreateStack(newStack);

        if (affectedRows > 0) Console.WriteLine("it worked");
        else Console.WriteLine("something went wrong");
    }

    internal void DeleteStack()
    {
        ViewStacks();

        Console.WriteLine("Choose the id to delete it");
        int id = Int32.Parse(Console.ReadLine());

        var affectedRows = _databaseManager.DeleteStack(id);

        if (affectedRows > 0) Console.WriteLine("Deleted succesfully");
        else Console.WriteLine("Something went wrong");
    }

    internal void UpdateStack()
    {
        var list = _databaseManager.GetAllStacks();

        var stackToUpdate = AnsiConsole.Prompt(
            new SelectionPrompt<CardStack>()
            .Title("Select a [green]session[/] to update:")
            .UseConverter(cs => cs.Name)
            .AddChoices(list));

        var newName = AnsiConsole.Prompt(
            new TextPrompt<string>("Choose a new name for the stack"));

        var newStack = new CardStack(newName);
        var affectedRows = _databaseManager.UpdateStack(newStack);

        if (affectedRows > 0) Console.WriteLine("Updated succesfully");
        else Console.WriteLine("Something went wrong");
    }
}
