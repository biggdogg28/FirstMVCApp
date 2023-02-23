using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembershipTypesRespository
    {
        private readonly ProgrammingClubDataContext _context;
        public MembershipTypesRespository(ProgrammingClubDataContext context)
        {
            _context = context;
        }
        public DbSet<MembershipTypeModel> GetMembershipTypes()
        {
            return _context.MembershipTypes;
        }
    }
}
