namespace FollowUpApi.Models;

public class MemberService : IMemberService
{
    private readonly StaffMemberDB _staffMember;

    public MemberService(StaffMemberDB staffMember){
        _staffMember = staffMember;
    }  
    public List<Member> GetMembers() => _staffMember.Members.ToList();
    public Member ? GetMember(int id) => _staffMember.Members.FirstOrDefault(x => x.Id == id);
    public void SaveMember(Member member) {
        _staffMember.Members.Add(member);
        _staffMember.SaveChanges();
    }


}