using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lab5.Entities
{
    [Table("klienci", Schema = "cukiernia")]
    public partial class klienci
    {
        public klienci()
        {
            zamowienia = new HashSet<zamowienium>();
        }

        [Key]
        public int idklienta { get; set; }
        [StringLength(130)]
        public string nazwa { get; set; } = null!;
        [StringLength(30)]
        public string ulica { get; set; } = null!;
        [StringLength(15)]
        public string miejscowosc { get; set; } = null!;
        [StringLength(6)]
        public string kod { get; set; } = null!;
        [StringLength(20)]
        public string telefon { get; set; } = null!;

        [InverseProperty("idklientaNavigation")]
        public virtual ICollection<zamowienium> zamowienia { get; set; }
    }
}
