using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace PrySilva2503
{
    OleDbConnection conexionBD;
    OleDbCommand comandoBD;
    OleDbDataAdapter adaptadorDS;
    DataSet objDataSet = new DataSet();
    DirectoryInfo rutaProyecto = new DirectoryInfo(@"../..");
    string cadenaConexion;
    public bool estadoConexion;
    internal class clsBasedeDatos
    {

    }

    public void ConectarBaseDatos()
    {
        conexionBD = new OleDbConnection(cadenaConexion);
        conexionBD.Open();
        estadoConexion = true;
    }
}
