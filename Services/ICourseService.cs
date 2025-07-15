using CrudOp.Models;

namespace CrudOp.Services
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        Course GetCourseById(int id);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}
