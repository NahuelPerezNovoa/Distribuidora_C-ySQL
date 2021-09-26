using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Entidades
{
    public static class SerializacionYGuardado
    {
        public static event Callback ArchivoCreado;

        public delegate void Callback(Object pedido);

        /// <summary>
        /// Genera un archivo txt en base a una lista de tipo T. Se utiliza para guardar pedidos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="auxLista"></param>
        /// <param name="rutaArchivo"></param>
        public static void GuardarEnTxt(object pedido)
        {
            try
            {
                List<Object> lista = (List<Object>)pedido;
                string rutaArchivo = (string)lista[1];
                Documento documento = (Documento)lista[0];

                using (StreamWriter auxSw = new StreamWriter(rutaArchivo, false))
                {
                    string nameOfFile = rutaArchivo.Remove(0, rutaArchivo.LastIndexOf('\\') + 1);
                    auxSw.WriteLine(nameOfFile);
                    foreach (var item in documento.Pedido)
                    {
                        auxSw.WriteLine(item.ToString());
                    }

                    ArchivoCreado.Invoke(documento);
                }
            }
            catch
            {
                throw new WriteFileErrorException();
            }


        }

        /// <summary>
        /// Genera un archivo xml en base a una lista tipo T. Se utiliza para guardar los datos de la distribuidora
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="auxLista"></param>
        /// <param name="rutaArchivo"></param>
        public static void GuardarEnXml<T>(object pedido) where T : class

        {
            try
            {
                List<Object> lista = (List<Object>)pedido;
                string rutaArchivo = (string)lista[1];
                List<T> listaPedido = (List<T>)lista[0];

                using (XmlTextWriter auxArchivo = new XmlTextWriter(rutaArchivo, Encoding.UTF8))
                {
                    XmlSerializer auxEscritor = new XmlSerializer(typeof(List<T>));

                    auxEscritor.Serialize(auxArchivo, listaPedido);


                }
            }
            catch
            {
                throw new WriteFileErrorException();
            }

        }

        /// <summary>
        /// Lee un archivo xml. Se usa para levantar los datos guardados de la distribuidora
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="auxLista"></param>
        /// <param name="rutaArchivo"></param>
        /// <returns></returns>
        public static List<T> LeerXml<T>(List<T> auxLista, string rutaArchivo) where T : class
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    using (XmlTextReader auxArchivoALeer = new XmlTextReader(rutaArchivo))
                    {
                        XmlSerializer auxLector = new XmlSerializer(typeof(List<T>));
                        auxLista = (List<T>)auxLector.Deserialize(auxArchivoALeer);
                    }
                }
            }
            catch
            {
                throw new ReadFileErrorException();
            }
            return auxLista;

        }










    }
}
