using People.Data.DTO;
using People.Data.Entities.Interfaces;
using People.Data.Enums;
using People.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public class Agent : Person, IAgent, IDeleteAware
    {
        public virtual ICollection<Meeting> Meetings { get; set; }

        public bool Deleted { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        [Required]
        public DateTimeOffset? ModifiedOn { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset CreatedOn { get; set; }
        [Required]
        public Departement Departement { get; set; }

    }
}
