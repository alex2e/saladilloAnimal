using SaladilloAnimal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SaladilloAnimal.Views
{
    public class UserPageViewModel : INotifyPropertyChanged
    {

        #region Campos
        private string datoNombre = String.Empty;
        private string datoDni = String.Empty;

        //SEGUNDA LÍNEA
        private int datoTipoMascota = -1;
        private string datoNombreMascota = String.Empty;
        private int datoEdadMascota = -1;
        private string datoColorMascota = String.Empty;
        private float datoPesoMascota = -1;
        private Clientes cliente;
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


        #endregion

        public UserPageViewModel(Clientes cliente)
        {
            this.cliente = cliente;
            IniciarValores();
        }

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

            DatoDni = cliente.Dni;
            DatoNombre = cliente.Cliente;
            DatoTipoMascota = cliente.Tipo_Mascota;
            DatoNombreMascota = cliente.Nombre;
            DatoEdadMascota = cliente.Edad;
            DatoColorMascota = cliente.Color;
            DatoPesoMascota = cliente.Peso;






        }
        #endregion
    }
}