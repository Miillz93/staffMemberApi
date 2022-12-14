using FollowUpApi.Models;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StaffMemberDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("StaffMember")));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/", ()=> "Hello World");
app.MapGet("/members", (IMemberService memberService) => memberService.GetMembers());
app.MapGet("/members/{id:int}", (int id, IMemberService memberService) => {
    var member = memberService.GetMember(id);
    return member == null ? Results.NotFound() : Results.Ok();
});
app.MapPost("/members", (Member member, IMemberService memberService) => memberService.SaveMember(member));
app.MapPut("/member", () => "Hello Millz!");
app.MapDelete("/members/{id:int}", () => "Hello Millz!");


app.Run();
