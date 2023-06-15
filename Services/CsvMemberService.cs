using System.Globalization;
using CsvHelper;
using  FollowUpApi.Models;
using Microsoft.AspNetCore.Hosting;

namespace FollowUpApi.Services;

public interface ICsvMemberService
{
    IEnumerable<Member> GetMembers();
}
public class CsvMemberService : ICsvMemberService
{
    private readonly StreamReader _streamReader;
    private readonly IWebHostEnvironment _env;

    public CsvMemberService(IWebHostEnvironment env)
    {
        _env = env;
        string contentRootPath = _env.ContentRootPath;
        _streamReader = new StreamReader(Path.Combine(contentRootPath, "assets", "staffmember.csv"));
    }

    public IEnumerable<Member> GetMembers(){
        using (var csv = new CsvReader(_streamReader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<Member>().ToList();
            return records;
        }

    }
}


