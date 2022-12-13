using FollowUpApi.Models;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StaffMemberDB>(opt => opt.UseInMemoryDatabase("StaffMemberItemList"));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/", ()=> "Hello World");

app.Run();
