using emanetV2.Data;
using emanetV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Service
{
    public class AnimalTypeService : IAnimalTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AnimalType> _animalTypeRepository;

        public AnimalTypeService(IUnitOfWork unitOfWork, IRepository<AnimalType> animalTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _animalTypeRepository = animalTypeRepository;
        }
        public IList<AnimalType> GetAllAdmin()
        {
            return _animalTypeRepository.GetAllAdmin() as IList<AnimalType>;
        }
        public IList<AnimalType> GetAllWeb()
        {
            return _animalTypeRepository.GetAllWeb() as IList<AnimalType>;
        }
        public AnimalType GetWeb(int? animalTypeId)
        {
            return _animalTypeRepository.GetWeb(animalTypeId);
        }
        public AnimalType GetAdmin(int? animalTypeId)
        {
            return _animalTypeRepository.GetAdmin(animalTypeId);
        }
        public int New(AnimalType newAnimalType)
        {
            _animalTypeRepository.Insert(newAnimalType);
            _unitOfWork.SaveChanges();
            return newAnimalType.Id;
        }

        public int Edit(AnimalType editedAnimalType)
        {
            _animalTypeRepository.Update(editedAnimalType);
            _unitOfWork.SaveChanges();
            return editedAnimalType.Id;
        }

        public bool Publish(int? animalTypeId)
        {
            _animalTypeRepository.Publish(animalTypeId);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Draft(int? animalTypeId)
        {
            _animalTypeRepository.Draft(animalTypeId);
            _unitOfWork.SaveChanges();
            return true;

        }

        public bool Remove(int? animalTypeId)
        {
            _animalTypeRepository.Remove(animalTypeId);
            _unitOfWork.SaveChanges();
            return true;
        }
    }

    public interface IAnimalTypeService
    {
        IList<AnimalType> GetAllAdmin();
        IList<AnimalType> GetAllWeb();
        AnimalType GetAdmin(int? animalTypeId);
        AnimalType GetWeb(int? animalTypeId);
        int New(AnimalType newAnimalType);
        int Edit(AnimalType editedAnimalType);
        bool Publish(int? animalTypeId);
        bool Draft(int? animalTypeId);
        bool Remove(int? animalTypeId);
    }
}
