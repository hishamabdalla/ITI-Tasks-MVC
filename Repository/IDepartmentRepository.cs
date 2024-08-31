using ITI.Models;

namespace ITI.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Add(Department course);
        void Update(int Id, Department course);
        void Delete(int Id);
    }
}
