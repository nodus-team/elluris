using Nodus.Elluris.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nodus.Elluris.Domain.Models
{
    public class Evento : EntityBase
    {
        [ForeignKey("EventoPeriodo")]
        [Display(Name = "Periodo do Evento")]
        public Guid EventoPeriodoId { get; set; }
        public virtual EventoPeriodo EventoPeriodo { get; set; }
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
        [Display(Name ="Observação")]
        public string Observacao { get; set; }

    }
}
