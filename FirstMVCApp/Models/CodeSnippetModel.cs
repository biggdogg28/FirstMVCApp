using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class CodeSnippetModel
    {
        [Key]
        public Guid IDCodeSnippet { get; set; }

        [StringLength(100, ErrorMessage = "The title must be 100 characters max!")]
        public string Title { get; set; }

        public string ContentCode { get; set; }
        
        public Guid IDMember { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Revision number should be positive!")]
        public int Revision { get; set; }

        public DateTime DateTimeAdded { get; set; }

        public bool IsPublished { get; set; }
    }
}
