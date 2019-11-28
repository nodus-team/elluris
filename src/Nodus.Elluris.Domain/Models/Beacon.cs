using Nodus.Elluris.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Nodus.Elluris.Domain.Models
{
    public class Beacon : EntityBase
    {
        [Display(Name ="Código do Beacon")]
        public string BeaconCode { get; set; }
    }
}
