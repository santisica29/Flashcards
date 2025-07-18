using Flashcards.Controller;
using Spectre.Console;
using static Flashcards.Enums;

namespace Flashcards.View;

public class UserInterface
{
    private readonly StackController _stackController = new();
    internal void MainMenu()
    {
        bool isUserFinished = false;

        while (!isUserFinished)
        {
            Console.Clear();

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("Main Menu")
                .UseConverter(e => Helpers.GetEnumDescription(e))
                .AddChoices(Enum.GetValues<MenuOptions>()));

            switch (choice)
            {
                case MenuOptions.ManageStacks:
                    StacksMenu();
                    break;
                case MenuOptions.ManageFlashcards:
                    FlashcardsMenu();
                    break;
                case MenuOptions.Exit:
                    isUserFinished = true;
                    break;
            }
        }
    }
    internal void FlashcardsMenu()
    {
        throw new NotImplementedException();
    }

    internal void StacksMenu()
    {
        Console.Clear();
        bool userWantsToReturnToMainMenu = false;

        while (!userWantsToReturnToMainMenu)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<StacksMenuOptions>()
                .Title("Stacks Menu")
                .UseConverter(e => Helpers.GetEnumDescription(e))
                .AddChoices(Enum.GetValues<StacksMenuOptions>()));

            switch (choice)
            {
                case StacksMenuOptions.ViewStacks:
                    _stackController.ViewStacks();
                    break;
                case StacksMenuOptions.SelectStack:
                    _stackController.SelectStack();
                    break;
                case StacksMenuOptions.AddStack:
                    _stackController.AddStack();
                    break;
                case StacksMenuOptions.DeleteStack:
                    _stackController.DeleteStack();
                    break;
                case StacksMenuOptions.UpdateStack:
                    _stackController.UpdateStack();
                    break;
                case StacksMenuOptions.Return:
                    userWantsToReturnToMainMenu = true;
                    break;
            }
        }
    }
}