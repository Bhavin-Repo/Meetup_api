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
        [Required(ErrorMessage ="Missing Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Missing DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Missing Locality")]
        public string Locality { get; set; }

        [Required(ErrorMessage = "Missing NumberOfGuest")]
        public int NumberOfGuest { get; set; }

        [Required(ErrorMessage = "Missing Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Missing ProfessionId")]
        public int ProfessionId { get; set; }

        [ForeignKey("ProfessionId")]
        public Profession Profession { get; set; }

    }
}
