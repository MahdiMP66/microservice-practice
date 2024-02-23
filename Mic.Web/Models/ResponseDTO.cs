namespace Mic.Web.Models
{
    public class ResponseDTO
    {
        public object? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "Successed";
    }
}
