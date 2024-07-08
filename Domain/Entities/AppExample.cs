
namespace Domain.Entities
{
    public class AppExample
    {
        public AppExample()
        {
            samples = new HashSet<AppSample>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //1 Example có nhiều loại
        public ICollection<AppSample> samples { get; set; }
    }
}
