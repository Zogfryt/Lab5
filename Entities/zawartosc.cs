using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lab5.Entities
{
    [Table("zawartosc", Schema = "cukiernia")]
    public partial class zawartosc
    {
        [Key]
        [StringLength(4)]
        public string idpudelka { get; set; } = null!;
        [Key]
        [StringLength(3)]
        public string idczekoladki { get; set; } = null!;
        public int sztuk { get; set; }

        [ForeignKey("idczekoladki")]
        [InverseProperty("zawartoscs")]
        public virtual czekoladki idczekoladkiNavigation { get; set; } = null!;
        [ForeignKey("idpudelka")]
        [InverseProperty("zawartoscs")]
        public virtual pudelka idpudelkaNavigation { get; set; } = null!;
    }
}
