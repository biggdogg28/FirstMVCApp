using FirstMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVCApp.Test.RepositoriesTests
{
    [TestClass]
    internal class AnnouncementsRespositoryTests
    {
        [TestMethod]
        public void GetAllAnnouncements()
        {
            // Arrange
            AnnouncementModel announcement1 = new AnnouncementModel
            {
                IDAnnouncement = Guid.NewGuid(),
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.Now,
                EventDate = DateTime.Now,
                Tags = "Tags1",
                Text = "Announcement",
                Title = "Event1",
            };

            AnnouncementModel announcement2 = new AnnouncementModel
            {
                IDAnnouncement = Guid.NewGuid(),
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.Now,
                EventDate = DateTime.Now,
                Tags = "Tags1",
                Text = "Announcement",
                Title = "Event1",
            };

            List<AnnouncementModel> list = new List<AnnouncementModel>();
            list.Add(announcement1);
            list.Add(announcement2);

            // Act 
            


            // Assert

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Event1", list.First().Tags);
        }
    }
}
