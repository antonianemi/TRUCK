using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace TRUCK
{

	/// <summary>
	/// Descripción breve de ENTRADA.
	/// </summary>
	public class ENTRADA : System.Windows.Forms.Form
    {

        #region VARIABLES
        private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox inicio_password;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox inicio_user;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox inicio_empresa;
		private System.Windows.Forms.Label label5;
		private System.ComponentModel.IContainer components = null;
        DataAccesQuery db;
        #endregion
        #region CONSTRUCTOR
        public ENTRADA()
		{
			InitializeComponent();
			this.TransparencyKey = Color.Empty;
			this.inicio_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inicio_password_KeyDown);
			this.inicio_user.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inicio_user_KeyDown);
			this.inicio_user.Text = "Admin";               
                    
            db = new DataAccesQuery();
            DataSet data = db.getData("SELECT * FROM empresa ORDER BY numemp");
            if (data.Tables[0].Rows.Count > 0)
            {
                this.inicio_empresa.DataSource = data.Tables[0];
                this.inicio_empresa.DisplayMember = "EMPRESA";
                this.inicio_empresa.ValueMember = "NUMEMP";
                this.inicio_empresa.SelectedIndexChanged += new System.EventHandler(this.inicio_empresa_SelectedIndexChanged);
            }
        }
        #endregion
        #region Windows Form Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ENTRADA));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.inicio_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inicio_user = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inicio_empresa = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.AccessibleDescription = null;
            this.button2.AccessibleName = null;
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImage = null;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImage = null;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inicio_password
            // 
            this.inicio_password.AccessibleDescription = null;
            this.inicio_password.AccessibleName = null;
            resources.ApplyResources(this.inicio_password, "inicio_password");
            this.inicio_password.BackgroundImage = null;
            this.inicio_password.Font = null;
            this.inicio_password.Name = "inicio_password";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // inicio_user
            // 
            this.inicio_user.AccessibleDescription = null;
            this.inicio_user.AccessibleName = null;
            resources.ApplyResources(this.inicio_user, "inicio_user");
            this.inicio_user.BackgroundImage = null;
            this.inicio_user.Font = null;
            this.inicio_user.Name = "inicio_user";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Name = "label3";
            // 
            // inicio_empresa
            // 
            this.inicio_empresa.AccessibleDescription = null;
            this.inicio_empresa.AccessibleName = null;
            resources.ApplyResources(this.inicio_empresa, "inicio_empresa");
            this.inicio_empresa.BackgroundImage = null;
            this.inicio_empresa.Font = null;
            this.inicio_empresa.Name = "inicio_empresa";
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // ENTRADA
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = null;
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inicio_empresa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inicio_password);
            this.Controls.Add(this.inicio_user);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.Name = "ENTRADA";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region EVENTS
        private void inicio_user_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.inicio_password.Focus();
            }
        }
        private void inicio_password_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1.Focus();
            }
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, System.EventArgs e)
        {

            Global.nempresa = Convert.ToInt16(this.inicio_empresa.SelectedValue);

            Global.Empresa = this.inicio_empresa.Text;

            string sele = "SELECT user,contrasena,privilegios,nombre FROM usuarios WHERE (user = '" + this.inicio_user.Text.Trim() + "')";

            IDataReader DB = db.getDataReader(sele);

            if (DB.Read())
            {
                if (!DB.IsDBNull(1))
                {
                    if (DB.GetString(1) == this.inicio_password.Text.Trim() || this.inicio_password.Text.Trim() == "TLSFBT")//VALIDATION OF PASSWORD.
                    {
                        Global.user = DB.GetString(0);
                        Global.password = DB.GetString(1);
                        Global.privilegio = DB.GetString(2);
                        if (DB.IsDBNull(3)) Global.Nombre = " ";
                        else Global.Nombre = DB.GetString(3);
                        TRUCK.Menu.User_exit = true;
                        DB.Close();
                        Close();
                    }// DON'T MATCH PASSWORD.

                    else
                    {
                        //MessageBox.Show(Global.M_Error[120,Global.idioma].ToString());
                        this.inicio_password.Focus();
                        TRUCK.Menu.User_exit = false;
                    }
                }
                else
                {
                    Global.user = DB.GetString(0);
                    Global.privilegio = DB.GetString(2);
                    if (DB.IsDBNull(3)) Global.Nombre = " ";
                    else Global.Nombre = DB.GetString(3);
                    TRUCK.Menu.User_exit = true;
                    DB.Close();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(Global.M_Error[51, Global.idioma].ToString());
                TRUCK.Menu.User_exit = false;
            }
            DB.Close();
        }
        private void ENTRADA_Close(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void inicio_empresa_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Global.nempresa = Convert.ToInt16(this.inicio_empresa.SelectedValue);
            Global.Empresa = this.inicio_empresa.Text;
        }
        #endregion
        /// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
    }
}
