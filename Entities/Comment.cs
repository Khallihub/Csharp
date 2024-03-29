namespace Blog.Entities

{
    public class Comment : BaseEntity
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public required string Text { get; set; }
    }
}