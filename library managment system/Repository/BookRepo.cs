using library_managment_system.Models;

namespace library_managment_system.Repository
{
    public class BookRepo : IBookRepo

    {
        public Context _context;
        public BookRepo(Context context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.FirstOrDefault(c => c.Id == id);
        }

        public Book GetByName(string name)
        {
            return _context.Books.FirstOrDefault(c => c.Name == name);
        }

        public void Insert(Book obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public void Update(Book obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            Book obj = GetById(id);
            _context.Remove(obj);
            _context.SaveChanges();
        }
        
    }
}
