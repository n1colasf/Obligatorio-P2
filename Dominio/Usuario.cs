using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public class Usuario : IComparable<Usuario>
    {
        #region Atributos
        private string cedula;
        private string contrasena;
        private string rol;
        private Cliente unC;
        #endregion
        #region Contructor
        public Usuario(string cedula, string contrasena, string rol, Cliente unC)
        {
            this.cedula = cedula;
            this.contrasena = contrasena;
            this.rol = rol;
            this.unC = unC;
        }
        #endregion
        #region Propiedades
        public string Cedula
        {
            get { return cedula; }
        }
        public string Contrasena
        {
            get { return contrasena; }
        }
        public string Rol
        {
            get { return rol; }
        }
        public Cliente UnC
        {
            get { return unC; }
        }
        #endregion
        #region MetodosClase
        public static bool ValidarCedula(string cedula)
        {
            bool valido = false;
            if (cedula.All(char.IsDigit) && cedula.Length >= 7 && cedula.Length <= 9)
            {
                valido = true;
            }
            return valido;
        }
        public static bool ValidarRol(string rol)
        {
            bool valido = false;
            if (rol == "Operador" || rol == "Cliente")
            {
                valido = true;
            }
            return valido;
        }
        public static bool ValidarContrasena(string contrasena)
        {
            bool valido = false;
            bool tieneMayuscula = contrasena.Any(c => char.IsUpper(c));
            bool tieneMinuscula = contrasena.Any(c => char.IsLower(c));
            bool tieneDigito = contrasena.Any(c => char.IsNumber(c));
            if (contrasena.Length >= 6 && tieneMayuscula && tieneMinuscula && tieneDigito)
            {
                valido = true;
            }
            return valido;
        }
        #endregion
        #region MetodoInstancia
        public int CompareTo(Usuario other)
        {
            int orden = unC.Apellido.CompareTo(other.unC.Apellido);
            if (orden == 0)
            {
                orden = unC.Nombre.CompareTo(other.unC.Nombre);
            }
            return orden;
        }
        #endregion
    }
}
