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
    }
}
