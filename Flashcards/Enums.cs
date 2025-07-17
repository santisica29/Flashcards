using System.ComponentModel;

namespace Flashcards;
internal class Enums
{
    public enum MenuOptions
    {
        [Description("View Stack")]
        ViewStacks,
        [Description("View Flashcards")]
        ViewFlashcards,
        [Description("Study")]
        Study,
        [Description("View Study Data")]
        ViewStudyData,
        Exit
    }
}
