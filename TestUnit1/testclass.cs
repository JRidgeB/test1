using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using TestUnit1;
using System.Security.Cryptography.X509Certificates;

namespace TestUnit1
{

    internal class testclass
    {
        static List<Book> books = new List<Book>();
        static List<User> users = new List<User>();
        static Dictionary<User, List<Book>> borrowedBooks = new Dictionary<User, List<Book>>();
        static public string AddBook(string title, string author, string isbn, int bId)
        {

            

            int id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
            books.Add(new Book { Id = id, Title = title, Author = author, ISBN = isbn });
            
                string ret = "Book added successfully!\n";
            return ret;
        }

        static void EditBook()
        {

            ListBooks();
            Console.Write("\nEnter Book ID to Edit: ");

            if (int.TryParse(Console.ReadLine(), out int bookId))
            {

                Book book = books.FirstOrDefault(b => b.Id == bookId);

                if (book != null)
                {
                    Console.Write("Enter new Title (leave blank to keep current): ");
                    string title = Console.ReadLine();
                    if (!string.IsNullOrEmpty(title)) book.Title = title;

                    Console.Write("Enter new Author (leave blank to keep current): ");
                    string author = Console.ReadLine();
                    if (!string.IsNullOrEmpty(author)) book.Author = author;

                    Console.Write("Enter new ISBN (leave blank to keep current): ");
                    string isbn = Console.ReadLine();
                    if (!string.IsNullOrEmpty(isbn)) book.ISBN = isbn;

                    Console.WriteLine("Book updated successfully!\n");
                }
                else
                {
                    Console.WriteLine("Book not found!\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!\n");
            }
        }

        static public string DeleteBook(int bId)
        {

        

        
   
            if (bId == bId)
            {

                Book book = books.FirstOrDefault(b => b.Id == bId);

                if (book != null)
                {
                    books.Remove(book);
                    string ret = "Book deleted successfully!\n";
                    return ret;
                }
                else
                {
                    string ret ="Book not found!\n";
                    return ret;
                }
            }
            else
            {
                string ret = "Invalid input!\n";
                return ret;
            }
        }

        static void ListBooks()
        {

            Console.WriteLine("\nAvailable Books:");

            var bookGroups = books.GroupBy(b => b.Id).Select(bookGroup => new { Book = bookGroup.First(), Count = bookGroup.Count() });

            foreach (var group in bookGroups)
            {
                Console.WriteLine($"{group.Book.Id}. {group.Book.Title} by {group.Book.Author} (ISBN: {group.Book.ISBN}) - Available Copies: {group.Count}");
            }

            Console.WriteLine();
        }
        static public void ReadBooks()
        {
            try
            {
                foreach (var line in File.ReadLines("./Data/Books.csv"))
                {
                    var fields = line.Split(',');

                    if (fields.Length >= 4)
                    {
                        var book = new Book
                        {
                            Id = int.Parse(fields[0].Trim()),
                            Title = fields[1].Trim(),
                            Author = fields[2].Trim(),
                            ISBN = fields[3].Trim()
                        };

                        books.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static public string ReadUsers()
        {
            try
            {
                foreach (var line in File.ReadLines("./Data/Users.csv"))
                {
                    var fields = line.Split(',');

                    if (fields.Length >= 3) // Ensure there are enough fields
                    {
                        var user = new User
                        {
                            Id = int.Parse(fields[0].Trim()),
                            Name = fields[1].Trim(),
                            Email = fields[2].Trim()
                        };

                        users.Add(user);
                    }
                    string retu = "sucess";
                    return retu;
                }
            }
            catch (Exception ex)
            {
                string retu = "An error occurred: {ex.Message}";
                return retu;
            }
            string ret = "error";
            return ret;
        }
        static public User AddUser(string inputOne, string inputTwo, int inputThree)
        {
            Console.Write("\nEnter User Name: ");
            string name = inputOne;

            Console.Write("Enter Email: ");
            string email = inputTwo;

            int id = inputThree;

            User ret = new User { Id = id, Name = name, Email = email };

            Console.WriteLine("User added successfully!\n");
            return ret;
        }

        static public User EditUser(int inputOne, string inputTwo, string inputThree)
        {

            ListUsers();
            Console.Write("\nEnter User ID to Edit: ");



            User user = users.FirstOrDefault(u => u.Id == inputOne);

            if (user != null)
            {
                Console.Write("Enter new Name (leave blank to keep current): ");
                string name = inputTwo;
                if (!string.IsNullOrEmpty(name)) user.Name = name;

                Console.Write("Enter new Email (leave blank to keep current): ");
                string email = inputThree;
                if (!string.IsNullOrEmpty(email)) user.Email = email;

                Console.WriteLine("User updated successfully!\n");
                return user;
            }
            else
            {
                Console.WriteLine("User not found!\n");
                return null;
            }

        }

        static public string DeleteUser(int id)
        {

          
           


            User user = users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                users.Remove(user);
                string ret = "User deleted successfully!";
                return ret;
            }
            else
            {
                string ret = "User not found!";
                return ret;
            }

        }


       

    
        

        static public int ListUsers()
        {

            Console.WriteLine("\nUsers:");

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}. {user.Name} (Email: {user.Email})");
            }

            Console.WriteLine();
            return 0;
        }

        static string BorrowBook(int bId,int  uId)
        {

         
            Console.Write("\nEnter Book ID to Borrow: ");

            if (bId == bId)
            {

                Book book = books.FirstOrDefault(b => b.Id == bId);

                if (book != null && books.Count(b => b.Id == bId) > 0)
                {

                    ListUsers();
                    Console.Write("\nEnter User ID who is borrowing the book: ");

                    if (uId == uId)
                    {

                        User user = users.FirstOrDefault(u => u.Id == uId);

                        if (user != null)
                        {
                            if (!borrowedBooks.ContainsKey(user))
                            {
                                borrowedBooks[user] = new List<Book>();
                            }
                            borrowedBooks[user].Add(book);
                            books.Remove(book);
                            string ret = "Book borrowed successfully!\n";
                            return ret;

                        }
                        else
                        {
                            string ret = "User not found!\n";
                            return ret;
                        }
                    }
                    else
                    {
                        string ret = "Invalid input!\n";
                        return ret;
                    }
                }
                else
                {
                    string ret = "Book not found or no available copies!\n";
                    return ret;
                }
            }
            else
            {
                string ret = "Invalid input!\n";
                return ret;
            }
            string thing = "null";
            return thing;
        }

        static void ReturnBook()
        {

            ListBorrowedBooks();
            Console.Write("\nEnter User ID to return a book for: ");

            if (int.TryParse(Console.ReadLine(), out int userId))
            {

                User user = users.FirstOrDefault(u => u.Id == userId);

                if (user != null && borrowedBooks.ContainsKey(user) && borrowedBooks[user].Count > 0)
                {

                    Console.WriteLine("Borrowed Books:");

                    for (int i = 0; i < borrowedBooks[user].Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {borrowedBooks[user][i].Title} by {borrowedBooks[user][i].Author} (ISBN: {borrowedBooks[user][i].ISBN})");
                    }

                    Console.Write("\nEnter the number of the book to return: ");

                    if (int.TryParse(Console.ReadLine(), out int bookNumber) && bookNumber >= 1 && bookNumber <= borrowedBooks[user].Count)
                    {

                        Book bookToReturn = borrowedBooks[user][bookNumber - 1];

                        borrowedBooks[user].RemoveAt(bookNumber - 1);
                        books.Add(bookToReturn);

                        Console.WriteLine("Book returned successfully!\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!\n");
                    }
                }
                else
                {
                    Console.WriteLine("User not found or no borrowed books!\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!\n");
            }
        }

        static void ListBorrowedBooks()
        {

            Console.WriteLine("\nBorrowed Books:");

            foreach (var entry in borrowedBooks)
            {
                Console.WriteLine($"User: {entry.Key.Name}");

                foreach (var book in entry.Value)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN})");
                }

                Console.WriteLine();
            }
        }
        
    }
}
