using BookLibrary2.Domain.Models;

namespace BookLibrary2.Domain.Interfaces
{
    public interface IMemberRepository
    {
        ICollection<Member> GetMembers();
        Member GetMember(int memberId);
        bool MemberExists(int memberId);
        bool CreateMember(Member member);
        bool Save();
    }
}
