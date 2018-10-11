using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        private String title;
        private String author;
        private int id;

        public Book (String title, String author, int id)
        {
            this.title = title;
            this.author = author;
            this.id = id;
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
