using System;
using System.Collections.Generic;
using System.ComponentModel;
using LiminoAPI.Business.DTO_s;
using LiminoAPI.Business.Services;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;
using Moq;
using Xunit;

namespace LiminoAPI.Business.Tests
{
    public class CategoryServiceTest : IDisposable
    {
        private Mock<IBaseRepository<Category>> _repoMock;
        private CategoryService _categoryService;

        private readonly IList<CategoryDTO> _categoriesDTOs;
        private readonly IList<CategoryDTO> _videoCategoriesDTOs;
        private readonly IList<CategoryDTO> _audioCategoriesDTOs;
        private readonly IList<CategoryDTO> _conversationCategoriesDTOs;

        private readonly IList<Category> _categories;
        private readonly IList<Category> _videoCategories;
        private readonly IList<Category> _audioCategories;
        private readonly IList<Category> _conversationCategories;

        private readonly CategoryDTO _video1DTO = new CategoryDTO
            {Id = 1, ImageUrl = "imageUrl1", Name = "eten"};

        private readonly CategoryDTO _audio1DTO = new CategoryDTO
            {Id = 2, ImageUrl = "imageUrl2", Name = "verkeer"};

        private readonly CategoryDTO _audio2DTO = new CategoryDTO
            {Id = 3, ImageUrl = "imageUrl3", Name = "drinken"};

        private readonly CategoryDTO _conversation1DTO = new CategoryDTO
            {Id = 4, ImageUrl = "imageUrl4", Name = "wassen"};

        private readonly Category _video1 = new Category
            {Id = 1, ImageUrl = "imageUrl1", Name = "eten"};

        private readonly Category _audio1 = new Category
            {Id = 2, ImageUrl = "imageUrl2", Name = "verkeer"};

        private readonly Category _audio2 = new Category
            {Id = 3, ImageUrl = "imageUrl3", Name = "drinken"};

        private readonly Category _conversation1 = new Category
            {Id = 4, ImageUrl = "imageUrl4", Name = "wassen"};

        public CategoryServiceTest()
        {
            _repoMock = new Mock<IBaseRepository<Category>>();
            _categoryService = new CategoryService(_repoMock.Object);

            _categoriesDTOs = new List<CategoryDTO> {_video1DTO, _audio1DTO, _audio2DTO, _conversation1DTO};
            _videoCategoriesDTOs = new List<CategoryDTO> {_video1DTO};
            _audioCategoriesDTOs = new List<CategoryDTO> {_audio1DTO, _audio2DTO};
            _conversationCategoriesDTOs = new List<CategoryDTO> {_conversation1DTO};

            _categories = new List<Category> {_video1, _audio1, _audio2, _conversation1};
            _videoCategories = new List<Category> {_video1};
            _audioCategories = new List<Category> {_audio1, _audio2};
            _conversationCategories = new List<Category> {_conversation1};
        }

        public void Dispose()
        {
        }

        [Fact]
        public void GetAllCategoriesReturnsAllCategoriesAsDTOs()
        {
            _repoMock.Setup(repo => repo.GetAll()).Returns(_categories);

            var allCategories = _categoryService.GetAllCategories();

            Assert.Equal(_categoriesDTOs, allCategories);
        }
    }
}