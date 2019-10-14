using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using LiminoAPI.Business.DTO_s;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;

namespace LiminoAPI.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _repo;

        public CategoryService(IBaseRepository<Category> repo)
        {
            _repo = repo;
        }

        public CategoryService()
        {
            
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            return MapEntityListToDTOList(_repo.GetAll());
        }

        private static IEnumerable<CategoryDTO> MapEntityListToDTOList(IEnumerable<Category> categories)
        {
            return categories.Select(category => new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl
            }).ToList();
        }
    }
}