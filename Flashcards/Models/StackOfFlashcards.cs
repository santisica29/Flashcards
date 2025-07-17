namespace Flashcards.Models;
public class StackOfFlashcards
{
    public int Id { get; set; }
    public string Name { get; set; }

    public StackOfFlashcards()
    {

    }
    public StackOfFlashcards(string name)
    {
        Name = name;
    }
}
