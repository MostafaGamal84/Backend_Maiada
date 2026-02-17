using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class CourseTemplate:EntityBase
    {
        public CourseTemplate()
        {
            CourseInstances = new HashSet<CourseInstance>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Level { get; set; }
        public int? DurationWeeks { get; set; }
        public decimal? DefaultPrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<CourseInstance> CourseInstances { get; set; }
    }
}
