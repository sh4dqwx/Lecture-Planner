namespace DB.Models
{
    public class Hall
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Lecture>? Lectures { get; set;}
    }
}
