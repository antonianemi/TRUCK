using System;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Diagnostics;

namespace TRUCK
{
	/// <summary>
	/// Descripción breve de ADOutil.
	/// </summary>
	/// 

	public class ADOutil
	{
		public OleDbConnection dbConnection;
		public DataTable dbDataTable;
		public DataSet dbDataSet;
		public OleDbDataAdapter dbDataAdapter;
		public string ArchivoDatos;
		public string CadenaConexion;
		public string CadenaSelect;
		public string NombreTabla;
		public string Condicion;        		
		public ADOutil()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		public void Conectar(string nombreBaseDatos, string commandString, string nom_tabla)
		{
			try
			{
				if (CadenaSelect == "")
				{
					CadenaSelect = "SELECT * FROM " + nom_tabla;
				}
				if (validar_database(ref nombreBaseDatos, ref commandString, ref nom_tabla))
				{                    
					//dbConnection.Open();
					dbDataSet = new DataSet();
					dbDataAdapter = new OleDbDataAdapter(CadenaSelect, dbConnection);
                	OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dbDataAdapter);
					dbDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
					dbDataAdapter.Fill(dbDataSet, nom_tabla);
                    
					dbConnection.Close();
				}
				return;
			}
			catch (System.Data.OleDb.OleDbException ex)
			{
				ShowErrors(ex);
				return;
			}
		}
        public void Conectar(string nombreBaseDatos, string commandString, string nom_tabla, string coneccion)
        {
            try
            {
                if (CadenaSelect == "")
                {
                    CadenaSelect = "SELECT * FROM " + nom_tabla;
                }
                if (validar_database(ref nombreBaseDatos, ref commandString, ref nom_tabla,ref coneccion))
                {
                    //dbConnection.Open();
                    dbDataSet = new DataSet();
                    dbDataAdapter = new OleDbDataAdapter(CadenaSelect, dbConnection);
                    OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dbDataAdapter);
                    dbDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    dbDataAdapter.Fill(dbDataSet, nom_tabla);

                    dbConnection.Close();
                }
                return;
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                ShowErrors(ex);
                return;
            }
        }       
		public void Desconectar()
		{
			dbDataAdapter.Dispose();
			dbDataSet.Clear();
			dbDataSet.Dispose();
			dbConnection.Close();
			dbConnection.Dispose();
        }
       	public void Actualizar(DataSet dbDataSet, string nombreBaseDatos, string commandString, string nom_tabla)
		{
			if (validar_database(ref nombreBaseDatos, ref commandString, ref nom_tabla))
			{
				dbDataAdapter = new OleDbDataAdapter(CadenaSelect, dbConnection);
				dbDataAdapter.UpdateCommand = new OleDbCommand(CadenaSelect,dbConnection);
				OleDbCommandBuilder commanBuilder = new OleDbCommandBuilder(dbDataAdapter);
				commanBuilder.RefreshSchema();
				dbDataAdapter.Update(dbDataSet,NombreTabla);                
			}
			return;
		}
		public void Borrar(DataSet dbDataSet, string nombreBaseDatos, string commandString, string nom_tabla)
		{
			if (validar_database(ref nombreBaseDatos, ref commandString,ref nom_tabla))
			{
				dbDataAdapter = new OleDbDataAdapter(CadenaSelect, dbConnection);
				dbDataAdapter.DeleteCommand = new OleDbCommand(CadenaSelect,dbConnection);
				OleDbCommandBuilder commanBuilder = new OleDbCommandBuilder(dbDataAdapter);
				commanBuilder.RefreshSchema();
				dbDataAdapter.Update(dbDataSet,NombreTabla);				
			}
			return;
		}
		public void Nuevo(DataSet dbDataSet, string nombreBaseDatos, string commandString, string nom_tabla)
		{
			if (validar_database(ref nombreBaseDatos, ref commandString, ref nom_tabla))
			{
				dbDataAdapter = new OleDbDataAdapter(CadenaSelect, dbConnection);
				dbDataAdapter.InsertCommand = new OleDbCommand(CadenaSelect,dbConnection);
				OleDbCommandBuilder commanBuilder = new OleDbCommandBuilder(dbDataAdapter);
				commanBuilder.RefreshSchema();
				dbDataAdapter.Update(dbDataSet,NombreTabla);
			}
			return;
		}		
		public bool validar_database(ref string nombreBaseDatos,ref string commandString, ref string nom_tabla)
		{
			if (nombreBaseDatos == "")
			{
				nombreBaseDatos = ArchivoDatos;
			}
			ArchivoDatos = nombreBaseDatos;

			if (ArchivoDatos == "")
			{
				return false;
			}
			if (commandString == "")
			{
				commandString = CadenaSelect;
			}
			CadenaSelect = commandString;

			if (CadenaSelect == "")
			{
				CadenaSelect = "SELECT * FROM " + nom_tabla;
			}	

			ArchivoDatos = Global.DATABASE;
			CadenaConexion = Global.Conexion; 

			try
			{
				dbConnection = new OleDbConnection();
                dbConnection.ConnectionString = CadenaConexion;
			}
			catch(System.PlatformNotSupportedException explat)
			{
				MessageBox.Show(explat.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			catch (Exception e)
			{
				MessageBox.Show(Global.M_Error[35,Global.idioma].ToString() + e.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			return true;
		}
        public bool validar_database(ref string nombreBaseDatos, ref string commandString, ref string nom_tabla, ref string connecion)
        {
            if (nombreBaseDatos == "")
            {
                nombreBaseDatos = ArchivoDatos;
            }
            ArchivoDatos = nombreBaseDatos;

            if (ArchivoDatos == "")
            {
                return false;
            }
            if (commandString == "")
            {
                commandString = CadenaSelect;
            }
            CadenaSelect = commandString;

            if (CadenaSelect == "")
            {
                CadenaSelect = "SELECT * FROM " + nom_tabla;
            }
            CadenaConexion = connecion;

            try
            {
                dbConnection = new OleDbConnection();
                dbConnection.ConnectionString = CadenaConexion;
            }
            catch (System.PlatformNotSupportedException explat)
            {
                MessageBox.Show(explat.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(Global.M_Error[35, Global.idioma].ToString() + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
		public void ShowErrors(System.Data.OleDb.OleDbException e)
		{
		
			System.Data.OleDb.OleDbErrorCollection errorCollection = e.Errors;
			
			System.Text.StringBuilder bld = new System.Text.StringBuilder();
			Exception inner = e.InnerException;

			if (null != inner)
			{
				MessageBox.Show("Inner Exception: " + inner.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			// Enumerate the errors to a message box.
			foreach (System.Data.OleDb.OleDbError err in errorCollection) 
			{
				//bld.Append("\n Error Code: " + err.SQLState.ToString()); 
				if (err.SQLState == "3022") bld.Append(Global.M_Error[116,Global.idioma]+"...");
				else bld.Append(err.Message);
				//bld.Append("\n Minor Err.: " + err.NativeError);
				//bld.Append("\n Source    : " + err.Source);
				
				MessageBox.Show(bld.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
				
				bld.Remove(0, bld.Length);
			}
		}			
		public string[] NombresTablas()
		{
			string[] nomTablas = new String[0];
			DataTable dataTable;
			System.DBNull dbNull=null;

			//' En el ejemplo usado anteriomente indicaba "TABLES" en lugar de "TABLE"

			object[] restrictions = new object[]{dbNull, dbNull, dbNull, "TABLE"};
			int i;
			
			if (dbConnection.State != ConnectionState.Connecting)
			{
				dbConnection = new OleDbConnection(CadenaConexion);
			}

			if (dbConnection.State != ConnectionState.Open)
			{
				dbConnection.Open();
			}
			
			dataTable = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);
			i = dataTable.Rows.Count - 1;

			if (i > -1)
			{
				nomTablas = new string[i];
				for (i = 0; i <= (dataTable.Rows.Count - 1); i++)
				{
					nomTablas[i] = dataTable.Rows[i].ItemArray.ToString();
				}
			}
			
			return nomTablas;
		}		
		public string[] NombresColumnas()
		{
			DataColumn columna;
			int i, j;
			string[] nomCol=new string[0];
			
			j = dbDataSet.Tables[NombreTabla].Columns.Count - 1;
			
			nomCol= new string[j];
			for( i = 0; i< j; i++)
			{
				columna = dbDataSet.Tables[NombreTabla].Columns[i];
				nomCol[i] = columna.ColumnName;
			}
			return(nomCol);
		}
		public void Cancel()
		{			
			MessageBox.Show(Global.M_Error[7,Global.idioma].ToString());
		}
        public int Find_Codigo(string n_codigo, string campo)
        {
            int encontro = -1;

            dbDataSet.Tables[NombreTabla].PrimaryKey = new System.Data.DataColumn[] { dbDataSet.Tables[NombreTabla].Columns[campo] };

            System.Data.DataRow dr = dbDataSet.Tables[NombreTabla].Rows.Find(Convert.ToInt32(n_codigo));

            if (dr != null)
            {
                encontro = buscar_posicion(Convert.ToInt32(n_codigo), campo);
            }
            return encontro;
        }
        public int Find_Descripcion(string descrip, string campo2, string campo1)
        {
            int encontro = -1;
            int len = descrip.Length;

            System.Data.DataRow[] dr = dbDataSet.Tables[NombreTabla].Select("SUBSTRING(" + campo2 + ",1," + len + ") = '" + descrip + "'");

            if (dr.Length > 0)
            {
                encontro = buscar_posicion(Convert.ToInt32(dr[0][campo1]), campo1);
            }
            return encontro;
        }
		public int buscar_posicion(int elemento,string clave)
		{
			int desde,hasta,medio,posicion; // desde y hasta indican los límites del array que se está mirando.
			posicion = 0;
			
			for(desde=0,hasta=dbDataSet.Tables[NombreTabla].Rows.Count-1;desde<=hasta;)
			{					
				if(desde==hasta) // si el array sólo tiene un elemento:
				{
					if(Convert.ToInt32(dbDataSet.Tables[NombreTabla].Rows[desde][clave]) == elemento) // si es la solución:
						posicion=desde; // darle el valor.
					else // si no es el valor:
						posicion=-1; // no está en el array.
					break; // Salir del bucle.
				}
				medio=(desde+hasta)/2; // Divide el array en dos.
				if(Convert.ToInt32(dbDataSet.Tables[NombreTabla].Rows[medio][clave])==elemento) // Si coincide con el central:
				{
					posicion=medio; // ese es la solución
					break; // y sale del bucle.
				}
				else if(Convert.ToInt32(dbDataSet.Tables[NombreTabla].Rows[medio][clave])>elemento) // si es menor:
					hasta=medio-1; // elige el array izquierda.
				else // y si es mayor:
					desde=medio+1; // elige el array de la derecha.
			}
			return posicion;
		}
        public int buscar_posicion(string elemento, string clave)
        {
            int desde, hasta, medio, posicion; // desde y hasta indican los límites del array que se está mirando.
            posicion = 0;

            for (desde = 0, hasta = dbDataSet.Tables[NombreTabla].Rows.Count - 1; desde <= hasta; )
            {
                if (desde == hasta) // si el array sólo tiene un elemento:
                {
                    if (String.CompareOrdinal(dbDataSet.Tables[NombreTabla].Rows[desde][clave].ToString(),elemento) == 0) // si es la solución:
                        posicion = desde; // darle el valor.
                    else // si no es el valor:
                        posicion = -1; // no está en el array.
                    break; // Salir del bucle.
                }
                medio = (desde + hasta) / 2; // Divide el array en dos.
                /*if (String.CompareOrdinal(dbDataSet.Tables[NombreTabla].Rows[medio][clave].ToString() == elemento) // Si coincide con el central:
                {
                    posicion = medio; // ese es la solución
                    break; // y sale del bucle.
                }*/
                if (String.CompareOrdinal(dbDataSet.Tables[NombreTabla].Rows[medio][clave].ToString(),elemento) > 0) // si es menor:
                    hasta = medio - 1; // elige el array izquierda.
                else if (String.CompareOrdinal(dbDataSet.Tables[NombreTabla].Rows[medio][clave].ToString(), elemento) < 0) // y si es mayor:
                    desde = medio + 1; // elige el array de la derecha.
                else
                {
                    posicion = medio;
                    break;
                }
            }
            return posicion;
        }
        public int Previous(ref CurrencyManager cmRegister)
        {
            if (cmRegister.Position > 0)
            {
                return (cmRegister.Position -= 1);
            }
            else
            {
                //MessageBox.Show(Global.M_Error[1,Global.idioma].ToString());
                return 0;
            }
        }
        public int Next(ref CurrencyManager cmRegister)
        {
            if (cmRegister.Position != cmRegister.Count - 1)
            {
                return (cmRegister.Position += 1);
            }
            else
            {
                //MessageBox.Show(Global.M_Error[0,Global.idioma].ToString());
                return (cmRegister.Count - 1);
            }
        }
    }																		
}

