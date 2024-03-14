namespace LibraryCatalogue
{
    class Book
    {
        public string Title { get; }
        public string Author;
        public string ISBN;
        public int PublicationYear;

        public Book(string Title, string Author, string ISBN, int PublicationYear)
        {
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
            this.PublicationYear = PublicationYear;
        }
    }
    class MediaItem
    {
        public string Title { get; }
        public string MediaType;
        public int Duration;

        public MediaItem(string Title, string MediaType, int Duration)
        {
            this.Title = Title;
            this.MediaType = MediaType;
            this.Duration = Duration;
        }
    }
    class Library
    {
        string Name;
        string Address;
        List<Book> Books;
        List<MediaItem> MediaItems;

        public Library(string Name, string Address)
        {
            this.Name = Name;
            this.Address = Address;
            Books = new List<Book>();
            MediaItems = new List<MediaItem>();

        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }
        public void AddMediaItem(MediaItem mediaItem)
        {
            MediaItems.Add(mediaItem);
        }
        public void RemoveMediaItem(MediaItem mediaItem)
        {
            MediaItems.Remove(mediaItem);
        }
        public void PrintCatalog()
        {
            Console.WriteLine("List of books");
            foreach (Book book in Books)
            {
                Console.WriteLine($"{book.Title}, {book.Author}, {book.ISBN}, {book.PublicationYear}");
            }
            Console.WriteLine("List of media items");
            for (int i = 0; i < MediaItems.Count; i++)
            {
                Console.WriteLine($"{MediaItems[i].Title}, {MediaItems[i].MediaType}, {MediaItems[i].Duration}");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("To Kill a Mockingbird", "Harper Lee", "978-0446310789", 1960);
            Book book2 = new Book("1984", "George Orwell", "978-0451524935", 1949);
            Book book3 = new Book("Moby Dick", "Herman Melville", "978-1503280786", 1851);

            MediaItem mediaItem1 = new MediaItem("The Godfather", "Movie", 175);
            MediaItem mediaItem2 = new MediaItem("Bohemian Rhapsody", "Song", 6);
            MediaItem mediaItem3 = new MediaItem("Breaking Bad", "TV Show", 3600);
            Library library = new("Abrehot", "4 kilo");

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddMediaItem(mediaItem1);
            library.AddMediaItem(mediaItem2);
            library.AddMediaItem(mediaItem3);

            library.PrintCatalog();

            library.RemoveBook(book1);
            library.RemoveMediaItem(mediaItem1);

            library.PrintCatalog();

        }


    }
}
