using library_managment_system.Models;

namespace library_managment_system.Repository
{
    public class BorrowRepo : IBorrow
    {
        private readonly Context _context;

        public BorrowRepo(Context context)
        {
            _context = context;
        }

        public void BorrowBook(string code, string bookName)
        {
            var person = _context.People.SingleOrDefault(p => p.Code == code);
            var book = _context.Books.SingleOrDefault(b => b.Name == bookName);

            if (person == null || book == null)
            {
                throw new InvalidOperationException("Invalid Person Code or Book Name.");
            }

            if (book.AvailableCopies <= 0)
            {
                throw new InvalidOperationException("This book copy is not available right now.");
            }

            book.AvailableCopies--;
            var borrow = new Borrow { BookId = book.Id, PersonId = person.Id };
            _context.Borrows.Add(borrow);
            _context.SaveChanges();
        }

        public void ReturnBook(string code, string bookName)
        {
            var person = _context.People.SingleOrDefault(p => p.Code == code);
            var book = _context.Books.SingleOrDefault(b => b.Name == bookName);

            if (person == null || book == null)
            {
                throw new InvalidOperationException("Invalid Person Code or Book Name.");
            }

            var borrow = _context.Borrows.SingleOrDefault(b => b.BookId == book.Id && b.PersonId == person.Id && b.ReturnDate == null);

            if (borrow == null)
            {
                throw new InvalidOperationException("No active borrow found for this book and person.");
            }

            book.AvailableCopies++;
            borrow.ReturnDate = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
