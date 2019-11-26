using Nodus.NodusArt.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nodus.NodusArt.Domain.Models
{
    public class Evento : EntityBase
    {
        [ForeignKey("EventoPeriodo")]
        [Display(Name = "Periodo do Evento")]
        public Guid EventoPeriodoId { get; set; }
        public virtual EventoPeriodo EventoPeriodo { get; set; }

        public string Descricao { get; set; }
        public string Observacao { get; set; }
    }
}
