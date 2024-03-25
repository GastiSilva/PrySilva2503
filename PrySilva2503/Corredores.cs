using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace PrySilva2503
{
    internal class Corredores
    {
        string cnnstr;
        public DataTable dtCorredores;
        OleDbDataAdapter da;

        public Corredores()
        {
            //crrear conexion
            OleDbConnection cnn = new OleDbConnection();
            cnnstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =Carreras.mdb";
            cnn.ConnectionString = cnnstr;
            cnn.Open();
            // crear comando
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Corredores";
            cmd.CommandType = CommandType.TableDirect;
            cmd.Connection = cnn;
            // crear adapter
            da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            // llenar
            dtCorredores = new DataTable();
            da.Fill(dtCorredores);
            //builder
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
        }

        public DataTable Leer()
        {
            return dtCorredores;
        }

        public void Agregar(int id, string nombre)
        {
            DataRow dr = dtCorredores.NewRow();
            dr["IdCorredor"] = id;
            dr["Nombre"] = nombre;
            dtCorredores.Rows.Add(dr);
            da.Update(dtCorredores);
        }

        public void Eliminar(int id)
        {

        }

        public void Actualizar(int id, string nombre)
        {

        }
    }
 
}
