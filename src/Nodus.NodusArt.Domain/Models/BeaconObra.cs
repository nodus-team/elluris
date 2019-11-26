using Nodus.NodusArt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nodus.NodusArt.Domain.Models
{
    public  class BeaconObra :EntityBase
    {
        public virtual Beacon Beacon { get; set; }
        public virtual Obras Obra { get; set; }
    }
}
