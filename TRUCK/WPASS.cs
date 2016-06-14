using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace TRUCK
{
	/// <summary>
	/// Descripción breve de WPASS.
	/// </summary>
	public class WPASS : System.Windows.Forms.Form
    {
        
        #region VARIABLES
        DataAccesQuery db;
        DataSet dt;
        private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
		private System.ComponentModel.IContainer components = null;
        #endregion
        #region CONSTRUCTORS
        public WPASS(int x, int y)
		{
            string query = "";
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();
			this.Tag = Global.M_Error[168,Global.idioma].ToString();
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
			this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            this.TransparencyKey = Color.Empty;
            query = "SELECT * FROM Usuarios ORDER BY user";

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
		#region Windows Form Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador, no se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WPASS));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.Label3);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.Name = "Label3";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // WPASS
            // 
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WPASS";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        #region EVENTS
        private void button1_Click(object sender, System.EventArgs e)
		{
		    cambiar_password(Global.user,Global.password);
			this.Close();
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void cambiar_password(string user,string passw)
		{
            string query = "";
			if (passw == this.textBox1.Text.Trim())
			{
				if (this.textBox2.Text.Trim() == this.textBox3.Text.Trim())
				{
                    query = "UPDATE Usuarios SET contrasena ='" + this.textBox2.Text.Trim() + "' WHERE ( user = '" + user + "')";
                    db.ExcetuteQuery(query);
				}
				else
				{
					MessageBox.Show(Global.M_Error[117,Global.idioma].ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show(Global.M_Error[120,Global.idioma].ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (Global.password != this.textBox1.Text.Trim())
				{
					MessageBox.Show(Global.M_Error[120,Global.idioma].ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Information);
					this.textBox1.Focus();
				}
				else this.textBox2.Focus();
			}
		}
		private void textBox2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.textBox3.Focus();
			}
		}
		private void textBox3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (this.textBox3.Text.Trim() != this.textBox2.Text.Trim())
				{
					MessageBox.Show(Global.M_Error[117,Global.idioma].ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Information);
					this.textBox2.Focus();
				}
				else this.button1.Focus();
			}
        }
        #endregion
    }
}
