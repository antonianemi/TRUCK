using System;
using System.Drawing;
using System.Windows.Forms;

namespace TRUCK
{

	/// <summary>
	/// Descripción breve de depurar.
	/// </summary>
	public class depurar : System.Windows.Forms.Form
    {
        #region Windows Form Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(depurar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ven2 = new MaskedTextBox.MaskedTextBox();
            this.ven1 = new MaskedTextBox.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fec1 = new System.Windows.Forms.DateTimePicker();
            this.fec2 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ven2);
            this.panel1.Controls.Add(this.ven1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.fec1);
            this.panel1.Controls.Add(this.fec2);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // ven2
            // 
            this.ven2.AccessibleDescription = null;
            this.ven2.AccessibleName = null;
            resources.ApplyResources(this.ven2, "ven2");
            this.ven2.BackgroundImage = null;
            this.ven2.DateOnly = false;
            this.ven2.DecimalOnly = false;
            this.ven2.DigitOnly = true;
            this.ven2.Font = null;
            this.ven2.IPAddrOnly = false;
            this.ven2.Name = "ven2";
            this.ven2.PhoneWithAreaCode = false;
            this.ven2.SSNOnly = false;
            // 
            // ven1
            // 
            this.ven1.AccessibleDescription = null;
            this.ven1.AccessibleName = null;
            resources.ApplyResources(this.ven1, "ven1");
            this.ven1.BackgroundImage = null;
            this.ven1.DateOnly = false;
            this.ven1.DecimalOnly = false;
            this.ven1.DigitOnly = true;
            this.ven1.Font = null;
            this.ven1.IPAddrOnly = false;
            this.ven1.Name = "ven1";
            this.ven1.PhoneWithAreaCode = false;
            this.ven1.SSNOnly = false;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // fec1
            // 
            this.fec1.AccessibleDescription = null;
            this.fec1.AccessibleName = null;
            resources.ApplyResources(this.fec1, "fec1");
            this.fec1.BackgroundImage = null;
            this.fec1.CalendarFont = null;
            this.fec1.CustomFormat = null;
            this.fec1.Font = null;
            this.fec1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fec1.Name = "fec1";
            // 
            // fec2
            // 
            this.fec2.AccessibleDescription = null;
            this.fec2.AccessibleName = null;
            resources.ApplyResources(this.fec2, "fec2");
            this.fec2.BackgroundImage = null;
            this.fec2.CalendarFont = null;
            this.fec2.Font = null;
            this.fec2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fec2.Name = "fec2";
            this.fec2.Value = new System.DateTime(2005, 1, 19, 0, 0, 0, 0);
            // 
            // button2
            // 
            this.button2.AccessibleDescription = null;
            this.button2.AccessibleName = null;
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackgroundImage = null;
            this.button2.Font = null;
            this.button2.Name = "button2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.AccessibleDescription = null;
            this.txtStatus.AccessibleName = null;
            resources.ApplyResources(this.txtStatus, "txtStatus");
            this.txtStatus.Font = null;
            this.txtStatus.ForeColor = System.Drawing.Color.Blue;
            this.txtStatus.Name = "txtStatus";
            // 
            // depurar
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.ControlBox = false;
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.Name = "depurar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        #region VARIABLES
        DataAccesQuery db;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private int op;
		private System.Windows.Forms.Label txtStatus;
		private System.Windows.Forms.DateTimePicker fec2;
		private System.Windows.Forms.DateTimePicker fec1;
		private MaskedTextBox.MaskedTextBox ven2;
		private MaskedTextBox.MaskedTextBox ven1;
		private System.ComponentModel.IContainer components = null;
        #endregion
        #region CONSTRUCT
        public depurar(int ventana)
        {
            InitializeComponent();
            db = new DataAccesQuery();
            this.TransparencyKey = Color.Empty;

            if (ventana == 6)
            {
                this.ven1.DigitOnly = false;
                this.ven2.DigitOnly = false;
                this.ven1.MaxLength = 12;
                this.ven2.MaxLength = 12;
            }
            else
            {
                this.ven1.MaxLength = 5;
                this.ven2.MaxLength = 5;
            }

            this.ven1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ven1_KeyDown);
            this.ven2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ven2_KeyDown);
            this.ven2.Validating += new System.ComponentModel.CancelEventHandler(this.ven2_Validating);
            this.ven2.LostFocus += new System.EventHandler(this.ven2_LostFocus);

            op = ventana;

            switch (op)
            {
                case 2: asigna_texto(201, 202); break; //Productos
                case 3: asigna_texto(203, 204); break; //Proveedor
                case 4: asigna_texto(193, 194); break; //Cliente				
                case 5: asigna_texto(296, 297); break; //Transportisata					
                case 6: asigna_texto(298, 299); break; //Vehiculo					
            }
            //
            // TODO: Agregar código de constructor después de llamar a InitializeComponent
            //
        }
        #endregion
        #region FUNCTIONS
        private void asigna_texto(int msg1, int msg2)
        {
            this.label1.Text = Global.M_Error[msg1, Global.idioma].ToString();
            this.label2.Text = Global.M_Error[msg2, Global.idioma].ToString();
        }
		private void depura(int ran1, int ran2,string nombre_tabla,int n_mensaje)  //29
		{				
			string sele = "DELETE FROM "+ nombre_tabla + " WHERE ( numero >= " + ran1 + " AND numero <= "+ ran2 + " AND numemp = " + Global.nempresa + ")";
            db.ExcetuteQuery(sele);
            txtStatus.Text = Global.M_Error[n_mensaje, Global.idioma] + Global.M_Error[28, Global.idioma];            
        }
        private void depura(string ran1, string ran2, string nombre_tabla, int n_mensaje) //269
		{
			string sele = "DELETE FROM " + nombre_tabla + " WHERE ( numero >= '" + ran1 + "' AND numero <= '"+ ran2 + "' AND numemp = " + Global.nempresa + ")";
            db.ExcetuteQuery(sele);
            txtStatus.Text = Global.M_Error[n_mensaje, Global.idioma] + Global.M_Error[28, Global.idioma];
        }
        #endregion
        #region EVENTS
        private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (ven1.Text != "" )
				{
					if (ven2.Text == "" )
					{
						MessageBox.Show(this.label2.Text + " " +Global.M_Error[67,Global.idioma]);
						this.ven2.Focus();
						return;
					}
				}
				else 
				{
					if (ven2.Text != "")
					{
						MessageBox.Show(this.label1.Text + " " +Global.M_Error[67,Global.idioma]);
						this.ven1.Focus();
						return;
					}
					MessageBox.Show(Global.M_Error[305,Global.idioma]);
					this.Close();
					return;
				}
				if (ven1.DigitOnly)
				{
					if (Convert.ToInt32(ven2.Text) < Convert.ToInt32(ven1.Text))
					{
						MessageBox.Show(this.label2.Text + " " +Global.M_Error[129,Global.idioma]);
						this.ven2.Focus();
						return;
					}
				}


				DialogResult depura_op = MessageBox.Show(Global.M_Error[52,Global.idioma].ToString(),Global.M_Error[3,Global.idioma].ToString(),MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
				if (depura_op == DialogResult.Yes)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

					switch(op)
					{
						case 2:
						{//Producto
			                 asigna_texto(201, 202);
							depura(Convert.ToInt32(ven1.Text),Convert.ToInt32(ven2.Text),"Articulos",19);
						}break;
						case 3:
						{//Proveedor
			                asigna_texto(203, 204);
							depura(Convert.ToInt32(ven1.Text),Convert.ToInt32(ven2.Text),"Proveedor",29);
						}break;
						case 4:
						{//Cliente
				              asigna_texto(193, 194);
							depura(Convert.ToInt32(ven1.Text),Convert.ToInt32(ven2.Text),"cliente",30);
						}break;
						case 5:
						{//Transportista
				            asigna_texto(199, 200);
							depura(Convert.ToInt32(ven1.Text),Convert.ToInt32(ven2.Text),"Transportistas",291);
						}break;
						case 6:
						{//vehiculo tara
				             asigna_texto(296, 297);
							depura(ven1.Text,ven2.Text,"Taras",269);
						}break;
					}
					MessageBox.Show(Global.M_Error[53,Global.idioma].ToString());
					TRUCK.Menu.depura = true;
					this.Cursor = System.Windows.Forms.Cursors.Default;
					this.Close();
				}
			}
			catch(System.Data.OleDb.OleDbException myException)
			{
				for (int i=0; i < myException.Errors.Count; i++)
				{
					MessageBox.Show("Index #" + i + "\n" +
						"Message: " + myException.Errors[i].Message + "\n" +
						"Native: " + myException.Errors[i].NativeError.ToString() + "\n" +
						"Source: " + myException.Errors[i].Source + "\n" +
						"SQL: " + myException.Errors[i].SQLState + "\n","",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void ven1_KeyDown( object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter){this.ven2.Focus();}
		}
		private void ven2_KeyDown( object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				 this.button1.Focus();
			}
		}
		private void ven2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (ven1.Text != "" )
			{
				if (ven2.Text == "" )
				{
					MessageBox.Show(this.label2.Text + " " +Global.M_Error[67,Global.idioma]);
					this.ven2.Focus();
				}
				else this.button1.Focus();
			}
			else 
			{
				if (ven2.Text != "")
				{
					MessageBox.Show(this.label1.Text + " " +Global.M_Error[67,Global.idioma]);
					this.ven1.Focus();
				}
				else this.button1.Focus();
			}
		}
        private void ven2_LostFocus(object sender, System.EventArgs e)
		{
			if (ven1.Text != "" && ven2.Text != "")
			{
				if (ven1.DigitOnly)
				{
					if (Convert.ToInt32(ven2.Text) < Convert.ToInt32(ven1.Text))
					{
						MessageBox.Show(this.label2.Text + " " +Global.M_Error[129,Global.idioma]);
						this.ven2.Focus();
					}
				}
			}
		}
		private void fec1_KeyDown( object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				this.fec2.Focus();
			}
		}
		private void fec2_KeyDown( object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				this.button1.Focus();
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
        
    }
}
