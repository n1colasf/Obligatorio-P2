using System;
using System.Collections.Generic;

namespace Dominio
{
    public class TVision
    {
        #region Atributos
        private List<Canal> canales;
        private List<Paquete> paquetes;
        private List<Usuario> usuarios;
        private List<Compra> compras;
        private static TVision instancia;
        #endregion
        #region Constructor y Metodo Singleton
        //Singleton
        public static TVision Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new TVision();
                }
                return instancia;
            }
        }
        //Constructor
        private TVision()
        {
            canales = new List<Canal>();
            paquetes = new List<Paquete>();
            usuarios = new List<Usuario>();
            compras = new List<Compra>();
            PrecargaCanales();
            PrecargarPaquetes();
            PrecargarCompletarPaquetes();
            PrecargarUsuario();
            PrecargarComprasACliente();
        }
        #endregion
        #region Precargas
        public void PrecargarUsuario()
        {
            //Operadores
            AgregarOperador("12345678", "123mmMMH", "Operador");
            AgregarOperador("97856412", "123llAA8", "Operador");
            //Clientes
            AgregarCliente("95236412", "123llAA7", "Cliente", "Natalia", "Garcia");
            AgregarCliente("95236412", "123llAA7", "Cliente", "Noelia", "Garcia");//FALLA- MISMA CI
            AgregarCliente("42531689", "123llAA8", "Cliente", "Leonardo", "Garcia");
            AgregarCliente("42531589", "123jjJJ8", "Cliente", "Gabriela", "Santos");
            AgregarCliente("95236452", "123llAA7", "Cliente", "Macarena", "Alvarez");
            AgregarCliente("42536589", "123llAA8", "Cliente", "Lourdes", "Garcia");
            AgregarCliente("48531589", "123jjJJ8", "Cliente", "German", "Santos");
            AgregarCliente("15236412", "123llAA7", "Cliente", "Nancy", "Garcia");
            AgregarCliente("42538689", "123llAA8", "Cliente", "Heber", "Garcia");
            AgregarCliente("AAA58568", "123llAA7", "Cliente", "Noelia", "Garcia");//FALLA- CI CON LETRAS
            AgregarCliente("58568", "123llAA7", "Cliente", "Noelia", "Garcia");//FALLA- CI CON MENOS DE 7 CARACTERES
            AgregarCliente("54875698", "123", "Cliente", "Noelia", "Garcia");//FALLA- CONTRASENA MENOS DE 6 DIGITOS
            AgregarCliente("54885698", "123AAAA", "Cliente", "Noelia", "Garcia");//FALLA- CONTRASENA SIN MINUSCULA
            AgregarCliente("54885298", "aaaAAAA", "Cliente", "Noelia", "Garcia");//FALLA- CONTRASENA SIN NUMERO
            AgregarCliente("54885290", "aa25874", "Cliente", "Noelia", "Garcia");//FALLA- CONTRASENA SIN MAYUSCULA
            AgregarCliente("54811190", "123llAA8", "Cliente", "N", "Garcia");//FALLA- NOMBRE MENOR A 2 CARACTERES
            AgregarCliente("22211190", "123llAA8", "Cliente", "Noelia", "G");//FALLA- APELLIDO MENOR A 2 CARACTERES

        }
        private void PrecargaCanales()
        {
            AgregarCanal("FOX HD", 1000, true, 200); //FALLA - RESOLUCION NO VALIDA
            AgregarCanal("", 1080, false, 500);//FALLA - NOMBRE VACIO
            AgregarCanal("JJ", 1080, false, -500);//FALLA - PRECIO NEGATIVO
            //CANALES SD
            AgregarCanal("VTV", 576, true, 100);//id1
            AgregarCanal("VTV", 576, true, 100);//FALLA - IGUAL A ANTERIOR
            AgregarCanal("CNN", 576, true, 200);//id2
            AgregarCanal("JETIX", 576, false, 300);//id3
            AgregarCanal("HISTORY CHANNEL", 576, false, 400);//id4
            AgregarCanal("DISCOVERY KIDS", 576, false, 500);//id5
            AgregarCanal("CARTOON NETWORK", 576, false, 300);//id6
            //CANALES HD
            AgregarCanal("DISCOVERY CHANNEL HD", 1080, true, 100);//id6
            AgregarCanal("ISAT HD", 1080, true, 200);//id7
            AgregarCanal("TNT HD", 1080, true, 300);//id8
            AgregarCanal("GLITZ HD", 1080, false, 400);//id9
            AgregarCanal("HBO HD", 1080, false, 500);//id10
            AgregarCanal("FOX SPORTS HD", 1080, false, 500);//id11
            AgregarCanal("VTV HD", 1080, true, 100);//id12
        }
        private void PrecargarPaquetes()
        {
            AgregarPaqueteHD("CANALES HD", true, 150, true, "TNT HD", 1080);//id1
            AgregarPaqueteHD("CANALES HD", true, 150, true, "TNT HD", 1080);//FALLA - IGUAL AL ANTERIOR
            AgregarPaqueteSD("", true, 100, true, "VTV", 576);//FALLA - NOMBRE VACIO
            AgregarPaqueteSD("CANALES SD", true, 100, true, "VTV", 576);//id2
            AgregarPaqueteHD("DEPORTES HD", true, 150, true, "VTV HD", 1080);//id3
            AgregarPaqueteHD("PELICULAS HD", false, 150, false, "HBO HD", 1080);//id4
            AgregarPaqueteSD("DEPORTES SD", true, 100, true, "VTV", 576);//id5
            AgregarPaqueteSD("ESPECTACULOS SD", true, 100, true, "VTV", 1080);//FALLA - RESOLUCION INCORRECTA
            AgregarPaqueteSD("DOCUMENTALES SD", true, 100, false, "HISTORY CHANNEL", 576);//id6
            AgregarPaqueteSD("ESPECTACULOS SD", true, 100, true, "HIST", 576);//FALLA - CANAL NO EXISTE
            AgregarPaqueteSD("NOTICIAS SD", false, 100, true, "CNN", 576);//id7
            AgregarPaqueteSD("SERIES SD", true, -8, false, "HISTORY CHANNEL", 576);//FALLA - PRECIO NEGATIVO
            AgregarPaqueteSD("INFANTILES SD", true, 100, false, "JETIX", 576);//id8
        }
        private void PrecargarCompletarPaquetes()
        {
            AgregarCanalPaqueteExtra(1, "ISAT HD", 1080);
            AgregarCanalPaqueteExtra(1, "DISCOVERY CHANNEL HD", 1080);
            AgregarCanalPaqueteExtra(1, "GLITZ HD", 1080);
            AgregarCanalPaqueteExtra(1, "FOX SPORTS HD", 1080);
            AgregarCanalPaqueteExtra(1, "VTV HD", 1080);
            AgregarCanalPaqueteExtra(1, "HBO HD", 1080);
            AgregarCanalPaqueteExtra(2, "CNN", 576);
            AgregarCanalPaqueteExtra(2, "JETIX", 576);
            AgregarCanalPaqueteExtra(2, "HISTORY CHANNEL", 576);
            AgregarCanalPaqueteExtra(2, "DISCOVERY KIDS", 576);
            AgregarCanalPaqueteExtra(2, "CARTOON NETWORK", 576);
            AgregarCanalPaqueteExtra(3, "FOX SPORTS HD", 1080);
            AgregarCanalPaqueteExtra(4, "ISAT HD", 1080);
            AgregarCanalPaqueteExtra(4, "GLITZ HD", 1080);
            AgregarCanalPaqueteExtra(4, "TNT HD", 1080);
            AgregarCanalPaqueteExtra(8, "DISCOVERY KIDS", 576);
            AgregarCanalPaqueteExtra(8, "CARTOON NETWORK", 576);
        }
        //Precarga utilizada para los datos de prueba, para visualizar clientes con compras cuyo vencimiento sea en los ultimos 30
        public void PrecargarComprasACliente()
        {
            Compra unaC1 = new Compra("06/19/2020", "06/19/2021", paquetes[1]);//aparece
            compras.Add(unaC1);
            AgregarPrecargaCompra(unaC1, Clientes()[0]);
            Compra unaC2 = new Compra("06/20/2020", "06/20/2021", paquetes[3]);//aparece
            AgregarPrecargaCompra(unaC2, Clientes()[1]);
            compras.Add(unaC2);
            Compra unaC3 = new Compra("05/01/2020", "05/01/2021", paquetes[4]);//no
            AgregarPrecargaCompra(unaC3, Clientes()[2]);
            compras.Add(unaC3);
            Compra unaC4 = new Compra("06/30/2020", "06/30/2021", paquetes[2]);//no
            AgregarPrecargaCompra(unaC4, Clientes()[3]);
            compras.Add(unaC4);
            //Aparece --> Compra en los ultimos 30 y compra fuera de los ultimos 30
            Compra unaC5 = new Compra("09/30/2020", "09/30/2021", paquetes[0]);
            AgregarPrecargaCompra(unaC5, Clientes()[4]);
            compras.Add(unaC5);
            Compra unaC6 = new Compra("06/19/2020", "06/19/2021", paquetes[1]);
            AgregarPrecargaCompra(unaC6, Clientes()[4]);
            compras.Add(unaC6);
        }
        #endregion
        #region Listas
        //Lista completa de canales
        public List<Canal> Canales()
        {
            List<Canal> aux = new List<Canal>();
            foreach (Canal unC in canales)
            {
                aux.Add(unC);
            }
            return aux;
        }
        //Lista completa de paquetes
        public List<Paquete> Paquetes()
        {
            List<Paquete> aux = new List<Paquete>();
            foreach (Paquete unP in paquetes)
            {
                aux.Add(unP);
            }
            return aux;
        }
        //Listado de compras
        public List<Compra> Compras()
        {
            List<Compra> aux = new List<Compra>();
            foreach(Compra unaC in compras)
            {
                aux.Add(unaC);
            }
            return aux;
        }
        //Crea una lista de clientes, filtra aquellos que tengan como rol "Cliente".
        public List<Usuario> Clientes()
        {
            List<Usuario> aux = new List<Usuario>();
            foreach (Usuario unU in usuarios)
            {
                if (unU.Rol == "Cliente")
                {
                    aux.Add(unU);
                }
            }
            return aux;
        }
        //Filtra los clientes que tengan compras cuyo vencimiento sea en los proximos 30 dias
        public List<Usuario> ClientesConVencimiento30()
        {
            List<Usuario> aux = new List<Usuario>();
            foreach(Usuario unU in Clientes())
            {
                if(unU.UnC.Vencimiento30())
                {
                    aux.Add(unU);
                }
            }
            return aux;
        }
        //Crea una lista con el o los paquetes con mayor costo
        public List<Paquete> PaquetesConMayorCosto()
        {
            List<Paquete> aux = new List<Paquete>();
            double mayor = double.MinValue; 
            foreach (Paquete unP in paquetes)
            {
                if(unP.PrecioFinal > mayor)
                {
                    mayor = unP.PrecioFinal;
                    aux.Clear();
                    aux.Add(unP);
                }else if(mayor == unP.PrecioFinal)
                {
                    aux.Add(unP);
                }
            }
            return aux;
        }
        //Crea un listado con los paquetes que incluyan un canal en particular
        public List<Paquete> BuscarPaquetesConCanal(int idCanal)
        {
            List<Paquete> aux = new List<Paquete>();
            foreach(Paquete unP in paquetes)
            {
                if(EncontrarCanal(unP, idCanal))
                {
                    aux.Add(unP);
                }
            }
            return aux;
        }
        //Crea un listado de compras cuya fecha de suscripcion esten entre dos fechas
        public List<Compra> ComprasXFecha (string Fecha1, string Fecha2)
        {
            List<Compra> aux = new List<Compra>();
            //Convierte a DateTime los strings de fechas pasados como parametros
            DateTime fecha1 = DateTime.Parse(Fecha1);
            DateTime fecha2 = DateTime.Parse(Fecha2);
            foreach (Compra unaC in compras)
            {
                //Convierte el atributo string de fecha compra de la compra DateTime
                DateTime fechaCompra = DateTime.Parse(unaC.FechaCompra);
                if(fechaCompra >= fecha1 && fechaCompra <= fecha2)
                {
                    aux.Add(unaC);
                }
            }
            return aux;
        }
        //Ordena los clientes por apellido y si tienen el mismo apellido los ordena por nombre
        public List<Usuario> ClientesOrdenadosApellido()
        {
            List<Usuario> aux = new List<Usuario>();
            foreach (Usuario unU in Clientes())
            {
              aux.Add(unU);
            }
            aux.Sort();
            return aux;
        }
        //Lista de paquetes cuyo precio sea superior al indicado
        public List<Paquete> PaquetesBaseSuperiorA(int precio)
        {
            List<Paquete> aux = new List<Paquete>();
            if (precio > 0)
            {
                foreach (Paquete unP in paquetes)
                {
                    if (unP.PrecioBase > precio)
                    {
                        aux.Add(unP);
                    }
                }
            }
            return aux;
        }
        //Lista de los paquetes con mayor cantidad de canales
        public List<Paquete> PaquetesConMasCanales()
        {
            int mayor = int.MinValue;
            int cantidadCanales;
            List<Paquete> aux = new List<Paquete>();
            foreach (Paquete unP in paquetes)
            {
                cantidadCanales = unP.ContarCanales();
                if (cantidadCanales > mayor)
                {
                    mayor = cantidadCanales;
                    aux.Clear();
                    aux.Add(unP);
                }
                else if (cantidadCanales == mayor)
                {
                    aux.Add(unP);
                }
            }
            return aux;
        }
        #endregion
        #region AccionesConObjetos
        //Calcula el costo de un listado de compras
        public double CalcularCostoCompras(List<Compra> listaCompras)
        {
            double costo = 0;
            foreach (Compra unaC in listaCompras)
            {
                costo += unaC.UnP.PrecioFinal;
            }
            return costo;
        }
        //Verifica usuario y contrasena --> Login
        public Usuario VerificarUsuario(string usuario, string contrasena)
        {
            Usuario usuarioEncontrado = null;
            foreach (Usuario unU in usuarios)
            {
                if(unU.Cedula == usuario && unU.Contrasena == contrasena)
                {
                    usuarioEncontrado = unU;
                }
            }
            return usuarioEncontrado;
        }
        //Hace que no quede visible el paquete que se quiere eliminar
        public bool EliminarCompraCliente(int idPaquete, string cedula)
        {
            bool eliminado = false;
            Usuario unU = EncontrarUsuario(cedula);
            if (unU.UnC.CancelarSuscripcion(idPaquete))
            {
                eliminado = true;
            }
            return eliminado;
        }
        public bool EncontrarCanal(Paquete unP, int idCanal)
        {
            bool encontrado = false;
            foreach (Canal unC in unP.CanalesPaquete())
            {
                if (unC.Id == idCanal)
                {
                    encontrado = true;
                }
            }
            return encontrado;
        }
        //Agrega clientes al listado de usuarios
        public bool AgregarCliente(string cedula, string contrasena, string rol, string nombre, string apellido)
        {
            bool exito = false;
            if (Usuario.ValidarCedula(cedula) && Usuario.ValidarContrasena(contrasena) && Usuario.ValidarRol(rol) && Cliente.ValidarApellido(apellido) && Cliente.ValidarNombre(nombre) && EncontrarUsuario(cedula) == null)
            {
                Cliente unC = new Cliente(nombre, apellido);
                Usuario unU = new Usuario(cedula, contrasena, rol, unC);
                usuarios.Add(unU);
                exito = true;
            }
            return exito;
        }
        //Busca una cedula en el listado de usuarios
        public Usuario EncontrarUsuario(string cedula)
        {
            Usuario unUsuario = null;
            foreach (Usuario unU in usuarios)
            {
                if (unU.Cedula == cedula)
                {
                    unUsuario = unU;
                }
            }
            return unUsuario;
        }
        //Busca exclusivamente en el listado de clientes una cedula
        public Usuario EncontrarCliente(string cedula)
        {
            Usuario unUsuario = null;
            foreach (Usuario unU in Clientes())
            {
                if (unU.Cedula == cedula)
                {
                    unUsuario = unU;
                }
            }
            return unUsuario;
        }
        //Agrega operadores al listado de usuarios
        public bool AgregarOperador(string cedula, string contrasena, string rol)
        {
            bool exito = false;
            if (Usuario.ValidarCedula(cedula) && Usuario.ValidarContrasena(contrasena) && Usuario.ValidarRol(rol) && EncontrarUsuario(cedula) == null)
            {
                Cliente unC = null;
                Usuario unU = new Usuario(cedula, contrasena, rol, unC);
                usuarios.Add(unU);
            }
            return exito;
        }
        //Agrega un canal al listado de canales
        public bool AgregarCanal(string nombre, int resolucion, bool multiLenguaje, decimal precio)
        {
            bool exito = false;
            //Si todos los valores del canal son validos y el canal ya no se encuentra precargado
            if (Canal.ValidarNombre(nombre) && Canal.ValidarResolucion(resolucion) && Canal.ValidarPrecio(precio) && EncontrarCanal(nombre, resolucion) == null)
            {
                Canal unC = new Canal(nombre, resolucion, multiLenguaje, precio);
                canales.Add(unC);
                exito = true;
            }
            return exito;
        }
        //Busca si un canal esta cargado en el sistema, busca por nombre y resolucion ya que no puede existir dos canales con mismo nombre e igual resolucion, si no lo encuentra devuelve null.
        public Canal EncontrarCanal(string nombre, int resolucion)
        {
            {
                Canal unC = null;
                int contador = 0;
                while (unC == null && contador < canales.Count)
                {
                    if (canales[contador].Nombre == nombre && canales[contador].Resolucion == resolucion)
                    {
                        unC = canales[contador];
                    }
                    contador++;
                }
                return unC;
            }
        }
        //Busca un paquete por id, si lo encuentra devuelve el paquete de lo contrario devuelve null
        public Paquete EncontrarPaquete(int id)
        {
            {
                Paquete unP = null;
                int contador = 0;
                while (unP == null && contador < paquetes.Count)
                {
                    if (paquetes[contador].Id == id)
                    {
                        unP = paquetes[contador];
                    }
                    contador++;
                }
                return unP;
            }
        }
        //Encuentra un paquete por el nombre
        public Paquete EncontrarPaquete(string nombre)
        {
            {
                Paquete unP = null;
                int contador = 0;
                while (unP == null && contador < paquetes.Count)
                {
                    if (paquetes[contador].Nombre == nombre)
                    {
                        unP = paquetes[contador];
                    }
                    contador++;
                }
                return unP;
            }
        }
        //Agrega un paquete HD con un canal.
        public bool AgregarPaqueteHD(string nombre, bool promo, double precioBase, bool grabacion, string nombreCanal, int resolucion)
        {
            bool exito = false;
            //Busco el canal que quiero agregar
            Canal unC = EncontrarCanal(nombreCanal, resolucion);
            //Si los datos del paquete son validos, se encontro el canal que quiero agregar y no existe un paquete registrado con igual nombre: creo el paquete, le agrego el canal y lo agrego a la lista de paquetes
            if (Paquete.ValidarNombre(nombre) && Paquete.ValidarPrecio(precioBase) && unC != null && EncontrarPaquete(nombre) == null)
            {
                PaqueteHD unPHD = new PaqueteHD(nombre, promo, precioBase, grabacion);
                if (unPHD.AgregarCanalPaquete(unC) == true)
                {
                    paquetes.Add(unPHD);
                    exito = true;
                }
            }
            return exito;
        }
        //Agregar un paquete SD con un canal.
        public bool AgregarPaqueteSD(string nombre, bool promo, double precioBase, bool mejoraCanal, string nombreCanal, int resolucion)
        {
            bool exito = false;
            //Busco el canal que quiero agregar
            Canal unC = EncontrarCanal(nombreCanal, resolucion);
            //Si los datos del paquete son validos y se encontro el canal que quiero agregar: creo el paquete, le agrego el canal y lo agrego a la lista de paquetes
            if (Paquete.ValidarNombre(nombre) && Paquete.ValidarPrecio(precioBase) && unC != null)
            {
                PaqueteSD unPSD = new PaqueteSD(nombre, promo, precioBase, mejoraCanal);

                if (unPSD.AgregarCanalPaquete(unC) == true)
                {
                    paquetes.Add(unPSD);
                    exito = true;
                }
            }
            return exito;
        }
        //Agrega un canal a un paquete ya cargado en el sistema
        public bool AgregarCanalPaqueteExtra(int id, string nombre, int resolucion)
        {
            bool exito = false;
            //Encuentro el canal que se quiere agregar
            Canal unC = EncontrarCanal(nombre, resolucion);
            //Encuentro el paquete que se quiere agregar
            Paquete unP = EncontrarPaquete(id);
            //Si el canal y el paquete fueron encontrados verifico que el tipo de paquete coincida con la resolucion del canal
            if (unC != null && unP != null)
            {
               exito = unP.AgregarCanalPaquete(unC);
            }
            return exito;
        }
        //Cambia el costo de los paquetes HD
        public bool CambiarCostoGrabacionPaqueteHD(double nuevoCosto)
        {
            bool exito = false;
            if (nuevoCosto > 0)
            {
                PaqueteHD.ModificarCostoGrabacion(nuevoCosto);
                exito = true;
            }
            return exito;
        }
        //Genera una compra con la fecha de hoy, la fecha de vencimiento (1 anio despues de hoy) y el objeto paquete. Esta es asignada al cliente.
        public bool ComprarPaquete(int idPaquete, string usuario)
        {
            bool compraRealizada = false;
            //Cliente
            Usuario cliente = EncontrarUsuario(usuario);
            //Compra
            Paquete unP = EncontrarPaquete(idPaquete);
            string fechaFin = DateTime.Now.AddYears(1).ToShortDateString();
            string fechaInicio = DateTime.Now.ToShortDateString();
            Compra unaC = new Compra(fechaInicio, fechaFin, unP);
            //Agrego al cliente
            if(!cliente.UnC.AgregaPaquete(unaC))
            {
                compras.Add(unaC);
                compraRealizada = true;
            }
            return compraRealizada;
        }
        //Funcion utilizada para la precarga de datos
        public void AgregarPrecargaCompra(Compra unaC, Usuario usuario)
        {
            usuario.UnC.AgregaPaquete(unaC);
        }
        #endregion
    }
}