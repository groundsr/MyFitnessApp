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
            //modelBuilder.Entity<BreakfastMeal>().ToTable("BreakfastMeals");
            //modelBuilder.Entity<DinnerMeal>().ToTable("DinnerMeals");
            //modelBuilder.Entity<LunchMeal>().ToTable("LunchMeals");
            //modelBuilder.Entity<DiaryExercise>().ToTable("DiaryExercises");


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<Breakfast>().HasMany(b => b.Meals).WithMany(b => b.Breakfasts).UsingEntity<BreakfastMeal>(
                j => j.HasOne(pt => pt.Meal).WithMany(t => t.BreakfastMeals).HasForeignKey(pt => pt.MealId),
                j => j.HasOne(pt => pt.Breakfast).WithMany(p => p.BreakfastMeals).HasForeignKey(pt => pt.BreakfastId),
                j =>
                {
                    j.Property(pt => pt.Quantity).HasDefaultValue(0);
                    j.HasKey(t => new { t.BreakfastId, t.MealId });
                });

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

            modelBuilder.Entity<Lunch>().HasMany(b => b.Meals).WithMany(b => b.Lunches).UsingEntity<LunchMeal>(
                j => j.HasOne(pt => pt.Meal).WithMany(t => t.LunchMeals).HasForeignKey(pt => pt.MealId),
                j => j.HasOne(pt => pt.Lunch).WithMany(p => p.LunchMeals).HasForeignKey(pt => pt.LunchId),
                j =>
                {
                    j.Property(pt => pt.Quantity).HasDefaultValue(0);
                    j.HasKey(t => new { t.LunchId, t.MealId });
                });

            modelBuilder.Entity<Dinner>().HasMany(b => b.Meals).WithMany(b => b.Dinners).UsingEntity<DinnerMeal>(
                j => j.HasOne(pt => pt.Meal).WithMany(t => t.DinnerMeals).HasForeignKey(pt => pt.MealId),
                j => j.HasOne(pt => pt.Dinner).WithMany(p => p.DinnerMeals).HasForeignKey(pt => pt.DinnerId),
                j =>
                {
                    j.Property(pt => pt.Quantity).HasDefaultValue(0);
                    j.HasKey(t => new { t.DinnerId, t.MealId });
                });


        }





    }

}

