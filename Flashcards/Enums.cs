using System.ComponentModel;

namespace Flashcards;
internal class Enums
{
    public enum MenuOptions
    {
        [Description("Manage Stacks")]
        ManageStacks,
        [Description("Manage Flashcards")]
        ManageFlashcards,
        [Description("Study")]
        Study,
        [Description("View Study Data")]
        ViewStudyData,
        Exit
    }

    public enum StacksMenuOptions
    {
        [Description("View Stacks")]
        ViewStacks,
        [Description("Select a Stack")]
        SelectStack,
        [Description("Add a stack")]
        AddStack,
        //[Description("Change current stack")]
        //ChangeStack,
        //[Description("View All the Flashcards in the current stack")]
        //ViewAllFlashcardsInStack,
        //[Description("Create a new Flashcard in the current stack")]
        //CreateFlashcardInStack,
        //[Description("Edit a Flashcard in the current stack")]
        //EditFlashcard,
        //[Description("Delete a Flashcard in the current stack")]
        //DeleteFlashcard,
        [Description("Delete Stack")]
        DeleteStack,
        [Description("Update Stack")]
        UpdateStack,
        [Description("Return to Main Menu")]
        Return,
        
    }
}
