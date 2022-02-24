using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get; set;}
        public string Wedder1 {get; set;}
        public string Wedder2 {get; set;}
        public DateTime WeddingDate {get; set;}
        public string Address {get; set;}
        public List<RSVP> RSVPs {get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}