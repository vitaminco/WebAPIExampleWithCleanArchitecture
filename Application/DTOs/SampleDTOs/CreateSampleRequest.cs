

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.DTOs.SampleDTOs
{
    public class CreateSampleRequest
    {
        [Required]
        [JsonRequired]
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int ExampleId { get; set; }
    }
}
