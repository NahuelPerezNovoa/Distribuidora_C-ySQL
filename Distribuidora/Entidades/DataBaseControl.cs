using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class DataBaseControl
    {
        static SqlCommand comando;
        static SqlConnection conexion;

        /// <summary>
        /// Constructor estatico encargado de instanciar la conexion y el comando con la base de datos, y
        /// de realizar la connection del comando
        /// </summary>
        static DataBaseControl()
        {
            DataBaseControl.conexion = new SqlConnection("Data Source=localhost; Initial Catalog=Distribuidora; Integrated Security=True");
            DataBaseControl.comando = new SqlCommand();

            DataBaseControl.comando.CommandType = CommandType.Text;
            comando.Connection = DataBaseControl.conexion;
        }

        /// <summary>
        /// Funcion encargada de Backupear la lista de stock de productos en la base de datos.
        /// Primero trunca la tabla correspondiente de la db y luego realiza un insert de todos
        /// los productos en la lista.
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static bool BackupearStockProductos(List<Producto> lista)
        {
            bool BackUpOk = true;

            string statementTruncar = "TRUNCATE table StockProductos";
            string statementInsertar = "INSERT INTO StockProductos (Cod,Nombre,Stock) values(@Cod,@Nombre,@Stock)";

            try
            {
                if (DataBaseControl.conexion.State != ConnectionState.Open)
                {
                    DataBaseControl.conexion.Open();
                }
                DataBaseControl.comando.CommandText = statementTruncar;
                DataBaseControl.comando.ExecuteNonQuery();

                DataBaseControl.comando.CommandText = statementInsertar;
                foreach (var item in lista)
                {
                    DataBaseControl.comando.Parameters.AddWithValue("@Cod", item.Cod);
                    DataBaseControl.comando.Parameters.AddWithValue("@Nombre", item.Nombre);
                    DataBaseControl.comando.Parameters.AddWithValue("@Stock", item.Stock);
                    DataBaseControl.comando.ExecuteNonQuery();
                    DataBaseControl.comando.Parameters.Clear();
                }
            }
            catch(Exception e)
            {
                BackUpOk = false;
            }
            finally
            {
                if (DataBaseControl.conexion.State != ConnectionState.Closed)
                {
                    DataBaseControl.conexion.Close();
                }

                DataBaseControl.comando.Parameters.Clear();
            }

            return BackUpOk;

        }


        /// <summary>
        /// Funcion encargada de Backupear la lista empleados en la base de datos.
        /// Primero trunca la tabla correspondiente de la db y luego realiza un insert de todos
        /// los empleados en la lista.
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static bool BackupearEmpleados(List<Operario> lista)
        {
            bool BackUpOk = true;

            string statementTruncar = "TRUNCATE table Empleados";
            string statementInsertar = "INSERT INTO Empleados (NroOperario,Nombre,Apellido) values(@NroOperario,@Nombre,@Apellido)";

            try
            {
                if (DataBaseControl.conexion.State != ConnectionState.Open)
                {
                    DataBaseControl.conexion.Open();
                }
                DataBaseControl.comando.CommandText = statementTruncar;
                DataBaseControl.comando.ExecuteNonQuery();

                DataBaseControl.comando.CommandText = statementInsertar;
                foreach (var item in lista)
                {
                    DataBaseControl.comando.Parameters.AddWithValue("@NroOperario", item.NroEmpleado);
                    DataBaseControl.comando.Parameters.AddWithValue("@Nombre", item.Nombre);
                    DataBaseControl.comando.Parameters.AddWithValue("@Apellido", item.Apellido);
                    DataBaseControl.comando.ExecuteNonQuery();
                    DataBaseControl.comando.Parameters.Clear();
                }
            }
            catch
            {

                BackUpOk = false;
            }
            finally
            {
                if (DataBaseControl.conexion.State != ConnectionState.Closed)
                {
                    DataBaseControl.conexion.Close();
                }

                DataBaseControl.comando.Parameters.Clear();
            }

            return BackUpOk;

        }
    }
}
