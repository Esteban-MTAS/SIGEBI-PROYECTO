namespace SIGEBI.Domain.Base
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static OperationResult<T> Ok(T data, string message = "")
        {
            return new OperationResult<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static OperationResult<T> Fail(string message)
        {
            return new OperationResult<T>
            {
                Success = false,
                Data = default,
                Message = message
            };
        }
    }
}