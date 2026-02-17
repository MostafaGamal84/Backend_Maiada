using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class StudentReport:EntityBase
    {
        public int Id { get; set; }
        public double Minutes { get; set; }
        public int? NewId { get; set; }
        public int NewFrom { get; set; }
        public int NewTo { get; set; }
        public string? NewRate { get; set; }
        public int? RecentPastId { get; set; }
        public int RecentPastFrom { get; set; }
        public int RecentPastTo { get; set; }
        public string? RecentPastRate { get; set; }
        public int? DistantPastId { get; set; }
        public int DistantPastFrom { get; set; }
        public int DistantPastTo { get; set; }
        public string? DistantPastRate { get; set; }
        public int? FarthestPastId { get; set; }
        public int FarthestPastFrom { get; set; }
        public int FarthestPastTo { get; set; }
        public string? FarthestPastRate { get; set; }
        public string? TheWordsQuranStranger { get; set; }
        public string? Intonation { get; set; }
        public string? Other { get; set; }
        public DateTime CreationTime { get; set; }
        public int? CircleId { get; set; }
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }
        public bool IsDeleted { get; set; }
        public int? AttendStatueId { get; set; }

        public virtual AttendStatue? AttendStatue { get; set; }
        public virtual Circle? Circle { get; set; }
        public virtual Quran? DistantPast { get; set; }
        public virtual Quran? FarthestPast { get; set; }
        public virtual Quran? New { get; set; }
        public virtual Quran? RecentPast { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
