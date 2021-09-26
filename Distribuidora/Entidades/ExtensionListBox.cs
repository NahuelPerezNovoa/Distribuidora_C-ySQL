using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public static class ExtensionListBox
    {
        /// <summary>
        /// Metodo encargado de cargar el ListBox mediante el pasaje de una lista tipo T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listBox"></param>
        /// <param name="lista"></param>
        public static void CargarListBoxDesdeLista<T>(this ListBox listBox, List<T> lista)
        {
            foreach (var item in lista)
            {
                listBox.Items.Add(item.ToString());
            }
        }
    }
}
