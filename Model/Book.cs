using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Model
{
    public class Book 
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Publisher { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(20)]
        public string AuthorLastName { get; set; }

        [MaxLength(20)]
        public string AuthorFirstName { get; set; }

        [NotMapped]
        public string AuthorName => $"{AuthorLastName}, {AuthorFirstName}";

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Price {  get; set; }

        //MLA Property
        [MaxLength(50)]
        public string? TitleOfContainer { get; set; }

        [MaxLength(10)]
        public string? PublicationYear { get; set; }

        [MaxLength(50)]
        public string? Location { get; set; }

        [MaxLength(10)]
        public string? PageNumbers { get; set; }

        [NotMapped]
        public string Citation => $"{AuthorName}. \"{Title}\". {(TitleOfContainer?.Length > 0 ? $"*{TitleOfContainer}*" : "")}, {Publisher}, {(PublicationYear?.Length > 0 ? $"{PublicationYear}" : "")}, {(Location?.Length > 0 ? $"{Location}" : "")}{(PageNumbers?.Length > 0 ? $". {PageNumbers}" : "")}";

        // Chicago Property
        public string? VolumeNo {  get; set; }  

        public string? Url { get; set; }

        [NotMapped]
        public string Chicago => $"{(Title?.Length > 0 ? $"*{Title}*," : "")}{VolumeNo}{$"({PublicationYear})"}{$": {PageNumbers}."}{Url}";
    }
}


