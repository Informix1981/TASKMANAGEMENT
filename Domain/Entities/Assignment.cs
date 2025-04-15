using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public int Complexity { get; set; } // Story Points
        public string Status { get; set; } = "Not Started";
        public int? ParentAssignmentId { get; set; }
        public Assignment? ParentAssignment { get; set; }
        public ICollection<Assignment>? SubAssignments { get; set; }
    }
}