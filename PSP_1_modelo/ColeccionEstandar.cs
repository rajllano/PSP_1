using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PSP_1_modelo
{
    /// <summary>
    /// Clase encargada de guardar el listado de Estandares
    /// </summary>
    public class ColeccionEstandar : Coleccion
    {
        /// <summary>
        /// Metodo: inicializa los parametros para el lenguaje C#
        /// En este punto se recomiendaria a futuro cargar un archivo 
        /// de configuración con los parametros de los lenguajes
        /// soportados por la aplicación
        /// </summary>
        public ColeccionEstandar()
        {
            Estandar e = new PSP_1_modelo.Estandar
                (
                    "C#",
                    "*.js,*.json,*.htm,*.html,*.cs", 
                    @"^[\s\t]*//.*?$,^[\s\t]*'.*?$", 
                    @".*/\*.*", 
                    @".*\*/",
                    @"\bMetodo\w*\b"
                );

            this.Agregar(e);
        }

        /// <summary>
        /// Metodo encargado de buscar en la coleccion de Estandares por el nombre
        /// </summary>
        /// <param name="Nombre">Nombre del estandar a buscar</param>
        /// <returns>En caso de encontrar coincidencia retorna referencia del objeto, caso contrario retorna null</returns>
        public Estandar BuscarPorNombre(String Nombre)
        {
            Estandar e = null;

            for(int x=0;x<this.Size();x++)
            {
                e = (Estandar)this.Elemento(x);

                if (e.Lenguaje.Equals(Nombre))
                    return e;
            }

            return e;
        }
    }
}