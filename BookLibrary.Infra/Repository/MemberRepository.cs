﻿using BookLibrary2.Domain.Interfaces;
using BookLibrary2.Domain.Models;
using BookLibrary2.Infra.Data;

namespace BookLibrary2.Infra.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataContext _context;

        public MemberRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateMember(Member member)
        {
            _context.Add(member);
            return Save();
        }

        public Member GetMember(int memberId)
        {
            return _context.members.Where(m => m.Id == memberId).FirstOrDefault();
        }

        public ICollection<Member> GetMembers()
        {
            return _context.members.ToList();
        }

        public bool MemberExists(int memberId)
        {
            return _context.members.Any(c => c.Id == memberId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
