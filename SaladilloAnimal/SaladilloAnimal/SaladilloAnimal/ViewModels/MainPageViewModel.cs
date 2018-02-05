using SaladilloAnimal.Models;
using SaladilloAnimal.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SaladilloAnimal.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        #region Constantes

        private const string MENSAJE_ERROR_USUARIOCONTRA = "Debe introducir Usuario y Contraseña(9 caracteres).";
        private const string MENSAJE_ERROR_USUARIO = "Debe introducir Usuario(9 caracteres).";
        private const string MENSAJE_ERROR_CONTRA = "Debe introducir Contraseña(9 caracteres).";
        private const string MENSAJE_ERROR_USUARIO_NOALTA = "El Usuario no está dado de Alta.";
        private const string MENSAJE_ERROR_CONTRA_NOCORRECTA = "La Contraseña no es correcta.";

        #endregion

        #region Campos

        // Nombre del Clientes
        private string nombreCliente = String.Empty;

        // Contraseña del Clientes
        private string passCliente = String.Empty;

        // Mensaje de error
        private string mensajeError = String.Empty;

        #endregion

        #region Propiedades

        /// <summary>
        /// Nombre del Clientes.
        /// </summary>
        public string NombreCliente
        {
            get
            {
                return nombreCliente;
            }
            set
            {
                if (nombreCliente != value)
                {
                    if (value != null && value.Length <= 9)
                    {
                        nombreCliente = value;
                    }
                    OnPropertyChanged("NombreCliente");
                }
            }
        }

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string PassCliente
        {
            get
            {
                return passCliente;
            }
            set
            {
                if (passCliente != value)
                {
                    if (value != null && value.Length <= 9)
                    {
                        passCliente = value;
                    }
                    OnPropertyChanged("PassCliente");
                }
            }
        }

        /// <summary>
        /// Mensaje de error.
        /// </summary>
        public string MensajeError
        {
            get
            {
                return mensajeError;
            }
            set
            {
                if (mensajeError != value)
                {
                    mensajeError = value;
                    OnPropertyChanged("MensajeError");
                }
            }
        }

        #endregion

        #region Elementos Interfaz INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Intenta iniciar sesión con los datos introducidos.
        /// </summary>
        /// <remarks>
        /// Comprueba que los datos introducidos cumplen las condiciones dadas,
        /// que el usuario está en la base de datos, e inicia sesión abriendo una nueva página
        /// dependiendo del tipo de usuario.
        /// </remarks>
        public async void EntrarAsync()
        {
            if (NombreCliente.Length < 9 && PassCliente.Length < 9)
            {
                MensajeError = MENSAJE_ERROR_USUARIOCONTRA;
            }
            else if (NombreCliente.Length < 9)
            {
                MensajeError = MENSAJE_ERROR_USUARIO;
            }
            else if (PassCliente.Length < 9)
            {
                MensajeError = MENSAJE_ERROR_CONTRA;
            }
            else
            {
                List<Clientes> listaUsuarios = new List<Clientes>(await App.ClienteRepo.ObtenerClientes());

                string Nombre = NombreCliente;

                Clientes clienteIdentificado = listaUsuarios.SingleOrDefault(t => t.Dni.Equals(NombreCliente));

                if (clienteIdentificado == null)
                {
                    MensajeError = MENSAJE_ERROR_USUARIO_NOALTA;
                }
                else if (!clienteIdentificado.Password.Equals(PassCliente))
                {
                    MensajeError = MENSAJE_ERROR_CONTRA_NOCORRECTA;
                }
                else
                {
                    if (clienteIdentificado.Tipo.Equals("CLIENTE"))
                    {

                        App.Current.MainPage = new ClientePage(clienteIdentificado);
                        
                    }
                   else if (clienteIdentificado.Tipo.Equals("TIENDA"))
                    {
                       
                        App.Current.MainPage = new AdminPage();
                       
                        
                    }
                }
            }




        }

        #endregion

    }
}
