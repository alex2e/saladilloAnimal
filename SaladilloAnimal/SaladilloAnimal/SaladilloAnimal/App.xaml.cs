using SaladilloAnimal.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SaladilloAnimal
{
	public partial class App : Application
	{
        public static ClienteRepository ClienteRepo { get; set; }
        public static TipoMascotaRepository TipoMascotaRepo { get; set; }

		public App (string dbPath)
		{
			InitializeComponent();

            ClienteRepo = new ClienteRepository(dbPath);
            TipoMascotaRepo = new TipoMascotaRepository(dbPath);

			MainPage = new SaladilloAnimal.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
