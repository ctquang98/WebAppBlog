namespace AppBlog.Models.Domain
{
    public class ResponseResult<T>
    {
        public static ResponseSuccess<T> Success(T Data) => new ResponseSuccess<T>() { IsSuccess = true, Data = Data };

        public static ResponseError Error(string code, string message = "") => new ResponseError() { ErrorCode = code, ErrorMessage = message };
    }
}
