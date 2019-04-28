using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book()
            {
                Isbn = "1234",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };

            book.ShowBook();
            CareTaker history=new CareTaker();
            history.memento = book.CreateUndo();

            book.Author = "VICTOR HUGO";
            book.Isbn = "54321";
            book.ShowBook();

            book.RestoreFromUndo(history.memento);
            book.ShowBook();
            Console.ReadLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _lastEdited;

        public string Title
        {
            get => _title; //değeri okuma
            set
            {
                _title = value;
                SetLastEdited();
            } //değeri yazma. nesne burada değişiyor.
        }

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                SetLastEdited();
            }
        }

        public string Isbn
        {
            get => _isbn;
            set
            {
                _isbn = value; 
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo() //desenden geliyor
        {
            return new Memento(_title,_author,_isbn,_lastEdited);
        }

        public void RestoreFromUndo(Memento memento) //desenden geliyor
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;

        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2} edited at: {3}",Title,Author,Isbn,_lastEdited);
        }


    }
    class Memento //desenden geliyor
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string title, string author, string isbn, DateTime lastEdited)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            LastEdited = lastEdited;
        }
    }

    class CareTaker //desenden geliyor
    {
        public Memento memento { get; set; }
    }
}
