using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POSApi.Models
{
    public class DescuentoPermitido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPermiso
        {
            get; set;
        }
        public int NoEmpleado
        {
            get; set;
        }
        public int IdDescuento
        {
            get; set;
        }
    }
}
