using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    //clase repository (repository pattern) sunt clase care implementeaza operatiile CRUD pe Baza de Date
    public class AnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public AnnouncementsRepository(ProgrammingClubDataContext context) 
        {
            _context = context;
        }

        public DbSet<AnnouncementModel> GetAnnouncements()
        {
            return _context.Announcements;
        }

        public void Add(AnnouncementModel model)
        {
            model.IDAnnouncement = Guid.NewGuid(); //setam IDul, because it was deleted from the view

            _context.Announcements.Add(model); //adding the model in ORM(ProgrammingClubDataContext) layer
            _context.SaveChanges(); //commit to database
        }

        public AnnouncementModel GetAnnouncementById(Guid id)
        {
            AnnouncementModel announcement = _context.Announcements.FirstOrDefault(x => x.IDAnnouncement == id);
            return announcement;
        }


        public void Update(AnnouncementModel model) 
        {
            AnnouncementModel announcement = GetAnnouncementById(model.IDAnnouncement);
            if (announcement != null)
            {
                _context.Announcements.Update(model);
                _context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            AnnouncementModel announcement = GetAnnouncementById(id);
            if (announcement != null)
            {
                _context.Announcements.Remove(announcement);
                _context.SaveChanges();
            }
        }
    }
}
