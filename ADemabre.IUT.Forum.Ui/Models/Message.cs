using System.ComponentModel.DataAnnotations;

namespace ADemabre.IUT.Forum.Ui.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid SujetId { get; set; }
        public Sujet Sujet { get; set; }
        public int UserId { get; set; }      
        public User User { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        public DateTime Creation { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Modification { get; set; }
    }
}
