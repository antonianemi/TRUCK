using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace TRUCK
{
    public class WEMPRESAS : System.Windows.Forms.Form
    {
        #region VARIABLES
        DataAccesQuery db;
        DataSet dt;
        private System.ComponentModel.IContainer components = null;
        private CurrencyManager cmRegister;
        private System.Windows.Forms.Panel datos_empresa;
        public string data_empresa;
        private string ruta_logo="";
        public static bool cancelar = false;
        private bool editar_dato = false;
        private System.Windows.Forms.Panel nicePanel1;
        private System.Windows.Forms.Label label_psw;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        public MaskedTextBox.MaskedTextBox id_empresa;
        public System.Windows.Forms.TextBox txt_telf;
        public System.Windows.Forms.TextBox txt_cp;
        public System.Windows.Forms.TextBox empresa;
        private System.Windows.Forms.TextBox pswd2;
        private System.Windows.Forms.TextBox pswd1;
        private System.Windows.Forms.TextBox user_txt;
        public System.Windows.Forms.TextBox dir3;
        public System.Windows.Forms.TextBox dir1;
        public System.Windows.Forms.TextBox dir2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tipo_com;
        private ToolStrip toolBar1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton7;
        private ToolStripButton toolStripButton8;
        private Button button1;
        private PictureBox pictureLogo;
        private OpenFileDialog openFileDialog1;
        #endregion
        #region CONSTRUCTORS
        public WEMPRESAS(int x, int y, int op)
        {
            db = new DataAccesQuery();
            // El Diseñador de Windows Forms requiere esta llamada.
            InitializeComponent();
            //this.cerrar = false;
            this.editar_dato = false;
            this.Location = new System.Drawing.Point(x, y);
            this.TransparencyKey = Color.Empty;
            this.button1.Click += new EventHandler(button1_Click);
            this.toolBar1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolBar1_ButtonClick);
            this.empresa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empresa_KeyDown);
            this.id_empresa.LostFocus += new System.EventHandler(this.id_empresa_LostFocus);
            this.id_empresa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.id_empresa_KeyDown);
            this.id_empresa.Validating += new System.ComponentModel.CancelEventHandler(this.id_empresa_Validating);
            this.dir1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dir1_KeyDown);
            this.dir2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dir2_KeyDown);
            this.dir3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dir3_KeyDown);
            this.txt_cp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cp_KeyDown);
            this.txt_telf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_telf_KeyDown);
            
            try
            {
                dt = db.getData("SELECT * FROM empresa ORDER BY numemp");
                dt.Tables[0].TableName = "empresa";
                cmRegister = (CurrencyManager)this.BindingContext[dt, "empresa"];

                cmRegister.Position = 0;

                dt.Tables[0].PrimaryKey = new DataColumn[] { dt.Tables[0].Columns["numemp"] };

                if (dt.Tables[0].Rows.Count > 0)
                {                   
                        this.toolBar1.Items[0].Enabled = false;
                        this.toolBar1.Items[2].Enabled = false; 
                }
            }
            catch (System.PlatformNotSupportedException explat)
            {
                MessageBox.Show(explat.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // TODO: agregar cualquier inicialización después de llamar a InitializeComponent
        }

        public WEMPRESAS(int x, int y)
        {
            db = new DataAccesQuery();
            // El Diseñador de Windows Forms requiere esta llamada.
            InitializeComponent();
            this.Location = new System.Drawing.Point(x, y);
            this.TransparencyKey = Color.Empty;
            this.button2.Click += new EventHandler(button2_Click);
            this.tipo_com.SelectedIndexChanged += new EventHandler(tipo_com_SelectedIndexChanged);
            bool existe = false;
            IDataReader dbempresa = db.getDataReader("SELECT * FROM empresa");
            if (dbempresa.Read()) existe = true;
            else existe = false;
            dbempresa.Close();

            if (!existe)
            {
                this.datos_empresa.Visible = false;
                this.datos_empresa.SendToBack();
                this.nicePanel1.Visible = true;
                this.nicePanel1.BringToFront();
                this.toolBar1.Visible = false;
                this.tipo_com.Items.Add(Global.M_Error[20, Global.idioma]);
                this.tipo_com.Items.Add(Global.M_Error[21, Global.idioma]);
                this.tipo_com.SelectedIndex = 0;
            }

        }


        #endregion


        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
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
        #region Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WEMPRESAS));
            this.datos_empresa = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.id_empresa = new MaskedTextBox.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_telf = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_cp = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dir3 = new System.Windows.Forms.TextBox();
            this.empresa = new System.Windows.Forms.TextBox();
            this.dir1 = new System.Windows.Forms.TextBox();
            this.dir2 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.nicePanel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tipo_com = new System.Windows.Forms.ComboBox();
            this.user_txt = new System.Windows.Forms.TextBox();
            this.pswd1 = new System.Windows.Forms.TextBox();
            this.pswd2 = new System.Windows.Forms.TextBox();
            this.label_psw = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolBar1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.datos_empresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.nicePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datos_empresa
            // 
            this.datos_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.datos_empresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datos_empresa.Controls.Add(this.button1);
            this.datos_empresa.Controls.Add(this.pictureLogo);
            this.datos_empresa.Controls.Add(this.id_empresa);
            this.datos_empresa.Controls.Add(this.label9);
            this.datos_empresa.Controls.Add(this.txt_telf);
            this.datos_empresa.Controls.Add(this.label10);
            this.datos_empresa.Controls.Add(this.txt_cp);
            this.datos_empresa.Controls.Add(this.pictureBox4);
            this.datos_empresa.Controls.Add(this.pictureBox5);
            this.datos_empresa.Controls.Add(this.label12);
            this.datos_empresa.Controls.Add(this.label16);
            this.datos_empresa.Controls.Add(this.label17);
            this.datos_empresa.Controls.Add(this.label18);
            this.datos_empresa.Controls.Add(this.dir3);
            this.datos_empresa.Controls.Add(this.empresa);
            this.datos_empresa.Controls.Add(this.dir1);
            this.datos_empresa.Controls.Add(this.dir2);
            this.datos_empresa.Controls.Add(this.label19);
            resources.ApplyResources(this.datos_empresa, "datos_empresa");
            this.datos_empresa.Name = "datos_empresa";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureLogo
            // 
            this.pictureLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureLogo, "pictureLogo");
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.TabStop = false;
            // 
            // id_empresa
            // 
            this.id_empresa.BackColor = System.Drawing.Color.Yellow;
            this.id_empresa.DateOnly = false;
            this.id_empresa.DecimalOnly = false;
            this.id_empresa.DigitOnly = true;
            this.id_empresa.IPAddrOnly = false;
            resources.ApplyResources(this.id_empresa, "id_empresa");
            this.id_empresa.Name = "id_empresa";
            this.id_empresa.PhoneWithAreaCode = false;
            this.id_empresa.SSNOnly = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txt_telf
            // 
            this.txt_telf.AcceptsReturn = true;
            this.txt_telf.BackColor = System.Drawing.Color.White;
            this.txt_telf.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_telf.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.txt_telf, "txt_telf");
            this.txt_telf.Name = "txt_telf";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // txt_cp
            // 
            this.txt_cp.AcceptsReturn = true;
            this.txt_cp.BackColor = System.Drawing.Color.White;
            this.txt_cp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_cp.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.txt_cp, "txt_cp");
            this.txt_cp.Name = "txt_cp";
            // 
            // pictureBox4
            // 
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            resources.ApplyResources(this.pictureBox5, "pictureBox5");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.TabStop = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Cursor = System.Windows.Forms.Cursors.Default;
            this.label12.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Cursor = System.Windows.Forms.Cursors.Default;
            this.label16.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.Cursor = System.Windows.Forms.Cursors.Default;
            this.label17.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // dir3
            // 
            this.dir3.AcceptsReturn = true;
            this.dir3.BackColor = System.Drawing.Color.White;
            this.dir3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dir3.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.dir3, "dir3");
            this.dir3.Name = "dir3";
            // 
            // empresa
            // 
            this.empresa.AcceptsReturn = true;
            this.empresa.BackColor = System.Drawing.Color.Yellow;
            this.empresa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.empresa.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.empresa, "empresa");
            this.empresa.Name = "empresa";
            // 
            // dir1
            // 
            this.dir1.AcceptsReturn = true;
            this.dir1.BackColor = System.Drawing.Color.White;
            this.dir1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dir1.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.dir1, "dir1");
            this.dir1.Name = "dir1";
            // 
            // dir2
            // 
            this.dir2.AcceptsReturn = true;
            this.dir2.BackColor = System.Drawing.Color.White;
            this.dir2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dir2.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.dir2, "dir2");
            this.dir2.Name = "dir2";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.Cursor = System.Windows.Forms.Cursors.Default;
            this.label19.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // nicePanel1
            // 
            this.nicePanel1.BackColor = System.Drawing.Color.Gray;
            this.nicePanel1.Controls.Add(this.label1);
            this.nicePanel1.Controls.Add(this.tipo_com);
            this.nicePanel1.Controls.Add(this.user_txt);
            this.nicePanel1.Controls.Add(this.pswd1);
            this.nicePanel1.Controls.Add(this.pswd2);
            this.nicePanel1.Controls.Add(this.label_psw);
            this.nicePanel1.Controls.Add(this.label8);
            this.nicePanel1.Controls.Add(this.label7);
            this.nicePanel1.Controls.Add(this.label14);
            this.nicePanel1.Controls.Add(this.button2);
            this.nicePanel1.Controls.Add(this.label15);
            this.nicePanel1.Controls.Add(this.label13);
            this.nicePanel1.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.nicePanel1, "nicePanel1");
            this.nicePanel1.Name = "nicePanel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // tipo_com
            // 
            resources.ApplyResources(this.tipo_com, "tipo_com");
            this.tipo_com.Name = "tipo_com";
            this.tipo_com.SelectedIndexChanged += new System.EventHandler(this.tipo_com_SelectedIndexChanged);
            // 
            // user_txt
            // 
            resources.ApplyResources(this.user_txt, "user_txt");
            this.user_txt.Name = "user_txt";
            // 
            // pswd1
            // 
            resources.ApplyResources(this.pswd1, "pswd1");
            this.pswd1.Name = "pswd1";
            // 
            // pswd2
            // 
            resources.ApplyResources(this.pswd2, "pswd2");
            this.pswd2.Name = "pswd2";
            // 
            // label_psw
            // 
            resources.ApplyResources(this.label_psw, "label_psw");
            this.label_psw.ForeColor = System.Drawing.Color.White;
            this.label_psw.Name = "label_psw";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label14.Name = "label14";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Name = "label15";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Name = "label13";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // toolBar1
            // 
            this.toolBar1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8});
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
            // toolStripButton5
            // 
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            this.toolStripButton5.Name = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            resources.ApplyResources(this.toolStripButton6, "toolStripButton6");
            this.toolStripButton6.Name = "toolStripButton6";
            // 
            // toolStripButton7
            // 
            resources.ApplyResources(this.toolStripButton7, "toolStripButton7");
            this.toolStripButton7.Name = "toolStripButton7";
            // 
            // toolStripButton8
            // 
            resources.ApplyResources(this.toolStripButton8, "toolStripButton8");
            this.toolStripButton8.Name = "toolStripButton8";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // WEMPRESAS
            // 
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.nicePanel1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.datos_empresa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WEMPRESAS";
            this.Tag = "";
            this.datos_empresa.ResumeLayout(false);
            this.datos_empresa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.nicePanel1.ResumeLayout(false);
            this.nicePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolBar1.ResumeLayout(false);
            this.toolBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region FUNCTIONS
        private void New_Dato()
        {   
                string query = "INSERT INTO empresa (numemp,empresa,direccion1,direccion2,direccion3,cp,telf,logo)" +
                " VALUES ( " 
                + Convert.ToInt32(this.id_empresa.Text) + 
                ",'" 
                + this.empresa.Text + "','" 
                + this.dir1.Text + "','" 
                + this.dir2.Text + "','" 
                + this.dir3.Text + "',"
                + this.txt_cp.Text + ",'"
                + this.txt_telf.Text + "','"
                + this.ruta_logo + "')";
                db.ExcetuteQuery(query); 
        }

        private void Save_Dato()
        {            
                string query = "UPDATE empresa SET empresa = '" + this.empresa.Text + "', direccion1 = '" + this.dir1.Text + "', direccion2 = '" + this.dir2.Text + "', direccion3 = '" + this.dir3.Text + "'," +
                " cp = '" + this.txt_cp.Text + "',telf = '" + this.txt_telf.Text + "', logo = '" + this.ruta_logo + "'" +
                " WHERE ( numemp = " + Convert.ToInt32(this.id_empresa.Text) + ")";
                db.ExcetuteQuery(query);           
        }
        private void Del_Dato()
        {                                 
         string query = "DELETE FROM empresa WHERE NUMEMP = " + Convert.ToInt32(this.id_empresa.Text);
         db.ExcetuteQuery(query);
         query = "DELETE FROM CLIENTE WHERE ( numemp = " + Convert.ToInt32(this.id_empresa.Text) + ")";
         db.ExcetuteQuery(query);
         query = "DELETE FROM ARTICULOS WHERE ( numemp = " + Convert.ToInt32(this.id_empresa.Text) + ")";
         db.ExcetuteQuery(query);
         query = "DELETE FROM PROVEEDOR WHERE ( numemp = " + Convert.ToInt32(this.id_empresa.Text) + ")";
         db.ExcetuteQuery(query);
         query = "DELETE FROM CLIENTE WHERE ( numemp = " + Convert.ToInt32(this.id_empresa.Text) + ")";
         db.ExcetuteQuery(query);
         query = "DELETE FROM TRANSPORTISTAS WHERE ( numemp = " + Convert.ToInt32(this.id_empresa.Text) + ")";
         db.ExcetuteQuery(query);
         query = "DELETE FROM TARA WHERE ( numemp = " + Convert.ToInt32(this.id_empresa.Text) + ")" ;
         db.ExcetuteQuery(query);
         MessageBox.Show(Global.M_Error[3, Global.idioma].ToString());
        }

        private bool Find_Numero(string nombre)
        {

            bool encontro = false;

            int len = nombre.Length;

            dt.Tables[0].PrimaryKey = new DataColumn[] { dt.Tables[0].Columns["numemp"] };

            DataRow dr = dt.Tables[0].Rows.Find(nombre);

            if (dr != null)
            {
                encontro = true;
                cmRegister.Position = buscar_posicion(Convert.ToInt32(dr["numemp"]), "numemp");
            }
            return encontro;
        }


        public bool muestra_empresa(string codigo)
        {
            if (this.Find_Numero(codigo))
            {
                this.Mostrar_Datos(cmRegister.Position, 1);
                return true;
            }
            else return false;

        }


        private void Mostrar_Datos(int pos, int op)
        {
            if (dt.Tables[0].Rows.Count > 0 && pos >= 0)
            {
                DataRow dr = dt.Tables[0].Rows[pos];
                this.id_empresa.Text = dr["numemp"].ToString();
                this.empresa.Text = dr["empresa"].ToString();
                this.dir1.Text = dr["direccion1"].ToString();
                this.dir2.Text = dr["direccion2"].ToString();
                this.dir3.Text = dr["direccion3"].ToString();
                this.txt_cp.Text = dr["cp"].ToString();
                this.txt_telf.Text = dr["telf"].ToString();
                this.ruta_logo = dr["logo"].ToString().Trim();

                if (this.ruta_logo.Length > 0 && ruta_logo!=null&& ruta_logo !=string.Empty) this.pictureLogo.Image = new Bitmap(this.ruta_logo);
                if (op == 0) this.id_empresa.Focus();
                else this.empresa.Focus();
                this.editar_dato = false;
            }
        }


        private void limpiar()
        {
            this.id_empresa.Text = "";
            this.empresa.Text = "";
            this.dir1.Text = "";
            this.dir2.Text = "";
            this.dir3.Text = "";
            this.txt_cp.Text = "";
            this.txt_telf.Text = "";
            this.id_empresa.Enabled = true;
        }


        private void ver_empre()
        {
            this.toolBar1.Items[1].Enabled = false;
            this.toolBar1.Items[2].Enabled = false;
            this.toolBar1.Items[3].Enabled = false;
            this.toolBar1.Items[4].Enabled = false;
            this.toolBar1.Items[5].Enabled = false;
            this.toolBar1.Items[6].Enabled = false;
            this.datos_empresa.Visible = false;
            this.nicePanel1.Visible = false;
        }


        public void comando(int opcion)
        {
            System.Windows.Forms.ToolStripItem bt = this.toolBar1.Items[opcion];   //= new MSComctlLib.ButtonClass();
            this.toolBar1_ButtonClick(this.toolBar1, new ToolStripItemClickedEventArgs(bt));
        }



        public int Find_Codigo(string n_codigo, string campo)
        {
            int encontro = -1;

            dt.Tables[0].PrimaryKey = new System.Data.DataColumn[] { dt.Tables[0].Columns[campo] };

            System.Data.DataRow dr = dt.Tables[0].Rows.Find(Convert.ToInt32(n_codigo));

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

            System.Data.DataRow[] dr = dt.Tables[0].Select("SUBSTRING(" + campo2 + ",1," + len + ") = '" + descrip + "'");

            if (dr.Length > 0)
            {
                encontro = buscar_posicion(Convert.ToInt32(dr[0][campo1]), campo1);
            }
            return encontro;
        }


        public int buscar_posicion(int elemento, string clave)
        {
            int desde, hasta, medio, posicion; // desde y hasta indican los límites del array que se está mirando.
            posicion = 0;

            for (desde = 0, hasta = dt.Tables[0].Rows.Count - 1; desde <= hasta;)
            {
                if (desde == hasta) // si el array sólo tiene un elemento:
                {
                    if (Convert.ToInt32(dt.Tables[0].Rows[desde][clave]) == elemento) // si es la solución:
                        posicion = desde; // darle el valor.
                    else // si no es el valor:
                        posicion = -1; // no está en el array.
                    break; // Salir del bucle.
                }
                medio = (desde + hasta) / 2; // Divide el array en dos.
                if (Convert.ToInt32(dt.Tables[0].Rows[medio][clave]) == elemento) // Si coincide con el central:
                {
                    posicion = medio; // ese es la solución
                    break; // y sale del bucle.
                }
                else if (Convert.ToInt32(dt.Tables[0].Rows[medio][clave]) > elemento) // si es menor:
                    hasta = medio - 1; // elige el array izquierda.
                else // y si es mayor:
                    desde = medio + 1; // elige el array de la derecha.
            }
            return posicion;
        }
        public int buscar_posicion(string elemento, string clave)
        {
            int desde, hasta, medio, posicion; // desde y hasta indican los límites del array que se está mirando.
            posicion = 0;

            for (desde = 0, hasta = dt.Tables[0].Rows.Count - 1; desde <= hasta;)
            {
                if (desde == hasta) // si el array sólo tiene un elemento:
                {
                    if (String.CompareOrdinal(dt.Tables[0].Rows[desde][clave].ToString(), elemento) == 0) // si es la solución:
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
                if (String.CompareOrdinal(dt.Tables[0].Rows[medio][clave].ToString(), elemento) > 0) // si es menor:
                    hasta = medio - 1; // elige el array izquierda.
                else if (String.CompareOrdinal(dt.Tables[0].Rows[medio][clave].ToString(), elemento) < 0) // y si es mayor:
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


        #endregion
        #region EVENTS
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            int cod = 0;

            switch (this.toolBar1.Items.IndexOf(e.ClickedItem))
            {
                case 0: //Nueva empresa
                    {
                        if (Global.clv_aceptada && Global.privilegio.Substring(0, 1) == "1")
                        {
                            this.editar_dato = false;
                            this.nicePanel1.Visible = false;
                            this.nicePanel1.SendToBack();
                            this.toolBar1.Visible = true;
                            this.toolBar1.BringToFront();
                            this.datos_empresa.Visible = true;
                            this.toolBar1.Items[1].Enabled = true;
                            this.toolBar1.Items[3].Enabled = true;
                            this.toolBar1.Items[4].Enabled = true;
                            this.toolBar1.Items[5].Enabled = true;
                            this.toolBar1.Items[6].Enabled = true;
                            this.toolBar1.Items[7].Enabled = true;
                            this.datos_empresa.BringToFront();
                            this.editar_dato = false;
                            limpiar();
                            IDataReader LP = db.getDataReader("SELECT first 1 numemp FROM empresa order by numemp desc");
                            if (LP.Read()) cod = Convert.ToInt16(LP.GetValue(0));
                            LP.Close();
                            this.id_empresa.Text = Convert.ToString(cod + 1);
                            this.editar_dato = false;
                            this.empresa.Focus();
                        }
                    } break;



                case 1: //Guardar informacion
                    {
                        if (this.id_empresa.Text == "")
                        {
                            MessageBox.Show(Global.M_Error[90, Global.idioma].ToString() + " " + Global.M_Error[67, Global.idioma].ToString());
                            this.id_empresa.Focus();
                            break;
                        }
                        if (this.empresa.Text == "")
                        {
                            MessageBox.Show(Global.M_Error[49, Global.idioma].ToString());
                            this.empresa.Focus();
                            break;
                        }
                        if (Convert.ToInt32(this.id_empresa.Text) > 1 && !Keylock.IsPresent())
                        {
                            MessageBox.Show(Global.M_Error[147, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            bool existe = false;
                            cancelar = false;
                            this.editar_dato = false;
                            IDataReader Cfg = db.getDataReader("SELECT * FROM empresa WHERE ( numemp = " + Convert.ToInt32(this.id_empresa.Text) + ")");

                            if (Cfg.Read()) existe = true;
                            Cfg.Close();

                            if (!existe) New_Dato();
                            else Save_Dato();

                        }
                        this.Close();
                        this.Dispose();
                    } break;



                case 2://Borrar empresa

                    if (Global.clv_aceptada && Global.privilegio.Substring(0, 1) == "1")
                    {
                        if (MessageBox.Show(Global.M_Error[52, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (MessageBox.Show(Global.M_Error[60, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                if (this.Find_Numero(this.id_empresa.Text))
                                {
                                    Del_Dato();
                                }
                                else MessageBox.Show(Global.M_Error[2, Global.idioma]);
                            }
                        }
                    }
                    break;



                case 3: // Deshacer la edicion

                    this.editar_dato = false;

                    if (this.Find_Numero(this.id_empresa.Text)) Mostrar_Datos(cmRegister.Position, 0);
                    else
                    {
                        cod = dt.Tables[0].Rows.Count;
                        if (cod != 0)
                        {
                            this.id_empresa.Text = Convert.ToString(Convert.ToInt32(dt.Tables[0].Rows[cod - 1]["numemp"].ToString()) + 1);
                        }
                        else
                        {
                            this.id_empresa.Text = Convert.ToString(dt.Tables[0].Rows.Count + 1);
                        }
                        limpiar();
                    }
                    break;



                case 4: // Cambiar Password

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
                    break;
                case 5: //ir hacia atras
                    Mostrar_Datos(Previous(ref cmRegister), 0);
                    break;
                case 6: //ir hacia adelante
                    Mostrar_Datos(Next(ref cmRegister), 0);
                    break;
                case 7:	//cerrar y regresar al listado
                    cancelar = true;
                    if (this.editar_dato)
                    {
                        if (MessageBox.Show(Global.M_Error[303, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {                            
                            this.comando(1);
                        }
                        else
                        {
                            this.Close();
                            this.Dispose();
                        }
                    }
                    else
                    {
                        this.Close();
                        this.Dispose();
                    }
                    break;
            }
        } 
        private void id_empresa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.id_empresa.Text == "" || this.id_empresa.Text == null)
                {
                    MessageBox.Show(Global.M_Error[90, Global.idioma].ToString() + " " + Global.M_Error[67, Global.idioma].ToString());
                    this.id_empresa.Focus();
                }
                else
                {
                    this.id_empresa.Enabled = false;
                    this.empresa.Focus();
                }
            }
        }
        private void id_empresa_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.id_empresa.Text == "" || this.id_empresa.Text == null || this.id_empresa.Text == "0")
            {
                MessageBox.Show(Global.M_Error[90, Global.idioma].ToString() + " " + Global.M_Error[67, Global.idioma].ToString());
                this.id_empresa.Focus();
            }
        }
        private void id_empresa_LostFocus(object sender, System.EventArgs e)
        {
            if (Find_Numero(id_empresa.Text))
            {
                Mostrar_Datos(cmRegister.Position, 1);
                this.id_empresa.Focus();
            }
        }
        private void editar_TextChanged(object sender, System.EventArgs e)
        {
            this.editar_dato = true;
        }
        private void Salir_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(Global.M_Error[318, Global.idioma], "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                cancelar = true;
                this.Dispose();
                this.Close();
            }
        }


        private void tipo_com_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Global.aplicacion = tipo_com.SelectedIndex;
        }


        private void dir1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { this.dir2.Focus(); }
        }
        private void dir2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { this.dir3.Focus(); }
        }
        private void dir3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { this.txt_cp.Focus(); }
        }
        private void txt_cp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { this.txt_telf.Focus(); }
        }
        private void txt_telf_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.id_empresa.Text == "" || this.id_empresa.Text == "0")
                {
                    MessageBox.Show(Global.M_Error[90, Global.idioma].ToString() + " " + Global.M_Error[67, Global.idioma].ToString());
                    this.id_empresa.Focus();
                }
                if (this.empresa.Text == "")
                {
                    MessageBox.Show(Global.M_Error[49, Global.idioma].ToString());
                    this.empresa.Focus();
                }
                this.editar_dato = false;
                DataRow DB = dt.Tables[0].Rows.Find(Convert.ToInt32(this.id_empresa.Text));
                if (DB == null) New_Dato();
                else Save_Dato();
            }
        }
        private void empresa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.empresa.Text == "" || this.empresa.Text == null)
                {
                    MessageBox.Show(Global.M_Error[49, Global.idioma].ToString());
                    this.empresa.Focus();
                }
                else this.dir1.Focus();
            }

        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            bool existe;
            bool pas;
            if (this.user_txt.Text != "")
            {
                IDataReader usua = db.getDataReader("SELECT user,contrasena FROM Usuarios WHERE (user = '" + this.user_txt.Text + "')");
                if (usua.Read()) existe = true;
                else existe = false;
                usua.Close();

                if (this.pswd1.Text != this.pswd2.Text)
                {
                    MessageBox.Show(Global.M_Error[117, Global.idioma]);
                    this.pswd1.Focus();
                    pas = false;
                    return;
                }

                else pas = true;
                if (pas)
                {

                    if (!existe) db.ExcetuteQuery("INSERT INTO Usuarios ([user],contrasena,privilegios,nombre,tipo,iniciales) VALUES ('" + this.user_txt.Text + "','" + this.pswd2.Text + "','111111111111111','" + Global.M_Error[145, Global.idioma] + "',0,'ADMIN')");

                    else db.ExcetuteQuery("UPDATE Usuarios SET contrasena = '" + this.pswd1.Text + "', privilegios = '111111111111111',nombre = '" + Global.M_Error[145, Global.idioma] + "' WHERE ( user = '" + this.user_txt.Text + "')");

                    this.nicePanel1.Visible = false;
                    this.nicePanel1.SendToBack();
                    this.toolBar1.Visible = true;
                    this.toolBar1.BringToFront();
                    this.datos_empresa.Enabled = false;
                    this.datos_empresa.BringToFront();
                    this.toolBar1.Items[1].Enabled = false;
                    this.toolBar1.Items[2].Enabled = false;
                    this.toolBar1.Items[4].Enabled = false;
                    this.toolBar1.Items[5].Enabled = false;
                    this.toolBar1.Items[6].Enabled = false;
                    this.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap logo;
            this.openFileDialog1.DefaultExt = "JPG";
            this.openFileDialog1.Filter = "Image Files(*.BMP;*.JPG)|*.BMP;*.JPG|All files (*.*)|*.*";
            DialogResult result = this.openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string openFileName = this.openFileDialog1.FileName;
                string nombre_logo = this.openFileDialog1.SafeFileName;
                try
                {
                    if (nombre_logo != openFileName)
                    {
                        this.pictureLogo.SizeMode = PictureBoxSizeMode.CenterImage;
                        logo = new Bitmap(openFileName);
                        this.pictureLogo.Image = null;
                        if (logo.PhysicalDimension.Height <= 128 && logo.PhysicalDimension.Width <= 128)
                        {
                            this.pictureLogo.Image = new Bitmap(openFileName);

                            if (System.IO.File.Exists(Global.appPath + "\\" + nombre_logo)) System.IO.File.Replace(openFileName, Global.appPath + "\\" + nombre_logo, null);
                            else System.IO.File.Copy(openFileName, Global.appPath + "\\" + nombre_logo);
                            ruta_logo = Global.appPath + "\\" + nombre_logo;
                        }
                        else MessageBox.Show(Global.M_Error[301, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show(Global.M_Error[302, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(Global.M_Error[300, Global.idioma] + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                }
            }
        }
        #endregion

    }
}

