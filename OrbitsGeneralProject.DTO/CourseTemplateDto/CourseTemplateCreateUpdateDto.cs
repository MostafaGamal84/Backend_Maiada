namespace Orbits.GeneralProject.DTO.CourseTemplateDto
{
    public class CourseTemplateCreateUpdateDto
    {
        public string Name { get; set; } = null!;
        public string? Level { get; set; }
        public int DurationWeeks { get; set; }
        public decimal? DefaultPrice { get; set; }
    }
}
