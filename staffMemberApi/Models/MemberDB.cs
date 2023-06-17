using Microsoft.EntityFrameworkCore;
using StaffMemberApi.Models;

namespace FollowUpApi.Models;

public class StaffMemberDB : DbContext
{
    //public DbSet<Member> Members {get;set;}
    public DbSet<Member> Members => Set<Member>();
    public DbSet<User> Users => Set<User>();
    public StaffMemberDB(DbContextOptions<StaffMemberDB> options)
        : base(options) { }
    
    
}