namespace AppBlog.Utils
{
    public class ResponseResult2<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorCode { get; set; }

        public static ResponseResult2<T> Success(T Data) => new ResponseResult2<T> { IsSuccess = true, Data = Data }; 
        public static ResponseResult2<T> Fail(string code) => new ResponseResult2<T> { IsSuccess = false, ErrorCode = code };
    }
}
