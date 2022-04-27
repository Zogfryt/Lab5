using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lab5.Entities
{
    [Table("artykuly", Schema = "cukiernia")]
    public partial class artykuly
    {
        [Key]
        public int idzamowienia { get; set; }
        [Key]
        [StringLength(4)]
        public string idpudelka { get; set; } = null!;
        public int sztuk { get; set; }

        [ForeignKey("idpudelka")]
        [InverseProperty("artykulies")]
        public virtual pudelka idpudelkaNavigation { get; set; } = null!;
        [ForeignKey("idzamowienia")]
        [InverseProperty("artykulies")]
        public virtual zamowienium idzamowieniaNavigation { get; set; } = null!;
    }
}
