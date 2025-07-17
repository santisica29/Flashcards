using Spectre.Console;
using static Flashcards.Enums;

namespace Flashcards.View;

public class UserInterface
{
    internal void MainMenu()
    {
        bool isUserFinished = false;

        while (!isUserFinished)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("Main Menu")
                .UseConverter(e => Helpers.GetEnumDescription(e))
                .AddChoices(Enum.GetValues<MenuOptions>()));

            switch (choice)
            {
                case MenuOptions.Exit:
                    isUserFinished = true;
                    break;
                case MenuOptions.ViewStacks:
                    StacksMenu();
                    break;
                case MenuOptions.ViewFlashcards:
                    FlashcardsMenu();
                    break;

            }
            ;
            var answer = choice switch
            {
                MenuOptions.Exit => 
                MenuOptions.ViewStacks => StacksMenu(),
                MenuOptions.ViewFlashcards => FlashcardsMenu(),
                MenuOptions.Study => throw new NotImplementedException(),
                MenuOptions.ViewStudyData => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };

        }

    }
    internal void FlashcardsMenu()
    {
        throw new NotImplementedException();
    }

    internal void StacksMenu()
    {
        
    }
}