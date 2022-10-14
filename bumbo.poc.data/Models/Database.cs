using Microsoft.EntityFrameworkCore;

namespace bumbo.poc.data.Models;

public class Database
{
    public DbSet<Prognosis> Prognoses { get; set; }
    public DbSet<PrognosisInput> PrognosisInputs { get; set; }
    public DbSet<PrognosisNorm> PrognosisNorms { get; set; }
    public DbSet<ScheduleItem> ScheduleItems { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WorkedTime> WorkedTimes { get; set; }
}