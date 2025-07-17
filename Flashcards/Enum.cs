using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    internal class Enum
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
}
