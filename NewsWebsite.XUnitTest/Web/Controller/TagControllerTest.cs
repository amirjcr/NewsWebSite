using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NewsWebsite.Areas.Admin.Controllers;
using NewsWebsite.Data.Contracts;
using NewsWebsite.Entities;
using NewsWebsite.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewsWebsite.XUnitTest.Web.Controller
{
    public class TagControllerTest
    {
        private readonly Mock<IUnitOfWork> _moqIUnitOfWork;
        private readonly Mock<IMapper> _moqIMapper;
        private readonly TagController _controller;

        public TagControllerTest()
        {
            _moqIUnitOfWork = new Mock<IUnitOfWork>();
            _moqIMapper = new Mock<IMapper>();
            _controller = new TagController(_moqIUnitOfWork.Object, _moqIMapper.Object);
        }

        [Fact]
        public async Task NotSaveDataWhenModelErrorForCreateOrUpdateAction()
        {
            _controller.ModelState.AddModelError("x", "Test error");
            await _controller.CreateOrUpdate(null);

            _moqIUnitOfWork.Verify(x => x.BaseRepository<Tag>().CreateAsync(It.IsAny<Tag>()), Times.Never);
        }

        [Fact]
        public async Task SaveDataWhenNotModelErrorForCreateOrUpdateAction()
        {
            _moqIUnitOfWork.Setup(x => x.BaseRepository<Tag>().CreateAsync(It.IsAny<Tag>()))
              .Returns(Task.CompletedTask);

            _moqIUnitOfWork.Setup(x => x.Commit())
             .Returns(Task.CompletedTask);


            var tag = new TagViewModel { TagName = "ایران" };


            _moqIUnitOfWork.Setup(x => x.TagRepository.IsExistTag(tag.TagName, null))
                .Returns(false);

            _controller.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());

            await _controller.CreateOrUpdate(tag);

            _moqIUnitOfWork.Verify(x => x.BaseRepository<Tag>().CreateAsync(It.IsAny<Tag>()), Times.Once);
        }
    }
}
