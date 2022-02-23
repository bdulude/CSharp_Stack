using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get; set;}

        [Required(ErrorMessage = "Required")]
        public string Name {get; set;}

        
        [Required(ErrorMessage = "Required")]
        [NotMapped]
        public int ChefId {get; set;}
        public Chef Chef {get; set;}

        [Required(ErrorMessage = "Required")]
        [Range(1, 5)]
        public int Tastiness {get; set;}

        [Required(ErrorMessage = "Required")]
        [Range(0, 50000)]
        public int Calories {get; set;}

        [Required(ErrorMessage = "Required")]
        public string Description {get; set;}
        

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}