using Microsoft.EntityFrameworkCore;
using MyFitnessApp.Models;

namespace MyFitnessApp.Data
{
    public class FitnessContext : DbContext
    {

        public FitnessContext(DbContextOptions<FitnessContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPlan> UserPlans { get; set; }
        public DbSet<UserGoal> UserGoals { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserPlan>().ToTable("UserPlan");
            modelBuilder.Entity<UserGoal>().ToTable("UserGoal");
            modelBuilder.Entity<Diary>().ToTable("Diary");
            modelBuilder.Entity<Meal>().ToTable("Meal");
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
        }
    }
}
