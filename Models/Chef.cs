using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }


        [NotMapped]
        public int Age
        {
            get
            {
                int age = 0;
                age = DateTime.Now.Year - Birthday.Year;
                if (DateTime.Now.DayOfYear < Birthday.DayOfYear)
                    age = age - 1;

                return age;
            }
        }


        public List<Dish> CreatedDishes { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}