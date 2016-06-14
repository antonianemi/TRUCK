using System;
using System.IO;
using System.IO.Ports;

namespace TRUCK
{
	/// <summary>
	/// Descripción breve de Global.
	/// </summary>
	/// 
	public class Global
	{
		
		public struct lgrupo
		{
			public string ngpo;
			public string nombre;
		}

      /*  public static string NAME_DATABASE = "FABATSAMTY\\EPOSERVER";
        public static string DATABASE = "DBSINS";

        public static string syspath = System.IO.Directory.GetCurrentDirectory();   //directorio de trabajo

        //public static string appPath = syspath.Replace("bin\\Debug","data");
        //public static string DATABASE = appPath + "\\" + NAME_DATABASE;		/*syspath.Replace("bin\\Debug","data\\"+ NAME_DATABASE);*/
        //public static string REPORTES = syspath.Replace("bin\\Debug","Reportes");

      /*  public static string appPath = syspath + @"\DATA";
        //public static string DATABASE = appPath+@"\" + NAME_DATABASE;
        public static string REPORTES = syspath + @"\Reportes";

        public const string Conexion = @"Integrated Security=True;Persist Security Info=True;Initial Catalog=DBSINS;Data Source=FABATSAMTY\EPOSERVER; Pooling=False";*/


        public static string NAME_DATABASE = "TRUCKDB.FDB"; //@"\\192.168.100.6\trabajo\scaletruck\DATA\DBTRUCK.MDB";
		public static string syspath = System.IO.Directory.GetCurrentDirectory();   //"C:\\Prog-pls6\\PLSLIGHT\\SCALNET-CLIENTE-SERVIDOR\\SCALENET";					//directorio de trabajo

		//public static string appPath = syspath.Replace("bin\\Debug","data");
		//public static string DATABASE = appPath + "\\" + NAME_DATABASE;		/*syspath.Replace("bin\\Debug","data\\"+ NAME_DATABASE);*/
		//public static string REPORTES = syspath.Replace("bin\\Debug","Reportes");

		public static string appPath = syspath + @"\DATA";
        public static string DATABASE = appPath + @"\" + NAME_DATABASE;
        public static string DATABASELOCAL = appPath + @"\" + NAME_DATABASE;
        public static string REPORTES = syspath + @"\Reportes";

        public const string Motor = "Microsoft.ACE.OLEDB.12.0;Password='';Persist Security Info=True;User ID=Admin; Mode =ReadWrite;Data Source= "; 
	    public static string Conexion = Motor + DATABASE;

		public static int year = System.DateTime.Now.Year;
		public static int mes = System.DateTime.Now.Month;
		public static int dia = System.DateTime.Now.Day;
		public static int hora = System.DateTime.Now.Hour;
		public static int minutos = System.DateTime.Now.Minute;
		public static int segundo = System.DateTime.Now.Second;

        public static DateTime MyDateShort = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, System.DateTime.Now.Hour, System.DateTime.Now.Minute, System.DateTime.Now.Second);

        public static string[] velocidad = new string[] {"9600", "19200", "38400", "57600" };
        public static string[] puerto = new[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7" };

        public static System.Collections.ArrayList port;

		public static string user;		//nombre del usuario
		public static string password;	//password del usuario
		public static string privilegio;  //privilegio del usuario
		public static int idioma = 0; // seleccion de mensaje
		public static string idioma2 = "es-MX"; //lenguaje ingles o español en-US o es-MX
		public static string moneda = "$"; // caracter de moneda
		public static int n_decimal = 0; // numero de decimal
		public static string F_Decimal = "{0:####0}"; //Formato de decimal
		public static string F_Total = "{0:#,###,###,##0}"; // Formato de decimal de los totales
		public static string F_Fecha = "dd/MM/yyyy"; // formato de fecha
        public static string F_Fecha2 = "yyyy/MM/dd"; // formato de fecha para la base de datos
        public static string F_Hora = "HH:mm:ss"; //formato de hora
        
		public static int nempresa = 0;     //numero de empresa 
		public static int nind;			//numero de ingrediente
		public static int ncod;			//numero de codigo
		public static int nplu;			//numero de plu
		public static int nidbas;		//numero de ID de la bascula
				
		//Arreglo para Mensajes en dos idiomas
		public static string[,] M_Error = new string[500,2]; //Listado de mensajes en el sistema 0= español 1= Ingles
        public static string frame;                 //cadena de caracteres recibida por el serial  
		public static string ppeso;					//capacidad Kg o Lb
		public static string Empresa;				//Nombre de la empresa
        public static string Logo_activo;           //Ruta del Logo Activo;
		public static string Nombre;				//Nombre del Usuario
		public static string INVENTARIO = "";       //Movimiento del Inventario
		public static int P_COMM1 = 1;				//Nombre de puerto serial para el indicador 1
        public static int P_COMM2 = 0;				//Nombre de puerto serial para el indicador 2
        public static int P_COMM3 = 0;				//Nombre de puerto serial para el indicador 3
        public static int P_COMM = 0;				//Nombre de puerto serial para el display
		public static int Buad = 0;					//Velocidad del Baud
        public static int Buad1 = 0;					//Velocidad del Baud
        public static int Buad2 = 0;					//Velocidad del Baud
        public static int Buad3 = 0;					//Velocidad del Baud
        public static bool local1 = false;
        public static bool local2 = false;
        public static bool local3 = false;
        public static bool Remoto = false;
        public static bool realizo_impresion = true;  //Para saber si se imprimio el documento
		public static bool envio_dato = false;		//bandera que indica si se envio algun dato
		public static bool clv_aceptada=false;		//Bandera que indica si se la clave es aceptada
		public static int tipo_dato = 1;            //Tipo de aplicaion de (2)tres indicadores o (1) un indicador 
        public static int scale = 0;                // Tipo de bascula o indicador conectado para elejir el protocolo de comunicacion (0) PIQ/PI (1)720i (2)otros
        public static bool display = false;         //Para saber si tiene un display remoto o no.
        public static int aplicacion = 0;           //Tipo de aplicacion (0)publica, (1)privada o (2)de pesaje solamente

		public  Global()
		{
            //Cargar_puertos();
		}

        public void Cargar_puertos()
        {

            port = new System.Collections.ArrayList();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())  port.Add(s);
            port.Sort(); 
         
            if (port.Count <= 0)
            {
                System.Windows.Forms.MessageBox.Show(Global.M_Error[320,Global.idioma]);
            }            
        }


		public void Cargar_Mensajes()
		{
			FileStream fi = new FileStream(Global.appPath+"\\mensajes.txt",FileMode.Open,FileAccess.Read,FileShare.Read);
			StreamReader sr = new StreamReader(fi,System.Text.Encoding.Unicode);
			sr.BaseStream.Position =0;
				
			int pos,l_pos;
			char cc = (char)9;
			string renglon;
			string mensaje_esp,mensaje_ing;
			int posicion;
			
			while ((renglon = sr.ReadLine()) != null)
			{
				if (renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos = renglon.Length;}
				}
				else{pos = renglon.IndexOf(cc);}
				posicion = Convert.ToInt32(renglon.Substring(0, pos));
				renglon = renglon.Substring(pos + 1);

				if (renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos = renglon.Length;}
				}
				else{pos = renglon.IndexOf(cc);}
				mensaje_esp = renglon.Substring(0, pos);
				renglon = renglon.Substring(pos + 1);

				if (renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos = renglon.Length;}
				}
				else{pos = renglon.IndexOf(cc);}
				mensaje_ing = renglon.Substring(0, pos);
				renglon = "";

				M_Error[posicion,0]=mensaje_esp;
				M_Error[posicion,1]=mensaje_ing;
				mensaje_esp="";
				mensaje_ing="";
			}															 
		}	
	}
}
