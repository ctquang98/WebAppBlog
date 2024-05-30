namespace AppBlog.Utils
{
    public class ResponseSuccess<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
    }
}
