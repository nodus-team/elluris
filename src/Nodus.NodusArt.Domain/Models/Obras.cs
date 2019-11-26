using Nodus.NodusArt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nodus.NodusArt.Domain.Models
{
    public class Obras : EntityBase
    {
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string UrlFoto { get; set; }
    }
}
