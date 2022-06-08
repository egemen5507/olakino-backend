using System.Collections.Generic;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class DietCategory : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Diet> Diets { get; } = new List<Diet>();
    }
}