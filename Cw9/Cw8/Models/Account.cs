using System.ComponentModel.DataAnnotations;

namespace Cw8.Models
{
    public class Account
    {
        [Key]
        public int IdAccount { get; set; }
        [Required]
        [MaxLength(30)]
        public string Login { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        [MaxLength(64)]
        public string Salt { get; set; }
        [Required]
        [MaxLength(64)]
        public string RefreshToken { get; set; }
       
    }
}
