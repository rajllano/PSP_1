using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PSP_1_modelo
{
    public class Aplicacion
    {
        /// <summary>
        /// Metodo: Constructor de la clase
        /// </summary>
        public Aplicacion()
        {
            this.ColeccionEstandar = new PSP_1_modelo.ColeccionEstandar();
            this.ColeccionArchivos = new PSP_1_modelo.ColeccionArchivos();
        }

        /// <summary>
        /// Metodo: Destructor de la clase
        /// </summary>
        ~Aplicacion()
        {
            this.ColeccionEstandar = null;
            this.ColeccionArchivos = null;

            GC.Collect();
        }

        public ColeccionEstandar ColeccionEstandar { get; set; }

        public ColeccionArchivos ColeccionArchivos { get; set; }
    }
}