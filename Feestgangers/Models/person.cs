using System.ComponentModel.DataAnnotations;

namespace Feestgangers.Models
{
    public class Person
    {
        [Required(ErrorMessage ="Wij zouden het erg op prijs stellen als u uw voornaam invult")]
        public string Firstname { get; set; }
        [Required(ErrorMessage ="Het opgeven van een achternaam is verplicht")]
        public string Lastname { get; set; }
        [Required(ErrorMessage ="Emailadres is verplicht")]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Adress { get; set; }

        public string Description { get; set; }

    }
}
