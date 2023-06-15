using FollowUpApi.Models;

namespace FollowUpApi.Services;

public interface IMemberService
{
    public List<Member> GetMembers();
    public Member ? GetMember(int id);
    public void SaveMember(Member member);


}