using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Services
{
    public class AddDonarDto
    {

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? FullName { get; set; }
        public int? Age { get; set; }
        [Column(TypeName = "nvarchar(3)")]
        public string? BloodGroup { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(100)")]

        public string? Address { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Email { get; set; }
    }
}
