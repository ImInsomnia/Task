using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
