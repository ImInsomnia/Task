namespace Core.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Deleted { get; set; }
    }
}
