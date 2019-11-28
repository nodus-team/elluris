using Nodus.Elluris.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nodus.Elluris.Domain.Models
{
    public class EventoPeriodo : EntityBase
    {

        [Display(Name = "Data Inicial do Evento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicial { get; set; }
        [Display(Name = "Data Final do Evento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFinal { get; set; }

    }
}
