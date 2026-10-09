namespace Common.Wrappers
{
    public class HttpResponse<T>
    {
        public HttpResponse()
        {
            Succeeded = true;
        }

        public HttpResponse(T result, string message = null)
        {
            Succeeded = true;
            Result = result;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}