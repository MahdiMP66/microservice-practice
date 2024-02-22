using System.ComponentModel.DataAnnotations;

namespace BonAPI.Models
{
    public class Bon
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(1000,9999)]
        public int Code { get; set; }
        [Required]
        [Range(0, 100)]
        public double Off { get; set; }
        public DateTime Created { get; set; }
    }
}
