using emanetV2.Data;
using emanetV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace emanetV2.Service
{
    public class AnimalSizeService : IAnimalSizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AnimalSize> _animalSizeRepository;

        public AnimalSizeService(IUnitOfWork unitOfWork, IRepository<AnimalSize> animalSizeRepository)
        {
            _unitOfWork = unitOfWork;
            _animalSizeRepository = animalSizeRepository;
        }
        public IList<AnimalSize> GetAllAdmin()
        {
            return _animalSizeRepository.GetAllAdmin() as IList<AnimalSize>;
        }
        public IList<AnimalSize> GetAllWeb()
        {
            return _animalSizeRepository.GetAllWeb() as IList<AnimalSize>;
        }
        public AnimalSize GetWeb(int? animalSizeId)
        {
            return _animalSizeRepository.GetWeb(animalSizeId);
        }
        public AnimalSize GetAdmin(int? animalSizeId)
        {
            return _animalSizeRepository.GetAdmin(animalSizeId);
        }
        public int New(AnimalSize newAnimalSize)
        {
            _animalSizeRepository.Insert(newAnimalSize);
            _unitOfWork.SaveChanges();
            return newAnimalSize.Id;
        }

        public int Edit(AnimalSize editedAnimalSize)
        {
            _animalSizeRepository.Update(editedAnimalSize);
            _unitOfWork.SaveChanges();
            return editedAnimalSize.Id;
        }

        public bool Publish(int? animalSizeId)
        {
            _animalSizeRepository.Publish(animalSizeId);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Draft(int? animalSizeId)
        {
            _animalSizeRepository.Draft(animalSizeId);
            _unitOfWork.SaveChanges();
            return true;

        }

        public bool Remove(int? animalSizeId)
        {
            _animalSizeRepository.Remove(animalSizeId);
            _unitOfWork.SaveChanges();
            return true;
        }
    }

    public interface IAnimalSizeService
    {
        IList<AnimalSize> GetAllAdmin();
        IList<AnimalSize> GetAllWeb();
        AnimalSize GetAdmin(int? animalSizeId);
        AnimalSize GetWeb(int? animalSizeId);
        int New(AnimalSize newAnimalSize);
        int Edit(AnimalSize editedAnimalSize);
        bool Publish(int? animalSizeId);
        bool Draft(int? animalSizeId);
        bool Remove(int? animalSizeId);
    }
}
