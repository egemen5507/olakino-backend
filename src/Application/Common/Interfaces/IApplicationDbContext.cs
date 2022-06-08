using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Domain.Entities.Exercise> Exercises { get; set; }
        public DbSet<Domain.Entities.ExerciseCategory> ExerciseCategories { get; set; }
        public DbSet<Domain.Entities.Diet> Diets { get; set; }
        public DbSet<Domain.Entities.DietCategory> DietCategories { get; set; }
        public DbSet<ActivityLog> ActivityLogs{ get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
