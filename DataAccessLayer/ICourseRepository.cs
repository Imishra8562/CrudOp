using CrudOp.Models;

namespace CrudOp.DataAccessLayer
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
        Course GetCourseById(int id);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}
