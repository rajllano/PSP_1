using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSP_1_control;

namespace PSP_1_gui
{
    class Program
    {
        /// <summary>
        /// Funcion main de la aplicación y su punto de ejecución inicial
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            String RutaDirectorio = String.Empty;

            try
            {
                Console.WriteLine("****************************************************");
                Console.WriteLine("***              CONTADOR DE LINEAS              ***");
                Console.WriteLine("****************************************************");
                Console.WriteLine("Ruta del Directorio: ");

                RutaDirectorio = Console.ReadLine();

                Console.WriteLine("");

                Console.Write(ControlCalculo.CalcularMetricas(RutaDirectorio, "C#"));
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: [" + e.Message + "]");
            }
            finally
            {
                Console.ReadKey();

                GC.Collect();
            }
        }
    }
}
