namespace FollowUpApi.Models;


public interface IMemberService
{
    public List<Member> GetMembers();
    public Member ? GetMember(int id);
    public void SaveMember(Member member);


}