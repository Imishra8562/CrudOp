using CrudOp.DataAccessLayer;
using CrudOp.Models;

namespace CrudOp.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(IConfiguration configuration) // Add IConfiguration parameter  
        {
            _repository = new CourseRepository(configuration); // Pass configuration to CourseRepository  
        }

        public List<Course> GetAllCourses() => _repository.GetAllCourses();
        public Course GetCourseById(int id) => _repository.GetCourseById(id);
        public void AddCourse(Course course) => _repository.AddCourse(course);
        public void UpdateCourse(Course course) => _repository.UpdateCourse(course);
        public void DeleteCourse(int id) => _repository.DeleteCourse(id);
    }
}
