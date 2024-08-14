﻿using System.ComponentModel.DataAnnotations;

namespace library_managment_system.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
