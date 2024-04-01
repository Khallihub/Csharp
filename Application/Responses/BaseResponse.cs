namespace Application.Responses
{
    public class BaseResponse
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = String.Empty;

        public List<string>? Errors { get; set; }

    }
}
