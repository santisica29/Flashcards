using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Models
{
    internal class FlashcardDTO
    {
        public int Id { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }

        public FlashcardDTO(int id, string front, string back)
        {
            Id = id;
            Front = front;
            Back = back;
        }
    }
}
