using Microsoft.EntityFrameworkCore;
namespace FollowUpApi.Models;

public class StaffMemberDB : DbContext
{
    //public DbSet<Member> Members {get;set;}
    public DbSet<Member> Members => Set<Member>();
     public StaffMemberDB(DbContextOptions<StaffMemberDB> options)
        : base(options) { }
    
    
}