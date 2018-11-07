﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Client
    {
        private int id;
        private String firstName;
        private String lastName;
        private List<Book> books = new List<Book>();

        public Client(String firstName, String lastName, int id)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int GetId()
        {
            return this.id;
        }

        public void SetId(int id)
        {
            this.id = id; 
        }

        public String GetName()
        {
            return this.firstName + ' ' + this.lastName;
        }

        public String GetFirstName()
        {
            return this.firstName;
        }

        public void setFirstName(String firstName)
        {
            this.firstName = firstName;
        }

        public String GetLastName()
        {
            return  this.lastName;
        }

        public void setLastName(String lastName)
        {
            this.lastName = lastName;
        }

        public void AddBook(Book newBook)
        {
            books.Add(newBook);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public int GetAmountOfBooks()
        {
            return books.Count;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public void Update(Client updatedClient)
        {
            this.id = updatedClient.GetId();
            this.firstName = updatedClient.GetFirstName();
            this.lastName = updatedClient.GetLastName();
            this.books = updatedClient.GetAllBooks();
        }
    }
}
