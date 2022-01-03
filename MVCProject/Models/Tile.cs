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

        public byte[] Photo { get; set; }

        public byte[] Thumb { get; set; }

        [Display(Name = "Datum vnosa")]
        [DataType(DataType.Date)] // Če ne želimo dodajati časa
        public DateTime DateInserted { get; set; }
    }

    public class TileViewIndex
    {
        public Guid TileID { get; set; }

        [Display(Name = "Naslov")] // Prikaz naziva polja
        public string Title { get; set; }

        [Display(Name = "Vsebina")]
        public string Content { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Datum vnosa")]
        public DateTime DateInserted { get; set; }
    }

    public class TileViewPublic
    {
        public Guid TileID { get; set; }

        [Display(Name = "Naslov")] // Prikaz naziva polja
        public string Title { get; set; }

        public byte[] Thumb { get; set; }

        public byte[] Photo { get; set; }
    }
}
