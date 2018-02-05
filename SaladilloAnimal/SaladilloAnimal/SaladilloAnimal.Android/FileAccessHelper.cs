using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SaladilloAnimal.Droid
{
    class FileAccessHelper
    {
        //Devuelve la ruta de la BD en Android
        public static String GetLocalFilePath(String filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            return System.IO.Path.Combine(path, filename);
        }
    }
}