using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooxi.Models
{
    public class MeasureUnit
    {
        [Required]
        public Guid MeasureUnitId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Short { get; set; }
        [Required]
        public decimal Grams { get; set; }
    }
}
