namespace AppBlog.Models.Domain
{
    public class ResponseSuccess<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
    }
}
