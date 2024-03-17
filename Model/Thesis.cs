using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LibraryApp.Model
{
    public class Thesis
    {
        [Key]
        public int Id { get; set; }
        public int ScholarId {  get; set; }
        [ForeignKey(nameof(ScholarId))]
        public virtual ResearchScholar ResearchScholar { get; set; }

        public string Publisher { get; set; }
        public string Title { get; set; }
    }
}
