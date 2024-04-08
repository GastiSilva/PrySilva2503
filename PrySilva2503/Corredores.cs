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
            // creo PK
            DataColumn[] dc = new DataColumn[1];
            dc[0] = dtCorredores.Columns["IdCorredor"];
            dtCorredores.PrimaryKey = dc;
        }

        public DataTable Leer()
        {
            return dtCorredores;
        }

        public bool Agregar(int id, string nombre)
        {
            bool res = false;
            DataRow dr = dtCorredores.Rows.Find(id);
            if(dr == null)
            {
                DataRow nuevo = dtCorredores.NewRow();
                nuevo["IdCorredor"] = id;
                nuevo["Nombre"] = nombre;
                dtCorredores.Rows.Add(nuevo);
                da.Update(dtCorredores);
                res =  true;
            }
            return res;
 
        }

        public void Eliminar(int id)
        {
            DataRow dr = dtCorredores.Rows.Find(id);
            if (dr != null)
            {
                dr.Delete();
                da.Update(dtCorredores);
            }
        }


        public void Actualizar(int id, string nombre)
        {
            DataRow dr = dtCorredores.Rows.Find(id);
            if (dr != null)
            {
                dr["Nombre"] = nombre;
                da.Update(dtCorredores); 
            }
        }
    }
 
}
