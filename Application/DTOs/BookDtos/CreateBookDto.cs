namespace Assesment.Application.DTOs.BookDtos
{
    public class CreateBookDto : IBookDto
    {
        public required string title { get; set; }
        public required string author { get; set; }
        public required string genre { get; set; }
        public DateTime dateTime { get; set; }
    }
}
