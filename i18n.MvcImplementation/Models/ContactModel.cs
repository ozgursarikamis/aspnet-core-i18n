using System.ComponentModel.DataAnnotations;

namespace i18n.MvcImplementation.Models
{
    public class ContactModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(500)]
        public string Comment { get; set; }
    }
}
