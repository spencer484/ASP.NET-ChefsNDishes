using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        public string DishName { get; set; }

        [Required]
        [Range(1, 2000)]
        public int Calories { get; set; }

        [Required]
        [Range(1, 5)]
        public int Tastiness { get; set; }

        [Required]
        public string Description { get; set; }

        public int ChefId { get; set; }

        public Chef Chef { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}