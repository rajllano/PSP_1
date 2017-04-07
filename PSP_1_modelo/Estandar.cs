using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PSP_1_modelo
{
    public class Estandar
    {
        /// <summary>
        /// Metodo: constructor sin parametros
        /// </summary>
        public Estandar()
        {
        }

        /// <summary>
        /// Metodo: constructor que recibe todos los atributos de la clase para inicializarla
        /// </summary>
        /// <param name="Lenguaje">Lenguaje al que pertenece la parametrización</param>
        /// <param name="Extenciones">Extenciones de archivo en las que se contiene el codigo fuente</param>
        /// <param name="TiposComentarioLineales">Expresion regular para identificar un comentario lineal</param>
        /// <param name="TiposComentariosBloqueAperturas">Expresion regular para identificar apertura de comentarios multilinea</param>
        /// <param name="TiposComentariosBloqueCierres">Expresión regular para identificar cierre de comentarios multilinea</param>
        /// <param name="Metodos">Cadena identificadora de un metodo</param>
        public Estandar(String Lenguaje, String Extenciones, String TiposComentarioLineales, String TiposComentariosBloqueAperturas, String TiposComentariosBloqueCierres, String Metodos)
        {
            this.Lenguaje = Lenguaje;

            this.Extensiones = new List<string>();

            foreach (string Cadena in Extenciones.ToString().Split(','))
            {
                this.Extensiones.Add(Cadena);
            }

            this.TiposComentarioLineales = new List<Regex>();

            foreach (string Cadena in TiposComentarioLineales.ToString().Split(','))
            {
                this.TiposComentarioLineales.Add(new Regex(Cadena, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline));
            }

            this.TiposComentariosBloqueAperturas = new List<Regex>();

            foreach (string Cadena in TiposComentariosBloqueAperturas.ToString().Split(','))
            {
                this.TiposComentariosBloqueAperturas.Add(new Regex(Cadena));
            }

            this.TiposComentariosBloqueCierres = new List<Regex>();

            foreach (string Cadena in TiposComentariosBloqueCierres.ToString().Split(','))
            {
                this.TiposComentariosBloqueCierres.Add(new Regex(Cadena));
            }

            this.Metodos = Metodos;
        }

        public string Lenguaje { get; set; }

        public List<String> Extensiones { get; set; }

        public List<Regex> TiposComentarioLineales { get; set; }

        public List<Regex> TiposComentariosBloqueAperturas { get; set; }

        public List<Regex> TiposComentariosBloqueCierres { get; set; }

        public String Metodos { get; set; }
    }
}