﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestWorkQuestions.DAL;

#nullable disable

namespace TestWorkQuestions.DAL.Migrations
{
    [DbContext(typeof(EfContext))]
    [Migration("20240926070045_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Ответ");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uuid")
                        .HasComment("Идентификатор вопроса");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Interview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uuid")
                        .HasComment("Идентификатор анкеты");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId")
                        .IsUnique();

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CorrectAnswerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Название вопроса");

                    b.Property<int>("Position")
                        .HasColumnType("integer")
                        .HasComment("Номер вопроса");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CorrectAnswerId");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Result", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InterviewId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("InterviewId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Описание анкеты");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Название анкеты");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Answer", b =>
                {
                    b.HasOne("TestWorkQuestions.Core.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Interview", b =>
                {
                    b.HasOne("TestWorkQuestions.Core.Entities.Survey", "Survey")
                        .WithOne("Interview")
                        .HasForeignKey("TestWorkQuestions.Core.Entities.Interview", "SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Question", b =>
                {
                    b.HasOne("TestWorkQuestions.Core.Entities.Answer", "CorrectAnswer")
                        .WithMany()
                        .HasForeignKey("CorrectAnswerId");

                    b.HasOne("TestWorkQuestions.Core.Entities.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CorrectAnswer");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Result", b =>
                {
                    b.HasOne("TestWorkQuestions.Core.Entities.Answer", "Answer")
                        .WithMany("Results")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestWorkQuestions.Core.Entities.Interview", "Interview")
                        .WithMany("Results")
                        .HasForeignKey("InterviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestWorkQuestions.Core.Entities.Question", "Question")
                        .WithMany("Results")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Interview");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Answer", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Interview", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Results");
                });

            modelBuilder.Entity("TestWorkQuestions.Core.Entities.Survey", b =>
                {
                    b.Navigation("Interview");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
