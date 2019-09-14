using emanetV2.Data;
using emanetV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Service
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Animal> _animalRepository;

        public AnimalService(IUnitOfWork unitOfWork, IRepository<Animal> animalRepository)
        {
            _unitOfWork = unitOfWork;
            _animalRepository = animalRepository;
        }

        public int New(Animal newAnimal)
        {
            _animalRepository.Insert(newAnimal);
            _unitOfWork.SaveChanges();
            return newAnimal.Id;
        }

        public int Edit(Animal editedAnimal)
        {
            _animalRepository.Update(editedAnimal);
            _unitOfWork.SaveChanges();
            return editedAnimal.Id;
        }
    }

    public interface IAnimalService
    {
        int New(Animal newAnimal);
        int Edit(Animal editedAnimal);
    }
}

