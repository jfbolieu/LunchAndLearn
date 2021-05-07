using People.Data.Entities.Interfaces;
using People.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public class Meeting : IMeeting, IModifyAware, ICannotDelete, IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public DateTime ExpectedEndTime { get; set; }
        public DateTime? ActualEndTime { get; set; }

        [Required]
        public int LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public virtual Location Location { get; set; }

        [Required]
        public int AgentId { get; set; }
        [ForeignKey(nameof(AgentId))]
        public virtual Agent Agent { get; set; }

        [Required]
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; }


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
