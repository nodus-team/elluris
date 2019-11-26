using Nodus.Elluris.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nodus.Elluris.Domain.Models
{
    public class EventoPeriodo : EntityBase
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
