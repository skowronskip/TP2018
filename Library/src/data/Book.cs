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
        private Client client;

        public Book (String title, String author, int id)
        {
            this.title = title;
            this.author = author;
            this.id = id;
        }

        public String GetTitle()
        {
            return this.title;
        }

        public String GetAuthor()
        {
            return this.author;
        }

        public int GetId()
        {
            return this.id;
        }

        public Client GetClient()
        {
            return this.client;
        }

        public void SetClient(Client client)
        {
            this.client = client;
        }
    }
}
