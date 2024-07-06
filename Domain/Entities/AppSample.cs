

namespace Domain.Entities
{
    public class AppSample
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ExampleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // 1 loại đơn giản thuộc 1 ví dụ
        public AppExample AppExample { get; set; }
    }
}
