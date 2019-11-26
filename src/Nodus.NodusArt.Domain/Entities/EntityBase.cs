using System;
using System.Collections.Generic;
using System.Text;

namespace Nodus.NodusArt.Domain.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
            this.DataAtualizacao = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
