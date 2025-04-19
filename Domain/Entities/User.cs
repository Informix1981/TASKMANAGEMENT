using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; } // User or Admin
        public ICollection<UserGroup>? UserGroups { get; set; }
    }
}