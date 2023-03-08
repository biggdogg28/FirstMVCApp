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
        public void GetAllAnnouncements()
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
    }
}
