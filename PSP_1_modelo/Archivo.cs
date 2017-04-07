using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSP_1_modelo
{
    public class Archivo
    {
        /// <summary>
        /// Metodo: constructor de la clase. Es el encargado de inicializar los contadores
        /// </summary>
        public Archivo()
        {
            this.ContadorLineas = 0;
            this.ContadorLineasBlancas = 0;
            this.ContadorComentarios = 0;
            this.ContadorMetodos = 0;
        }

        public String Nombre { get; set; }

        public int ContadorLineas { get; set; }

        public int ContadorLineasBlancas { get; set; }

        public int ContadorComentarios { get; set; }

        public int ContadorMetodos { get; set; }
    }
}