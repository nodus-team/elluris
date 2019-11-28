using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nodus.Elluris.Domain.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
            this.DataAtualizacao = DateTime.Now;
        }

        public Guid Id { get; set; }
        [Display(Name = "Data de Atualização")]
        public DateTime DataAtualizacao { get; set; }
    }
}
