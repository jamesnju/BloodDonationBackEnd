﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonation.Models.Entities
{
    public class DonationCandidate
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? FullName { get; set; }
        public int? Age{ get; set; }
        [Column(TypeName = "nvarchar(3)")]
        public string? BloodGroup { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(100)")]

        public string? Address { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Email { get; set; }
        //public string Message { get; set; }
    }
}
