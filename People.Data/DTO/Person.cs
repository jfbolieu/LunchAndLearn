using People.Data.Entities.Interfaces;
using People.Data.Enums;
using People.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace People.Data.DTO
{
    public abstract class Person : IPerson, IEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [MaxLength(1)]
        public string Initial { get; set; }
        [Required, DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "yyyy-MM-dd")]
        public DateTime BirthDate { get; set; }
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        [NotMapped]
        public string Fullname { get => string.Join(" ", new[] { FirstName, Initial, LastName }.Where(x => !string.IsNullOrWhiteSpace(x))); }

    }
}
