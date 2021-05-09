using People.Data.Enums;
using People.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

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
        [MaxLength(100)]
        public string MiddleName { get; set; }
        [Required, DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "yyyy-MM-dd")]
        public DateTime BirthDate { get; set; }
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

    }
}
