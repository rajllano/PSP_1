using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSP_1_modelo;

namespace PSP_1_control
{
    public static class ControlGui
    {
        /// <summary>
        /// Metodo: se encarga de procesar el procesamiento de los archivos
        /// </summary>
        /// <returns>Cadena con la tabla de resultados para presentar al usuario</returns>
        public static String ProcesarSalida()
        {
            Archivo a;

            String Respuesta = String.Empty;
            int ContadorMetodos = 0;
            int ContadorComentarios = 0;
            int ContadorLineasBlancas = 0;
            int ContadorLineas = 0;

            Respuesta += String.Format("| {0,30} | {1,15} | {2,15} | {3,15} | {4,15} |\n", "Nombre", "Metodos", "Comentarios", "LineasBlancas", "Lineas");

            for (int x=0;x<ControlAplicacion.getInstancia().ColeccionArchivos.Size();x++)
            {
                a = (Archivo)ControlAplicacion.getInstancia().ColeccionArchivos.Elemento(x);

                if(a != null)
                { 
                    Respuesta += String.Format("| {0,30} | {1,15} | {2,15} | {3,15} | {4,15} |\n", a.Nombre, a.ContadorMetodos, a.ContadorComentarios, a.ContadorLineasBlancas, a.ContadorLineas);

                    ContadorMetodos += a.ContadorMetodos;
                    ContadorComentarios += a.ContadorComentarios;
                    ContadorLineasBlancas += a.ContadorLineasBlancas;
                    ContadorLineas += a.ContadorLineas;
                }
            }

            Respuesta += String.Format("| {0,30} | {1,15} | {2,15} | {3,15} | {4,15} |\n", ControlAplicacion.getInstancia().ColeccionArchivos.Size(), ContadorMetodos, ContadorComentarios, ContadorLineasBlancas, ContadorLineas);

            return Respuesta;
        }
    }
}
