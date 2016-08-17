using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace TRUCK
{






    public class WDGENERAL : System.Windows.Forms.Form
    {
        #region VARIABLES
        private System.ComponentModel.IContainer components = null;
		private CurrencyManager cmRegister;
		private System.Windows.Forms.ComboBox f_fecha;
		private System.Windows.Forms.ComboBox s_moneda;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox n_decimal;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label4;
		private bool editar_dato=false;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox PUERTO1;
		private System.Windows.Forms.ComboBox BAUD1;
		private System.Windows.Forms.ComboBox PUERTO2;
		private System.Windows.Forms.ComboBox BAUD2;
		private System.Windows.Forms.CheckBox DISPLAY;
		private System.Windows.Forms.TextBox txt_folio;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox BAUD3;
		private System.Windows.Forms.ComboBox PUERTO3;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox PUERTO4;
		private System.Windows.Forms.ComboBox BAUD4;
        private ComboBox type_scale;
        private Label label9;
        private ToolStrip toolBar1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ComboBox type_appli;
        private Label label11;
        private TextBox path_serv;
        private Label label15;
        private CheckBox Rmto;
        private Button button1;
        private Label label16;
        private ComboBox tipo_display;
        DataSet data;
        DataAccesQuery db = new DataAccesQuery();
        #endregion
        #region CONSTRUCTORS
        public WDGENERAL(int x, int y, int op)
        {
            InitializeComponent();
            this.Location = new System.Drawing.Point(x, y);
            this.TransparencyKey = Color.Empty;
            this.s_moneda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.s_moneda_KeyDown);
            this.s_moneda.SelectedIndexChanged += new System.EventHandler(this.editar_TextChanged);
            this.n_decimal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.n_decimal_KeyDown);
            this.n_decimal.TextChanged += new System.EventHandler(this.editar_TextChanged);
            this.f_fecha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_fecha_KeyDown);
            this.f_fecha.SelectedIndexChanged += new System.EventHandler(this.editar_TextChanged);
            this.toolBar1.ItemClicked += new ToolStripItemClickedEventHandler(this.toolBar1_ButtonClick);
            if (Global.aplicacion < 2)
            {
                this.type_scale.Items.Add("PIQ/PI");
                this.type_scale.Items.Add("720i");
                this.type_scale.SelectedIndex = 0;
            }                     

            if (Global.aplicacion < 2)
            {
                this.type_appli.Enabled = true;
                this.type_appli.Items.Add(Global.M_Error[69, Global.idioma]);
                this.type_appli.Items.Add(Global.M_Error[70, Global.idioma]);
                this.type_appli.SelectedIndex = 0;
            }
            else this.type_appli.Enabled = false;

            this.f_fecha.Items.Add("dd/MM/yyyy");
            this.f_fecha.Items.Add("MM/dd/yyyy");
            this.f_fecha.Items.Add("yyyy/MM/dd");
            this.f_fecha.SelectedIndex = 0;

            this.s_moneda.Items.Add("$");
            this.s_moneda.Items.Add("€");
            this.s_moneda.Items.Add("£");
            this.s_moneda.Items.Add("Ç");
            this.s_moneda.Items.Add("R");
            this.s_moneda.SelectedIndex = 0;
            if (Global.port.Count > 0)
            {
                for (int z = 0; z < Global.port.Count; z++)
                {
                    this.PUERTO1.Items.Add(Global.port[z]);
                    this.PUERTO2.Items.Add(Global.port[z]);
                    this.PUERTO3.Items.Add(Global.port[z]);
                    this.PUERTO4.Items.Add(Global.port[z]);
                }
                this.PUERTO1.SelectedIndex = 0;
                this.PUERTO2.SelectedIndex = 0;
                this.PUERTO3.SelectedIndex = 0;
                this.PUERTO4.SelectedIndex = 0;
            }                    

            for (int z = 0; z < Global.velocidad.Length; z++)
            {
                this.BAUD1.Items.Add(Global.velocidad[z]);
                this.BAUD2.Items.Add(Global.velocidad[z]);
                this.BAUD3.Items.Add(Global.velocidad[z]);
                this.BAUD4.Items.Add(Global.velocidad[z]);
            }
            this.BAUD1.SelectedIndex = 0;
            this.BAUD2.SelectedIndex = 0;
            this.BAUD3.SelectedIndex = 0;
            this.BAUD4.SelectedIndex = 0;
                        
            this.tipo_display.Items.Add("AURORA65");
            this.tipo_display.Items.Add("GM8895A");
            this.tipo_display.SelectedIndex = 0;
            
            this.n_decimal.Text = "2";

            if (op == 1)
            {
                this.f_fecha.SelectedIndex = 0;
                this.s_moneda.SelectedIndex = 0;
                this.n_decimal.Text = "2";
            }

            try
            {     
                data = db.getData("SELECT * FROM configuracion");

                data.Tables[0].TableName = "configuracion";

                cmRegister = (CurrencyManager)this.BindingContext[data, "configuracion"];
                
                cmRegister.Position = 0;
                
                if (data.Tables[0].Rows.Count > 0)
                {
                    this.type_appli.Enabled = false;
                    Mostrar_Datos(cmRegister.Position);
                }
            }
            catch (System.PlatformNotSupportedException explat)
            {
                MessageBox.Show(explat.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            this.f_fecha = new System.Windows.Forms.ComboBox();
            this.s_moneda = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.n_decimal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.BAUD3 = new System.Windows.Forms.ComboBox();
            this.PUERTO3 = new System.Windows.Forms.ComboBox();
            this.DISPLAY = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BAUD2 = new System.Windows.Forms.ComboBox();
            this.PUERTO2 = new System.Windows.Forms.ComboBox();
            this.BAUD1 = new System.Windows.Forms.ComboBox();
            this.PUERTO1 = new System.Windows.Forms.ComboBox();
            this.PUERTO4 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.BAUD4 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tipo_display = new System.Windows.Forms.ComboBox();
            this.type_scale = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolBar1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.type_appli = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.path_serv = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Rmto = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // f_fecha
            // 
            resources.ApplyResources(this.f_fecha, "f_fecha");
            this.f_fecha.Name = "f_fecha";
            // 
            // s_moneda
            // 
            resources.ApplyResources(this.s_moneda, "s_moneda");
            this.s_moneda.Name = "s_moneda";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // n_decimal
            // 
            resources.ApplyResources(this.n_decimal, "n_decimal");
            this.n_decimal.Name = "n_decimal";
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
            // BAUD3
            // 
            resources.ApplyResources(this.BAUD3, "BAUD3");
            this.BAUD3.Name = "BAUD3";
            // 
            // PUERTO3
            // 
            resources.ApplyResources(this.PUERTO3, "PUERTO3");
            this.PUERTO3.Name = "PUERTO3";
            // 
            // DISPLAY
            // 
            resources.ApplyResources(this.DISPLAY, "DISPLAY");
            this.DISPLAY.Name = "DISPLAY";
            this.DISPLAY.CheckedChanged += new System.EventHandler(this.DISPLAY_CheckedChanged);
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
            // BAUD2
            // 
            resources.ApplyResources(this.BAUD2, "BAUD2");
            this.BAUD2.Name = "BAUD2";
            // 
            // PUERTO2
            // 
            resources.ApplyResources(this.PUERTO2, "PUERTO2");
            this.PUERTO2.Name = "PUERTO2";
            // 
            // BAUD1
            // 
            resources.ApplyResources(this.BAUD1, "BAUD1");
            this.BAUD1.Name = "BAUD1";
            // 
            // PUERTO1
            // 
            resources.ApplyResources(this.PUERTO1, "PUERTO1");
            this.PUERTO1.Name = "PUERTO1";
            // 
            // PUERTO4
            // 
            resources.ApplyResources(this.PUERTO4, "PUERTO4");
            this.PUERTO4.Name = "PUERTO4";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // BAUD4
            // 
            resources.ApplyResources(this.BAUD4, "BAUD4");
            this.BAUD4.Name = "BAUD4";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.f_fecha);
            this.groupBox1.Controls.Add(this.n_decimal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.s_moneda);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_folio);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.PUERTO1);
            this.groupBox2.Controls.Add(this.BAUD3);
            this.groupBox2.Controls.Add(this.PUERTO2);
            this.groupBox2.Controls.Add(this.BAUD1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.PUERTO3);
            this.groupBox2.Controls.Add(this.BAUD2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.tipo_display);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.PUERTO4);
            this.groupBox3.Controls.Add(this.BAUD4);
            this.groupBox3.Controls.Add(this.DISPLAY);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // tipo_display
            // 
            resources.ApplyResources(this.tipo_display, "tipo_display");
            this.tipo_display.Name = "tipo_display";
            // 
            // type_scale
            // 
            resources.ApplyResources(this.type_scale, "type_scale");
            this.type_scale.Name = "type_scale";
            this.type_scale.SelectedIndexChanged += new System.EventHandler(this.type_scale_SelectedIndexChanged);
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
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            resources.ApplyResources(this.toolBar1, "toolBar1");
            this.toolBar1.Name = "toolBar1";
            // 
            // toolStripButton1
            // 
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.Name = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            this.toolStripButton4.Name = "toolStripButton4";
            // 
            // type_appli
            // 
            resources.ApplyResources(this.type_appli, "type_appli");
            this.type_appli.Name = "type_appli";
            this.type_appli.SelectedIndexChanged += new System.EventHandler(this.type_appli_SelectedIndexChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // path_serv
            // 
            this.path_serv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.path_serv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            resources.ApplyResources(this.path_serv, "path_serv");
            this.path_serv.Name = "path_serv";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // Rmto
            // 
            resources.ApplyResources(this.Rmto, "Rmto");
            this.Rmto.Name = "Rmto";
            this.Rmto.UseVisualStyleBackColor = true;
            this.Rmto.CheckedChanged += new System.EventHandler(this.Rmto_CheckedChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WDGENERAL
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Rmto);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.path_serv);
            this.Controls.Add(this.type_appli);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.type_scale);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WDGENERAL";
            this.Tag = "";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.toolBar1.ResumeLayout(false);
            this.toolBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion
        #region funciones de DB







        /// <summary>
        /// here is saved the mode aplication when the user is selected.
        /// </summary>
        private void New_Dato()
        {
            string query = "INSERT INTO configuracion (puerto,baudrate,puerto2,baudrate2,puerto3,baudrate3,puerto4,baudrate4,tipo,scale,formato_fecha,num_decimal,car_moneda,folio,display,aplicacion,path,rmto)" +
                "VALUES ( " + this.PUERTO1.SelectedIndex + "," + this.BAUD1.SelectedIndex + "," + this.PUERTO2.SelectedIndex + "," + this.BAUD2.SelectedIndex + "," +
                this.PUERTO3.SelectedIndex + "," + this.BAUD3.SelectedIndex + "," + this.PUERTO4.SelectedIndex + "," + this.BAUD4.SelectedIndex + "," + Global.tipo_dato + "," + this.type_scale.SelectedIndex + ",'" +
                this.f_fecha.Text + "'," + Convert.ToInt16(this.n_decimal.Text) + ",'" + this.s_moneda.Text + "'," + Convert.ToInt32(this.txt_folio.Text) + ",'" + ((this.DISPLAY.Checked) ? 1 : 0) + "'," + Global.aplicacion + ",'" +
                this.path_serv.Text + "','" + ((this.Rmto.Checked) ? 1 : 0) + "')";
            try
            {
                db.ExcetuteQuery(query);
                Mostrar_Datos(cmRegister.Position);
            }
            catch (DBConcurrencyException dbcx)
            {
                string customErrorMessage;
                customErrorMessage = dbcx.Message.ToString();
                customErrorMessage += dbcx.Row[0].ToString();
                MessageBox.Show(customErrorMessage.ToString());
                data.RejectChanges();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                data.RejectChanges();
            }
        }



		private void Save_Dato()
		{

            string query = "UPDATE configuracion SET formato_fecha = '" + this.f_fecha.Text + "', num_decimal = " + ((this.n_decimal.Text.Equals("")) ? 0 : Convert.ToInt16(this.n_decimal.Text)) +
                ", baudrate = " + this.BAUD1.SelectedIndex + ", puerto = " + this.PUERTO1.SelectedIndex +
                ", baudrate2 = " + this.BAUD2.SelectedIndex + ", puerto2 = " + this.PUERTO2.SelectedIndex +
                ", baudrate3 = " + this.BAUD3.SelectedIndex + ", puerto3 = " + this.PUERTO3.SelectedIndex +
                ", baudrate4 = " + this.BAUD4.SelectedIndex + ", puerto4 = " + this.PUERTO4.SelectedIndex +
                ", car_moneda = '" + this.s_moneda.Text + "', display = " + ((this.DISPLAY.Checked) ? 1 : 0) +
                ", folio = " + ((this.n_decimal.Text.Equals("")) ? 0 : Convert.ToInt32(this.n_decimal.Text)) + ", tipo = " + Global.tipo_dato +
                ", path = '" + this.path_serv.Text + "', rmto = " + ((this.Rmto.Checked) ? 1 : 0) + ", numemp = " + Global.nempresa;
            try
            {
                switch (((this.n_decimal.Text.Equals("")) ? 0 : Convert.ToInt32(this.n_decimal.Text)))
                {
                    case 0: Global.F_Decimal = "{0:####0}"; break;
                    case 1: Global.F_Decimal = "{0:###0.0}"; break;
                    case 2: Global.F_Decimal = "{0:##0.#0}"; break;
                }

                db.ExcetuteQuery(query);
                data = db.getData("SELECT * FROM configuracion");
                Mostrar_Datos(cmRegister.Position);
            }
            catch (DBConcurrencyException dbcx)
            {
                string customErrorMessage;
                customErrorMessage = dbcx.Message.ToString();
                customErrorMessage += dbcx.Row[0].ToString();
                MessageBox.Show(customErrorMessage.ToString());
                data.RejectChanges();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                data.RejectChanges();
            }
		}
		private void Mostrar_Datos(int pos)
		{
            if (data.Tables[0].Rows.Count > 0)
            {
                DataRow dr = data.Tables[0].Rows[pos];

                this.f_fecha.Text = dr["formato_fecha"].ToString();
                this.s_moneda.Text = dr["car_moneda"].ToString();
                this.n_decimal.Text = dr["num_decimal"].ToString();
                this.txt_folio.Text = dr["folio"].ToString();
                Global.aplicacion = Convert.ToInt16(dr["aplicacion"].ToString());
                Global.tipo_dato = (string.IsNullOrEmpty(dr["tipo"].ToString()))? 0 : Convert.ToInt16(dr["tipo"].ToString());
                Global.nempresa = (string.IsNullOrEmpty(dr["numemp"].ToString())) ? 0 : Convert.ToInt16(dr["numemp"].ToString());
                this.type_appli.SelectedIndex = Global.tipo_dato - 1;
                try
                {
                    this.type_scale.SelectedIndex = Convert.ToInt16(dr["scale"].ToString());
                    this.PUERTO1.SelectedIndex = Convert.ToInt16(dr["puerto"].ToString());
                    this.BAUD1.SelectedIndex = Convert.ToInt16(dr["baudrate"].ToString());
                    this.PUERTO2.SelectedIndex = Convert.ToInt16(dr["puerto2"].ToString());
                    this.BAUD2.SelectedIndex = Convert.ToInt16(dr["baudrate2"].ToString());
                    this.PUERTO3.SelectedIndex = Convert.ToInt16(dr["puerto3"].ToString());
                    this.BAUD3.SelectedIndex = Convert.ToInt16(dr["baudrate3"].ToString());
                    if (Global.aplicacion < 2)
                    {
                        switch (Global.tipo_dato)
                        {
                            case 1:
                                {                                   
                                    this.PUERTO2.Enabled = false;
                                    this.PUERTO3.Enabled = false;
                                    this.BAUD2.Enabled = false;
                                    this.BAUD3.Enabled = false;
                                } break;
                            case 2:
                                {
                                    this.PUERTO2.Enabled = true;
                                    this.PUERTO3.Enabled = true;
                                    this.BAUD2.Enabled = true;
                                    this.BAUD3.Enabled = true;
                                } break;
                        }
                    }
                        if (dr["display"].ToString()=="1")
                        {
                        this.DISPLAY.Checked = true;
                        PUERTO4.SelectedIndex = Convert.ToInt16(dr["puerto4"].ToString());
                        this.BAUD4.SelectedIndex = Convert.ToInt16(dr["baudrate4"].ToString());
                    }
                    else
                    {
                        this.DISPLAY.Checked = false;
                        this.PUERTO4.SelectedIndex = -1;
                        this.BAUD4.SelectedIndex = 0;
                    }
                    if (dr["rmto"].ToString() == "1")
                        this.Rmto.Checked = true;
                    else
                        this.Rmto.Checked = false;

                    this.path_serv.Text = dr["path"].ToString();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    MessageBox.Show(Global.M_Error[24, Global.idioma],"", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Global.n_decimal = Convert.ToInt16(this.n_decimal.Text);
                Global.F_Fecha = this.f_fecha.Text;
                Global.moneda = this.s_moneda.Text;
                Global.P_COMM = this.PUERTO4.SelectedIndex;  //display
                Global.P_COMM1 = this.PUERTO1.SelectedIndex; //indicador 1
                Global.P_COMM2 = this.PUERTO2.SelectedIndex; //indicador 2
                Global.P_COMM3 = this.PUERTO3.SelectedIndex; //indicador 3
                Global.Buad = this.BAUD4.SelectedIndex;
                Global.Buad1 = this.BAUD1.SelectedIndex;
                Global.Buad2 = this.BAUD2.SelectedIndex;
                Global.Buad3 = this.BAUD3.SelectedIndex;
                this.editar_dato = false;
            }
        }        
        String GetIP()
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
		public void comando(int opcion)
		{
            System.Windows.Forms.ToolStripItem bt = this.toolBar1.Items[opcion];
            this.toolBar1_ButtonClick(this.toolBar1, new ToolStripItemClickedEventArgs(bt));
		}
		private void limpiar()
		{	
			this.f_fecha.Text="";
			this.s_moneda.Text="";
			this.n_decimal.Text="0";
        }
        #endregion
        #region eventos de captura
        private void button2_Click(object sender, System.EventArgs e)
		{
			this.toolBar1.Visible = true;
			this.toolBar1.BringToFront();
			limpiar();
		}
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Rmto.Checked)
            {
                OpenFileDialog dlgOpenFile = new OpenFileDialog();
                dlgOpenFile.ShowReadOnly = true;

                if (dlgOpenFile.ShowDialog() == DialogResult.OK)
                {
                    this.path_serv.Text = dlgOpenFile.FileName;
                }
            }
        }                       
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            switch (this.toolBar1.Items.IndexOf(e.ClickedItem))
            {
                case 0:
                    Global.clv_aceptada = false;
                    clave clv2 = new clave(2);
                    clv2.ShowDialog(this);
                    if (Global.clv_aceptada && Global.privilegio.Substring(0, 1) == "1")
                    {
                        this.groupBox1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(Global.M_Error[51, Global.idioma]);
                        this.groupBox1.Enabled = false;
                    }
                    break;
                case 1: //Actualizacion de configuracion

                    this.editar_dato = false;
                    bool existe = false;


                    IDataReader Cfg = db.getDataReader("SELECT * FROM configuracion");
                    if (Cfg.Read()) existe = true;
                    else existe = false;
                    Cfg.Close();
                    if (!existe) New_Dato();
                    else Save_Dato();
                    if (Global.Remoto)
                    {
                        using (FileStream fp = new FileStream(Global.appPath + "\\Connect.txt", FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            using (StreamWriter wf = new StreamWriter(fp))
                            {
                                wf.WriteLine(this.path_serv.Text);
                                wf.Close();
                                fp.Close();
                            }
                        }
                    }
                    this.groupBox1.Enabled = false;
                    this.comando(3);
                    break;

                case 3:

                    if (this.editar_dato)
                    {
                        if (MessageBox.Show(Global.M_Error[303, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.comando(1);
                        }
                    }
                    this.Close();
                    break;
            }
        }	
		private void s_moneda_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{ this.n_decimal.Focus();}
		}
		private void n_decimal_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (Convert.ToInt16(this.n_decimal.Text) > 2)
				{
					MessageBox.Show(Global.M_Error[74,Global.idioma].ToString());
					this.n_decimal.Focus();
				}
				else 
				{
					IDataReader Cfg = db.getDataReader("SELECT * FROM DatosGral");

					if (!Cfg.Read())
					{
						Cfg.Close();
						New_Dato();
					}
					Cfg.Close();
					Save_Dato();
				}
			}
		}
		private void f_fecha_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{ this.s_moneda.Focus();}
		}		
		private void editar_TextChanged(object sender, System.EventArgs e)
		{
			this.editar_dato=true;
        }
        #endregion
        #region eventos de combobox y check box
        private void DISPLAY_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.DISPLAY.Checked)
			{
                this.PUERTO4.Enabled=true;
				this.BAUD4.Enabled=true;
                Global.display = true;
			}
			else
			{				
				
				this.PUERTO4.Enabled=false;
				this.BAUD4.Enabled=false;
                Global.display = false;
			}
		}
        private void type_scale_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.scale = this.type_scale.SelectedIndex;
            if (Global.aplicacion < 2)
            {
                this.type_appli.Enabled = true;
            }
            else
            {
                this.type_appli.Enabled = false;
            }
        }
        private void type_appli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.type_appli.SelectedIndex == 0)
            {
                Global.tipo_dato = 1;
                this.PUERTO2.Enabled = false;
                this.PUERTO3.Enabled = false;
                this.BAUD2.Enabled = false;
                this.BAUD3.Enabled = false;
            }
            else if (this.type_appli.SelectedIndex == 1)
            {
                Global.tipo_dato = 2;
                this.PUERTO2.Enabled = true;
                this.PUERTO3.Enabled = true;
                this.BAUD2.Enabled = true;
                this.BAUD3.Enabled = true;
            }
        
        }
        private void Rmto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Rmto.Checked)
            {
                Global.Remoto = true;
                this.path_serv.Enabled = true;
                this.path_serv.Focus();
            }
            else
            {
                Global.Remoto = false;
                this.path_serv.Enabled = false;
                if (System.IO.File.Exists(Global.appPath + "\\Connect.txt"))
                {
                    System.IO.File.Delete(Global.appPath + "\\Connect.txt");
                }
            }
        }
        #endregion
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Save_Dato();
        }
    }
}

