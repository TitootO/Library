using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Book
    {
        public Book(string bookname, string autor, short acr, DateTime age, int count)
        {
            BookName = bookname;
            Autor = autor;
            Acr = acr;
            Age = age;
            Count = count;
        }
        public string BookName { get; set; }
        public string Autor { get; set; }
        public short Acr { get; set; }
        public DateTime Age { get; set; }
        public int Count { get; set; }
    }
}
