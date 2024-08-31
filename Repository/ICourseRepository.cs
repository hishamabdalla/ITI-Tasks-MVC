using ITI.Models;

namespace ITI.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetById(int id);
        void Add(Course course);
        void Update(int Id ,Course course);
        void Delete(int Id);
    }
}
