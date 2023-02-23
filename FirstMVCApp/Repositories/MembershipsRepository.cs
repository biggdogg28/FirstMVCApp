using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembershipsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public MembershipsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }
        public DbSet<MembershipModel> GetMemberships()
        {
            return _context.Memberships;
        }
    }
}
