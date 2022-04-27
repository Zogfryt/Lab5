using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lab5.Entities
{
    [Table("zamowienia", Schema = "cukiernia")]
    public partial class zamowienium
    {
        public zamowienium()
        {
            artykulies = new HashSet<artykuly>();
        }

        [Key]
        public int idzamowienia { get; set; }
        public int idklienta { get; set; }
        public DateOnly datarealizacji { get; set; }

        [ForeignKey("idklienta")]
        [InverseProperty("zamowienia")]
        public virtual klienci idklientaNavigation { get; set; } = null!;
        [InverseProperty("idzamowieniaNavigation")]
        public virtual ICollection<artykuly> artykulies { get; set; }
    }
}
