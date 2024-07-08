

using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.SampleDTOs
{
    public class UpdateSampleRequest
    {
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public int? ExampleId { get; set; }
    }
}
