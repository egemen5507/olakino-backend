using System.Collections.Generic;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class ExerciseCategory : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Exercise> Exercises { get; } = new List<Exercise>();
    }
}