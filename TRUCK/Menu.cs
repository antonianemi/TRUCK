using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Globalization;
using System.Threading;



namespace TRUCK
{


    /// <summary>
    /// Descripción breve de Form1.
    /// </summary>
    ///	
    public class Menu : System.Windows.Forms.Form
    {
        #region VARIABLES
        DataAccesQuery db;
        private MenuItem MenuInfo;
		private System.Windows.Forms.MenuItem menuinfo1;
		private System.Windows.Forms.MenuItem menuinfo2;
		private System.Windows.Forms.MenuItem menuinfo3;
		private System.Windows.Forms.MenuItem MenuCom;
		private System.Windows.Forms.MenuItem MenuExit;
		public System.Windows.Forms.MainMenu mainMenu;
		private System.ComponentModel.IContainer components = null;
		public static bool depura = false;
		private int x,y;
		public static bool User_exit = false;
		private System.Windows.Forms.MenuItem menuItem10;
		public System.Windows.Forms.MenuItem menuOpen1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem12;
		public System.Windows.Forms.StatusBar StatusBar;
		public System.Windows.Forms.StatusBarPanel NumLock;
		public System.Windows.Forms.StatusBarPanel Status;
		public System.Windows.Forms.StatusBarPanel StatusBarra;
        public System.Windows.Forms.StatusBarPanel Tiempo;
        private MenuItem menuItem13;
        private MenuItem menuItem14;
        private System.Windows.Forms.Timer timer1;
        private MenuItem menuItem16;
        private MenuItem menuItem15;
        private MenuItem menuItem17;
        private MenuItem MenuEmpresa;
		private System.Windows.Forms.MenuItem menuItem11;
        #endregion
        #region CONSTRUCTOR
        public Menu()
		{   		
			InitializeComponent();
            Global G = new Global();
			G.Cargar_Mensajes();
            G.Cargar_puertos();
			this.TransparencyKey = Color.Empty;
			this.IsMdiContainer = true;
			this.BringToFront();
		}
        #endregion


        #region EVENTS
        private void Menu_Load(object sender, System.EventArgs e)
        {
            OperatingSystem os;
            try
            {
                this.IsMdiContainer = true;
                this.WindowState = FormWindowState.Maximized;
                this.BackColor = System.Drawing.Color.Gray;
                this.Status.Text = Global.M_Error[58, Global.idioma].ToString();

                y = this.Size.Height / 8;
                x = this.Size.Width / 8;

                if (!System.IO.File.Exists(Global.appPath + "\\CAMIONERADB.FDB"))
                {
                    MessageBox.Show(Global.M_Error[31, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    this.Dispose();
                }


                else
                {
                    db = new DataAccesQuery();//se rea una nueva base de datos.

                    var data = db.getData("SELECT * FROM empresa");

                    int emp = data.Tables[0].Rows.Count;


                    if (emp <= 0)
                    {
                        WEMPRESAS empresa = new WEMPRESAS(x, y);
                        this.AddOwnedForm(empresa);
                        empresa.ShowDialog();
                        Global.Empresa = empresa.empresa.Text;
                    }
                    else
                    {

                        this.MenuEmpresa.MenuItems.Clear();

                        for (int g = 0; g < emp; g++)
                        {
                            this.MenuEmpresa.MenuItems.Add(data.Tables[0].Rows[g]["numemp"].ToString() + data.Tables[0].Rows[g]["empresa"].ToString());
                            this.MenuEmpresa.MenuItems[g].Click += new EventHandler(Menu_Click);
                        }
                    }

                    using (FileStream fi = new FileStream(Global.appPath + "\\recibe.ttt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    { fi.Close(); }

                    IDataReader Cfg = db.getDataReader("SELECT num_decimal,car_moneda,formato_fecha,tipo,display,scale,aplicacion,puerto,puerto2,puerto3,puerto4,baudrate,baudrate2,baudrate3,baudrate4 FROM configuracion where numemp = " + Global.nempresa);

                    if (!Cfg.Read())
                    {
                        Cfg.Close();
                        WDGENERAL config = new WDGENERAL(x, y, 2);
                        this.AddOwnedForm(config);
                        config.ShowDialog();
                    }
                    else
                    {
                        for (int i = 0; i < Cfg.FieldCount; i++)
                        {
                            if (Cfg.GetName(i) == "num_decimal")
                            {
                                if (!Cfg.IsDBNull(i))
                                {
                                    Global.n_decimal = Cfg.GetInt16(i);
                                    if (Global.n_decimal == 0)
                                    {
                                        Global.F_Decimal = "{0:####0}";
                                        Global.F_Total = "{0:#,###,###,##0}";
                                    }
                                    if (Global.n_decimal == 1)
                                    {
                                        Global.F_Decimal = "{0:###0.0}";
                                        Global.F_Total = "{0:###,###,##0.0}";
                                    }
                                    if (Global.n_decimal == 2)
                                    {
                                        Global.F_Decimal = "{0:##0.#0}";
                                        Global.F_Total = "{0:##,###,##0.#0}";
                                    }
                                }
                                else
                                {
                                    Global.F_Decimal = "{0:##0.#0}";
                                    Global.F_Total = "{0:##,###,##0.#0}";
                                }
                            }
                            if (Cfg.GetName(i) == "formato_fecha") { Global.F_Fecha = Cfg.GetString(i); }
                            if (Cfg.GetName(i) == "car_moneda") { Global.moneda = Cfg.GetString(i); }
                            if (Cfg.GetName(i) == "tipo") { Global.tipo_dato = Cfg.GetInt32(i); }
                            if (Cfg.GetName(i) == "display") { Global.display = Cfg.GetBoolean(i); }
                            if (Cfg.GetName(i) == "scale") { Global.scale = Cfg.GetInt32(i); }
                            if (Cfg.GetName(i) == "aplicacion") { Global.aplicacion = Cfg.GetInt32(i); }
                            if (Cfg.GetName(i) == "puerto4") { Global.P_COMM = Cfg.GetInt16(i); }
                            if (Cfg.GetName(i) == "puerto") { Global.P_COMM1 = Cfg.GetInt16(i); }
                            if (Cfg.GetName(i) == "puerto2") { Global.P_COMM2 = Cfg.GetInt16(i); }
                            if (Cfg.GetName(i) == "puerto3") { Global.P_COMM3 = Cfg.GetInt16(i); }
                            if (Cfg.GetName(i) == "baudrate4") { Global.Buad = Cfg.GetInt32(i); }
                            if (Cfg.GetName(i) == "baudrate") { Global.Buad1 = Cfg.GetInt32(i); }
                            if (Cfg.GetName(i) == "baudrate2") { Global.Buad2 = Cfg.GetInt32(i); }
                            if (Cfg.GetName(i) == "baudrate3") { Global.Buad3 = Cfg.GetInt32(i); }
                        }
                        Cfg.Close();
                    }

                    DateTime MyDate = new DateTime(Global.year, Global.mes, Global.dia, Global.hora, Global.minutos, Global.segundo);

                    string fecha = string.Format("{0:" + Global.F_Fecha + "}", MyDate);
                    string hora1 = string.Format("{0:" + Global.F_Hora + "}", MyDate);

                    this.Tiempo.Text = fecha + " " + hora1;
                    this.Tiempo.ToolTipText = MyDate.ToString("f");
                    this.Text = Global.Empresa;

                    Registro rt = new Registro();

                    ENTRADA INIC = new ENTRADA();

                    INIC.ShowDialog(this);


                    if (User_exit == true)
                    {
                        for (int i = 0; i < this.mainMenu.MenuItems.Count; i++)
                        {
                            this.mainMenu.MenuItems[i].Enabled = true;
                            for (int j = 0; j < this.mainMenu.MenuItems[i].MenuItems.Count; i++)
                            {
                                this.mainMenu.MenuItems[i].MenuItems[j].Enabled = true;
                            }
                        }
                        for (int i = 0; i < Global.privilegio.Length; i++)
                        {
                            if (Global.privilegio.Substring(i, 1) == "1")
                            {
                                if (i == 7) { this.menuItem8.Enabled = true; } //Registrar transacciones
                                if (i == 6) { this.MenuInfo.Enabled = true; }  //Generar Reportes
                                if (i == 10) { this.menuItem6.Enabled = true; } //Configuracion
                                if (i == 8) { this.menuItem11.Enabled = true; }  //Reimprimir documento
                            }
                            else
                            {
                                if (i == 7) { this.menuItem8.Enabled = false; }
                                if (i == 6) { this.MenuInfo.Enabled = false; }
                                if (i == 10) { this.menuItem6.Enabled = false; }
                                if (i == 8) { this.menuItem11.Enabled = false; }
                            }
                        }
                        if (Global.aplicacion == 0)
                        {
                            this.menuItem12.Enabled = false;  //Ajustar inventario
                            this.menuinfo3.Enabled = false;  //Reporte de Inventario por familia
                        }
                        if (Global.aplicacion == 1) this.menuItem13.Enabled = false;

                        this.Text = Global.Empresa + " [" + Global.user + "]";
                    }
                    else
                    {
                        this.Dispose();
                        this.Close();
                    }
                    this.timer1.Start();
                }
            }
            catch (System.PlatformNotSupportedException explat)
            {
                MessageBox.Show(explat.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                os = Environment.OSVersion;
                if (os.Platform != PlatformID.Win32NT)
                {
                    throw new PlatformNotSupportedException(Global.M_Error[304, Global.idioma]);
                }
                os = null;
            }
        }
        void Menu_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MenuItem hj = (MenuItem)sender;
            bool cerrado = true;

            /*for (int w = this.MdiChildren.Length; w > 0; )
            {
                w--;                
                this.MdiChildren[w].Close();
            }*/
            for (int w = 0; w < this.MdiChildren.Length; w++)
            {
                if (this.MdiChildren[w].Name == "Monitor1" || this.MdiChildren[w].Name == "Monitor3" || this.MdiChildren[w].Name == "Transacciones3m" || this.MdiChildren[w].Name == "Transacciones1m")
                {
                    cerrado = false;
                    MessageBox.Show(Global.M_Error[33, Global.idioma].ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.MdiChildren[w].Activate();
                    break;
                }
            }
            if (cerrado)
            {
                Global.nempresa = Convert.ToInt16(hj.Text.Substring(0, 1));
                Global.Empresa = hj.Text.Substring(1);
            }
        }
        private void MenuExit_Click(object sender, System.EventArgs e)
        {
            bool cerrado = true;

            for (int w = 0; w < this.MdiChildren.Length; w++)
            {
                if (this.MdiChildren[w].Name == "Monitor1" || this.MdiChildren[w].Name == "Monitor3" || this.MdiChildren[w].Name == "Transacciones3m" || this.MdiChildren[w].Name == "Transacciones1m")
                {
                    cerrado = false;
                    MessageBox.Show(Global.M_Error[33, Global.idioma].ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.MdiChildren[w].Activate();
                    break;
                }
                else this.MdiChildren[w].Close();
            }
            if (cerrado)
            {
                this.Dispose();
                this.Close();
            }
        }
        private void menuItem6_Click(object sender, System.EventArgs e)
        {
            bool cerrado = true;
            for (int w = 0; w < this.MdiChildren.Length; w++)
            {
                if (this.MdiChildren[w].Name == "WDGENERAL")
                {
                    cerrado = false;
                    this.MdiChildren[w].Close();
                    break;
                }
            }
            if (cerrado)
            {
                WDGENERAL config = new WDGENERAL(x, y, 2);
                config.MdiParent = this;
                this.Status.Text = config.Tag.ToString();
                config.Show();
            }
        }
        private void menuItem9_Click(object sender, System.EventArgs e)
        {
            ENTRADA INIC = new ENTRADA();
            INIC.ShowDialog();
            if (User_exit == true)
            {
                for (int i = 0; i < this.mainMenu.MenuItems.Count; i++)
                {
                    this.mainMenu.MenuItems[i].Enabled = true;
                    for (int j = 0; j < this.mainMenu.MenuItems[i].MenuItems.Count; i++)
                    {
                        this.mainMenu.MenuItems[i].MenuItems[j].Enabled = true;
                    }
                }
                for (int i = 0; i < Global.privilegio.Length; i++)
                {
                    if (Global.privilegio.Substring(i, 1) == "1")
                    {
                        if (i == 7) { this.menuItem8.Enabled = true; } //Registrar transacciones
                        if (i == 6) { this.MenuInfo.Enabled = true; }  //Generar Reportes
                        if (i == 10) { this.menuItem6.Enabled = true; } //Configuracion
                        if (i == 8) { this.menuItem11.Enabled = true; }  //Reimprimir documento
                    }
                    else
                    {
                        if (i == 7) { this.menuItem8.Enabled = false; }
                        if (i == 6) { this.MenuInfo.Enabled = false; }
                        if (i == 10) { this.menuItem6.Enabled = false; }
                        if (i == 8) { this.menuItem11.Enabled = false; }
                    }
                }
                if (Global.aplicacion == 0)
                {
                    this.menuItem12.Enabled = false;  //Ajustar inventario
                    this.menuinfo3.Enabled = false;  //Reporte de Inventario por familia
                }
                if (Global.aplicacion == 1) this.menuItem13.Enabled = false;

                this.Text = Global.Empresa + " [" + Global.user + "]";
            }
            else
            {
                this.Dispose();
                this.Close();
            }
        }
        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            bool cerrado = true;
            for (int w = 0; w < this.MdiChildren.Length; w++)
            {
                if (this.MdiChildren[w].Name == "OpenWindows")
                {
                    cerrado = false;
                    this.MdiChildren[w].Activate();
                    break;
                }
            }
            if (cerrado)
            {
                OpenWindows cata = new OpenWindows();
                cata.MdiParent = this;
                cata.Show();
            }
        }
        private void menuItem4_Click(object sender, System.EventArgs e)
        {
            bool cerrado = true;
            for (int w = 0; w < this.MdiChildren.Length; w++)
            {
                if (this.MdiChildren[w].Name == "Monitor1")
                {
                    cerrado = false;
                    this.MdiChildren[w].Activate();
                }
                if (this.MdiChildren[w].Name == "Monitor3")
                {
                    cerrado = false;
                    this.MdiChildren[w].Activate();
                }
                if (this.MdiChildren[w].Name == "Transacciones3m")
                {
                    cerrado = false;
                    this.MdiChildren[w].Activate();
                    break;
                }
                if (this.MdiChildren[w].Name == "Transacciones2m")
                {
                    cerrado = false;
                    this.MdiChildren[w].Activate();
                    break;
                }
                if (this.MdiChildren[w].Name == "Transacciones1m")
                {
                    cerrado = false;
                    this.MdiChildren[w].Activate();
                    break;
                }
            }
            if (cerrado)
            {
                switch (Global.tipo_dato)
                {
                    case 1:
                        {
                            Monitor1 moni = new Monitor1();
                            moni.MdiParent = this;
                            moni.Show();
                        } break;
                    case 2:
                        {
                            Monitor3 moni = new Monitor3();
                            moni.MdiParent = this;
                            moni.Show();
                        } break;
                }
            }
        }
        private void menuItem5_Click(object sender, System.EventArgs e)
        {
            bool cerrado = true;
            for (int w = 0; w < this.MdiChildren.Length; w++)
            {
                if (this.MdiChildren[w].Name == "Registro")
                {
                    cerrado = false;
                    this.MdiChildren[w].Activate();
                    break;
                }
            }
            if (cerrado)
            {
                Registro reg = new Registro();
                reg.MdiParent = this;
                reg.Show();
            }
        }
        private void menuItem8_Click(object sender, System.EventArgs e)
        {
            bool cerrado = true;
            for (int w = 0; w < this.MdiChildren.Length; w++)
            {
                if (this.MdiChildren[w].Name == "Monitor1")
                {
                    cerrado = false;
                    this.MdiChildren[w].Activate();
                }
                if (this.MdiChildren[w].Name == "Monitor3")
                {
                    cerrado = false;
                    this.MdiChildren[w].Activate();
                }
                if (this.MdiChildren[w].Name == "Transacciones3m")
                {
                    cerrado = false;
                    this.MdiChildren[w].Activate();
                    break;
                }
                if (this.MdiChildren[w].Name == "Transacciones2m")
                {
                    cerrado = false;
                    this.MdiChildren[w].Activate();
                    break;
                }
                if (this.MdiChildren[w].Name == "Transacciones1m")
                {
                    cerrado = false;
                    this.MdiChildren[w].Activate();
                    break;
                }
            }
            if (cerrado)
            {
                switch (Global.tipo_dato)
                {
                    case 1:
                        {
                            Transacciones1m E_S = new Transacciones1m();
                            E_S.MdiParent = this;
                            if (!E_S.cancelar_transaccion) E_S.Show();
                        } break;
                    case 2:
                        {
                            //Transacciones3m E_S = new Transacciones3m();
                            //E_S.MdiParent = this;
                            //if (!E_S.cancelar_transaccion) E_S.Show();
                        } break;
                    /* case 3:
                         {
                             Transacciones2m E_S = new Transacciones2m();
                             E_S.MdiParent = this;
                             if (!E_S.cancelar_transaccion) E_S.Show();
                         } break;        */
                }
            }
        }
        private void menuinfo1_Click(object sender, EventArgs e)
        {
            RListados RL = new RListados(0);
            RL.Show();
        }
        private void menuinfo2_Click(object sender, EventArgs e)
        {
            RHistoria RH = new RHistoria();
            RH.Show();
        }
        private void menuItem1_Click(object sender, EventArgs e)
        {
            ROtros RO = new ROtros(1);
            RO.Show();
        }
        private void menuItem3_Click(object sender, EventArgs e)
        {
            ROtros RO = new ROtros(2);
            RO.Show();
        }
        private void menuItem11_Click(object sender, EventArgs e)
        {
            Folio fo = new Folio();
            fo.Show();
        }
        private void menuItem14_Click(object sender, EventArgs e)
        {
            Global.clv_aceptada = false;
            clave clv1 = new clave(2);
            clv1.inicio_user.Text = Global.user;
            clv1.ShowDialog(this);
            if (Global.clv_aceptada && Global.privilegio.Substring(0, 1) == "1")
            {
                WPASS pass = new WPASS(this.Location.X, this.Location.Y);
                pass.ShowDialog(this);
            }
            else { MessageBox.Show(Global.M_Error[51, Global.idioma]); }
        }
        private void menuItem12_Click(object sender, EventArgs e)
        {
            Global.clv_aceptada = false;
            clave clv1 = new clave(2);
            clv1.inicio_user.Text = Global.user;
            clv1.ShowDialog(this);
            if (Global.clv_aceptada && Global.privilegio.Substring(0, 1) == "1")
            {
                Inventario iv = new Inventario(this.Location.X, this.Location.Y);
                iv.ShowDialog(this);
            }
            else { MessageBox.Show(Global.M_Error[51, Global.idioma]); }
        }
        private void menuinfo3_Click(object sender, EventArgs e)
        {
            ROtros RO = new ROtros(0);
            RO.Show();
        }
        private void menuItem13_Click(object sender, EventArgs e)
        {
            Liquidacion RL = new Liquidacion();
            RL.Show();
        }
        private void menuItem10_Click(object sender, EventArgs e)
        {
            Acerca a = new Acerca();
            a.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime MyDate = new DateTime(Global.year, Global.mes, Global.dia, System.DateTime.Now.Hour, System.DateTime.Now.Minute, System.DateTime.Now.Second);

            string fecha = string.Format("{0:" + Global.F_Fecha + "}", MyDate);
            string hora1 = string.Format("{0:" + Global.F_Hora + "}", MyDate);

            this.Tiempo.Text = fecha + " " + hora1;
            this.Tiempo.ToolTipText = MyDate.ToString("f");
            this.Text = Global.Empresa;
        }
        private void menuItem15_Click(object sender, EventArgs e) //Compactar DataBase
        {
            Global.clv_aceptada = false;
            clave clv1 = new clave(2);
            clv1.inicio_user.Text = Global.user;
            clv1.ShowDialog(this);
            if (Global.clv_aceptada && Global.privilegio.Substring(0, 1) == "1")
            {
                //Global.DATABASE = Global.appPath + @"\" + Global.NAME_DATABASE;
                //Global.Conexion = Global.Motor + Global.DATABASE;

                if (System.IO.File.Exists(Global.DATABASE))
                {
                    CompactAccessDB(Global.Conexion, Global.DATABASE);
                }
            }
        }
        private void menuItem17_Click(object sender, EventArgs e) // Respalda DataBase
        {

            Global.clv_aceptada = false;

            clave clv1 = new clave(2);

            clv1.inicio_user.Text = Global.user;

            clv1.ShowDialog(this);


            if (Global.clv_aceptada && Global.privilegio.Substring(0, 1) == "1")
            {

                string nombre_backup = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString();


                if (System.IO.File.Exists(Global.DATABASE))
                {
                    if (!System.IO.File.Exists(Global.appPath + "\\" + nombre_backup + ".mdb")) System.IO.File.Copy(Global.DATABASE, Global.appPath + "\\" + nombre_backup + ".mdb", true);
                }

            }
        }       
        //One of the MDI Child windows has been activated
		protected void MDIChildActivated(object sender, System.EventArgs e) 
		{		
			if (null == this.ActiveMdiChild) 
			{
				StatusBar.Text = "";
			} 
			else 
			{
				StatusBar.Text = this.ActiveMdiChild.Text;
			}
		}
		//Window->Cascade Menu item handler
		protected void WindowCascade_Click(object sender, System.EventArgs e) 
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}
		//Window->Tile Horizontally Menu item handler
		protected void WindowTileH_Click(object sender, System.EventArgs e) 
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}
		//Window->Tile Vertically Menu item handler
		protected void WindowTileV_Click(object sender, System.EventArgs e) 
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}
        #endregion

        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            if (System.IO.File.Exists(Global.appPath + "\\setup.txt"))
            {
                StreamReader fi = System.IO.File.OpenText(Global.appPath + "\\setup.txt");
                fi.BaseStream.Position = 0;

                if (fi.Peek() != -1)
                {
                    Global.idioma2 = fi.ReadLine().Trim();
                    if (Global.idioma2 == "es-MX") Global.idioma = 0;
                    if (Global.idioma2 == "en-US") Global.idioma = 1;
                }
                fi.Close();
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(Global.idioma2);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Global.idioma2);
            Application.Run(new Menu());
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuOpen1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.MenuCom = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.MenuInfo = new System.Windows.Forms.MenuItem();
            this.menuinfo1 = new System.Windows.Forms.MenuItem();
            this.menuinfo2 = new System.Windows.Forms.MenuItem();
            this.menuinfo3 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.MenuEmpresa = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.MenuExit = new System.Windows.Forms.MenuItem();
            this.StatusBar = new System.Windows.Forms.StatusBar();
            this.NumLock = new System.Windows.Forms.StatusBarPanel();
            this.Status = new System.Windows.Forms.StatusBarPanel();
            this.StatusBarra = new System.Windows.Forms.StatusBarPanel();
            this.Tiempo = new System.Windows.Forms.StatusBarPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NumLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBarra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tiempo)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuOpen1,
            this.MenuCom,
            this.MenuInfo,
            this.MenuEmpresa,
            this.menuItem10,
            this.MenuExit});
            // 
            // menuOpen1
            // 
            this.menuOpen1.Index = 0;
            this.menuOpen1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.menuItem16,
            this.menuItem15,
            this.menuItem17,
            this.menuItem7,
            this.menuItem14,
            this.menuItem9});
            this.menuOpen1.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            resources.ApplyResources(this.menuOpen1, "menuOpen1");
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            resources.ApplyResources(this.menuItem2, "menuItem2");
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            resources.ApplyResources(this.menuItem4, "menuItem4");
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            resources.ApplyResources(this.menuItem5, "menuItem5");
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 3;
            resources.ApplyResources(this.menuItem6, "menuItem6");
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 4;
            resources.ApplyResources(this.menuItem16, "menuItem16");
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 5;
            resources.ApplyResources(this.menuItem15, "menuItem15");
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 6;
            resources.ApplyResources(this.menuItem17, "menuItem17");
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            resources.ApplyResources(this.menuItem7, "menuItem7");
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 8;
            resources.ApplyResources(this.menuItem14, "menuItem14");
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 9;
            resources.ApplyResources(this.menuItem9, "menuItem9");
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // MenuCom
            // 
            this.MenuCom.Index = 1;
            this.MenuCom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem11,
            this.menuItem12});
            this.MenuCom.MergeOrder = 3;
            resources.ApplyResources(this.MenuCom, "MenuCom");
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            resources.ApplyResources(this.menuItem8, "menuItem8");
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 1;
            resources.ApplyResources(this.menuItem11, "menuItem11");
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 2;
            resources.ApplyResources(this.menuItem12, "menuItem12");
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // MenuInfo
            // 
            this.MenuInfo.Index = 2;
            this.MenuInfo.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuinfo1,
            this.menuinfo2,
            this.menuinfo3,
            this.menuItem1,
            this.menuItem3,
            this.menuItem13});
            this.MenuInfo.MergeOrder = 5;
            resources.ApplyResources(this.MenuInfo, "MenuInfo");
            // 
            // menuinfo1
            // 
            this.menuinfo1.Index = 0;
            resources.ApplyResources(this.menuinfo1, "menuinfo1");
            this.menuinfo1.Click += new System.EventHandler(this.menuinfo1_Click);
            // 
            // menuinfo2
            // 
            this.menuinfo2.Index = 1;
            resources.ApplyResources(this.menuinfo2, "menuinfo2");
            this.menuinfo2.Click += new System.EventHandler(this.menuinfo2_Click);
            // 
            // menuinfo3
            // 
            this.menuinfo3.Index = 2;
            resources.ApplyResources(this.menuinfo3, "menuinfo3");
            this.menuinfo3.Click += new System.EventHandler(this.menuinfo3_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            resources.ApplyResources(this.menuItem1, "menuItem1");
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            resources.ApplyResources(this.menuItem3, "menuItem3");
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 5;
            resources.ApplyResources(this.menuItem13, "menuItem13");
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // MenuEmpresa
            // 
            this.MenuEmpresa.Index = 3;
            resources.ApplyResources(this.MenuEmpresa, "MenuEmpresa");
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 4;
            this.menuItem10.MergeOrder = 8;
            resources.ApplyResources(this.menuItem10, "menuItem10");
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Index = 5;
            this.MenuExit.MergeOrder = 9;
            resources.ApplyResources(this.MenuExit, "MenuExit");
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.NumLock,
            this.Status,
            this.StatusBarra,
            this.Tiempo});
            this.StatusBar.ShowPanels = true;
            // 
            // NumLock
            // 
            resources.ApplyResources(this.NumLock, "NumLock");
            this.NumLock.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            // 
            // Status
            // 
            resources.ApplyResources(this.Status, "Status");
            this.Status.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            // 
            // StatusBarra
            // 
            resources.ApplyResources(this.StatusBarra, "StatusBarra");
            this.StatusBarra.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            // 
            // Tiempo
            // 
            resources.ApplyResources(this.Tiempo, "Tiempo");
            this.Tiempo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Menu
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.StatusBar);
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu;
            this.Name = "Menu";
            this.Tag = "";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBarra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tiempo)).EndInit();
            this.ResumeLayout(false);

        }
        private void CompactAccessDB(string connectionString, string mdwfilename)
        {
            //string src = connectionString;
            //string dest = "Microsoft.ACE.OLEDB.12.0; Data Source=" + Global.appPath + "\\tempdb.mdb";
            //JRO.JetEngine jro = new JRO.JetEngine();
            //jro.CompactDatabase(src, dest);
            //File.Delete(mdwfilename);
            //File.Move(Global.appPath + "\\tempdb.mdb", mdwfilename);
        }	
		protected override void Dispose(bool disposing)
		{
            bool cerrado = true;

            if (MessageBox.Show(Global.M_Error[318, Global.idioma], "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int w = 0; w < this.MdiChildren.Length; w++)
                {
                    if (this.MdiChildren[w].Name == "Monitor1" || this.MdiChildren[w].Name == "Monitor3" || this.MdiChildren[w].Name == "Transacciones3m" || this.MdiChildren[w].Name == "Transacciones1m")
                    {
                        cerrado = false;
                        MessageBox.Show(Global.M_Error[33, Global.idioma].ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.MdiChildren[w].Activate();
                        break;
                    }
                    else this.MdiChildren[w].Close();

                }
                if (cerrado)
                {                 
                    if (disposing)
                    {
                        if (components != null)
                        {
                            components.Dispose();
                        }
                    }
                    base.Dispose(disposing);
                }
            }
		}
	}
}
