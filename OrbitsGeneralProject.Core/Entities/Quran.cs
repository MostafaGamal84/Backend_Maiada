using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Quran:EntityBase
    {
        public Quran()
        {
            StudentReportDistantPasts = new HashSet<StudentReport>();
            StudentReportFarthestPasts = new HashSet<StudentReport>();
            StudentReportNews = new HashSet<StudentReport>();
            StudentReportRecentPasts = new HashSet<StudentReport>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<StudentReport> StudentReportDistantPasts { get; set; }
        public virtual ICollection<StudentReport> StudentReportFarthestPasts { get; set; }
        public virtual ICollection<StudentReport> StudentReportNews { get; set; }
        public virtual ICollection<StudentReport> StudentReportRecentPasts { get; set; }
    }
}
