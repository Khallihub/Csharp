namespace Assessment.Domain
{
    public class Book {
        public int id {get; set;}
        public string title {get; set;} = string.Empty;
        public string author {get; set;} = string.Empty;
        public string genre {get; set;} = string.Empty;
        public DateTime releaseYear;
    }
}

// title, author, genre, release year.