using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    // Base class for all users (e.g., Member, Librarian)
    public class User
    {
        private static int nextId = 1; // Used to auto-increment user IDs
        public string name { get; set; }
        public int id { get; } 

        public User(string name)
        {
            this.name = name;
            this.id = nextId++; // Assign a unique ID when a user is created
        }
    }

    // Interface for actions that can be performed with books
    public interface Iactions
    {
        public void Borrow(string bookName);
        public void Return(string bookName);
    }

    // MEMBER CLASS: Represents someone who borrows books
    public class Member : User, Iactions
    {
        public int limit = 4; // Max number of books a member can borrow at once
        public List<string> BorrowedBooks = new List<string>(); // Currently borrowed books
        public List<string> BorrowingHistory = new List<string>(); // All-time borrowing history

        public Member(string name) : base(name) { }

        // Borrow a book if under the borrowing limit
        public void Borrow(string bookName)
        {
            if (BorrowedBooks.Count < limit)
            {
                Console.WriteLine($"Book named '{bookName}' was borrowed by user {name} (ID: {id})");
                BorrowedBooks.Add(bookName); // Track current borrow
                BorrowingHistory.Add(bookName); // Track in total history
            }
            else
            {
                Console.WriteLine($"{name} has reached the borrowing limit ({limit}).");
            }
        }

        // Return a borrowed book
        public void Return(string bookName)
        {
            if (BorrowedBooks.Contains(bookName))
            {
                Console.WriteLine($"User {name} returned book called {bookName}");
                BorrowedBooks.Remove(bookName); 
            }
            else
            {
                Console.WriteLine($"'{bookName}' is not currently borrowed by {name}.");
            }
        }
    }

    // LIBRARIAN CLASS: Manages books and members
    public class Librarian : User
    {
        // List to track registered library members
        List<Member> SystemMembers = new List<Member>();

        // List to keep track of books in the library
        List<Book> Books = new List<Book>();

        public Librarian(string name) : base(name) { }

        // Add a new book to the library collection
        public void AddBook(string title, int id, string author, int totalCopies)
        {
            Book newBook = new Book(title, id, author);
            Books.Add(newBook);
            Console.WriteLine($"{title} was added to the library.");
        }

        // Remove a book from the catalog by title
        public void RemoveBook(string title)
        {
            Book bookToRemove = Books.FirstOrDefault(b => b.title == title);
            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
                Console.WriteLine($"'{title}' book was removed by librarian");
            }
            else
            {
                Console.WriteLine($"Book '{title}' not found in library.");
            }
        }

        // Register a new member into the system
        public void RegisterMember(string name)
        {
            Member newMember = new Member(name);
            SystemMembers.Add(newMember);
        }

        // Look up a member’s profile by their ID
        public void ViewMember(int memberID)
        {
            Member viewMember = SystemMembers.FirstOrDefault(b => b.id == memberID);
            if (viewMember != null)
            {
                Console.WriteLine("=== Member Information ===");
                Console.WriteLine($"Name: {viewMember.name}");
                Console.WriteLine($"ID: {viewMember.id}");
                Console.WriteLine($"Borrowing Limit: {viewMember.limit}");
                Console.WriteLine($"Currently Borrowed: {viewMember.BorrowedBooks.Count}");
                Console.WriteLine("Borrowed Books:");
                foreach (var book in viewMember.BorrowedBooks)
                {
                    Console.WriteLine($"  • {book}");
                }
            }
            else
            {
                Console.WriteLine($"Member with ID {memberID} not found.");
            }
        }

        // Display the list of books in the library catalog
        public void ViewCatalog()
        {
            Console.WriteLine("=== Library Catalog ===");
            if (Books.Count == 0)
            {
                Console.WriteLine("No books available in the catalog.");
                return;
            }

            foreach (var book in Books)
            {
                Console.WriteLine($"Title: {book.title}, Author: {book.Author}, ID: {book.itemID}");
            }
        }
    }
}
