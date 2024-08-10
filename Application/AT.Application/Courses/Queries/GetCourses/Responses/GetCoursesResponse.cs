namespace AT.Application.Courses.Queries.GetCourses.Responses
{
    public class GetCoursesResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AvailableVacancies { get; set; }
    }
}