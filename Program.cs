using FollowUpApi.Models;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StaffMemberDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("StaffMember")));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IMemberService, MemberService>();

var app = builder.Build();

app.MapGet("/api/", ()=> "Hello World");
app.MapGet("/api/members", (IMemberService memberService) => memberService.GetMembers());
app.MapGet("/api/members/{id:int}", (int id, IMemberService memberService) => {
    var member = memberService.GetMember(id);
    return member == null ? Results.NotFound() : Results.Ok(member);
});
app.MapPost("/api/members", (Member member, IMemberService memberService) => memberService.SaveMember(member));
app.MapPut("/api/members{id:int}", (int id) => "Hello Millz!");
app.MapDelete("/api/members/{id:int}", (int id) => "Hello Millz!");


app.Run();
