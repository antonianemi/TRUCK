using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TRUCK
{
	/// <summary>
	/// Descripción breve de Buscar.
	/// </summary>
	public class Buscar : System.Windows.Forms.Form
    {
        #region VARIABLES
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		public static string codigo;
		public static string nombre;
		private MaskedTextBox.MaskedTextBox descripcion;
		private MaskedTextBox.MaskedTextBox numero;
		private System.ComponentModel.IContainer components = null;
        #endregion
        #region FUCTIONS
        public Buscar(int tipo,string tex1,string tex2)
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();
            this.TransparencyKey = Color.Empty;
			this.numero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numero_KeyDown);
			this.descripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.descripcion_KeyDown);
			this.label1.Text = tex1;
			this.label2.Text = tex2;

			if (tipo == 1)this.descripcion.Enabled = false;
			else this.numero.Enabled = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Buscar));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.descripcion = new MaskedTextBox.MaskedTextBox();
            this.numero = new MaskedTextBox.MaskedTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.descripcion);
            this.groupBox1.Controls.Add(this.numero);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // descripcion
            // 
            this.descripcion.DateOnly = false;
            this.descripcion.DecimalOnly = false;
            this.descripcion.DigitOnly = false;
            this.descripcion.IPAddrOnly = false;
            resources.ApplyResources(this.descripcion, "descripcion");
            this.descripcion.Name = "descripcion";
            this.descripcion.PhoneWithAreaCode = false;
            this.descripcion.SSNOnly = false;
            // 
            // numero
            // 
            this.numero.DateOnly = false;
            this.numero.DecimalOnly = false;
            this.numero.DigitOnly = true;
            this.numero.IPAddrOnly = false;
            resources.ApplyResources(this.numero, "numero");
            this.numero.Name = "numero";
            this.numero.PhoneWithAreaCode = false;
            this.numero.SSNOnly = false;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Buscar
            // 
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Buscar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        #region EVENTS
        private void numero_KeyDown(object sender,System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.descripcion.Focus();
				codigo = this.numero.Text;
			}
		}
		private void descripcion_KeyDown(object sender,System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.button1.Focus();
				nombre = this.descripcion.Text;
			}
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
			codigo = this.numero.Text;
			nombre = this.descripcion.Text;
			this.Close();
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
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
    }
}
