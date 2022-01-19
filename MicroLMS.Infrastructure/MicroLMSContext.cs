using MicroLMS.Domain;

namespace MicroLMS.Infrastructure;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class MicroLMSContext : DbContext
{
    public MicroLMSContext(DbContextOptions<MicroLMSContext> options) : base(options)
    {
    }

    public DbSet<ContentLink> ContentLinks { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseBlock> ExerciseBlocks { get; set; }
    public DbSet<ExerciseVariant> ExerciseVariants { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<Session> Sessions { get; set; }
}