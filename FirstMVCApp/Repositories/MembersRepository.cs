using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using FirstMVCApp.ViewModel;
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

        public MemberCodeSnippetViewModel GetMemberCodeSnippet(Guid memberId)
        {
            MemberCodeSnippetViewModel memberCodeSnippetViewModel = new MemberCodeSnippetViewModel();
            MemberModel member = _context.Members.FirstOrDefault(x => x.IDMember == memberId);
            if (member != null)
            {
                memberCodeSnippetViewModel.Name = member.Name;

                memberCodeSnippetViewModel.Position = member.Position;
                memberCodeSnippetViewModel.Title = member.Title;
                
                // ToList() is executed on the database directly and it returns everything which is filtered

                // Only at the return is there a .ToList() 

                // difference between IQueryable vs IEnumerable
                // IQueryable prepares a query but does not execute it on the database
                // IQueryable is used when there are custom filters >>>>> Vandut de: emag, x, y, z
                // pret intre: 10000 - 20000
                // livrare: emag genius

                IQueryable<CodeSnippetModel> memberCodeSnippets = _context.CodeSnippets.Where(x => x.IDMember == memberId);

                foreach (CodeSnippetModel dbCodeSnippet in memberCodeSnippets)
                {
                    memberCodeSnippetViewModel.CodeSnippets.Add(dbCodeSnippet);
                }
            }

            return memberCodeSnippetViewModel;
        }
    }
}
