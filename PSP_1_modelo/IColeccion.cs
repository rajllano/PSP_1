using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSP_1_modelo
{
    public interface IColeccion
    {
        /// <summary>
        /// Agrega un objeto a la colección
        /// </summary>
        /// <param name="o">Objeto que se agregara a la colección</param>
        void Agregar(Object o);

        /// <summary>
        /// Elimina un objeto de la coleccón
        /// </summary>
        /// <param name="o">Objeto que se desea eliminar</param>
        void Eliminar(Object o);

        /// <summary>
        /// Retorna el elemento actual de la colección
        /// </summary>
        /// <param name="Indice">Posición en la colección de un elemento de la colección</param>
        /// <returns></returns>
        Object Elemento(int Indice);

        /// <summary>
        /// Tamaño de la colección
        /// </summary>
        /// <returns></returns>
        int Size();
    }
}