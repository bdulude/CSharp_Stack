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
        // public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int age()
        {
            // return DateTime.Now.Year - this.DateOfBirth.Year;
            if (this.DateOfBirth != null)
            {
                DateTime dob = this.DateOfBirth ?? DateTime.Now;
                return DateTime.Now.Year - dob.Year;
            }
            return -1;
        }

        public List<Dish> CreatedDishes {get; set;}
    }
}