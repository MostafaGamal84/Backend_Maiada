namespace Orbits.GeneralProject.DTO.CourseTemplateDto
{
    public class CourseTemplateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Level { get; set; }
        public int? DurationWeeks { get; set; }
        public decimal? DefaultPrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
