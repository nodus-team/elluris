using Nodus.NodusArt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nodus.NodusArt.Domain.Models
{
    public class ObraEvento : EntityBase
    {
        public int Id_Obra { get; set; }
        public int Id_Evento { get; set; }
    }
}
