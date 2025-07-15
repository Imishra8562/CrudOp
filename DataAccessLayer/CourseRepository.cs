using CrudOp.Models;
using Microsoft.Data.SqlClient;
namespace CrudOp.DataAccessLayer
{
    public class CourseRepository : ICourseRepository
    {
        private readonly string connectionString;

        public CourseRepository(IConfiguration configuration)
        {
            // Use IConfiguration to retrieve the connection string
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Course";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    courses.Add(new Course
                    {
                        CourseId = (int)reader["CourseId"],
                        CourseName = reader["CourseName"].ToString(),
                        Description = reader["Description"].ToString(),
                        Duration = reader["Duration"].ToString(),
                        Fees = (decimal)reader["Fees"],
                        CreatedDate = (DateTime)reader["CreatedDate"]
                    });
                }
            }
            return courses;
        }

        public Course GetCourseById(int id)
        {
            Course course = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Course WHERE CourseId=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    course = new Course
                    {
                        CourseId = (int)reader["CourseId"],
                        CourseName = reader["CourseName"].ToString(),
                        Description = reader["Description"].ToString(),
                        Duration = reader["Duration"].ToString(),
                        Fees = (decimal)reader["Fees"],
                        CreatedDate = (DateTime)reader["CreatedDate"]
                    };
                }
            }
            return course;
        }

        public void AddCourse(Course course)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Course (CourseName, Description, Duration, Fees, CreatedDate) " +
                             "VALUES (@CourseName, @Description, @Duration, @Fees, @CreatedDate)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@Description", course.Description);
                cmd.Parameters.AddWithValue("@Duration", course.Duration);
                cmd.Parameters.AddWithValue("@Fees", course.Fees);
                cmd.Parameters.AddWithValue("@CreatedDate", course.CreatedDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCourse(Course course)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Course SET CourseName=@CourseName, Description=@Description, Duration=@Duration, Fees=@Fees WHERE CourseId=@CourseId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@Description", course.Description);
                cmd.Parameters.AddWithValue("@Duration", course.Duration);
                cmd.Parameters.AddWithValue("@Fees", course.Fees);
                cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCourse(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Course WHERE CourseId=@CourseId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CourseId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
