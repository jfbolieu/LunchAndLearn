using People.Data.DTO;
using People.Data.Entities.Interfaces;
using People.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public class Client : Person, IClient, IDeleteAware
    {

        [Required]
        public string Code { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Since { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool Deleted { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        [Required]
        public DateTimeOffset? ModifiedOn { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset CreatedOn { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }
 
    }
}
