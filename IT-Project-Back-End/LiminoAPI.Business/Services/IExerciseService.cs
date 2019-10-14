using System.Collections.Generic;

namespace LiminoAPI.Business.Services
{
    public interface IExerciseService
    {
        IEnumerable<ExerciseDTO> GetAll();
        IEnumerable<ExerciseDTO> GetAllForCategoryId(long? categoryId);
        IEnumerable<ExerciseDTO> GetAllExercisesByTypeAndCategory(string type, long? categoryId);
        ExerciseDTO GetById(long id);
        long Add(ExerciseDTO exerciseDTO);
        void Delete(long id);
        void Put(ExerciseDTO exerciseDTO);
    }
}