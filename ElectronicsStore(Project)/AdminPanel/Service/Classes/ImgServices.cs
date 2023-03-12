using AdminPanel.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Service.Classes
{
    public static class ImgServices
    {
        public static string? ImgChoice()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.jfif";

            fileDialog.ShowDialog();
            return fileDialog.FileName;
        }
    }
}
