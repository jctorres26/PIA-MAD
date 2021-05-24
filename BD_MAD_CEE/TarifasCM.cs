using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_MAD_CEE
{
    class TarifasCM
    {
        public string Tipo_Servicio { get; set; }

        public int Mes { get; set; }
        public int Anio { get; set; }

        public float Basico { get; set; }
        public float Intermedio { get; set; }
        public float Excedente { get; set; }
    }
}
