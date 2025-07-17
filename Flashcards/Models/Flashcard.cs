using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Models
{
    internal class Flashcard
    {
        public int Id { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public int StackId { get; set; }

        public Flashcard(int id, string front, string back, int stackID) 
        {
            Id = id;
            Front = front;
            Back = back;
            StackId = stackID;
        }
    }
}
