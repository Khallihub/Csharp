namespace Blog.Entities

{
    public class Post : BaseEntity
    {
        public int PostId  { get; set; }
        public required string Title  { get; set; } 
        public required string Content   { get; set; }
    }
}