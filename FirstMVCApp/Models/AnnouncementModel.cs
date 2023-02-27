using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class AnnouncementModel
    {
        [Key]
        public Guid? IDAnnouncement { get; set; }
        [Required(ErrorMessage = "This field is mandatory.")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        public DateTime ValidTo { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        [StringLength(251, ErrorMessage = "Title field can be 250 characters maximum.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        [StringLength(250, ErrorMessage = "Text field can be 250 characters maximum.")]
        [MinLength(20, ErrorMessage = "Min Lenght 20.")]
        public string Text { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        [StringLength(1000, ErrorMessage = "Tags field can be 1000 characters maximum.")]
        public string Tags { get; set; }
    }

}
