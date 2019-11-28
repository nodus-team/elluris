using Nodus.Elluris.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nodus.Elluris.Domain.Models
{
    public class Obras : EntityBase
    {
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public string UrlFoto { get; set; }
    }
}
