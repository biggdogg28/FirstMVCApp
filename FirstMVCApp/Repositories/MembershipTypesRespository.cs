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
        public void Add(MembershipTypeModel model)
        {
            model.IDMembershipType = Guid.NewGuid(); //setam IDul, because it was deleted from the view

            _context.MembershipTypes.Add(model); //adding the model in ORM(ProgrammingClubDataContext) layer
            _context.SaveChanges(); //commit to database
        }

        public MembershipTypeModel GetMembershipTypesById(Guid id)
        {
            MembershipTypeModel model = _context.MembershipTypes.FirstOrDefault(x => x.IDMembershipType == id);
            return model;
        }

        public void Update(MembershipTypeModel model)
        {
            _context.MembershipTypes.Update(model);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            MembershipTypeModel membershipType = GetMembershipTypesById(id);
            _context.MembershipTypes.Remove(membershipType);
            _context.SaveChanges();
        }
    }
}
