using emanetV2.Data;
using emanetV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Service
{
    public class PublicationService : IPublicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Publication> _publicationRepository;

        public PublicationService(IUnitOfWork unitOfWork, IRepository<Publication> publicationRepository)
        {
            _unitOfWork = unitOfWork;
            _publicationRepository = publicationRepository;

        }
        public IList<Publication> GetAllAdmin()
        {
            return _publicationRepository.GetAllAdmin() as IList<Publication>;
        }
        public IList<Publication> GetAllWeb()
        {
            return _publicationRepository.GetAllWeb() as IList<Publication>;
        }

        public IList<Publication> GetLastTenPublicationWeb()
        {
            return _publicationRepository.GetLastTenEntityWeb();
        }
        public Publication GetAdmin(int? id)
        {
            return _publicationRepository.GetAdmin(id);
        }
        public Publication GetWeb(int? id)
        {
            return _publicationRepository.GetWeb(id);
        }

        public int New(Publication newPublication)
        {
            _publicationRepository.Insert(newPublication);
            _unitOfWork.SaveChanges();
            return newPublication.Id;
        }

        public int Edit(Publication editedPublication)
        {
            _publicationRepository.Update(editedPublication);
            _unitOfWork.SaveChanges();
            return editedPublication.Id;

        }

        public bool Publish(int? publicationId)
        {
            _publicationRepository.Publish(publicationId);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Draft(int? publicationId)
        {
            _publicationRepository.Draft(publicationId);
            _unitOfWork.SaveChanges();
            return true;

        }

        public bool Remove(int? publicationId)
        {
            _publicationRepository.Remove(publicationId);
            _unitOfWork.SaveChanges();
            return true;
        }
    }

    public interface IPublicationService
    {
        IList<Publication> GetLastTenPublicationWeb();
        IList<Publication> GetAllAdmin();
        IList<Publication> GetAllWeb();
        Publication GetAdmin(int? id);
        Publication GetWeb(int? id);
        int New(Publication newPublication);
        int Edit(Publication editedPublication);
        bool Publish(int? publicationId);
        bool Draft(int? publicationId);
        bool Remove(int? publicationId);
    }
}
