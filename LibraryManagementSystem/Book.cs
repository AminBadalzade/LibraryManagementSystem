using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    // Base class for all library items (like books)
    public abstract class LibraryItem
    {
        public string title { get; set; }  
        public int itemID { get; set; }   

        public LibraryItem(string title, int itemID)
        {
            this.title = title;
            this.itemID = itemID;
        }
        public abstract void CheckOut();   
        public abstract void Return();    
    }

  
    public class Book : LibraryItem
    {
        public string Author { get; set; }          
        public int TotalCopies { get; set; }        
        public int AvailableCopies { get; set; }     

        // Constructor to initialize a new book with title, itemID, author, and total copies
        public Book(string title, int itemID, string author, int totalCopies = 1) : base(title, itemID)
        {
            Author = author;
            TotalCopies = totalCopies;
            AvailableCopies = totalCopies;  // Initially, all copies are available
        }

        // Method to check out the book. Reduces the available copies if there are any.
        public override void CheckOut()
        {
            // If there are available copies, decrease the count
            if (AvailableCopies > 0)
            {
                AvailableCopies--;
                Console.WriteLine($"Book '{title}' checked out. Available copies: {AvailableCopies}");
            }
            else
            {
                Console.WriteLine($"No available copies of '{title}'.");
            }
        }

        // Method to return a book. Increases the available copies if the total number of copies allows it.
        public override void Return()
        {
            // If there are copies checked out, we can increase the available copies
            if (AvailableCopies < TotalCopies)
            {
                AvailableCopies++;
                Console.WriteLine($"Book '{title}' returned. Available copies: {AvailableCopies}");
            }
            else
            {
                // If all copies are already in the library, inform the user
                Console.WriteLine($"All copies of '{title}' are already in the library.");
            }
        }
    }
}
