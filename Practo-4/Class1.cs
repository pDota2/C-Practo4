using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practo_4
{
    internal class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Note(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
