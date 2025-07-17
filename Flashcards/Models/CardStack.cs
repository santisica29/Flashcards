namespace Flashcards.Models;
public class CardStack
{
    public int Id { get; set; } = 1;
    public string Name { get; set; }

    public CardStack()
    {
        Id++;
    }
    public CardStack(string name)
    {
        Id++;
        Name = name;
    }
}
