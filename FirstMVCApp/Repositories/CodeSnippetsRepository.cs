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

        public DbSet<CodeSnippetModel> GetCodeSnippets() // get all from table
        {
            return _context.CodeSnippets;
        }
        public void AddCodeSnippet(CodeSnippetModel model)
        {
            model.IDCodeSnippet = Guid.NewGuid(); //setam IDul, because it was deleted from the view

            // _context.Entry(model).State= EntityState.Added <<< Another method

            _context.CodeSnippets.Add(model); //adding the model in ORM(ProgrammingClubDataContext) layer
            _context.SaveChanges(); //commit to database
        }
        public CodeSnippetModel GetCodeSnippetById(Guid id) // get code snippet for a certain ID -> Page Details
        {
            CodeSnippetModel codeSnippet = _context.CodeSnippets.FirstOrDefault(x => x.IDCodeSnippet == id); 
            return codeSnippet;
        }

        public void UpdateCodeSnippet(CodeSnippetModel model)
        {
            _context.CodeSnippets.Update(model);
            _context.SaveChanges();
        }

        public void DeleteCodeSnippet(Guid id)
        {
            CodeSnippetModel codeSnippet = GetCodeSnippetById(id);
            _context.CodeSnippets.Remove(codeSnippet);
            _context.SaveChanges();
        }
    }
}
