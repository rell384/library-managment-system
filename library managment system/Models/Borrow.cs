using System.ComponentModel.DataAnnotations;

namespace library_managment_system.Models
{
    public class Borrow
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int PersonId { get; set; }

        public DateTime BorrowDate { get; set; } = DateTime.Now;

        public DateTime? ReturnDate { get; set; }
    }
}
