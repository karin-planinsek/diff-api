using DiffApi.Controllers;
using DiffApi.Db;
using DiffApi.Dto;
using DiffApi.Infrastructure.Repositories;
using DiffApi.Infrastructure.Services;
using DiffApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DiffApi.Tests
{
    public class DiffControllerTests
    {
        private readonly DiffContext _context;
        private readonly ILeftDiffRepository _leftRepository;
        private readonly IRightDiffRepository _rightRepository;
        private readonly ILeftDiffService _leftService;
        private readonly IRightDiffService _rightService;
        private readonly DiffService _diffService;
        private readonly DiffController _controller;

        public DiffControllerTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<DiffContext>()
                .UseInMemoryDatabase(databaseName: "DiffTests");
            _context = new DiffContext(dbContextOptions.Options);
            _leftRepository = new LeftDiffRepository(_context);
            _rightRepository = new RightDiffRepository(_context);
            _leftService = new LeftDiffService(_leftRepository);
            _rightService = new RightDiffService(_rightRepository);
            _diffService = new DiffService();
            _controller = new DiffController(_leftService, _rightService, _diffService);
        }

        [Fact]
        public void CreateLeftDiff_Successfully_Creates_LeftDiff()
        {
            // Arrange

            DiffRequestDto data = new DiffRequestDto { Data = "test" };
            DiffRequestDto nullData = new DiffRequestDto { Data = null };

            // Act

            var result = _controller.CreateLeftDiff(1, data);
            var nullResult = _controller.CreateLeftDiff(1, nullData);

            // Assert

            Assert.IsType<CreatedResult>(result);
            Assert.IsType<BadRequestResult>(nullResult);
        }

        [Fact]
        public void CreateRightDiff_Successfully_Creates_RightDiff()
        {
            // Arrange

            DiffRequestDto data = new DiffRequestDto { Data = "test" };
            DiffRequestDto nullData = new DiffRequestDto { Data = null };

            // Act

            var result = _controller.CreateRightDiff(1, data);
            var nullResult = _controller.CreateRightDiff(1, nullData);

            // Assert

            Assert.IsType<CreatedResult>(result);
            Assert.IsType<BadRequestResult>(nullResult);
        }

        [Fact]
        public void GetDiff_Returns_Diff_Details()
        {
            // Arrange

            LeftDiff left = _leftService.FindDiffById(1);
            RightDiff right = _rightService.FindDiffById(1);

            // Act

            var result = _controller.GetDiff(1);

            // Assert

            if (left == null || right == null)
                Assert.IsType<NotFoundResult>(result);
            else
                Assert.IsType<OkResult>(result);
        }
    }
}