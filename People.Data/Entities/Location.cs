using People.Data.Entities.Interfaces;
using People.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public class Location : ILocation, IDeleteAware, IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string Room { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        [Required]
        [StringLength(6)]
        public string PostalCode { get; set; }
        [MaxLength(500)]
        public string Coordinates { get; set; }
        [Required]
        public bool Deleted { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        [Required]
        public DateTimeOffset? ModifiedOn { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset CreatedOn { get; set; }

    }
}
