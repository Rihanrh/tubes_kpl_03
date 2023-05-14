using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    public class MenuMakanan<T>
    {
        public string name_menu { get; set; }
        public List<T> path_images { get; set; }
        public double harga_menu { get; set; }
        public string deskripsi_menu { get; set; }

        public MenuMakanan(string name, List<T> listImages, double harga, string deskripsi)
        {
            Contract.Requires(!string.IsNullOrEmpty(name), "Name cannot be null or empty.");
            Contract.Requires(listImages != null && listImages.Count > 0, "List of images cannot be null or empty.");
            Contract.Requires(harga >= 0, "Price cannot be negative.");
            Contract.Requires(!string.IsNullOrEmpty(deskripsi), "Description cannot be null or empty.");

            this.name_menu = name;
            this.path_images = listImages;
            this.harga_menu = harga;
            this.deskripsi_menu = deskripsi;
        }

        public void showImages()
        {
            Debug.Assert(this.path_images != null, "List of images cannot be null.");

            for (int i = 0; i < path_images.Count; i++)
            {
                Console.WriteLine(path_images[i]);
            }
        }
    }
}

