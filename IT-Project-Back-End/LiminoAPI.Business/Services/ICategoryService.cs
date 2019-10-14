using System.Collections.Generic;
using LiminoAPI.Business.DTO_s;

namespace LiminoAPI.Business.Services
{
    public interface ICategoryService
    {


        IEnumerable<CategoryDTO> GetAllCategories();
    }
}