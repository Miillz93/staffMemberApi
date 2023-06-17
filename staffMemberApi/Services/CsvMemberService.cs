using System.Globalization;
using CsvHelper;
using  FollowUpApi.Models;
using Microsoft.AspNetCore.Hosting;

namespace FollowUpApi.Services;

public interface ICsvMemberService
{
    IEnumerable<Member> GetMembers();
    IEnumerable<Member> GetMembers(int pageNumber, int pageSize);
    Member GetMember(int id);

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
        using var csv = new CsvReader(_streamReader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<Member>().ToList();

        return records;
    }
    public IEnumerable<Member> GetMembers(int pageNumber, int pageSize){
        using var csv = new CsvReader(_streamReader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<Member>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return records;
    }

    public Member GetMember(int id){
        using var csv = new CsvReader(_streamReader, CultureInfo.InvariantCulture);
        var record = csv.GetRecords<Member>()
            .Where(x => x.Id == id)
            .FirstOrDefault() ?? throw new NullReferenceException();
        
        return record;
    }

}


