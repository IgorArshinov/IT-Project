using System;
using System.Collections.Generic;
using System.ComponentModel;
using LiminoAPI.Business.DTO_s;
using LiminoAPI.Business.Services;
using LiminoAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LiminoAPI.Tests
{
    public class CategoryControllerTest : IDisposable
    {
        private readonly CategoryController _controller;
        private readonly Mock<ICategoryService> _serviceMock;

        private readonly IList<CategoryDTO> _categories;
        private readonly IList<CategoryDTO> _videoCategories;
        private readonly IList<CategoryDTO> _audioCategories;
        private readonly IList<CategoryDTO> _conversationCategories;


        private readonly CategoryDTO _video1 = new CategoryDTO
            {Id = 1, ImageUrl = "imageUrl1", Name = "eten"};

        private readonly CategoryDTO _audio1 = new CategoryDTO
            {Id = 2, ImageUrl = "imageUrl2", Name = "verkeer"};

        private readonly CategoryDTO _audio2 = new CategoryDTO
            {Id = 3, ImageUrl = "imageUrl3", Name = "drinken"};

        private readonly CategoryDTO _conversation1 = new CategoryDTO
            {Id = 4, ImageUrl = "imageUrl4", Name = "wassen"};


        public CategoryControllerTest()
        {
            _serviceMock = new Mock<ICategoryService>();

            _controller = new CategoryController(_serviceMock.Object);

            _categories = new List<CategoryDTO> {_video1, _audio1, _audio2};
            _videoCategories = new List<CategoryDTO> {_video1};
            _audioCategories = new List<CategoryDTO> {_audio1, _audio2};
            _conversationCategories = new List<CategoryDTO> {_conversation1};
        }

        public void Dispose()
        {
        }

        [Fact]
        private void GetCategoriesWithoutParamsReturnsAllCategories()
        {
            _serviceMock.Setup(service => service.GetAllCategories()).Returns(_categories);

            var actionResult = _controller.GetCategories();

            Assert.IsType<OkObjectResult>(actionResult);
            var result = (OkObjectResult) actionResult;
            var responseObject = (ResponseObject) result.Value;

            Assert.Equal(_categories, responseObject.Data);
        }
    }
}