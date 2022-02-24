using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get; set;}
        public int CreatorId {get; set;}
        [Required]
        public string Wedder1 {get; set;}
        [Required]
        public string Wedder2 {get; set;}
        [Required]
        [Display(Name = "Wedding Date")]
        public DateTime WeddingDate {get; set;}
        [Required]
        public string Address {get; set;}
        public List<RSVP> RSVPs {get; set;}
        public User Creator {get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}