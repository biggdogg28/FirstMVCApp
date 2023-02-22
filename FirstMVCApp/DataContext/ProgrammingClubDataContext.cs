using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.DataContext
{
    public class ProgrammingClubDataContext : DbContext
    {
        public ProgrammingClubDataContext(DbContextOptions<ProgrammingClubDataContext> options) : base(options) { }

        public DbSet <AnnouncementModel> Announcements { get; set; }

        //public DbSet<CodeSnippetModel> CodeSnippets { get; set; }

    }
}
