using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class User
    {
        public User(int id, string name, string family, List<short> listbook)
        {
            Id = id;
            Name = name;
            Family = family;
            ListBook = listbook;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public List<short> ListBook { get; set; }
    }
}
