using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloAnimal.UWP
{
    class FileAccessHelper
    {
        //Método que va a devolver la ruta de la BD para windows
        public static String GetLocalFilePath(String filename)
        {
            string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;

            return System.IO.Path.Combine(path, filename);
        }
    }
}
