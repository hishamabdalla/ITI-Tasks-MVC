using ITI.Models;

namespace ITI.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIEntity _context;
        //Ask "Inject"
        public DepartmentRepository(ITIEntity db)
        {
            _context = db;
        }

        public DepartmentRepository()
        {
        }

        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.FirstOrDefault(c => c.Id == id);
        }
        public void Add(Department dept)
        {
            _context.Departments.Add(dept);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            _context.Departments.Remove(GetById(Id));
            _context.SaveChanges();
        }
        public void Update(int Id, Department dept)
        {
            _context.Departments.Update(dept);
            _context.SaveChanges();
        }
    }
}