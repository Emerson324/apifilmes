using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace apifilmes.Models
{
    [Table("tb_filme")]
    public partial class TbFilme
    {
        public TbFilme()
        {
            TbDiretors = new HashSet<TbDiretor>();
            TbFilmeAtors = new HashSet<TbFilmeAtor>();
        }

        [Key]
        [Column("id_filme")]
        public int IdFilme { get; set; }
        [Column("nm_filme")]
        [StringLength(100)]
        public string NmFilme { get; set; }
        [Column("ds_genero")]
        [StringLength(100)]
        public string DsGenero { get; set; }
        [Column("nr_duracao")]
        public int? NrDuracao { get; set; }
        [Column("vl_avaliacao")]
        public decimal? VlAvaliacao { get; set; }
        [Column("bt_disponivel")]
        public bool? BtDisponivel { get; set; }
        [Column("dt_lancamento", TypeName = "date")]
        public DateTime? DtLancamento { get; set; }

        [InverseProperty(nameof(TbDiretor.IdFilmeNavigation))]
        public virtual ICollection<TbDiretor> TbDiretors { get; set; }
        [InverseProperty(nameof(TbFilmeAtor.IdFilmeNavigation))]
        public virtual ICollection<TbFilmeAtor> TbFilmeAtors { get; set; }
    }
}
