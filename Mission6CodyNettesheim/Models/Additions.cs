using System.ComponentModel.DataAnnotations;

namespace Mission6CodyNettesheim.Models
{
    public class Additions
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? Lent { get; set; }
        [MaxLength(25)]
        public string? Notes {  get; set; }

        
    }
}
