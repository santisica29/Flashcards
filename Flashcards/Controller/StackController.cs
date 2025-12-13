using Flashcards.Data;
using Flashcards.Models;
using Flashcards.Controller;
using Spectre.Console;

namespace Flashcards.Controller;
internal class StackController
{
    private readonly DatabaseManager _databaseManager = new();
    private readonly FlashcardController flashcardController = new();
    internal void ViewStacks()
    {
        Console.Clear();
        var list = _databaseManager.GetAllStacks();

        if (list.Count == 0)
        {
            AnsiConsole.MarkupLine("No data found.");
            Console.ReadKey();
            return;
        }

        foreach (var stack in list)
        {
            AnsiConsole.MarkupLine($"{stack.Id} {stack.Name}");
        }

        AnsiConsole.MarkupLine("-------------------");
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
        ViewStacks();

        Console.WriteLine("Choose the id to update it");
        int id = Int32.Parse(Console.ReadLine());

        var newName = AnsiConsole.Prompt(
            new TextPrompt<string>("Choose a new name for the stack"));

        var affectedRows = _databaseManager.UpdateStack(id, newName);

        if (affectedRows > 0) Console.WriteLine("Updated succesfully");
        else Console.WriteLine("Something went wrong");
    }

    //internal void SelectStack()
    //{
    //    var stack = ChooseStack("Choose a stack to see it flashcards");

    //    var listOfFlashcards = GetFlashcardsFromStack(stack.Id);

        
    //}

    //internal List<Flashcard> GetFlashcardsFromStack(int stackId)
    //{
    //    var flashcards = DatabaseManager.FetchFlashcardsByStackId(stackId);

    //    return flashcards;
    //}

    internal CardStack ChooseStack(string message, string color = "green")
    {
        var list = _databaseManager.GetAllStacks();

        var stackSelected = AnsiConsole.Prompt(
            new SelectionPrompt<CardStack>()
            .Title($"[{color}] {message}")
            .UseConverter(cs => cs.Name)
            .AddChoices(list));

        return stackSelected;
    }
}
