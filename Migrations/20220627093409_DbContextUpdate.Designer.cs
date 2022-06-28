﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFitnessApp.Data;

namespace MyFitnessApp.Migrations
{
    [DbContext(typeof(FitnessContext))]
    [Migration("20220627093409_DbContextUpdate")]
    partial class DbContextUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BreakfastMeal", b =>
                {
                    b.Property<int>("BreakfastsId")
                        .HasColumnType("int");

                    b.Property<int>("MealsId")
                        .HasColumnType("int");

                    b.HasKey("BreakfastsId", "MealsId");

                    b.HasIndex("MealsId");

                    b.ToTable("BreakfastMeal");
                });

            modelBuilder.Entity("DiaryExercise", b =>
                {
                    b.Property<int>("DiariesId")
                        .HasColumnType("int");

                    b.Property<int>("ExercisesId")
                        .HasColumnType("int");

                    b.HasKey("DiariesId", "ExercisesId");

                    b.HasIndex("ExercisesId");

                    b.ToTable("DiaryExercise");
                });

            modelBuilder.Entity("DinnerMeal", b =>
                {
                    b.Property<int>("DinnersId")
                        .HasColumnType("int");

                    b.Property<int>("MealsId")
                        .HasColumnType("int");

                    b.HasKey("DinnersId", "MealsId");

                    b.HasIndex("MealsId");

                    b.ToTable("DinnerMeal");
                });

            modelBuilder.Entity("LunchMeal", b =>
                {
                    b.Property<int>("LunchesId")
                        .HasColumnType("int");

                    b.Property<int>("MealsId")
                        .HasColumnType("int");

                    b.HasKey("LunchesId", "MealsId");

                    b.HasIndex("MealsId");

                    b.ToTable("LunchMeal");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Breakfast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Breakfast");
                });

            modelBuilder.Entity("MyFitnessApp.Models.BreakfastMeal", b =>
                {
                    b.Property<int>("BreakfastId")
                        .HasColumnType("int");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BreakfastId", "MealId");

                    b.HasIndex("MealId");

                    b.ToTable("BreakfastMeals");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Diary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BreakfastId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DinnerId")
                        .HasColumnType("int");

                    b.Property<int?>("LunchId")
                        .HasColumnType("int");

                    b.Property<int>("TotalCalories")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BreakfastId");

                    b.HasIndex("DinnerId");

                    b.HasIndex("LunchId");

                    b.HasIndex("UserId");

                    b.ToTable("Diary");
                });

            modelBuilder.Entity("MyFitnessApp.Models.DiaryExercise", b =>
                {
                    b.Property<int>("DiaryId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("HowLong")
                        .HasColumnType("int");

                    b.HasKey("DiaryId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("DiaryExercises");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Dinner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Dinner");
                });

            modelBuilder.Entity("MyFitnessApp.Models.DinnerMeal", b =>
                {
                    b.Property<int>("DinnerId")
                        .HasColumnType("int");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("DinnerId", "MealId");

                    b.HasIndex("MealId");

                    b.ToTable("DinnerMeals");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Lunch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Lunch");
                });

            modelBuilder.Entity("MyFitnessApp.Models.LunchMeal", b =>
                {
                    b.Property<int>("LunchId")
                        .HasColumnType("int");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("LunchId", "MealId");

                    b.HasIndex("MealId");

                    b.ToTable("LunchMeals");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("Carbohydrates")
                        .HasColumnType("int");

                    b.Property<int>("Fat")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Protein")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Meal");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("MyFitnessApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<double>("Bmi")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserGoalId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserGoalId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MyFitnessApp.Models.UserGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Goal")
                        .HasColumnType("int");

                    b.Property<float>("GoalPerWeek")
                        .HasColumnType("real");

                    b.Property<int>("GoalWeight")
                        .HasColumnType("int");

                    b.Property<int>("UserActivity")
                        .HasColumnType("int");

                    b.Property<int?>("UserPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserPlanId");

                    b.ToTable("UserGoal");
                });

            modelBuilder.Entity("MyFitnessApp.Models.UserPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BMI")
                        .HasColumnType("int");

                    b.Property<int>("TotalCalories")
                        .HasColumnType("int");

                    b.Property<int>("TotalCarbs")
                        .HasColumnType("int");

                    b.Property<int>("TotalFat")
                        .HasColumnType("int");

                    b.Property<int>("TotalProtein")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserPlan");
                });

            modelBuilder.Entity("MyFitnessApp.Models.UserProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentWeight")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WeightLogDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserProgress");
                });

            modelBuilder.Entity("BreakfastMeal", b =>
                {
                    b.HasOne("MyFitnessApp.Models.Breakfast", null)
                        .WithMany()
                        .HasForeignKey("BreakfastsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyFitnessApp.Models.Meal", null)
                        .WithMany()
                        .HasForeignKey("MealsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiaryExercise", b =>
                {
                    b.HasOne("MyFitnessApp.Models.Diary", null)
                        .WithMany()
                        .HasForeignKey("DiariesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyFitnessApp.Models.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DinnerMeal", b =>
                {
                    b.HasOne("MyFitnessApp.Models.Dinner", null)
                        .WithMany()
                        .HasForeignKey("DinnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyFitnessApp.Models.Meal", null)
                        .WithMany()
                        .HasForeignKey("MealsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LunchMeal", b =>
                {
                    b.HasOne("MyFitnessApp.Models.Lunch", null)
                        .WithMany()
                        .HasForeignKey("LunchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyFitnessApp.Models.Meal", null)
                        .WithMany()
                        .HasForeignKey("MealsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyFitnessApp.Models.BreakfastMeal", b =>
                {
                    b.HasOne("MyFitnessApp.Models.Breakfast", "Breakfast")
                        .WithMany()
                        .HasForeignKey("BreakfastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyFitnessApp.Models.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breakfast");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Diary", b =>
                {
                    b.HasOne("MyFitnessApp.Models.Breakfast", "Breakfast")
                        .WithMany()
                        .HasForeignKey("BreakfastId");

                    b.HasOne("MyFitnessApp.Models.Dinner", "Dinner")
                        .WithMany()
                        .HasForeignKey("DinnerId");

                    b.HasOne("MyFitnessApp.Models.Lunch", "Lunch")
                        .WithMany()
                        .HasForeignKey("LunchId");

                    b.HasOne("MyFitnessApp.Models.User", "User")
                        .WithMany("Diaries")
                        .HasForeignKey("UserId");

                    b.Navigation("Breakfast");

                    b.Navigation("Dinner");

                    b.Navigation("Lunch");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyFitnessApp.Models.DiaryExercise", b =>
                {
                    b.HasOne("MyFitnessApp.Models.Diary", "Diary")
                        .WithMany()
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyFitnessApp.Models.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diary");

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("MyFitnessApp.Models.DinnerMeal", b =>
                {
                    b.HasOne("MyFitnessApp.Models.Dinner", "Dinner")
                        .WithMany()
                        .HasForeignKey("DinnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyFitnessApp.Models.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dinner");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Ingredient", b =>
                {
                    b.HasOne("MyFitnessApp.Models.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("MyFitnessApp.Models.LunchMeal", b =>
                {
                    b.HasOne("MyFitnessApp.Models.Lunch", "Lunch")
                        .WithMany()
                        .HasForeignKey("LunchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyFitnessApp.Models.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lunch");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("MyFitnessApp.Models.User", b =>
                {
                    b.HasOne("MyFitnessApp.Models.UserGoal", "UserGoal")
                        .WithMany("Users")
                        .HasForeignKey("UserGoalId");

                    b.Navigation("UserGoal");
                });

            modelBuilder.Entity("MyFitnessApp.Models.UserGoal", b =>
                {
                    b.HasOne("MyFitnessApp.Models.UserPlan", "UserPlan")
                        .WithMany("UserGoals")
                        .HasForeignKey("UserPlanId");

                    b.Navigation("UserPlan");
                });

            modelBuilder.Entity("MyFitnessApp.Models.UserProgress", b =>
                {
                    b.HasOne("MyFitnessApp.Models.User", "User")
                        .WithMany("UserProgresses")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("MyFitnessApp.Models.User", b =>
                {
                    b.Navigation("Diaries");

                    b.Navigation("UserProgresses");
                });

            modelBuilder.Entity("MyFitnessApp.Models.UserGoal", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MyFitnessApp.Models.UserPlan", b =>
                {
                    b.Navigation("UserGoals");
                });
#pragma warning restore 612, 618
        }
    }
}
