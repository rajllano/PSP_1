using PSP_1_modelo;

namespace PSP_1_control
{
    public static class ControlAplicacion
    {
        private static Aplicacion a = null;

        /// <summary>
        /// Metodo: Singleton del modelo de la aplicación
        /// </summary>
        /// <returns></returns>
        public static Aplicacion getInstancia()
        {
            if (a == null)
                a = new Aplicacion();

            return a;
        }
    }
}
