using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melygarazs.Models
{
    public class Parkolas
    {
        [Key]
        public int Sorszam { get; set; }
        public string Rendszam { get; set; }
        public DateTime Kezdete { get; set; }
        public DateTime? Vege { get; set; }
    }
}
