using emanetV2.Data;
using emanetV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Service
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Member> _memberRepository;

        public MemberService(IUnitOfWork unitOfWork, IRepository<Member> memberRepository)
        {
            _unitOfWork = unitOfWork;
            _memberRepository = memberRepository;

        }
        public Member GetAdmin(int memberId)
        {
            return _memberRepository.GetAdmin(memberId);
        }
        public Member GetWeb(int memberId)
        {
            return _memberRepository.GetWeb(memberId);
        }

        public int New(Member newMember)
        {
            _memberRepository.Insert(newMember);
            _unitOfWork.SaveChanges();
            return newMember.Id;
        }

        public int Edit(Member editedMember)
        {
            _memberRepository.Update(editedMember);
            _unitOfWork.SaveChanges();
            return editedMember.Id;
        }

        public bool Publish(int? memberId)
        {
            _memberRepository.Publish(memberId);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Draft(int? memberId)
        {
            _memberRepository.Draft(memberId);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Remove(int? memberId)
        {
            _memberRepository.Remove(memberId);
            _unitOfWork.SaveChanges();
            return true;
        }

        public IList<Member> GetAllAdmin()
        {
            return _memberRepository.GetAllAdmin() as IList<Member>;
        }
        public IList<Member> GetAllWeb()
        {
            return _memberRepository.GetAllWeb() as IList<Member>;
        }
    }

    public interface IMemberService
    {
        IList<Member> GetAllAdmin();
        IList<Member> GetAllWeb();
        Member GetAdmin(int memberId);
        Member GetWeb(int memberId);
        int New(Member newMember);
        int Edit(Member editedMember);
        bool Publish(int? memberId);
        bool Draft(int? memberId);
        bool Remove(int? memberId);
    }
}
