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

        public DbSet<Breakfast> Breakfast { get; set; }
        public DbSet<Lunch> Lunch { get; set; }
        public DbSet<Dinner> Dinner { get; set; }
        public DbSet<UserProgress> UserProgress { get; set; }
        public DbSet<BreakfastMeal> BreakfastMeals { get; set; }
        public DbSet<LunchMeal> LunchMeals { get; set; }
        public DbSet<DinnerMeal> DinnerMeals { get; set; }
        public DbSet<DiaryExercise> DiaryExercises { get; set; }

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
            modelBuilder.Entity<Breakfast>().ToTable("Breakfast");
            modelBuilder.Entity<Lunch>().ToTable("Lunch");
            modelBuilder.Entity<Dinner>().ToTable("Dinner");
            modelBuilder.Entity<UserProgress>().ToTable("UserProgress");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
            modelBuilder.Entity<BreakfastMeal>().HasKey(bm => new { bm.BreakfastId, bm.MealId });
            modelBuilder.Entity<BreakfastMeal>().HasOne(bm => bm.Breakfast).WithMany(b => b.BreakfastMeals).HasForeignKey(bm => bm.BreakfastId);
            modelBuilder.Entity<BreakfastMeal>().HasOne(bm => bm.Meal).WithMany(m => m.BreakfastMeals).HasForeignKey(bm => bm.MealId);


            modelBuilder.Entity<LunchMeal>().HasKey(bm => new { bm.LunchId, bm.MealId });
            modelBuilder.Entity<LunchMeal>().HasOne(bm => bm.Lunch).WithMany(b => b.LunchMeals).HasForeignKey(bm => bm.LunchId);
            modelBuilder.Entity<LunchMeal>().HasOne(bm => bm.Meal).WithMany(m => m.LunchMeals).HasForeignKey(bm => bm.MealId);


            modelBuilder.Entity<DinnerMeal>().HasKey(bm => new { bm.DinnerId, bm.MealId });
            modelBuilder.Entity<DinnerMeal>().HasOne(bm => bm.Dinner).WithMany(b => b.DinnerMeals).HasForeignKey(bm => bm.DinnerId);
            modelBuilder.Entity<DinnerMeal>().HasOne(bm => bm.Meal).WithMany(m => m.DinnerMeals).HasForeignKey(bm => bm.MealId);

            

            modelBuilder.Entity<Diary>().HasMany(d => d.Exercises).WithMany(d => d.Diaries).UsingEntity<DiaryExercise>(
                j => j.
                        HasOne(de => de.Exercise)
                        .WithMany(e => e.DiaryExercises)
                        .HasForeignKey(de => de.ExerciseId),
                j => j.
                        HasOne(de => de.Diary)
                        .WithMany(d => d.DiaryExercises)
                        .HasForeignKey(de => de.DiaryId),
                j =>
                {
                    j.Property(de => de.HowLong).HasDefaultValue(0);
                    j.HasKey(d => new { d.DiaryId, d.ExerciseId });
                });

        }





    }

}

