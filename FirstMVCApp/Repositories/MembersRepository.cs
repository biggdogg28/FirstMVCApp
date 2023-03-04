using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembersRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public MembersRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public DbSet<MemberModel> GetMembers()
        {
            return _context.Members;
        }

        public void Add(MemberModel model)
        {
            model.IDMember = Guid.NewGuid(); //setam IDul, because it was deleted from the view

            _context.Members.Add(model); //adding the model in ORM(ProgrammingClubDataContext) layer
            _context.SaveChanges(); //commit to database
        }

        public MemberModel GetMemberById(Guid id)
        {
            MemberModel model = _context.Members.FirstOrDefault(x => x.IDMember == id);
            return model;
        }

        public void Update(MemberModel model)
        {
            _context.Members.Update(model);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            MemberModel member = GetMemberById(id);
            _context.Members.Remove(member);
            _context.SaveChanges();
        }
    }
}
