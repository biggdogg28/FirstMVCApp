using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstMVCApp.Test.Helpers;
using Microsoft.Identity.Client;

namespace FirstMVCApp.Test.RepositoriesTests
{
    [TestClass]
    public class AnnouncementsRespositoryTests
    {
        private readonly AnnouncementsRepository _repository;
        private readonly ProgrammingClubDataContext _contextInMemory;

        public AnnouncementsRespositoryTests()
        {
            _contextInMemory = Helpers.DBContextHelper.GetDatabaseContext();
            _repository = new AnnouncementsRepository(_contextInMemory);
        }


        [TestMethod]
        public void GetAllAnnouncements_ExistAnnouncements()
        {

            // Arrange
            AnnouncementModel announcement1 = new AnnouncementModel()
            {
                IDAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2023, 05, 02),
                ValidTo = new DateTime(2023, 05, 02),
                EventDate = new DateTime(2023, 05, 02),
                Tags = "Tags1",
                Text = "Announcement",
                Title = "Event1",
            };

            AnnouncementModel announcement3 = new AnnouncementModel()
            {
                EventDate = new DateTime(2022, 05, 02),
                IDAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2022, 08, 06),
                ValidTo = new DateTime(2021, 06, 5),
                Tags = "Tag",
                Title = "title",
                Text = "Dexter"
            };

            AnnouncementModel announcement2 = new AnnouncementModel()
            {
                IDAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2023, 05, 02),
                ValidTo = new DateTime(2023, 05, 02),
                EventDate = new DateTime(2023, 05, 02),
                Tags = "Tags2",
                Text = "Announcement2",
                Title = "Event2",
            };

            List<AnnouncementModel> newList = new List<AnnouncementModel>();
            newList.Add(announcement3);

            List<AnnouncementModel> list = new List<AnnouncementModel>();
            list.Add(announcement1);
            list.Add(announcement2);
            list.Add(announcement3);
            Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement1);
            Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement2);
            Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement3);




            // Act 
            List<AnnouncementModel> dbAnnouncements = _repository.GetAnnouncements().ToList();


            // Assert

            Assert.AreEqual(list.Count, dbAnnouncements.Count);

            // Assert.AreEqual("Event1", list.First().Tags);
        }

        [TestMethod]
        public void GetAnnouncements_WithoutDataInDB()
        {
            //Act
            List<AnnouncementModel> dbAnnouncements = _repository.GetAnnouncements().ToList();

            //Assert
            Assert.AreEqual(0, dbAnnouncements.Count);
        }

        [TestMethod]
        public void GetAnnouncementById()
        {
            //Arrange
            AnnouncementModel announcement1 = new AnnouncementModel()
            {
                IDAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2023, 05, 02),
                ValidTo = new DateTime(2023, 05, 02),
                EventDate = new DateTime(2023, 05, 02),
                Tags = "Tags2",
                Text = "Announcement2",
                Title = "Event2",
            };
            AnnouncementModel announcement = Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement1);

            Guid id = (Guid)announcement1.IDAnnouncement;

            //Act
            var result = _repository.GetAnnouncementById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(announcement1.Title, result.Title);
            Assert.AreEqual(announcement1.Tags, result.Tags);
            Assert.AreEqual(announcement1.ValidFrom, result.ValidFrom);
            Assert.AreEqual(announcement1.ValidTo, result.ValidTo);
            Assert.AreEqual(announcement1.EventDate, result.EventDate);

        }

        [TestMethod]
        public void GetAnnouncementById_WhenNotExists()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            //Act
            var result = _repository.GetAnnouncementById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteAnnouncemenet_AnnouncemenetNotExist()
        {

            //Arrage
            Guid id = Guid.NewGuid();


            //Act
            _repository.Delete(id);
            var result = _repository.GetAnnouncementById(id);

            //Assert
            Assert.IsNull(result);


        }

        [TestMethod]
        public void DeleteAnnouncemenet_AnnouncemenetExist()
        {
            //Assert
            Guid id = Guid.NewGuid();

            AnnouncementModel announcement1 = new AnnouncementModel()
            {
                IDAnnouncement = id,
                ValidFrom = new DateTime(2023, 05, 02),
                ValidTo = new DateTime(2023, 05, 02),
                EventDate = new DateTime(2023, 05, 02),
                Tags = "Tags2",
                Text = "Announcement2",
                Title = "Event2",
            };
            AnnouncementModel announcement = Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement1);

            //Act
            _repository.Delete(id);
            var result = _repository.GetAnnouncementById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateAnnouncement_AnnouncementExist()
        {
            AnnouncementModel announcement1 = new AnnouncementModel
            {
                IDAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "tags1",
                Text = "Announcemment",
                Title = "Event1",
            };
            AnnouncementModel announcement = Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement1);
            announcement.Tags = "tagsUpdated";
            _repository.Update(announcement);

            AnnouncementModel updatedModel = _repository.GetAnnouncementById((Guid)announcement1.IDAnnouncement);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual(announcement.Tags, updatedModel.Tags);
        }

        public void UpdateAnnouncement_AnnouncementNotExists()
        {
            AnnouncementModel announcement1 = new AnnouncementModel
            {
                IDAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "tags1",
                Text = "Announcemment",
                Title = "Event1",
            };

            _repository.Update(announcement1);

            AnnouncementModel updatedModel = _repository.GetAnnouncementById((Guid)announcement1.IDAnnouncement);

            Assert.IsNull(updatedModel);
        }

    }
}
