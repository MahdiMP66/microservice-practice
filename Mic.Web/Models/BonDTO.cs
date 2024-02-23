using System.ComponentModel.DataAnnotations;

namespace BonAPI.Models.DTOs
{
    public class BonDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(1000, 9999)]
        public string Code { get; set; } = string.Empty;
        [Required]
        [Range(0, 100)]
        public double Off { get; set; }
    }
}
