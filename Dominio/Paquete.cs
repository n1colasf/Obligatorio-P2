using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Paquete
    {
        #region Atributos
        private string nombre;
        private bool promo;
        private double precioBase;
        private double precioFinal;
        private int id;
        private static int contadorId;
        private List<Canal> canalesPaquete = new List<Canal>();
        #endregion
        #region Propiedades
        public double PrecioBase
        {
            get { return precioBase; }
            set { precioBase = value; }
        }
        public double PrecioFinal
        {
            get { return precioFinal; }
            set { precioFinal = value; }
        }
        public bool Promo
        {
            get { return promo; }
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
        #region Listado
        public List<Canal> CanalesPaquete()
        {
            List<Canal> aux = new List<Canal>();
            foreach (Canal unC in canalesPaquete)
            {
                aux.Add(unC);
            }
            return aux;
        }
        #endregion
        #region Constructor
        public Paquete(string nombre, bool promo, double precioBase)
        {
            this.id = ++contadorId;
            this.nombre = nombre;
            this.promo = promo;
            this.precioBase = precioBase;
        }
        #endregion
        #region MetodosClase
        //Valida que el nombre no este vacio
        public static bool ValidarNombre(string nombre)
        {
            return nombre != "";
        }
        //Valida que el precio sea mayor a 0
        public static bool ValidarPrecio(double precio)
        {
            return precio > 0;
        }
        #endregion
        #region MetodoInstancia
        //Devuelve el numero de canales en el paquete
        public int ContarCanales()
        {
            return canalesPaquete.Count();
        }
        //Agrega un canal al listado de un paquete
        public void AgregarAPaquete(Canal unC)
        {
            canalesPaquete.Add(unC);
        }
        //Metodos abstracto a desarrollar en clases hijas
        public abstract bool AgregarCanalPaquete(Canal unC); 
        public abstract double Descuento();
        public abstract Canal BuscarCanal(Canal canal);
        #endregion
    }
}
