using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Diagnostics;
namespace TRUCK
{

    /// <summary>
    /// This class can save in the database new configuration or update a configuration existent.
    /// it is important to see its escenaries.
    /// </summary>
    public class WDGENERAL : System.Windows.Forms.Form, MVP.MVPGeneral.IRequiredViewOpc
    {
        private readonly MVP.MVPGeneral.IPresenterOpc _Presenter;

        #region VARIABLES
        private System.ComponentModel.IContainer components = null;
		private CurrencyManager cmRegister;
		private System.Windows.Forms.ComboBox cbm_Fecha;
		private System.Windows.Forms.ComboBox cbm_Moneda;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txt_Decimals;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label4;
		private bool editar_dato=false;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbm_Port1;
		private System.Windows.Forms.ComboBox cbm_port1_speed;
		private System.Windows.Forms.ComboBox cbm_port2;
		private System.Windows.Forms.ComboBox cbm_port2_speed;
		private System.Windows.Forms.CheckBox chk_Display;
		private System.Windows.Forms.TextBox txt_folio;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cbm_port3_speed;
		private System.Windows.Forms.ComboBox cbm_port3;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox gpr_Formats;
		private System.Windows.Forms.GroupBox gpr_Comunication;
		private System.Windows.Forms.GroupBox gpr_RemoteDisplay;
		private System.Windows.Forms.ComboBox cbm_Display_Port;
		private System.Windows.Forms.ComboBox cbm_Display_Speed;
        private ComboBox cbm_Scale_Indicator;
        private Label label9;
        private ToolStrip toolBar1;
        private ToolStripButton tbtn_Edit;
        private ToolStripButton tbtn_Save;
        private ToolStripButton tbtn_Erase;
        private ToolStripButton tbtn_close;
        private ComboBox cbm_Indicators;
        private Label label11;
        private TextBox txt_path_Server;
        private Label label15;
        private CheckBox chk_remoto;
        private Button btn_Examine;
        private Label label16;
        private ComboBox cbm_Display_Type;
        DataSet data;
        DataAccesQuery db = new DataAccesQuery();
        #endregion
        #region CONSTRUCTORS
        public WDGENERAL(int x, int y, int op)
        {
            InitializeComponent();
            Location = new System.Drawing.Point(x, y);
            TransparencyKey = Color.Empty;
            StartEscene();//change this class to start escene.
            _Presenter = new GeneralPresenter(this);//Instace of presenter.
        }
        #endregion
        /// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador, no se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WDGENERAL));
            this.txt_folio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbm_Fecha = new System.Windows.Forms.ComboBox();
            this.cbm_Moneda = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Decimals = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbm_port3_speed = new System.Windows.Forms.ComboBox();
            this.cbm_port3 = new System.Windows.Forms.ComboBox();
            this.chk_Display = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbm_port2_speed = new System.Windows.Forms.ComboBox();
            this.cbm_port2 = new System.Windows.Forms.ComboBox();
            this.cbm_port1_speed = new System.Windows.Forms.ComboBox();
            this.cbm_Port1 = new System.Windows.Forms.ComboBox();
            this.cbm_Display_Port = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbm_Display_Speed = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gpr_Formats = new System.Windows.Forms.GroupBox();
            this.gpr_Comunication = new System.Windows.Forms.GroupBox();
            this.gpr_RemoteDisplay = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbm_Display_Type = new System.Windows.Forms.ComboBox();
            this.cbm_Scale_Indicator = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolBar1 = new System.Windows.Forms.ToolStrip();
            this.tbtn_Edit = new System.Windows.Forms.ToolStripButton();
            this.tbtn_Save = new System.Windows.Forms.ToolStripButton();
            this.tbtn_Erase = new System.Windows.Forms.ToolStripButton();
            this.tbtn_close = new System.Windows.Forms.ToolStripButton();
            this.cbm_Indicators = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_path_Server = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chk_remoto = new System.Windows.Forms.CheckBox();
            this.btn_Examine = new System.Windows.Forms.Button();
            this.gpr_Formats.SuspendLayout();
            this.gpr_Comunication.SuspendLayout();
            this.gpr_RemoteDisplay.SuspendLayout();
            this.toolBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_folio
            // 
            resources.ApplyResources(this.txt_folio, "txt_folio");
            this.txt_folio.Name = "txt_folio";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbm_Fecha
            // 
            resources.ApplyResources(this.cbm_Fecha, "cbm_Fecha");
            this.cbm_Fecha.Name = "cbm_Fecha";
            // 
            // cbm_Moneda
            // 
            resources.ApplyResources(this.cbm_Moneda, "cbm_Moneda");
            this.cbm_Moneda.Name = "cbm_Moneda";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txt_Decimals
            // 
            resources.ApplyResources(this.txt_Decimals, "txt_Decimals");
            this.txt_Decimals.Name = "txt_Decimals";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // cbm_port3_speed
            // 
            resources.ApplyResources(this.cbm_port3_speed, "cbm_port3_speed");
            this.cbm_port3_speed.Name = "cbm_port3_speed";
            // 
            // cbm_port3
            // 
            resources.ApplyResources(this.cbm_port3, "cbm_port3");
            this.cbm_port3.Name = "cbm_port3";
            // 
            // chk_Display
            // 
            resources.ApplyResources(this.chk_Display, "chk_Display");
            this.chk_Display.Name = "chk_Display";
            this.chk_Display.CheckedChanged += new System.EventHandler(this.DISPLAY_CheckedChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cbm_port2_speed
            // 
            resources.ApplyResources(this.cbm_port2_speed, "cbm_port2_speed");
            this.cbm_port2_speed.Name = "cbm_port2_speed";
            // 
            // cbm_port2
            // 
            resources.ApplyResources(this.cbm_port2, "cbm_port2");
            this.cbm_port2.Name = "cbm_port2";
            // 
            // cbm_port1_speed
            // 
            resources.ApplyResources(this.cbm_port1_speed, "cbm_port1_speed");
            this.cbm_port1_speed.Name = "cbm_port1_speed";
            // 
            // cbm_Port1
            // 
            resources.ApplyResources(this.cbm_Port1, "cbm_Port1");
            this.cbm_Port1.Name = "cbm_Port1";
            // 
            // cbm_Display_Port
            // 
            resources.ApplyResources(this.cbm_Display_Port, "cbm_Display_Port");
            this.cbm_Display_Port.Name = "cbm_Display_Port";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // cbm_Display_Speed
            // 
            resources.ApplyResources(this.cbm_Display_Speed, "cbm_Display_Speed");
            this.cbm_Display_Speed.Name = "cbm_Display_Speed";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // gpr_Formats
            // 
            this.gpr_Formats.Controls.Add(this.label8);
            this.gpr_Formats.Controls.Add(this.cbm_Fecha);
            this.gpr_Formats.Controls.Add(this.txt_Decimals);
            this.gpr_Formats.Controls.Add(this.label7);
            this.gpr_Formats.Controls.Add(this.label1);
            this.gpr_Formats.Controls.Add(this.cbm_Moneda);
            this.gpr_Formats.Controls.Add(this.label4);
            this.gpr_Formats.Controls.Add(this.txt_folio);
            resources.ApplyResources(this.gpr_Formats, "gpr_Formats");
            this.gpr_Formats.Name = "gpr_Formats";
            this.gpr_Formats.TabStop = false;
            // 
            // gpr_Comunication
            // 
            this.gpr_Comunication.Controls.Add(this.label10);
            this.gpr_Comunication.Controls.Add(this.label6);
            this.gpr_Comunication.Controls.Add(this.cbm_Port1);
            this.gpr_Comunication.Controls.Add(this.cbm_port3_speed);
            this.gpr_Comunication.Controls.Add(this.cbm_port2);
            this.gpr_Comunication.Controls.Add(this.cbm_port1_speed);
            this.gpr_Comunication.Controls.Add(this.label5);
            this.gpr_Comunication.Controls.Add(this.label3);
            this.gpr_Comunication.Controls.Add(this.cbm_port3);
            this.gpr_Comunication.Controls.Add(this.cbm_port2_speed);
            this.gpr_Comunication.Controls.Add(this.label12);
            this.gpr_Comunication.Controls.Add(this.label2);
            resources.ApplyResources(this.gpr_Comunication, "gpr_Comunication");
            this.gpr_Comunication.Name = "gpr_Comunication";
            this.gpr_Comunication.TabStop = false;
            // 
            // gpr_RemoteDisplay
            // 
            this.gpr_RemoteDisplay.Controls.Add(this.label16);
            this.gpr_RemoteDisplay.Controls.Add(this.cbm_Display_Type);
            this.gpr_RemoteDisplay.Controls.Add(this.label13);
            this.gpr_RemoteDisplay.Controls.Add(this.label14);
            this.gpr_RemoteDisplay.Controls.Add(this.cbm_Display_Port);
            this.gpr_RemoteDisplay.Controls.Add(this.cbm_Display_Speed);
            this.gpr_RemoteDisplay.Controls.Add(this.chk_Display);
            resources.ApplyResources(this.gpr_RemoteDisplay, "gpr_RemoteDisplay");
            this.gpr_RemoteDisplay.Name = "gpr_RemoteDisplay";
            this.gpr_RemoteDisplay.TabStop = false;
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // cbm_Display_Type
            // 
            resources.ApplyResources(this.cbm_Display_Type, "cbm_Display_Type");
            this.cbm_Display_Type.Name = "cbm_Display_Type";
            // 
            // cbm_Scale_Indicator
            // 
            resources.ApplyResources(this.cbm_Scale_Indicator, "cbm_Scale_Indicator");
            this.cbm_Scale_Indicator.Name = "cbm_Scale_Indicator";
            this.cbm_Scale_Indicator.SelectedIndexChanged += new System.EventHandler(this.type_scale_SelectedIndexChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // toolBar1
            // 
            this.toolBar1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_Edit,
            this.tbtn_Save,
            this.tbtn_Erase,
            this.tbtn_close});
            resources.ApplyResources(this.toolBar1, "toolBar1");
            this.toolBar1.Name = "toolBar1";
            // 
            // tbtn_Edit
            // 
            resources.ApplyResources(this.tbtn_Edit, "tbtn_Edit");
            this.tbtn_Edit.Name = "tbtn_Edit";
            this.tbtn_Edit.Click += new System.EventHandler(this.tbtn_Edit_Click);
            // 
            // tbtn_Save
            // 
            resources.ApplyResources(this.tbtn_Save, "tbtn_Save");
            this.tbtn_Save.Name = "tbtn_Save";
            this.tbtn_Save.Click += new System.EventHandler(this.tbtn_Save_Click);
            // 
            // tbtn_Erase
            // 
            resources.ApplyResources(this.tbtn_Erase, "tbtn_Erase");
            this.tbtn_Erase.Name = "tbtn_Erase";
            this.tbtn_Erase.Click += new System.EventHandler(this.tbtn_Erase_Click);
            // 
            // tbtn_close
            // 
            resources.ApplyResources(this.tbtn_close, "tbtn_close");
            this.tbtn_close.Name = "tbtn_close";
            this.tbtn_close.Click += new System.EventHandler(this.tbtn_close_Click);
            // 
            // cbm_Indicators
            // 
            resources.ApplyResources(this.cbm_Indicators, "cbm_Indicators");
            this.cbm_Indicators.Name = "cbm_Indicators";
            this.cbm_Indicators.SelectedIndexChanged += new System.EventHandler(this.type_appli_SelectedIndexChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txt_path_Server
            // 
            this.txt_path_Server.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_path_Server.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            resources.ApplyResources(this.txt_path_Server, "txt_path_Server");
            this.txt_path_Server.Name = "txt_path_Server";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // chk_remoto
            // 
            resources.ApplyResources(this.chk_remoto, "chk_remoto");
            this.chk_remoto.Name = "chk_remoto";
            this.chk_remoto.UseVisualStyleBackColor = true;
            this.chk_remoto.CheckedChanged += new System.EventHandler(this.Rmto_CheckedChanged);
            // 
            // btn_Examine
            // 
            resources.ApplyResources(this.btn_Examine, "btn_Examine");
            this.btn_Examine.Name = "btn_Examine";
            this.btn_Examine.UseVisualStyleBackColor = true;
            this.btn_Examine.Click += new System.EventHandler(this.button1_Click);
            // 
            // WDGENERAL
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btn_Examine);
            this.Controls.Add(this.chk_remoto);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_path_Server);
            this.Controls.Add(this.cbm_Indicators);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.cbm_Scale_Indicator);
            this.Controls.Add(this.gpr_RemoteDisplay);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gpr_Comunication);
            this.Controls.Add(this.gpr_Formats);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WDGENERAL";
            this.Tag = "";
            this.gpr_Formats.ResumeLayout(false);
            this.gpr_Formats.PerformLayout();
            this.gpr_Comunication.ResumeLayout(false);
            this.gpr_RemoteDisplay.ResumeLayout(false);
            this.toolBar1.ResumeLayout(false);
            this.toolBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion
        string GetIP()
		{	   
			String strHostName = System.Net.Dns.GetHostName();
			// Find host by name
			System.Net.IPHostEntry iphostentry = System.Net.Dns.GetHostEntry(strHostName);
			// Grab the first IP addresses
			string IPStr = "";
			foreach(System.Net.IPAddress ipaddress in iphostentry.AddressList)
			{
				IPStr = ipaddress.ToString();
				return IPStr;
			}
			return IPStr;
		}
		private void limpiar()
		{	
			cbm_Fecha.Text="";
			cbm_Moneda.Text="";
			txt_Decimals.Text="0";
        }
       
        #region eventos de captura
        private void button2_Click(object sender, System.EventArgs e)
		{
			this.toolBar1.Visible = true;
			this.toolBar1.BringToFront();
			limpiar();
		}
        private void button1_Click(object sender, EventArgs e)
        {
            if (chk_remoto.Checked)
            {
                OpenFileDialog dlgOpenFile = new OpenFileDialog();
                dlgOpenFile.ShowReadOnly = true;

                if (dlgOpenFile.ShowDialog() == DialogResult.OK)
                {
                    this.txt_path_Server.Text = dlgOpenFile.FileName;
                }
            }
        } 
		private void s_moneda_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                txt_Decimals.Focus();
            }
		}
        private void n_decimal_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (Convert.ToInt16(this.txt_Decimals.Text) > 2)
				{
					MessageBox.Show(Global.M_Error[74,Global.idioma].ToString());
					this.txt_Decimals.Focus();
				}
				else 
				{
					IDataReader Cfg = db.getDataReader("SELECT * FROM DatosGral");

					if (!Cfg.Read())
					{
						Cfg.Close();
					}
					Cfg.Close();
				}
			}
		}
        private void f_fecha_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{ this.cbm_Moneda.Focus();}
		}
        private void editar_TextChanged(object sender, System.EventArgs e)
		{
			editar_dato=true;
        }
        #endregion


        #region eventos de combobox y check box
        private void DISPLAY_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.chk_Display.Checked)
			{
                this.cbm_Display_Port.Enabled=true;
				this.cbm_Display_Speed.Enabled=true;
                Global.display = true;
			}
			else
			{				
				
				this.cbm_Display_Port.Enabled=false;
				this.cbm_Display_Speed.Enabled=false;
                Global.display = false;
			}
		}
        private void type_scale_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.scale = this.cbm_Scale_Indicator.SelectedIndex;
            if (Global.aplicacion < 2)
            {
                this.cbm_Indicators.Enabled = true;
            }
            else
            {
                this.cbm_Indicators.Enabled = false;
            }
        }
        private void type_appli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbm_Indicators.SelectedIndex == 0)
            {
                Global.tipo_dato = 1;
                this.cbm_port2.Enabled = false;
                this.cbm_port3.Enabled = false;
                this.cbm_port2_speed.Enabled = false;
                this.cbm_port3_speed.Enabled = false;
            }
            else if (this.cbm_Indicators.SelectedIndex == 1)
            {
                Global.tipo_dato = 2;
                this.cbm_port2.Enabled = true;
                this.cbm_port3.Enabled = true;
                this.cbm_port2_speed.Enabled = true;
                this.cbm_port3_speed.Enabled = true;
            }
        
        }
        private void Rmto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_remoto.Checked)
            {
                Global.Remoto = true;
                this.txt_path_Server.Enabled = true;
                this.txt_path_Server.Focus();
            }
            else
            {
                Global.Remoto = false;
                this.txt_path_Server.Enabled = false;
                if (System.IO.File.Exists(Global.appPath + "\\Connect.txt"))
                {
                    System.IO.File.Delete(Global.appPath + "\\Connect.txt");
                }
            }
        }
        #endregion

        void loadCombos()
        {
            InitializeComboDisplay();
            InitializeComboFecha();
            InitializeComboIndicator();
            InitializeComboMoneda();
            InitializeCombosIndicators();
            InitializeCombosPorts();
            InitializeCombosSpeeds();
            InitializeDisplayPort();
        }
        void InitializeCombosIndicators()
        {
            cbm_Indicators.Enabled = true;
            cbm_Indicators.Items.Add(Global.M_Error[69, Global.idioma]);
            cbm_Indicators.Items.Add(Global.M_Error[70, Global.idioma]);
            cbm_Indicators.SelectedIndex = 0;
        }
        void InitializeComboIndicator()
        {
            cbm_Scale_Indicator.Items.Add("PIQ/PI");
            cbm_Scale_Indicator.Items.Add("720i");
            cbm_Scale_Indicator.SelectedIndex = 0;
        }
        void InitializeComboMoneda()
        {
            cbm_Moneda.Items.Add("$");
            cbm_Moneda.Items.Add("€");
            cbm_Moneda.Items.Add("£");
            cbm_Moneda.Items.Add("Ç");
            cbm_Moneda.Items.Add("R");
            cbm_Moneda.SelectedIndex = 0;
        }
        void InitializeComboDisplay()
        {
            cbm_Display_Type.Items.Add("AURORA65");
            cbm_Display_Type.Items.Add("GM8895A");
            cbm_Display_Type.SelectedIndex = 0;
        }
        void InitializeDisplayPort()
        {
            cbm_Display_Port.Items.Add("");
        }
        void InitializeComboFecha()
        {
            cbm_Fecha.Items.Add("dd/MM/yyyy");
            cbm_Fecha.Items.Add("MM/dd/yyyy");
            cbm_Fecha.Items.Add("yyyy/MM/dd");
            cbm_Fecha.SelectedIndex = 0;
        }
        void InitializeCombosPorts()
        {
            if (Global.port.Count > 0)
            {
                for (int z = 0; z < Global.port.Count; z++)
                {
                    cbm_Port1.Items.Add(Global.port[z]);
                    cbm_port2.Items.Add(Global.port[z]);
                    cbm_port3.Items.Add(Global.port[z]);
                    cbm_Display_Port.Items.Add(Global.port[z]);
                }

                cbm_Port1.SelectedIndex = 0;
                cbm_port2.SelectedIndex = 0;
                cbm_port3.SelectedIndex = 0;
                cbm_Display_Port.SelectedIndex = 0;
            }
        }
        void InitializeCombosSpeeds()
        {
            for (int z = 0; z < Global.velocidad.Length; z++)
            {
                cbm_port1_speed.Items.Add(Global.velocidad[z]);
                cbm_port2_speed.Items.Add(Global.velocidad[z]);
                cbm_port3_speed.Items.Add(Global.velocidad[z]);
                cbm_Display_Speed.Items.Add(Global.velocidad[z]);
            }
            cbm_port1_speed.SelectedIndex = 0;
            cbm_port2_speed.SelectedIndex = 0;
            cbm_port3_speed.SelectedIndex = 0;
        }
        void StartEscene()
        {
            loadCombos();
        }
        void EsceneLoadData()
        {
        }
        void FillForm()
        {
        }
        void FillFormFromDataBase()
        {
        }
        void RefreshForm()
        {
        }
        /// <summary>
        /// Clean the values in the form, clean all the controls and verify of this form contains changes for to save.
        /// </summary>
        void CleanForm()
        {
        }
        public void ShowEscenaInicial()
        {   
        }
        public void ShowEscenaAccessDenied()
        {   
        }
        public void ShowEscenaAccess()
        {  
        }
        public void ClearControls()
        {  
        }
        public void BindDataToView(ENT_CONFIGURATION obj)
        {  
        }
        public void sendDataFromView()
        {
            
        }
        private void tbtn_close_Click(object sender, EventArgs e)
        {

        }
        private void tbtn_Erase_Click(object sender, EventArgs e)
        {

        }

        private void tbtn_Save_Click(object sender, EventArgs e)
        {
            ENT_CONFIGURATION obj = new ENT_CONFIGURATION();
            /*
            cbm_Display_Type
            cbm_Scale_Indicator
            cbm_Indicators
            */
            obj.car_moneda    = cbm_Moneda.SelectedItem.ToString();
            obj.num_decimal   = (txt_Decimals.Text=="")?0:Convert.ToInt32(txt_Decimals.Text);//Validate if is number
            obj.folio         = Convert.ToInt32(txt_folio.Text);
            obj.display       = (chk_Display.Checked) ? 1 : 0;
            obj.puerto4       = (cbm_Display_Port.SelectedItem!=null)  ? Convert.ToInt32((cbm_Display_Port.SelectedItem.ToString() == "") ? 0 : 0)  : 0;
            obj.baudrate4     = (cbm_Display_Speed.SelectedItem!=null) ? Convert.ToInt32((cbm_Display_Speed.SelectedItem.ToString() == "") ? 0 : 0) : 0;
            obj.baudrate      = (cbm_port1_speed.SelectedItem!=null)   ? Convert.ToInt32((cbm_port1_speed.SelectedItem.ToString() == "") ? 0 : 0)   : 0;
            obj.puerto        = (cbm_Port1.SelectedItem!=null)         ? Convert.ToInt32((cbm_Port1.SelectedItem.ToString() == "") ? 0 : 0)         : 0;
            obj.baudrate2     = (cbm_port2_speed.SelectedItem!=null)   ? Convert.ToInt32((cbm_port2_speed.SelectedItem.ToString() == "") ? 0 : 0)   : 0;
            obj.puerto2       = (cbm_port2.SelectedItem!=null)         ? Convert.ToInt32((cbm_port2.SelectedItem.ToString() == "") ? 0 : 0)         : 0;
            obj.baudrate3     = (cbm_port3_speed.SelectedItem!=null)   ? Convert.ToInt32((cbm_port3_speed.SelectedItem.ToString() == "") ? 0 : 0)   : 0;
            obj.puerto3       = (cbm_port3.SelectedItem != null)       ? Convert.ToInt32((cbm_port3.SelectedItem.ToString() == "") ? 0 : 0)         : 0;
            obj.tipo          = (cbm_Display_Type.SelectedItem != null)? Convert.ToInt32((cbm_Display_Type.SelectedItem.ToString() == "") ? 0 : 0)  : 0;
            obj.path          = txt_path_Server.Text;
            obj.rmto          = (chk_remoto.Checked) ? "1" : "0";
            obj.formato_fecha = (cbm_Fecha.SelectedItem != null)     ? (cbm_Fecha.SelectedItem.ToString() == "" ? "" : "") : "";
            
            _Presenter.saveConfiguration(obj);

            
        }
        private void tbtn_Edit_Click(object sender, EventArgs e)
        {

        }

        public ENT_CONFIGURATION getDataFromView()
        {
            ENT_CONFIGURATION obj = new ENT_CONFIGURATION();
            
            return obj;
        }
    }
}

