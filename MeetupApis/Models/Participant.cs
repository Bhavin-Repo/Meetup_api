using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetupApis.Models
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Locality { get; set; }

        [Required]
        public int NumberOfGuest { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public int ProfessionId { get; set; }

        [ForeignKey("ProfessionId")]
        public Profession Profession { get; set; }

    }
}
