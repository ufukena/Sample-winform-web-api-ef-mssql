using System.ComponentModel.DataAnnotations;

namespace ContactList.Domain.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string NameSurname { get; set; }

        [Required, MaxLength(50)]
        public string Phone { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

    }
}
