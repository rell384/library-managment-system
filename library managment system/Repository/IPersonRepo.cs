using library_managment_system.Models;

namespace library_managment_system.Repository
{
    public interface IPersonRepo
    {
        public List<Person> GetAll();


        public Person GetById(int id);

        public Person GetByCode(string code);

        public void Insert(Person obj);

        public void Update(Person obj);

        public void Delete(int id);
    }
}
