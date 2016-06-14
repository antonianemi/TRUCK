using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace TRUCK
{
	public class WUSER : Form1
    {
        #region VARIABLES
        DataAccesQuery db;
        DataSet dt;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label Label1;
		public System.Windows.Forms.CheckBox atributo1;
		public System.Windows.Forms.CheckBox atributo0;
		private System.Windows.Forms.CheckBox[] atributo;
		private System.ComponentModel.IContainer components = null;
		private CurrencyManager cmRegister;
		public System.Windows.Forms.CheckBox atributo3;
		private string para1="";
		private int opcion;
		private bool editar_dato=false;
		private bool cerrar=false;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox txt_descrip;
		public System.Windows.Forms.TextBox txt_user;
		private System.Windows.Forms.TextBox txt_ID;
		private System.Windows.Forms.TextBox txt_psw;
		public System.Windows.Forms.CheckBox atributo14;
		public System.Windows.Forms.CheckBox atributo9;
		public System.Windows.Forms.CheckBox atributo4;
		public System.Windows.Forms.CheckBox atributo2;
		public System.Windows.Forms.CheckBox atributo8;
		public System.Windows.Forms.CheckBox atributo5;
		public System.Windows.Forms.CheckBox atributo7;
		public System.Windows.Forms.CheckBox atributo6;
		public System.Windows.Forms.CheckBox atributo13;
		public System.Windows.Forms.CheckBox atributo10;
		public System.Windows.Forms.CheckBox atributo11;
		public System.Windows.Forms.CheckBox atributo12;
        private string txt_turno = "";
        private string txt_atributo = "";
        private ComboBox l_turno;
        private ComboBox C_tipo;
        private Label label5;
        private PictureBox pictureBox3;
        #endregion
        #region CONSTRUCS
        public WUSER(int x, int y,int opc)
		{
			// El Diseñador de Windows Forms requiere esta llamada.
			InitializeComponent();
            this.Location = new System.Drawing.Point(x,y);
			this.TransparencyKey = Color.Empty;
			this.Tag = Global.M_Error[145,Global.idioma].ToString();
			para1=Global.M_Error[207,Global.idioma].ToString();
			opcion = opc;
            this.l_turno.SelectedIndexChanged += new EventHandler(l_turno_SelectedIndexChanged);
            this.toolBar1.ItemClicked += new ToolStripItemClickedEventHandler(this.toolBar1_ButtonClick);
			this.txt_user.Validating+=new System.ComponentModel.CancelEventHandler(this.txt_user_Validating);
			this.txt_user.KeyDown+=new System.Windows.Forms.KeyEventHandler(this.txt_user_KeyDown);
			this.txt_user.TextChanged+=new System.EventHandler(this.editar_TextChanged);
			this.txt_psw.KeyDown+=new System.Windows.Forms.KeyEventHandler(this.txt_psw_KeyDown);
			this.txt_ID.Validating+=new System.ComponentModel.CancelEventHandler(this.txt_ID_Validating);
			this.txt_ID.KeyDown+=new System.Windows.Forms.KeyEventHandler(this.txt_ID_KeyDown);
			this.txt_descrip.KeyDown+=new System.Windows.Forms.KeyEventHandler(this.txt_descrip_KeyDown);
            this.txt_descrip.Validating+=new CancelEventHandler(txt_descrip_Validating);
			this.atributo = new System.Windows.Forms.CheckBox[]{this.atributo0,this.atributo1,this.atributo2,this.atributo3,this.atributo4,this.atributo5,
																   this.atributo6,this.atributo7,this.atributo8,this.atributo9,this.atributo10,this.atributo11,
																	this.atributo12,this.atributo13,this.atributo14};

            this.l_turno.Items.Add(Global.M_Error[8, Global.idioma]); 
            this.l_turno.Items.Add(Global.M_Error[15, Global.idioma]);
            this.l_turno.Items.Add(Global.M_Error[16, Global.idioma]);
            this.l_turno.SelectedIndex = 0;
            
            this.txt_turno = this.l_turno.Items[0].ToString();
            
            this.C_tipo.Items.Add(Global.M_Error[145, Global.idioma]);
            this.C_tipo.Items.Add(Global.M_Error[207, Global.idioma]);
            this.C_tipo.SelectedIndex = 1;
            
            dt = db.getData("SELECT * FROM usuarios ORDER BY user");

            this.cmRegister = (CurrencyManager)this.BindingContext[dt, "usuarios"];
			this.cmRegister.Position = 0;
			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WUSER));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.atributo14 = new System.Windows.Forms.CheckBox();
            this.atributo9 = new System.Windows.Forms.CheckBox();
            this.atributo4 = new System.Windows.Forms.CheckBox();
            this.atributo2 = new System.Windows.Forms.CheckBox();
            this.atributo1 = new System.Windows.Forms.CheckBox();
            this.atributo0 = new System.Windows.Forms.CheckBox();
            this.atributo3 = new System.Windows.Forms.CheckBox();
            this.atributo8 = new System.Windows.Forms.CheckBox();
            this.atributo5 = new System.Windows.Forms.CheckBox();
            this.atributo7 = new System.Windows.Forms.CheckBox();
            this.atributo6 = new System.Windows.Forms.CheckBox();
            this.atributo13 = new System.Windows.Forms.CheckBox();
            this.atributo10 = new System.Windows.Forms.CheckBox();
            this.atributo11 = new System.Windows.Forms.CheckBox();
            this.atributo12 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.C_tipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.l_turno = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_descrip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txt_psw = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImage = null;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = null;
            this.groupBox2.AccessibleName = null;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackgroundImage = null;
            this.groupBox2.Controls.Add(this.atributo14);
            this.groupBox2.Controls.Add(this.atributo9);
            this.groupBox2.Controls.Add(this.atributo4);
            this.groupBox2.Controls.Add(this.atributo2);
            this.groupBox2.Controls.Add(this.atributo1);
            this.groupBox2.Controls.Add(this.atributo0);
            this.groupBox2.Controls.Add(this.atributo3);
            this.groupBox2.Controls.Add(this.atributo8);
            this.groupBox2.Controls.Add(this.atributo5);
            this.groupBox2.Controls.Add(this.atributo7);
            this.groupBox2.Controls.Add(this.atributo6);
            this.groupBox2.Controls.Add(this.atributo13);
            this.groupBox2.Controls.Add(this.atributo10);
            this.groupBox2.Controls.Add(this.atributo11);
            this.groupBox2.Controls.Add(this.atributo12);
            this.groupBox2.Font = null;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // atributo14
            // 
            this.atributo14.AccessibleDescription = null;
            this.atributo14.AccessibleName = null;
            resources.ApplyResources(this.atributo14, "atributo14");
            this.atributo14.BackColor = System.Drawing.SystemColors.Control;
            this.atributo14.BackgroundImage = null;
            this.atributo14.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo14.Font = null;
            this.atributo14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo14.Name = "atributo14";
            this.atributo14.UseVisualStyleBackColor = false;
            // 
            // atributo9
            // 
            this.atributo9.AccessibleDescription = null;
            this.atributo9.AccessibleName = null;
            resources.ApplyResources(this.atributo9, "atributo9");
            this.atributo9.BackColor = System.Drawing.SystemColors.Control;
            this.atributo9.BackgroundImage = null;
            this.atributo9.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo9.Font = null;
            this.atributo9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo9.Name = "atributo9";
            this.atributo9.UseVisualStyleBackColor = false;
            // 
            // atributo4
            // 
            this.atributo4.AccessibleDescription = null;
            this.atributo4.AccessibleName = null;
            resources.ApplyResources(this.atributo4, "atributo4");
            this.atributo4.BackColor = System.Drawing.SystemColors.Control;
            this.atributo4.BackgroundImage = null;
            this.atributo4.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo4.Font = null;
            this.atributo4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo4.Name = "atributo4";
            this.atributo4.UseVisualStyleBackColor = false;
            // 
            // atributo2
            // 
            this.atributo2.AccessibleDescription = null;
            this.atributo2.AccessibleName = null;
            resources.ApplyResources(this.atributo2, "atributo2");
            this.atributo2.BackColor = System.Drawing.SystemColors.Control;
            this.atributo2.BackgroundImage = null;
            this.atributo2.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo2.Font = null;
            this.atributo2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo2.Name = "atributo2";
            this.atributo2.UseVisualStyleBackColor = false;
            // 
            // atributo1
            // 
            this.atributo1.AccessibleDescription = null;
            this.atributo1.AccessibleName = null;
            resources.ApplyResources(this.atributo1, "atributo1");
            this.atributo1.BackColor = System.Drawing.SystemColors.Control;
            this.atributo1.BackgroundImage = null;
            this.atributo1.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo1.Font = null;
            this.atributo1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo1.Name = "atributo1";
            this.atributo1.UseVisualStyleBackColor = false;
            // 
            // atributo0
            // 
            this.atributo0.AccessibleDescription = null;
            this.atributo0.AccessibleName = null;
            resources.ApplyResources(this.atributo0, "atributo0");
            this.atributo0.BackColor = System.Drawing.SystemColors.Control;
            this.atributo0.BackgroundImage = null;
            this.atributo0.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo0.Font = null;
            this.atributo0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo0.Name = "atributo0";
            this.atributo0.UseVisualStyleBackColor = false;
            // 
            // atributo3
            // 
            this.atributo3.AccessibleDescription = null;
            this.atributo3.AccessibleName = null;
            resources.ApplyResources(this.atributo3, "atributo3");
            this.atributo3.BackColor = System.Drawing.SystemColors.Control;
            this.atributo3.BackgroundImage = null;
            this.atributo3.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo3.Font = null;
            this.atributo3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo3.Name = "atributo3";
            this.atributo3.UseVisualStyleBackColor = false;
            // 
            // atributo8
            // 
            this.atributo8.AccessibleDescription = null;
            this.atributo8.AccessibleName = null;
            resources.ApplyResources(this.atributo8, "atributo8");
            this.atributo8.BackColor = System.Drawing.SystemColors.Control;
            this.atributo8.BackgroundImage = null;
            this.atributo8.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo8.Font = null;
            this.atributo8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo8.Name = "atributo8";
            this.atributo8.UseVisualStyleBackColor = false;
            // 
            // atributo5
            // 
            this.atributo5.AccessibleDescription = null;
            this.atributo5.AccessibleName = null;
            resources.ApplyResources(this.atributo5, "atributo5");
            this.atributo5.BackColor = System.Drawing.SystemColors.Control;
            this.atributo5.BackgroundImage = null;
            this.atributo5.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo5.Font = null;
            this.atributo5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo5.Name = "atributo5";
            this.atributo5.UseVisualStyleBackColor = false;
            // 
            // atributo7
            // 
            this.atributo7.AccessibleDescription = null;
            this.atributo7.AccessibleName = null;
            resources.ApplyResources(this.atributo7, "atributo7");
            this.atributo7.BackColor = System.Drawing.SystemColors.Control;
            this.atributo7.BackgroundImage = null;
            this.atributo7.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo7.Font = null;
            this.atributo7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo7.Name = "atributo7";
            this.atributo7.UseVisualStyleBackColor = false;
            // 
            // atributo6
            // 
            this.atributo6.AccessibleDescription = null;
            this.atributo6.AccessibleName = null;
            resources.ApplyResources(this.atributo6, "atributo6");
            this.atributo6.BackColor = System.Drawing.SystemColors.Control;
            this.atributo6.BackgroundImage = null;
            this.atributo6.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo6.Font = null;
            this.atributo6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo6.Name = "atributo6";
            this.atributo6.UseVisualStyleBackColor = false;
            // 
            // atributo13
            // 
            this.atributo13.AccessibleDescription = null;
            this.atributo13.AccessibleName = null;
            resources.ApplyResources(this.atributo13, "atributo13");
            this.atributo13.BackColor = System.Drawing.SystemColors.Control;
            this.atributo13.BackgroundImage = null;
            this.atributo13.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo13.Font = null;
            this.atributo13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo13.Name = "atributo13";
            this.atributo13.UseVisualStyleBackColor = false;
            // 
            // atributo10
            // 
            this.atributo10.AccessibleDescription = null;
            this.atributo10.AccessibleName = null;
            resources.ApplyResources(this.atributo10, "atributo10");
            this.atributo10.BackColor = System.Drawing.SystemColors.Control;
            this.atributo10.BackgroundImage = null;
            this.atributo10.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo10.Font = null;
            this.atributo10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo10.Name = "atributo10";
            this.atributo10.UseVisualStyleBackColor = false;
            // 
            // atributo11
            // 
            this.atributo11.AccessibleDescription = null;
            this.atributo11.AccessibleName = null;
            resources.ApplyResources(this.atributo11, "atributo11");
            this.atributo11.BackColor = System.Drawing.SystemColors.Control;
            this.atributo11.BackgroundImage = null;
            this.atributo11.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo11.Font = null;
            this.atributo11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo11.Name = "atributo11";
            this.atributo11.UseVisualStyleBackColor = false;
            // 
            // atributo12
            // 
            this.atributo12.AccessibleDescription = null;
            this.atributo12.AccessibleName = null;
            resources.ApplyResources(this.atributo12, "atributo12");
            this.atributo12.BackColor = System.Drawing.SystemColors.Control;
            this.atributo12.BackgroundImage = null;
            this.atributo12.Cursor = System.Windows.Forms.Cursors.Default;
            this.atributo12.Font = null;
            this.atributo12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atributo12.Name = "atributo12";
            this.atributo12.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.C_tipo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.l_turno);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_descrip);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_user);
            this.groupBox1.Controls.Add(this.txt_ID);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.txt_psw);
            this.groupBox1.Font = null;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.AccessibleDescription = null;
            this.pictureBox3.AccessibleName = null;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.BackgroundImage = null;
            this.pictureBox3.Font = null;
            this.pictureBox3.ImageLocation = null;
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // C_tipo
            // 
            this.C_tipo.AccessibleDescription = null;
            this.C_tipo.AccessibleName = null;
            resources.ApplyResources(this.C_tipo, "C_tipo");
            this.C_tipo.BackgroundImage = null;
            this.C_tipo.Font = null;
            this.C_tipo.FormattingEnabled = true;
            this.C_tipo.Name = "C_tipo";
            this.C_tipo.SelectedIndexChanged += new System.EventHandler(this.C_tipo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Font = null;
            this.label5.Name = "label5";
            // 
            // l_turno
            // 
            this.l_turno.AccessibleDescription = null;
            this.l_turno.AccessibleName = null;
            resources.ApplyResources(this.l_turno, "l_turno");
            this.l_turno.BackgroundImage = null;
            this.l_turno.Font = null;
            this.l_turno.FormattingEnabled = true;
            this.l_turno.Name = "l_turno";
            this.l_turno.SelectedIndexChanged += new System.EventHandler(this.l_turno_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleDescription = null;
            this.pictureBox1.AccessibleName = null;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackgroundImage = null;
            this.pictureBox1.Font = null;
            this.pictureBox1.ImageLocation = null;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.AccessibleDescription = null;
            this.pictureBox2.AccessibleName = null;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BackgroundImage = null;
            this.pictureBox2.Font = null;
            this.pictureBox2.ImageLocation = null;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = null;
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Name = "label6";
            // 
            // txt_descrip
            // 
            this.txt_descrip.AccessibleDescription = null;
            this.txt_descrip.AccessibleName = null;
            resources.ApplyResources(this.txt_descrip, "txt_descrip");
            this.txt_descrip.BackColor = System.Drawing.Color.Yellow;
            this.txt_descrip.BackgroundImage = null;
            this.txt_descrip.Font = null;
            this.txt_descrip.Name = "txt_descrip";
            this.txt_descrip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_descrip_KeyDown);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = null;
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Name = "label4";
            // 
            // txt_user
            // 
            this.txt_user.AccessibleDescription = null;
            this.txt_user.AccessibleName = null;
            resources.ApplyResources(this.txt_user, "txt_user");
            this.txt_user.BackColor = System.Drawing.Color.Yellow;
            this.txt_user.BackgroundImage = null;
            this.txt_user.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_user.Font = null;
            this.txt_user.Name = "txt_user";
            // 
            // txt_ID
            // 
            this.txt_ID.AccessibleDescription = null;
            this.txt_ID.AccessibleName = null;
            resources.ApplyResources(this.txt_ID, "txt_ID");
            this.txt_ID.BackColor = System.Drawing.Color.Yellow;
            this.txt_ID.BackgroundImage = null;
            this.txt_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ID.Font = null;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ID_KeyDown);
            this.txt_ID.Validating += new System.ComponentModel.CancelEventHandler(this.txt_ID_Validating);
            // 
            // Label1
            // 
            this.Label1.AccessibleDescription = null;
            this.Label1.AccessibleName = null;
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = null;
            this.Label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label1.Name = "Label1";
            // 
            // Label3
            // 
            this.Label3.AccessibleDescription = null;
            this.Label3.AccessibleName = null;
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.Font = null;
            this.Label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label3.Name = "Label3";
            // 
            // Label2
            // 
            this.Label2.AccessibleDescription = null;
            this.Label2.AccessibleName = null;
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = null;
            this.Label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label2.Name = "Label2";
            // 
            // txt_psw
            // 
            this.txt_psw.AccessibleDescription = null;
            this.txt_psw.AccessibleName = null;
            resources.ApplyResources(this.txt_psw, "txt_psw");
            this.txt_psw.BackgroundImage = null;
            this.txt_psw.Font = null;
            this.txt_psw.Name = "txt_psw";
            // 
            // WUSER
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.panel1);
            this.Font = null;
            this.Name = "WUSER";
            this.Tag = "";
            this.TopMost = false;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        #region FUNCTIONS
        public void comando(int opcion)
		{
            System.Windows.Forms.ToolStripItem bt = this.toolBar1.Items[opcion];
            this.toolBar1_ButtonClick(this.toolBar1, new ToolStripItemClickedEventArgs(bt));
		}




		private void Mostrar_Datos(int pos)
		{
			if (dt.Tables[0].Rows.Count > 0)
			{
				DataRow dr = dt.Tables[0].Rows[pos];

				this.txt_user.Text = dr["user"].ToString();
				this.txt_psw.Text = dr["contrasena"].ToString();
				this.txt_ID.Text = dr["iniciales"].ToString();
				this.txt_descrip.Text = dr["nombre"].ToString();
				this.txt_turno = dr["turno"].ToString();
                for (int j = 0; j < this.l_turno.Items.Count; j++)
                {
                    if (this.l_turno.Items[j].ToString() == this.txt_turno)
                    {
                        this.l_turno.SelectedIndex = j;
                        break;
                    }
                }
                this.txt_atributo = dr["privilegios"].ToString();
				for (int i=0;i< this.atributo.Length;i++)
				{
					if (dr["privilegios"].ToString().Substring(i,1) == "1")
					{ this.atributo[i].Checked = true;}
					else
					{ this.atributo[i].Checked = false;}
				}
                if (dr["tipo"].ToString().Length > 0) this.C_tipo.SelectedIndex = Convert.ToInt16(dr["tipo"].ToString());
			}
		}


		private void limpiar()
		{
			this.txt_user.Text = "";
			this.txt_psw.Text = "";
			this.txt_ID.Text = "";
			this.txt_descrip.Text="";
            this.l_turno.SelectedIndex = 0;
			this.txt_turno=this.l_turno.Items[0].ToString();
            this.txt_atributo = "";
			for (int i=0; i< this.atributo.Length;i++)
			{
				atributo[i].Checked = false;
			}
            this.txt_user.Focus();
		}


        private void Guardar_User()
        {
            string atrib = buscar_atributos();

            Conec.Condicion = "( user = '" + this.txt_user.Text + "')";
            Conec.CadenaSelect = "UPDATE " + Conec.NombreTabla +
                " SET contrasena = '" + this.txt_psw.Text + "', iniciales = '" + this.txt_ID.Text +
                "', privilegios = '" + atrib + "', nombre = '" + this.txt_descrip.Text +
                "', turno = '" + this.txt_turno + "', tipo = " + this.C_tipo.SelectedIndex + " WHERE " + Conec.Condicion;
            try
            {
                db.ExcetuteQuery(Conec.CadenaSelect);
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


		private void Nuevo_User()
		{		
			string atrib = buscar_atributos();
						
			Conec.CadenaSelect ="INSERT INTO usuarios ([user], contrasena, iniciales, privilegios, nombre, turno, tipo )" +
				" VALUES ('" + this.txt_user.Text + "','" + this.txt_psw.Text + "','" + this.txt_ID.Text + "','" + atrib.ToString() + "','" + this.txt_descrip.Text + "','" + this.txt_turno + "',"+ this.C_tipo.SelectedIndex + ")" ;
            try
            {
                if (this.txt_user.Text != "")
                {                   
                    db.ExcetuteQuery(Conec.CadenaSelect);                    
                }
            }
            catch (DBConcurrencyException dbcx)
            {
                string customErrorMessage;
                customErrorMessage = dbcx.Message.ToString();
                customErrorMessage += dbcx.Row[0].ToString();
                MessageBox.Show(customErrorMessage.ToString());
                dt.RejectChanges();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt.RejectChanges();
            }					
					MessageBox.Show(Global.M_Error[5,Global.idioma].ToString());
		}


		private void Borrar_User()
		{			
			Conec.Condicion = "( user = '" + this.txt_user.Text + "')";
			Conec.CadenaSelect = "DELETE * FROM " + Conec.NombreTabla + " WHERE " + Conec.Condicion;

			if (dt.Tables[0].Rows.Count > 0)
			{
                if (this.txt_user.Text.ToUpper() != "ADMIN" && this.txt_user.Text.ToUpper() != "OPERADOR" && this.txt_user.Text.ToUpper() != "OPERATOR")
                {
                    DataRow[] dr = dt.Tables[0].Select("user = '" + this.txt_user.Text + "'");  //.Rows[cmAgente.Position];
                    if (dr.Length > 0)
                    {
                        dr[0].Delete();

                        DataSet DSChanges = dt.GetChanges(DataRowState.Deleted);

                        if (DSChanges != null)
                        {
                            try
                            {
                                db.ExcetuteQuery(Conec.CadenaSelect);
                                dt.AcceptChanges();
                                MessageBox.Show(Global.M_Error[3, Global.idioma].ToString());
                            }
                            catch (DBConcurrencyException ex)
                            {
                                string customErrorMessage;

                                customErrorMessage = ex.Message.ToString();
                                customErrorMessage += ex.Row[0].ToString();
                                MessageBox.Show(customErrorMessage.ToString());

                            }
                            catch (OleDbException ex)
                            {
                                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Conec.dbDataSet.RejectChanges();
                            }
                        }
                    }
                }
			}
			else
			{				
				MessageBox.Show(Global.M_Error[2,Global.idioma]);
				cmRegister.Position = 0;
			}
		}


		private bool Find_User(string n_user)
		{			
			int i;
			bool buscar = false;

			Conec.Condicion = "(user = '" + n_user + "')"; 
			Conec.CadenaSelect = "SELECT * FROM " + Conec.NombreTabla + " WHERE " + Conec.Condicion;
			cmRegister.Position = 0;

			for (i = 0; i < dt.Tables[0].Rows.Count;i++)
			{
				DataRow dr = dt.Tables[0].Rows[i];
				
				if (dr["user"].ToString() !=  n_user)
				{
					cmRegister.Position += 1;
				}
				else
				{								
					buscar=true;
					break;
				}
			}
			return buscar;
		}


		private string buscar_atributos()
		{
			string privilegio = "";

			for (int i=0;i<this.atributo.Length;i++)
			{
				if (this.atributo[i].CheckState == CheckState.Checked)
				{ privilegio += "1";}
				else {privilegio += "0";}
			}

			return privilegio;
		}


		public bool muestra_ususario(string codigo)
		{
			if(this.Find_User(codigo))
			{
				this.Mostrar_Datos(this.cmRegister.Position);
				return true;
			}
			else return false;

		}
        #endregion


        #region EVENTS
        private void editar_TextChanged(object sender, System.EventArgs e)
        {
            this.editar_dato = true;
        }


        private void WUSER_Close(object sender, CancelEventArgs e)
        {
            this.Close();
        }


        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
		{

            switch (this.toolBar1.Items.IndexOf(e.ClickedItem))
			{
				case 0: 
				{
					limpiar();
					this.cerrar=false;
					this.editar_dato=false;
					this.txt_user.Focus();
				}break;
                case 1:
                    {
                        this.editar_dato = false;
                        if (this.txt_user.Text == "")
                        {
                            MessageBox.Show(Global.M_Error[95, Global.idioma].ToString());
                            this.txt_user.Focus();
                            break;
                        }
                        if (this.txt_ID.Text == "")
                        {
                            MessageBox.Show(Global.M_Error[97, Global.idioma].ToString());
                            this.txt_ID.Focus();
                            break;
                        }
                        if (this.txt_descrip.Text == "")
                        {
                            MessageBox.Show(Global.M_Error[88, Global.idioma].ToString());
                            this.txt_descrip.Focus();
                            break;
                        }
                        if (!Find_User(this.txt_user.Text)) Nuevo_User();
                        else Guardar_User();
                        if (cerrar) this.comando(6);
                        else this.comando(0);
                    } break;
				case 2:{Borrar_User();}break;
				case 3:
				{					
					limpiar();
				}break;
				case 4:{Mostrar_Datos(Previous(ref cmRegister));}break;
				case 5:{Mostrar_Datos(Next(ref cmRegister));}break;
				case 6:
				{
                    if (editar_dato)
                    {
                        if (MessageBox.Show(Global.M_Error[303, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.cerrar = true;
                            this.comando(1);
                        }
                        else this.Close();
                    }
                    else this.Close();
				}break;
			}		
		}		


		private void txt_user_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Insert){this.comando(0);}			
			if (e.KeyCode == Keys.Left){this.comando(5);}
			if (e.KeyCode == Keys.Right){this.comando(6);}
			if (e.KeyCode == Keys.Escape){this.comando(4);}
			if (e.KeyCode == Keys.Enter)
			{
				this.txt_psw.Focus();
			}
		}


		private void txt_user_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.txt_user.Text == "" )
			{
				MessageBox.Show(Global.M_Error[95,Global.idioma].ToString());
				this.txt_user.Focus();
			}
		}				


		private void txt_psw_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.txt_ID.Focus();
			}
		}


		private void txt_ID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.txt_ID.Text == "")
			{
				MessageBox.Show(Global.M_Error[97,Global.idioma].ToString());
				this.txt_ID.Focus();
			}			
		}


		private void txt_ID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                this.txt_descrip.Focus();
			}		
		}


        private void txt_descrip_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.txt_descrip.Text == "")
            {
                MessageBox.Show(Global.M_Error[88, Global.idioma].ToString());
                this.txt_descrip.Focus();
            }
        }


		private void txt_descrip_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				 this.l_turno.Focus();
			}		
		}


        private void l_turno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txt_turno = this.l_turno.SelectedItem.ToString();
            this.atributo0.Focus();
        }


        private void C_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.C_tipo.SelectedIndex == 0)
            {
                this.atributo0.Enabled = true;
                this.atributo2.Enabled = true;
                this.atributo3.Enabled = true;
                this.atributo10.Enabled = true;
                this.atributo13.Enabled = true;
                if (txt_atributo == "")
                {
                    for (int i = 0; i < this.atributo.Length; i++)
                        this.atributo[i].Checked = true;
                }
            }
            else
            {
                if (txt_atributo == "")
                {
                    for (int i = 0; i < this.atributo.Length; i++)
                        this.atributo[i].Checked = false;
                }
                this.atributo0.Enabled = false;
                this.atributo2.Enabled = false;
                this.atributo3.Enabled = false;
                this.atributo10.Enabled = false;
                this.atributo13.Enabled = false;
            }
        }


        #endregion
    }
}

