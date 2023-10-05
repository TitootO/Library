using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> user = new()
        {
            new User(0, "Варвара", "Степанова", new()),
            new User(1, "Вероника", "Касьянова", new()),
            new User(2, "Мирон", "Чернов", new()),
            new User(3, "Вячеслав", "Туманов", new()),
            new User(3, "Нина", "Чернова", new()),
            new User(3, "Андрей", "Федотов", new()),
        };
        List<Book> book = new(){
            new Book("Мастер и Маргарита", "Михаил Булгаков", 11, new(2005, 05, 05), 20),
            new Book("Война и мир", "Лев Толстой", 12, new(2005, 05, 05), 20),
            new Book("Маленький принц", "Антуан де Сент-Экзюпери", 13, new(2005, 05, 05), 20),
            new Book("Герой нашего времени", "Михаил Лермонтов", 14, new(2005, 05, 05), 20),
        };
        public MainWindow()
        {
            InitializeComponent();
            UsersList.ItemsSource = GetUsers();
            BooksList.ItemsSource = GetBooks();
        }
        List<User> GetUsers(string query = "")
        {
            if (query == "") return user;
            var users = new List<User>();
            foreach (var i in user)
                if (i.Name.Contains(query) || i.Family.Contains(query))
                    users.Add(i);
            return users;
        }
        List<Book> GetBooks(string query = "")
        {
            if (query == "") return book;
            var books = new List<Book>();
            foreach (var i in book)
                if (i.BookName.Contains(query) || i.Autor.Contains(query))
                    books.Add(i);
            return books;
        }
        List<Book> GetUsersBooks(User user)
        {
            if (user == null) return null;
            var books = new List<Book>();
            foreach (var i in user.ListBook)
                foreach (var j in book)
                    if (j.Acr == i)
                    {
                        books.Add(j);
                        break;
                    }
            return books;
        }
        void GiveBook(User usr,Book bok){
            if (usr == null || bok == null || bok.Count == 0) return;
            usr.ListBook.Add(bok.Acr);
            bok.Count--;
        }
        private void UserSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsersList.ItemsSource = GetUsers(UserSearch.Text);
        }
        private void BookSearch_TextChanged(object sender, TextChangedEventArgs e){ 
            BooksList.ItemsSource = GetBooks(BookSearch.Text);}

        private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e){
            BookUsersList.ItemsSource = GetUsersBooks(UsersList.SelectedItem as User); }

        private void Button_Click(object sender, RoutedEventArgs e){
            GiveBook(UsersList.SelectedItem as User, BooksList.SelectedItem as Book);
            BookUsersList.ItemsSource = GetUsersBooks(UsersList.SelectedItem as User);
            BooksList.Items.Refresh();
        }
    }
}
