using PSP_1_modelo;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PSP_1_control
{
    public static class ControlCalculo
    {
        /// <summary>
        /// Metodo: Encargado de buscar los archivos a ser procesados
        /// </summary>
        /// <param name="RutaDirectorio">Ruta del directorio donde se encuentra el codigo fuente</param>
        /// <param name="LenguajeProgramacion">Lenguaje de programación que se usara. Inicialmente solo disponible C#</param>
        /// <returns>Retorna la tabla con los calculos realizados</returns>
        public static String CalcularMetricas(String RutaDirectorio, String LenguajeProgramacion)
        {
            Estandar EstandarActivo;
            DirectoryInfo Directorio;

            if (!Directory.Exists(RutaDirectorio))
                throw new Exception("Directorio no existe.");

            Directorio = new DirectoryInfo(RutaDirectorio);

            EstandarActivo = (Estandar)ControlAplicacion.getInstancia().ColeccionEstandar.BuscarPorNombre(LenguajeProgramacion);

            if(EstandarActivo == null)
                throw new Exception("Lenguaje no soportado.");

            Archivo a;

            foreach (String Ext in EstandarActivo.Extensiones)
            {
                foreach (FileInfo Archivo in Directorio.GetFiles(Ext, SearchOption.AllDirectories))
                {
                    a = new Archivo();

                    a.Nombre = Archivo.Name;

                    CuentaLineasCodigo(a, Archivo, EstandarActivo);

                    ControlAplicacion.getInstancia().ColeccionArchivos.Agregar(a);
                }
            }

            return ControlGui.ProcesarSalida();
        }

        private static int tipoComentarioBloqueActual = -1;
        private static bool enBloqueComentado = false;

        /// <summary>
        /// Metodo que realiza el conteo de las metricas por archivo
        /// </summary>
        /// <param name="a">Objeto tipo archivo</param>
        /// <param name="arch">Objeto </param>
        /// <param name="EstandarActivo"></param>
        private static void CuentaLineasCodigo(Archivo a, FileInfo arch, Estandar EstandarActivo)
        {   
            using (StreamReader reader = File.OpenText(arch.FullName))
            {
                bool esVacia = false;
                bool esComentario = false;

                //Voy leyendo línea a línea y comprobamos si es una línea de código
                string linea = reader.ReadLine();
                while (linea != null)
                {
                    //Antes de nada comprueb si estoy en un bloque de comentario o no
                    if (enBloqueComentado)
                    {
                        esComentario = true;
                        //Ver si la línea actual cierra el comentario o no
                        if (EstandarActivo.TiposComentariosBloqueCierres[tipoComentarioBloqueActual].IsMatch(linea))
                        {
                            //Ya no estamos en un bloque a partir de ahora
                            enBloqueComentado = false;
                            tipoComentarioBloqueActual = -1;
                            /*
                            Con esta lógica, un caso en el que se contabilizarían mal líneas de código comentadas es cuando se cierra un comentario de bloque y se abre otro en la misma línea.
                            Lo considero un caso extremo que se dará muy poco (casi nunca) y asumo como un posible error de recuento mínimo en el total para no complicar el código.
                            */
                        }
                    }
                    else    //Línea de código normal, no dentro de un bloque comentado
                    {
                        //Veo si es una línea vacía (o solo con espacios/tabuladores)
                        esVacia = string.IsNullOrWhiteSpace(linea);

                        //Compruebo si es un comentario de los de una sola línea, los compruebo con las expresiones regulares
                        esComentario = false;
                        foreach (Regex r in EstandarActivo.TiposComentarioLineales)
                        {
                            if (r.IsMatch(linea))
                                esComentario = true;
                        }

                        if (new Regex(EstandarActivo.Metodos, RegexOptions.IgnoreCase).IsMatch(linea))
                            a.ContadorMetodos++;

                        //Verifico comentarios en varias líneas
                        //Primero veo si hay una apertura de comentario
                        for (int i = 0; i < EstandarActivo.TiposComentariosBloqueAperturas.Count; i++)
                        {
                            Regex r = EstandarActivo.TiposComentariosBloqueAperturas[i];

                            if (r.IsMatch(linea))  //Si es un comentario de bloque
                            {
                                //Debo comprobar antes de nada que no se cierre en la misma línea
                                if (!EstandarActivo.TiposComentariosBloqueCierres[i].IsMatch(linea))
                                {
                                    //Si el bloque actual no se cierra en esta misma línea, 
                                    //marco a partir de ahora todas las nuevas líneas como un bloque comentado
                                    //hasta que aparezca el bloque de cierre
                                    tipoComentarioBloqueActual = i; //para localizar la etiqueta de cierre del bloque
                                    enBloqueComentado = true;
                                }
                                esComentario = true;    //La línea actual es un comentario
                                break;  //Salgo del bucle
                                /*
                                NOTA: este código, tal y como está, no identificaría líneas de código que estén justo después del cierre de un comentario de código multi-línea.
                                Entiendo que este es un caso muy extremo que se dará muy poco frecuentemente (porque no tiene tampoco mucho sentido), y lo asumo como un posible error mínimo de recuento de líneas de código.
                                */
                            }
                        }
                    }
                    if (esComentario)
                        a.ContadorComentarios++;
                    else if (esVacia)
                        a.ContadorLineasBlancas++;
                    else
                        a.ContadorLineas++;
                    //Siguiente línea
                    linea = reader.ReadLine();
                }
            }
        }
    }
}
