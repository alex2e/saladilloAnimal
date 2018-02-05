using SaladilloAnimal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SaladilloAnimal
{
	public partial class MainPage : ContentPage
	{
        private MainPageViewModel viewModel;

        public MainPage()
		{
            InitializeComponent();

            viewModel = new MainPageViewModel();

            BindingContext = viewModel;

            btnEntrar.Clicked += BtnEntrar_Clicked;
        }

        private void BtnEntrar_Clicked(object sender, EventArgs e)
        {
            viewModel.EntrarAsync();
        }
    }
}
