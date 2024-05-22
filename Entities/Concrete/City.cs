using Core.Entities;

namespace Entities.Concrete
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
    }
}
