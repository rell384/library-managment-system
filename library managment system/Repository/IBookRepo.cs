using library_managment_system.Models;

namespace library_managment_system.Repository
{
    public interface IBookRepo
    {
        public List<Book> GetAll();

        public Book GetByName(string name);

        public Book GetById(int id);


        public void Insert(Book obj);

        public void Update(Book obj);

        public void Delete(int id);

        
    }
}
