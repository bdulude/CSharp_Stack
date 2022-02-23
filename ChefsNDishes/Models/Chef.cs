using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get; set;}

        [Required(ErrorMessage = "Required")]
        public string FirstName {get; set;}

        [Required(ErrorMessage = "Required")]
        public string LastName {get; set;}

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Dish> createdDishes {get; set;}
    }
}