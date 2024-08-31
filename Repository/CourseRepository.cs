using ITI.Models;

namespace ITI.Repository
{
    public class CourseRepository : ICourseRepository
    {
        ITIEntity _context;
        //Ask "Inject"
        public CourseRepository(ITIEntity db)
        {
            _context = db;
        }

        

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }
        public void Add(Course course)
        {
           _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Course course=GetById(Id);
            if (course != null)
            {
                _context.Courses.Remove(GetById(Id));
                _context.SaveChanges();
            }
            
        }
        public void Update(int Id, Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
    }
}
