using System.Collections.Generic;

namespace Domain.Entities
{
    public class UserGroup : IEntity<int>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}