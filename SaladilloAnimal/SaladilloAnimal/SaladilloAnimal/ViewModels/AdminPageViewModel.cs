using SaladilloAnimal.Models;
using SaladilloAnimal.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SaladilloAnimal.ViewModels
{
    class AdminPageViewModel : INotifyPropertyChanged
    {
        #region Constantes

        private const string MENSAJE_ERROR_DATOSINVALIDOS = "Por favor, revise los datos";
        private const string MENSAJE_ERROR_USUARIOEXISTENTE = "El cliente ya existe";

        #endregion

        #region Campos
        private string datoNombre = String.Empty;
        private string datoDni = String.Empty;

        //SEGUNDA LÍNEA
        private int datoTipoMascota = -1;
        private string datoNombreMascota = String.Empty;
        private int datoEdadMascota = -1;
        private string datoColorMascota = String.Empty;

        internal void AgregarUsuario(AdminPage adminPage)
        {
            throw new NotImplementedException();
        }

        private float datoPesoMascota = -1;

        // Mensaje de error
        private string mensajeError = String.Empty;

        // Lista de tipos de mascota que exiten
        private List<TipoMascota> datolistaMascotas = new List<TipoMascota>();

        // Lista de Clientes que exiten
        private List<Clientes> datolistaClientes = new List<Clientes>();



        #endregion

        #region Propiedades

        /// <summary>
        /// Nombre
        /// </summary>
        public string DatoNombre
        {
            get
            {
                return datoNombre;
            }
            set
            {
                if (datoNombre != value)
                {
                    datoNombre = value;
                    OnPropertyChanged("DatoNombre");
                }
            }
        }

        /// <summary>
        /// DNI
        /// </summary>
        public string DatoDni
        {
            get
            {
                return datoDni;
            }
            set
            {
                if (datoDni != value)
                {
                    datoDni = value;
                    OnPropertyChanged("DatoDni");
                }
            }
        }

        public int DatoTipoMascota
        {
            get
            {
                return datoTipoMascota;
            }
            set
            {
                if (datoTipoMascota != value)
                {
                    datoTipoMascota = value;
                    OnPropertyChanged("DatoTipoMascota");
                }
            }
        }

        public string DatoNombreMascota
        {
            get
            {
                return datoNombreMascota;
            }
            set
            {
                if (datoNombreMascota != value)
                {
                    datoNombreMascota = value;
                    OnPropertyChanged("DatoNombreMascota");
                }
            }
        }

        public int DatoEdadMascota
        {
            get
            {
                return datoEdadMascota;
            }
            set
            {
                if (datoEdadMascota != value)
                {
                    datoEdadMascota = value;
                    OnPropertyChanged("DatoEdadMascota");
                }
            }
        }

        public string DatoColorMascota
        {
            get
            {
                return datoColorMascota;
            }
            set
            {
                if (datoColorMascota != value)
                {
                    datoColorMascota = value;
                    OnPropertyChanged("DatoColorMascota");
                }
            }
        }

        public float DatoPesoMascota
        {
            get
            {
                return datoPesoMascota;
            }
            set
            {
                if (datoPesoMascota != value)
                {
                    datoPesoMascota = value;
                    OnPropertyChanged("DatoPesoMascota");
                }
            }
        }

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

        public List<Clientes> DatoListaClientes
        {
            get
            {
                return datolistaClientes;
            }
            set
            {
                if (datolistaClientes != value)
                {
                    datolistaClientes = value;
                    OnPropertyChanged("ListaClientes");
                }
            }
        }

        public List<TipoMascota> DatolistaMascotas
        {
            get
            {
                return datolistaMascotas;
            }
            set
            {
                if (datolistaMascotas != value)
                {
                    datolistaMascotas = value;
                    OnPropertyChanged("ListaTiposMascota");
                }
            }
        }


        #endregion

        #region Constructor

        public AdminPageViewModel()
        {
            IniciarValores();
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
        /// Cierra la sesión y vuelve a la página de inicio.
        /// </summary>
        /// <remarks>
        /// Cierra la sesión y vuelve a la página de inicio, permitiendo cambiar de usuario
        /// </remarks>
        public void CambiarUsuario()
        {
            App.Current.MainPage = new MainPage();
        }

        /// <summary>
        /// Inicializa los valores del View Model.
        /// </summary>
        /// <remarks>
        /// Da valores iniciales a las propiedades del View Model a partir del usuario logueado.
        /// </remarks>
        public async void IniciarValores()
        { 
            List<Clientes> listaClientes = new List<Clientes>(await App.ClienteRepo.ObtenerClientes());
            List<TipoMascota> ListaTipoMascostas = new List<TipoMascota>(await App.TipoMascotaRepo.ObtenerTiposMascota());
        }
        

        public async void AgregarUsuario(Page actualPage)
        {
            int edad = 0;
            int altura = 0;
            int peso = 0;
            List<Clientes> listaUsuariosTabla = new List<Clientes>(await App.ClienteRepo.ObtenerClientes());

            if (String.IsNullOrEmpty(DatoDni) ||
                String.IsNullOrEmpty(DatoNombre))
            {
                MensajeError = MENSAJE_ERROR_DATOSINVALIDOS;
            }
            else
            {

                if (listaUsuariosTabla.SingleOrDefault(t => t.Dni.Equals(DatoDni)) != null)
                {
                    MensajeError = MENSAJE_ERROR_USUARIOEXISTENTE;
                }
                else
                {
                    await App.ClienteRepo.AgregarCliente(DatoDni, DatoNombre,"", DatoTipoMascota, DatoNombreMascota, DatoEdadMascota, DatoColorMascota, DatoPesoMascota, "CLIENTE");
                    await actualPage.DisplayAlert("Usuario añadido correctamente.", "", "Aceptar");
                    App.Current.MainPage = new AdminPage();
                }
            }
        }

        #endregion

    }
}
