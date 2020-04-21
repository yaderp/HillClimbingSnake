using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB01_IA.ViewModel
{
    public class DatosViewModel
    {
        public int ID { set; get; }

        public string Velocidad { set; get; }

        public DatosViewModel(int ID,string Velocidad)
        {
            this.ID = ID;
            this.Velocidad = Velocidad;
        }

    }
}
