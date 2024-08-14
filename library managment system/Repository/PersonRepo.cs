using library_managment_system.Models;

namespace library_managment_system.Repository
{
    public class PersonRepo : IPersonRepo
    {
        public Context _context;
        public PersonRepo(Context context)
        {
            _context = context;
        }

        public List<Person> GetAll()
        {
            return _context.People.ToList();
        }

        public Person GetById(int id)
        {
            return _context.People.FirstOrDefault(c => c.Id == id);
        }

        public Person GetByCode(string code)
        {
            return _context.People.FirstOrDefault(c => c.Code == code);
        }

        public void Insert(Person obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public void Update(Person obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            Person obj = GetById(id);
            _context.Remove(obj);
            _context.SaveChanges();
        }
       
    }
}
