

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.DTOs.ExampleDTOs
{
    public class CreateExampleRequest
    {
        [Required]
        [JsonRequired]
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        [Required]
        [JsonRequired]
        public DateTime DueDate { get; set; }
    }
}
