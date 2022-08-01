using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PaqueteSD : Paquete
    {
        #region Atributos
        private bool mejoraCanal;
        private double precioConMejora;
        #endregion
        #region Propiedades
        public bool MejoraCanal
        {
            get { return mejoraCanal; }
        }
        public double PrecioConMejora
        {
            get { return precioConMejora; }
        }
        #endregion
        #region Constructor
        public PaqueteSD(string nombre, bool promo, double precioBase, bool mejoraCanal) : base(nombre, promo, precioBase)
        {
            this.mejoraCanal = mejoraCanal;
            this.PrecioFinal = Descuento();
        }
        #endregion
        #region MetodoInstancia
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
        //Si el paquete tiene mejora modifica el precio del paquete
        public bool AumentoMejora()
        {
            bool exito = false;
            if (MejoraCanal)
            {
                precioConMejora = PrecioBase * 1.2;
                exito = true;
            }
            else
            {
                precioConMejora = PrecioBase;
                exito = true;
            }
            return exito;
        }
        //Agrega un canal al paquete si ese canal no esta cargado en el listado y si la resolucion coincide con SD
        public override bool AgregarCanalPaquete(Canal unC)
        {
            bool exito = false;
            if (BuscarCanal(unC) == null && unC.Resolucion == 576)
            {
                AgregarAPaquete(unC);
                exito = true;
            }
            return exito;
        }
        //Si el paquete tiene promo aplica un descuento al precio final
        public override double Descuento()
        {
            AumentoMejora();
            PrecioFinal = precioConMejora;
            if (Promo)
            {
                PrecioFinal = precioConMejora * 0.85;
            }
            return PrecioFinal;
        }
        #endregion
    }
}
