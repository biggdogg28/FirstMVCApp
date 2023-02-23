using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class CodeSnippetsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public CodeSnippetsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public DbSet<CodeSnippetModel> GetCodeSnippets() 
        {
            return _context.CodeSnippets;
        }
    }
}
