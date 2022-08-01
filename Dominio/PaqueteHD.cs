using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PaqueteHD : Paquete
    {
        #region Atributos
        private bool grabacion;
        private double precioConGrabacion;
        private static double costoGrabacion = 500;
        #endregion
        #region Propiedades
        public bool Grabacion
        {
            get { return grabacion; }
        }
        public static double CostoGrabacion
        {
            get { return costoGrabacion; }
            set { costoGrabacion = value; }
        }
        #endregion
        #region Constructor
        public PaqueteHD(string nombre, bool promo, double precioBase, bool grabacion) : base(nombre, promo, precioBase)
        {
            this.grabacion = grabacion;
            this.PrecioFinal = Descuento();
        }
        #endregion
        #region  MetodoDeInstancia
        //Devuelve el costo de grabacion
        public static double DevolverCostoGrabacion()
        {
            return costoGrabacion;
        }
        //Busca si un canal se encuentra en el listado de canales de un paquete, si no se encuentra devuelve null
        public override Canal BuscarCanal(Canal canal)
        {
            Canal unC = null;
            int i = 0;
            while (unC == null && i < CanalesPaquete().Count)
            {
                if (CanalesPaquete()[i] == canal)
                {
                    unC = CanalesPaquete()[i];
                }
                i++;
            }
            return unC;
        }
        //Si el paquete tiene grabacion se modifica el precio 
        public bool AgregarCosto(bool grabacion)
        {
            bool exito = false;
            if (grabacion)
            {
                precioConGrabacion = PrecioBase + costoGrabacion;
                exito = true;
            }
            else
            {
                precioConGrabacion = PrecioBase;
                exito = true;
            }
            return exito;
        }
        //Agrega un canal al paquete
        public override bool AgregarCanalPaquete(Canal unC)
        {
            bool exito = false;
            if (BuscarCanal(unC) == null && unC.Resolucion == 1080)
            {
                AgregarAPaquete(unC);
                exito = true;
            }
            return exito;
        }
        //Si el paquete tiene promo aplica un descuento al precio final
        public override double Descuento()
        {
            AgregarCosto(grabacion);
            PrecioFinal = precioConGrabacion;
            if (Promo)
            {
                PrecioFinal = precioConGrabacion / 2;
            }
            return PrecioFinal;
        }
        #endregion
        #region MetodoDeClase
        //Modifica el costo de la grabacion, el costo nuevo es validado en sistema
        public static void ModificarCostoGrabacion(double costoNuevo)
        {
            costoGrabacion = costoNuevo;
        }
        #endregion
    }
}
