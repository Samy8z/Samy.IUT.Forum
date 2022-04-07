using System.ComponentModel.DataAnnotations;

namespace ADemabre.IUT.Forum.Ui.Models
{
    public class Categorie
    {
        public short Id { get; set; }        
        
        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string Nom { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"^[a-z][a-z\-]{3,}$", ErrorMessage = "La clé doit commencer par une lettre minuscule et non accentué et fait 3 lettres minimum")]
        public string Cle { get; set; }

        [Required]
        public short Order { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        public DateTime Creation { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Modification { get; set; } = DateTime.UtcNow;

        public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }
}
