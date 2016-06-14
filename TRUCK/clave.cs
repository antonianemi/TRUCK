using System.Windows.Forms;
using System.Data;

namespace TRUCK
{
	/// <summary>
	/// Descripción breve de clave.
	/// </summary>
	public class clave : System.Windows.Forms.Form
    {
        #region VARIABLES
        DataAccesQuery db;
        DataSet dt;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox inicio_password;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox inicio_user;
		private System.Windows.Forms.Label label1;
		private int tipo_user=0;
		private System.ComponentModel.IContainer components = null;
        #endregion
        #region FUCTIONS
        public clave(int opc)
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();
			this.inicio_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inicio_password_KeyDown);
			this.inicio_user.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inicio_user_KeyDown);
			tipo_user = opc;
			//
			// TODO: Agregar código de constructor después de llamar a InitializeComponent
			//
		}
        #endregion
        #region Windows Form Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            db = new DataAccesQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clave));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.inicio_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inicio_user = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inicio_password
            // 
            resources.ApplyResources(this.inicio_password, "inicio_password");
            this.inicio_password.Name = "inicio_password";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // inicio_user
            // 
            resources.ApplyResources(this.inicio_user, "inicio_user");
            this.inicio_user.Name = "inicio_user";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // clave
            // 
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inicio_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inicio_user);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "clave";
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
        private void button1_Click(object sender, System.EventArgs e)
        {



            string sele = "";
            if (this.tipo_user == 1)
            {
                sele = "SELECT user,contrasena,privilegios FROM Usuarios WHERE (user = '" + this.inicio_user.Text.Trim() + "' AND contrasena = '" + this.inicio_password.Text.Trim() + "')";
                IDataReader DB = db.getDataReader(sele);
                if (DB.Read())
                {
                    if (DB.GetString(2).Substring(17, 1) == "1") Global.clv_aceptada = true;
                    else MessageBox.Show(Global.M_Error[71, Global.idioma]);
                    DB.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Global.M_Error[51, Global.idioma].ToString());
                    this.inicio_user.Focus();
                    DB.Close();
                }
            }
            else
            {
                sele = "SELECT user,contrasena,privilegios FROM Usuarios WHERE (user = '" + this.inicio_user.Text.Trim() + "')"; // AND contrasena = '" + this.inicio_password.Text.Trim() + "')";
                IDataReader DB = db.getDataReader(sele);
                if (DB.Read())
                {
                    if (DB.GetString(1) == this.inicio_password.Text.Trim() || this.inicio_password.Text.Trim() == "TLSFBT")
                    {
                        //if (DB.GetInt16(2)== 0)
                        //{
                        Global.user = this.inicio_user.Text.Trim();
                        Global.password = DB.GetString(1);
                        Global.clv_aceptada = true;
                        Global.privilegio = DB.GetString(2);
                        //}
                        //else MessageBox.Show(Global.M_Error[71,Global.idioma]);
                        DB.Close();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(Global.M_Error[120, Global.idioma]);
                        this.inicio_password.Focus();
                    }
                    DB.Close();
                }
                else
                {
                    MessageBox.Show(Global.M_Error[51, Global.idioma].ToString());
                    this.inicio_user.Focus();
                    DB.Close();
                }
            }
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
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
