using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Book
    {
        private String title;
        private String author;

        public Book (String title, String author)
        {
            this.title = title;
            this.author = author;
        }

        public String getTitle()
        {
            return this.title;
        }

        public String getAuthor()
        {
            return this.author;
        }
    }
}
