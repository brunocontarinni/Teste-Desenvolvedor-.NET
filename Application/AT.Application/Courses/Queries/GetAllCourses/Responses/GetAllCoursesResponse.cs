namespace AT.Application.Courses.Queries.GetAllCourses.Responses
{
    public class GetAllCoursesResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AvailableVacancies { get; set; }
    }
}