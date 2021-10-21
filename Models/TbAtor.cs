using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace apifilmes.Models
{
    [Table("tb_ator")]
    public partial class TbAtor
    {
        public TbAtor()
        {
            TbFilmeAtors = new HashSet<TbFilmeAtor>();
        }

        [Key]
        [Column("id_ator")]
        public int IdAtor { get; set; }
        [Column("nm_ator")]
        [StringLength(100)]
        public string NmAtor { get; set; }
        [Column("vl_altura")]
        public decimal? VlAltura { get; set; }
        [Column("dt_nascimento", TypeName = "date")]
        public DateTime? DtNascimento { get; set; }

        [InverseProperty(nameof(TbFilmeAtor.IdAtorNavigation))]
        public virtual ICollection<TbFilmeAtor> TbFilmeAtors { get; set; }
    }
}
