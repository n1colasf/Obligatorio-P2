using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Canal
    {
        #region Atributos
        private string nombre;
        private int resolucion;
        private bool multiLenguaje;
        private decimal precio;
        private int id;
        private static int contadorId;
        #endregion
        #region Propiedades
        public decimal Precio
        {
            get { return precio; }
        }
        public bool MultiLenguaje
        {
            get { return multiLenguaje; }

        }
        public int Resolucion
        {
            get { return resolucion; }

        }
        public string Nombre
        {
            get { return nombre; }
        }
        public int Id
        {
            get { return id; }
        }
        #endregion
        #region Constructor
        public Canal(string nombre, int resolucion, bool multiLenguaje, decimal precio)
        {
            this.id = ++contadorId;
            this.nombre = nombre;
            this.resolucion = resolucion;
            this.multiLenguaje = multiLenguaje;
            this.precio = precio;
        }
        #endregion
        #region MetodosClase
        //Valida que el nombre del canal no este vacio
        public static bool ValidarNombre(string nombre)
        {
            return nombre != "";
        }
        //Valida que el precio sea mayor a 0
        public static bool ValidarPrecio(decimal precio)
        {
            return precio > 0;
        }
        //Valida que la resolucion corresponda a HD o a SD
        public static bool ValidarResolucion(int resolucion)
        {
            return resolucion == 576 || resolucion == 1080;
        }
        #endregion
    }

}
