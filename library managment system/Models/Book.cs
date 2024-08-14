using System.ComponentModel.DataAnnotations;

namespace library_managment_system.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Image { get; set; }

        [Required]
        public int TotalCopies { get; set; }

        public int  AvailableCopies { get; set; }
    }
}
