using Nodus.Elluris.Domain.Entities;
using Nodus.Elluris.Domain.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nodus.Elluris.Domain.Models
{
    public class EventoPeriodo : EntityBase
    {
        public EventoPeriodo()
        {
            PeriodoExtenso = ToString();
        }

        [Display(Name = "Data Inicial do Evento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicial { get; set; }
        [Display(Name = "Data Final do Evento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFinal { get; set; }
        public string PeriodoExtenso { get; set; }

        public override string ToString()
        {
            return this.DataInicial.ToBrazilianDate() + " - " + this.DataFinal.ToBrazilianDate();
        }
    }
}
