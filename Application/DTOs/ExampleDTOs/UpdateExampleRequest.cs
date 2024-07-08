﻿

using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ExampleDTOs
{
    public class UpdateExampleRequest
    {
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}
