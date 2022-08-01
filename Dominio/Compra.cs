using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public class Compra
    {
        #region Atributos
        private string fechaCompra;
        private string fechaVencimiento;
        private Paquete unP;
        private bool suscripto;
        #endregion
        #region Propiedades
        public bool Suscripto
        {
            get { return suscripto; }
            set { suscripto = value; }
        }
        public string FechaCompra
        {
            get { return fechaCompra; }
        }
        public string FechaVencimiento
        {
            get { return fechaVencimiento; }
        }
        public Paquete UnP
        {
            get { return unP; }
        }
        #endregion
        #region Constructores
        public Compra(string fechaCompra, string fechaVencimiento, Paquete unP)
        {
            this.fechaCompra = fechaCompra;
            this.fechaVencimiento = fechaVencimiento;
            this.unP = unP;
            this.suscripto = true;
        }
        #endregion
    }   
}
