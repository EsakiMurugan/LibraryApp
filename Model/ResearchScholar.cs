using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Model
{
    public class ResearchScholar
    {
        [Key]
        public int Id { get; set; } 
        public string ScholarNumber { get; set; }
        public string ScholarName { get; set; }
        public ICollection<Thesis> Thesis { get; set; }
    }
}
