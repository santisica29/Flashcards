using Flashcards.Data;
using Flashcards.Models;
using Spectre.Console;

namespace Flashcards.Controller;
internal class FlashcardController
{
    private readonly DatabaseManager _databaseManager = new();

    internal void AddFlashcard()
    {
        throw new NotImplementedException();
    }

    //internal List<FlashcardDTO> GetFlashcardsFromStack(CardStack stack)
    //{

    //}
    internal void ViewFlashcards()
    {
        Console.Clear();
        var list = _databaseManager.GetFlashcards();

        if (list.Count == 0)
        {
            AnsiConsole.MarkupLine("No data found.");
            Console.ReadKey();
            return;
        }

        foreach (var flashcard in list)
        {
            AnsiConsole.MarkupLine($"{flashcard.Id} {flashcard.Front} {flashcard.Back}");
        }

        AnsiConsole.MarkupLine("-------------------");
        Console.ReadKey();
    }
}
