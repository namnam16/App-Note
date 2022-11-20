using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNote
{
    public class Note
    {
        public string filePath { get; set; }

        public string fileName { get; set; }
        public string content { get; set; }

        public Note()
        {
            this.filePath = string.Empty;
            this.fileName = string.Empty;
            this.content = string.Empty;
        }
        public Note(string filePath, string fileName, string content)
        {
            this.filePath = filePath;
            this.fileName = fileName;
            this.content = content;
        }
    }
}
