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
    [Migration("20220611154955_addedFoodName")]
    partial class addedFoodName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyFitnessApp.Models.Diary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TotalCalories")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Diary");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaloriesBurnt")
                        .HasColumnType("int");

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

                    b.Property<int?>("DiaryId")
                        .HasColumnType("int");

                    b.Property<int>("Fat")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Protein")
                        .HasColumnType("int");

                    b.Property<int>("Types")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiaryId");

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

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserGoalId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

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

            modelBuilder.Entity("MyFitnessApp.Models.Diary", b =>
                {
                    b.HasOne("MyFitnessApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Ingredient", b =>
                {
                    b.HasOne("MyFitnessApp.Models.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Meal", b =>
                {
                    b.HasOne("MyFitnessApp.Models.Diary", null)
                        .WithMany("Meals")
                        .HasForeignKey("DiaryId");
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

            modelBuilder.Entity("MyFitnessApp.Models.Diary", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("MyFitnessApp.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");
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
