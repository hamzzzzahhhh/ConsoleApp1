//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace container
//{
//    public class Program
//    {
//        public interface IBookOperation
//        {
//            //interfaces dont provide function implementations
//            void AddBook(List<Book> books, Book book);
//            void RemoveBook(List<Book> books, int id);
//        }

//        public class BookOperation : IBookOperation
//        {
//            public void AddBook(List<Book> books, Book book)
//            {
//                books.Add(book);
//                Console.WriteLine("adding book successful");
//                Console.WriteLine("---------------------");
//            }
//            public void RemoveBook(List<Book> books, int id)
//            {
//                if(books.Count > 0)
//                {
//                    foreach (Book book in books)
//                    {
//                        if (book.ID == id)
//                        {
//                            books.Remove(book);
//                            Console.WriteLine("Removing book successfull");
//                            Console.WriteLine("---------------------");
//                            return;
//                        }
//                    }
//                }
//            }
//        }

//        //an interface object, that can change type, implementing dependency injection.
//        public interface IStaff
//        {
//            void Speak();
//            void Run();
//        }

//        public interface IHuman
//        {
//            void Speak();

//            void Run();
//        }

//        public class Staff : IStaff, IHuman
//        {
//            public string name;
//            public string id;

//            public Staff(string name, string id)
//            {
//                this.name = name;
//                this.id = id;
//            }

//            public virtual void Speak()
//            {
//                Console.WriteLine("Default Speaking");
//            }

//            public void Run()
//            {
//                Console.WriteLine("IStaff Running");
//            }

//            //void IStaff.Run()                       //if same method in 2 interfaces which are implemented by a class, then we can either write one function in implementing class which acts for both interfaces otherwsie write interface name dot function name to specify which interface's method is being called
//            //{
//            //    Console.WriteLine("IStaff Running");
//            //}

//            //void IHuman.Run()
//            //{
//            //    Console.WriteLine("IHuman Running");
//            //}
//        }

//        public class Librarian : Staff
//        {
//            public Librarian(string name, string id) : base(name, id) { }
//            public override void Speak()
//            {
//                Console.WriteLine($"My name is {name} and I'm the Librarian");
//            }
//        }
//        public class Cleaner : Staff
//        {
//            public Cleaner(string name, string id) : base(name, id) { }
//            public override void Speak()
//            {
//                Console.WriteLine($"My name is {name} and I'm the Cleaner");
//            }
//        }
//        public class Owner : Staff
//        {
//            public Owner(string name, string id) : base(name, id) { }
//            public override void Speak()
//            {
//                Console.WriteLine($"My name is {name} and I'm the Owner");
//            }
//        }

//        public class Library
//        {
//            //protected BookOperation bookops;
//            protected IBookOperation operations;
//            protected int libraryid;
//            protected string name;
//            public List<Book> books;
//            private readonly List<IStaff> staffmembers;

//            public Library(IBookOperation bookops, int libraryid, string name, IStaff member)
//            {
//                this.operations = bookops;
//                this.libraryid = libraryid;
//                this.name = name;
//                this.books = new List<Book>();
//                this.staffmembers = new List<IStaff>();
//                this.staffmembers.Add(member);
//            }

//            public void AddBooks(Book book)
//            {
//                operations.AddBook(books, book);
//            }

//            public void RemoveBooks(int id)
//            {
//                operations.RemoveBook(books, id);
//            }

//            public void AddMember(IStaff member)
//            {
//                staffmembers.Add(member);
//            }

//            public void DisplayStaffMembers()
//            {
//                foreach(IStaff temp in staffmembers)
//                {
//                    if(temp is Staff)
//                    {
//                        temp.Run();
//                    }
//                    else if(!(temp is Owner))
//                    {
//                        temp.Speak();
//                    }
//                }
//            }

//            public void DisplayInfo()
//            {
//                DisplayOwner();
//                Console.WriteLine("---------------------");
//                DisplayBooks();
//                Console.WriteLine("----------------------");
//                DisplayStaffMembers();
//                Console.WriteLine("----------------------");
//            }

//            public void DisplayOwner()
//            {
//                foreach(Staff temp in staffmembers)
//                {
//                    if(temp is Owner)
//                    {
//                        temp.Speak();
//                    }
//                }
//            }
//            public void DisplayBooks()
//            {
//                foreach(Book book in books)
//                {
//                    Console.WriteLine(book.ID);
//                    Console.WriteLine(book.name);
//                    Console.WriteLine(book.author);
//                }
//            }
//        }

//        public abstract class Book
//        {

//            public int id;
//            public int ID  //c# properties
//            {
//                get { return id; }
//            }

//            //protected string name;

//            protected string temp //Automatic Properties -> in this case gettter setters are useless becuase inside functions of automatic properties are more restrictive. Hence here getters setters are more restrictive instead of being public so this code is useless.
//            {
//                get; set;
//            }

//            public string name
//            {
//                get; set;
//            }

//            public string author
//            {
//                get; set;
//            }

//            public abstract void UpdateBook(int id, string name, string author); //abstract methods have no body, must to implement in derived class

//            public virtual void CheckingVirtualMethods()
//            {
//                //Console.WriteLine("virtual parent");
//            }
//        }

//        public class HorrorBook : Book
//        {
//            public HorrorBook(int id, string name, string author)
//            {
//                this.id = id;
//                this.name = name;
//                this.author = author;
//            }
//            public override void UpdateBook(int id, string name, string author)
//            {
//                this.id = id;
//                this.name = name;
//                this.author = author;
//            }

//            //public int GetID(){ return this.id; }
//            public string GetName() { return this.name; }
//            public string GetAuthor() {  return this.author; }

//            public override void CheckingVirtualMethods()
//            {
//                base.CheckingVirtualMethods();
//                //Console.WriteLine("overridden derived class");
//            }
//        }

//        public static void Main(string[] args)
//        {
//            Library StallionsLibrary = new Library(new BookOperation(), 1,"StallionsLibrary", new Owner("Mr. Ahmad", "1"));
//            HorrorBook horrorbook1 = new HorrorBook(100, "13b", "unknown");

//            horrorbook1.CheckingVirtualMethods();

//            //StallionsLibrary.AddBooks(horrorbook1);

//            //StallionsLibrary.DisplayInfo();

//            Console.BackgroundColor = ConsoleColor.Black;
//            Console.Clear();
//            Console.ForegroundColor = ConsoleColor.Cyan;
//;
//            Console.WriteLine("-------------------------------------Welcome to Stallions Library Management-------------------------------------------");

//            while(true)
//            {
//                Console.WriteLine("Click 1 to add a book to the library");
//                Console.WriteLine("Click 2 to remove a book from the library");
//                Console.WriteLine("Click 3 to display books of library");
//                Console.WriteLine("Click 4 to display Owner");
//                Console.WriteLine("Click 5 to display All information of Stallions Library");
//                Console.WriteLine("Click 6 to add staff member");
//                Console.WriteLine("Click X to exit the system...");
//                Console.WriteLine("---------------------");

//                string input = Console.ReadLine();

//                if (input == "X")
//                {
//                    return;
//                }

//                int choice;

//                Int32.TryParse(input, out choice);

//                if (choice == 1)
//                {
//                    Console.WriteLine("Enter ID of book");
//                    string id = Console.ReadLine();
//                    int _id;
//                    Int32.TryParse(id, out _id);

//                    Console.WriteLine("Enter Name of book");
//                    string name = Console.ReadLine();

//                    Console.WriteLine("Enter Author of book");
//                    string author = Console.ReadLine();

//                    HorrorBook temp = new HorrorBook(_id, name, author);

//                    StallionsLibrary.AddBooks(temp);
//                }

//                if (choice == 2)
//                {
//                    Console.WriteLine("Enter ID of book");
//                    string id = Console.ReadLine();
//                    int _id;
//                    Int32.TryParse(id, out _id);

//                    StallionsLibrary.RemoveBooks(_id);
//                }

//                if (choice == 3)
//                {
//                    StallionsLibrary.DisplayBooks();
//                }

//                if (choice == 4)
//                {
//                    StallionsLibrary.DisplayOwner();
//                }

//                if (choice == 5)
//                {
//                    StallionsLibrary.DisplayInfo();
//                }

//                if (choice == 6)
//                {
//                    Console.WriteLine("Owner is set by default.However you can add a Librarian or Cleaner or Default Staff ");

//                    Console.WriteLine("What is the type of Staff member you want to add");

//                    string input1 = Console.ReadLine();

//                    if(input1 == "Librarian")
//                    {
//                        Console.WriteLine("Enter name");
//                        string input2 = Console.ReadLine();
//                        Console.WriteLine("Enter id");
//                        string input3 = Console.ReadLine();
//                        IStaff librarian = new Librarian(input2, input3);
//                        StallionsLibrary.AddMember(librarian);
//                    }
//                    if (input1 == "Cleaner")
//                    {
//                        Console.WriteLine("Enter name");
//                        string input2 = Console.ReadLine();
//                        Console.WriteLine("Enter id");
//                        string input3 = Console.ReadLine();
//                        IStaff Cleaner = new Cleaner(input2, input3);
//                        StallionsLibrary.AddMember(Cleaner);
//                    }
//                    if (input1 == "Default Staff")
//                    {
//                        Console.WriteLine("Enter name");
//                        string input2 = Console.ReadLine();
//                        Console.WriteLine("Enter id");
//                        string input3 = Console.ReadLine();
//                        IStaff Staff = new Staff(input2, input3);
//                        StallionsLibrary.AddMember(Staff);
//                    }
//                }
//            }
//        }          
//    }
//}

using System;

namespace container
{
    class Program
    {
        static void Main(string[] args)
        {
            // Existing code (if any)
            //Console.WriteLine("Existing code execution.");

            // Create an instance of DBConnection and call ConnectToDatabase
            //DBConnection1 dbConnection = new DBConnection1();
            //dbConnection.ConnectToDatabaseToGetData();

            //dbConnection.ConnectToDatabaseToPostData();

            //DBConnectionDeleteData dbConnection = new DBConnectionDeleteData();
            //dbConnection.DeleteData();
            
            DBConnectionPutData dBConnection = new DBConnectionPutData();
            dBConnection.PutData();

            Console.WriteLine("Press X to terminate system...");
            Console.ReadLine();
        }
    }
}
