using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class Tile
    {
        [Key]   // Določimo PrimaryKey modela
        public Guid TileID { get; set; }

        [Display(Name = "Naslov")] // Prikaz naziva polja
        [Required(ErrorMessage = "Naslov morate obvezno vnesti!")] // Določimo, če je vrednost obvezna
        public string Title { get; set; }

        [Display(Name = "Vsebina")]
        public string Content { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Datum vnosa")]
        [DataType(DataType.Date)] // Če ne želimo dodajati časa
        public DateTime DateInserted { get; set; }
    }
}
