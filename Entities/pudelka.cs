using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lab5.Entities
{
    [Table("pudelka", Schema = "cukiernia")]
    public partial class pudelka
    {
        public pudelka()
        {
            artykulies = new HashSet<artykuly>();
            zawartoscs = new HashSet<zawartosc>();
        }

        [Key]
        [StringLength(4)]
        public string idpudelka { get; set; } = null!;
        [StringLength(40)]
        public string nazwa { get; set; } = null!;
        [StringLength(150)]
        public string? opis { get; set; }
        [Precision(7, 2)]
        public decimal cena { get; set; }
        public int stan { get; set; }

        [InverseProperty("idpudelkaNavigation")]
        public virtual ICollection<artykuly> artykulies { get; set; }
        [InverseProperty("idpudelkaNavigation")]
        public virtual ICollection<zawartosc> zawartoscs { get; set; }
    }
}
