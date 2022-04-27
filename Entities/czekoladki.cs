using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lab5.Entities
{
    [Table("czekoladki", Schema = "cukiernia")]
    public partial class czekoladki
    {
        public czekoladki()
        {
            zawartoscs = new HashSet<zawartosc>();
        }

        [Key]
        [StringLength(3)]
        public string idczekoladki { get; set; } = null!;
        [StringLength(30)]
        public string nazwa { get; set; } = null!;
        [StringLength(15)]
        public string? czekolada { get; set; }
        [StringLength(15)]
        public string? orzechy { get; set; }
        [StringLength(15)]
        public string? nadzienie { get; set; }
        [StringLength(100)]
        public string opis { get; set; } = null!;
        [Precision(7, 2)]
        public decimal koszt { get; set; }
        public int masa { get; set; }

        [InverseProperty("idczekoladkiNavigation")]
        public virtual ICollection<zawartosc> zawartoscs { get; set; }
    }
}
