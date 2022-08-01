using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public class Cliente 
    {
        #region Atributos
        private string nombre;
        private string apellido;
        private List<Compra> compras = new List<Compra>();
        #endregion
        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
        }
        public string Apellido
        {
            get { return apellido; }
        }
        public List<Compra> Compras
        {
            get { return compras; }
        }
        #endregion
        #region Constructor
        public Cliente(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
        #endregion
        #region Listado
        //Devuelve aquellas compras que no hayan sido canceladas 
        public List<Compra> ComprasVigentes()
        {
            List<Compra> aux = new List<Compra>();
            foreach (Compra unaC in compras)
            {
                if (unaC.Suscripto)
                {
                    aux.Add(unaC);
                }
            }
            return aux;
        }
        #endregion
        #region MetodosClase
        //Verifica que el nombre tenga al menos 2 caracteres (segun letra)
        public static bool ValidarNombre(string nombre)
        {
            bool valido = false;
            if (nombre.Length > 2)
            {
                valido = true;
            }
            return valido;
        }
        //Verifica que el apellido tenga al menos 2 caracteres (segun letra)
        public static bool ValidarApellido(string apellido)
        {
            bool valido = false;
            if (apellido.Length > 2)
            {
                valido = true;
            }
            return valido;
        }
        #endregion
        #region MetodosInstancia
        //Agrega una compra al listado de compras una compra
        public bool AgregaPaquete(Compra unaC)
        {
            bool tiene = false;
            int contador = 0;
            while (tiene && contador < ComprasVigentes().Count())
            {
                if (compras[contador].UnP.Id == unaC.UnP.Id)
                {
                    tiene = true;
                }
                contador++;
            }
            if (!tiene)
            {
                compras.Add(unaC);
            }
            return tiene;
        }
        //Busca un paquete en las compras realizadas por el usuario
        public bool BuscarPaquete(int idPaquete)
        {
            bool encontrado = false;
            foreach (Compra unaC in ComprasVigentes())
            {
                if (unaC.UnP.Id == idPaquete)
                {
                    encontrado = true;
                }
            }
            return encontrado;
        }
        //Cambia el atributo suscripto a false para que no quede visible en el lsitado de compras al cliente
        public bool CancelarSuscripcion(int idPaquete)
        {
            bool eliminado = false;
            foreach (Compra unC in compras)
            {
                if (unC.UnP.Id == idPaquete)
                {
                    eliminado = true;
                    unC.Suscripto = false;
                }
            }
            return eliminado;
        }
        //Verifica para cada compra del cliente si alguna de ellas cuenta con un vencimiento en los ultimos 30 dias, si lo encuentre devuelve true
        public bool Vencimiento30()
        {
            bool es = false;
            string menos30 = DateTime.Now.AddDays(-30).ToShortDateString();
            string hoy = DateTime.Now.ToShortDateString();
            foreach (Compra unaC in ComprasVigentes())
            {
                if (DateTime.Parse(unaC.FechaVencimiento) >= DateTime.Parse(menos30) && DateTime.Parse(unaC.FechaVencimiento) <= DateTime.Parse(hoy))
                {
                    es = true;
                }
            }
            return es;
        }
        #endregion
    }
}
