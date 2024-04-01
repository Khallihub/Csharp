namespace Assesment.Application.DTOs.BookDtos
{
    public interface IBookDto
    {
        //    (title, author, genre, release year.).
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public DateTime dateTime { get; set; }
    }
}
