using People.Data.Entities.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace People.Data.Entities
{
    public class Province : IDimension, IReadonlyEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
