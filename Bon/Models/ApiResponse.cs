using Azure;

namespace BonAPI.Models
{
    public class ApiResponse 
    {
        public object? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
