using SaladilloAnimal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaladilloAnimal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientePage : ContentPage
    {
        private UserPageViewModel viewModel;

        public ClientePage(Clientes cliente)
        {
            InitializeComponent();

            viewModel = new UserPageViewModel(cliente);

            BindingContext = viewModel;

            btnCambiarUsuario.Clicked += BtnCambiarUsuario_Clicked;
        }

        private void BtnCambiarUsuario_Clicked(object sender, EventArgs e)
        {
            viewModel.CambiarUsuario();
        }
    }
}