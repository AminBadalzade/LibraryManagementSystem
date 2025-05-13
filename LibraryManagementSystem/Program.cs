using System;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a librarian named Alice
            Librarian librarian = new Librarian("Alice");
            // Add a couple of books to the library's catalog
            librarian.AddBook("The Hobbit", 101, "J.R.R. Tolkien", totalCopies: 2);
            librarian.AddBook("1984", 102, "George Orwell", totalCopies: 1);
            librarian.AddBook("To Kill a Mockingbird", 103, "Harper Lee", totalCopies: 3);
            librarian.AddBook("Pride and Prejudice", 104, "Jane Austen", totalCopies: 2);
            librarian.AddBook("The Great Gatsby", 105, "F. Scott Fitzgerald", totalCopies: 1);

            Console.WriteLine();
            // Register a new member named Bob
            librarian.RegisterMember("Bob");

            Console.WriteLine();
            // Show all books currently available in the library
            librarian.ViewCatalog();

            Console.WriteLine();
            // Create a new member object for Bob
            // (In a real system, we would retrieve the registered member from the librarian’s list)
            Member member = new Member("Bob");

            // Bob borrows "The Hobbit"
            member.Borrow("The Hobbit");

            // Bob also borrows "1984"
            member.Borrow("1984");

            // Bob tries to borrow "The Hobbit" again
            // This should still work if he hasn't hit his borrowing limit
            member.Borrow("The Hobbit");
            member.Borrow("Pride and Prejudice");
            member.Borrow("The Great Gatsby");

            // Print some details about Bob’s current borrowed books
            Console.WriteLine();
            Console.WriteLine("Member details:");
            Console.WriteLine($"Name: {member.name}");
            Console.WriteLine($"Borrowed: {string.Join(", ", member.BorrowedBooks)}");

            Console.WriteLine();
            // Bob returns one copy of "The Hobbit"
            member.Return("The Hobbit");

            // Show the library's catalog again to see updated availability
            Console.WriteLine();
            librarian.ViewCatalog();
        }
    }
}
