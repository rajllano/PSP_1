using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSP_1_modelo
{
    public class Coleccion : IColeccion
    {
        private List<Object> Lista;

        /// <summary>
        /// Metodo: Constructor de la clase
        /// </summary>
        public Coleccion()
        {
            Lista = new List<Object>();
        }

        /// <summary>
        /// Metodo: Destructor de la clase
        /// </summary>
        ~Coleccion()
        {
            Lista = null;

            GC.Collect();
        }

        /// <summary>
        /// Metodo: Agregar un objeto a la coleccion
        /// </summary>
        /// <param name="o">Objeto que se desea agregar</param>
        public void Agregar(Object o)
        {
            Lista.Add(o);
        }

        /// <summary>
        /// Metodo: Retorna un elemento de la coleccion
        /// </summary>
        /// <param name="Indice">Indice del objeto en la coleccion</param>
        /// <returns>En caso de encontarse returna una referencia del objeto, en caso contrario retorna un null</returns>
        public Object Elemento(int Indice)
        {
            return Lista[Indice];
        }

        /// <summary>
        /// Metodo: Elimina un objeto de la coleccion
        /// </summary>
        /// <param name="o">Objeto que se desea eliminar</param>
        public void Eliminar(Object o)
        {
            Lista.Remove(o);
        }

        /// <summary>
        /// Metodo: Informa el tamaño de la coleccion
        /// </summary>
        /// <returns>Tamaño de la coleccion</returns>
        public int Size()
        {
            return Lista.Count();
        }
    }
}