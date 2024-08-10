namespace AT.API.Controllers.ViewModels
{
    public class UpdateCoursesViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AvailableVacancies { get; set; }
    }
}