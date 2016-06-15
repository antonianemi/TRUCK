using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace TRUCK
{	




    /// <summary>
    /// Permite Administrar la tara con la base de datos. 
    /// </summary>
	public class WTARA : Form1
    {

        #region VARIABLES
        DataAccesQuery db;
        DataSet dt;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components = null;
		public int i = 0;
		private CurrencyManager cmRegister;
        private bool editar_dato=false;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		public System.Windows.Forms.TextBox textBox1;
		public System.Windows.Forms.TextBox nombre;
		private System.Windows.Forms.Label label3;
		public  MaskedTextBox.MaskedTextBox numero;
		private MaskedTextBox.MaskedTextBox tara;
        #endregion

        #region CONSTRUCTORS
        public WTARA(int x, int y,int ventana)
		{
            db = new DataAccesQuery();
			InitializeComponent();
			this.Location = new System.Drawing.Point(x,y);
			this.TransparencyKey = Color.Empty;
			this.Tag = Global.M_Error[141,Global.idioma].ToString();
			this.numero.LostFocus+=new System.EventHandler(this.numero_LostFocus);
			this.numero.Validating+=new System.ComponentModel.CancelEventHandler(this.numero_Validating);
			this.numero.KeyDown+=new System.Windows.Forms.KeyEventHandler(this.numero_KeyDown);
			this.numero.TextChanged+=new System.EventHandler(this.editar_TextChanged);
			this.nombre.Validating+=new System.ComponentModel.CancelEventHandler(this.nombre_Validating);
			this.nombre.KeyDown+=new System.Windows.Forms.KeyEventHandler(this.nombre_KeyDown);
            this.nombre.TextChanged+=new System.EventHandler(this.editar_TextChanged);
			this.tara.KeyDown+=new System.Windows.Forms.KeyEventHandler(this.tara_KeyDown);
            this.toolBar1.ItemClicked += new ToolStripItemClickedEventHandler(this.toolBar1_ButtonClick);
            dt=db.getData("SELECT * FROM TARAS WHERE (numemp = " + Global.nempresa + ") ORDER BY NUMERO");
            dt.Tables[0].TableName = "TARAS";
            cmRegister = (CurrencyManager)this.BindingContext[dt, "TARAS"];
			cmRegister.Position = 0;
            dt.Tables[0].PrimaryKey = new DataColumn[] {dt.Tables[0].Columns["NUMERO"]};
		}
        #endregion
        #region Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WTARA));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tara = new MaskedTextBox.MaskedTextBox();
            this.numero = new MaskedTextBox.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tara);
            this.panel1.Controls.Add(this.numero);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.nombre);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Name = "panel1";
            // 
            // tara
            // 
            this.tara.DateOnly = false;
            this.tara.DecimalOnly = false;
            this.tara.DigitOnly = true;
            this.tara.IPAddrOnly = false;
            resources.ApplyResources(this.tara, "tara");
            this.tara.Name = "tara";
            this.tara.PhoneWithAreaCode = false;
            this.tara.SSNOnly = false;
            // 
            // numero
            // 
            this.numero.BackColor = System.Drawing.Color.Yellow;
            this.numero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numero.DateOnly = false;
            this.numero.DecimalOnly = false;
            this.numero.DigitOnly = false;
            this.numero.IPAddrOnly = false;
            resources.ApplyResources(this.numero, "numero");
            this.numero.Name = "numero";
            this.numero.PhoneWithAreaCode = false;
            this.numero.SSNOnly = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Name = "textBox1";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, resources.GetString("pictureBox2.ToolTip"));
            // 
            // nombre
            // 
            this.nombre.BackColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(this.nombre, "nombre");
            this.nombre.Name = "nombre";
            this.toolTip1.SetToolTip(this.nombre, resources.GetString("nombre.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // WTARA
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel1);
            this.Name = "WTARA";
            this.Tag = "";
            this.TopMost = false;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region EVENTS
        private void editar_TextChanged(object sender, System.EventArgs e)
        {
            this.editar_dato = true;
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
        #region FUNCTIONS
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
        public void comando(int opcion)
		{
            System.Windows.Forms.ToolStripItem bt = this.toolBar1.Items[opcion];
			this.toolBar1_ButtonClick(this.toolBar1, new ToolStripItemClickedEventArgs(bt));
		}
        private void New_Dato()
        {
            string query = "INSERT INTO Taras (numemp,numero,descripcion,tara) VALUES ( " + Global.nempresa + ",'" + this.numero.Text.Trim() + "','" + this.nombre.Text + "','" + this.tara.Text + "')";
            DataRow dr = dt.Tables[0].NewRow();
            try
            {
                if (this.numero.Text != "" && this.numero.Text != "0")
                {   
                    db.ExcetuteQuery(query);
                }
                else
                {
                    MessageBox.Show(Global.M_Error[89, Global.idioma].ToString());
                }
            }
            catch (DBConcurrencyException dbcx)
            {
                string customErrorMessage;
                customErrorMessage = dbcx.Message.ToString();
                customErrorMessage += dbcx.Row[0].ToString();
                MessageBox.Show(customErrorMessage.ToString());
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		private void Del_Dato()
		{
            string query = "DELETE FROM TARAS WHERE ( NUMERO = '" + this.numero.Text.Trim() + "' and NUMEMP = " + Global.nempresa + ")";

			if (numero.Text != "")
			{
				if (dt.Tables[0].Rows.Count > 0)
				{
					DataRow[] dr =  dt.Tables[0].Select("NUMERO = '" + this.numero.Text.Trim() +"'" );  //.Rows[cmAgente.Position];
					if (dr.Length > 0)
					{
						dr[0].Delete();

						DataSet DSChanges = dt.GetChanges(DataRowState.Deleted);

						if (DSChanges != null)
						{
							try
							{
                                db.ExcetuteQuery(query);
                                dt.AcceptChanges();
								MessageBox.Show(Global.M_Error[3,Global.idioma].ToString());
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
								MessageBox.Show(ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
								dt.RejectChanges();
							}
						}
					}
				}
				else
				{				
					MessageBox.Show(Global.M_Error[2,Global.idioma].ToString());
					cmRegister.Position = 0;
				}
			}
			else
			{
				MessageBox.Show(Global.M_Error[305,Global.idioma].ToString());
				cmRegister.Position = 0;
			}
		}
        private void Save_Dato()
        {

            string query = "UPDATE Tara  SET descripcion = '" + this.nombre.Text + "'," +"tara = '" + this.tara.Text + "' WHERE (numero = '" + numero.Text.Trim() + "' and numemp = " + Global.nempresa + ")";

            try
            {
                db.ExcetuteQuery(query);
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
        }
		private bool Find_Numero(string codigo)
		{
			bool encontro=false;
            cmRegister.Position = 0;
			
			DataRow[] dr = dt.Tables[0].Select("numero = '"+codigo.Trim()+"'");
			if (dr.Length > 0)
			{
				encontro = true;
				cmRegister.Position = buscar_posicion(codigo.Trim(),"numero");
			}
			return encontro;
		}
		private bool Find_Nombre(string codigo)
		{
			bool encontro=false;
			cmRegister.Position = 0;
			int len = codigo.Length;
			DataRow[] dr = dt.Tables[0].Select("SUBSTRING(descripcion,1," + len+ ") = '"+codigo+"'");
			if (dr.Length > 0)
			{
				encontro = true;
				cmRegister.Position = buscar_posicion(dr[0]["numero"].ToString(),"numero");
			}
			return encontro;
		}
		public bool muestra_codigo(string codigo)
		{
			if(this.Find_Numero(codigo))
			{
				this.Mostrar_Datos(cmRegister.Position,1);
				return true;
			}
			else return false;

		}
		private void Cancel_Agent()
		{
			this.numero.Text = "";
			this.nombre.Text = "";
		}
		private void Mostrar_Datos(int pos,int op)
		{	
			if (dt.Tables[0].Rows.Count > 0 && pos >= 0)
			{
				DataRow dr=dt.Tables[0].Rows[pos];
				numero.Text = dr["numero"].ToString();
				nombre.Text = dr["descripcion"].ToString();
				tara.Text = dr["tara"].ToString();
				if (op == 0)numero.Focus();
				else nombre.Focus();
				this.editar_dato=false;
			}
		}
        private void limpiar()
        {
            this.numero.Text = "";
            this.nombre.Text = "";
            this.tara.Text = "";
            this.editar_dato = false;
        }
        #endregion


        #region EVENTS
        private void WTARA_Close(object sender, CancelEventArgs e)
		{		
			this.Close();		
		}
		private void nombre_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (this.nombre.Text == "")
				{
					MessageBox.Show(Global.M_Error[90,Global.idioma].ToString());
					this.nombre.Focus();
				}
				else this.tara.Focus();
			}
		}		
		private void numero_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
	    {
			if (e.KeyCode == Keys.Insert){this.comando(0);}			
			if (e.KeyCode == Keys.Left){this.comando(4);}
			if (e.KeyCode == Keys.Right){this.comando(5);}
			if (e.KeyCode == Keys.Escape){this.comando(3);}
			if (e.KeyCode == Keys.Enter)
			{
				this.nombre.Focus();
			}
		}		
		private void tara_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.comando(1);
			}
		}
        private void numero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.numero.Text == "")
            {
                MessageBox.Show(Global.M_Error[89, Global.idioma].ToString());
                this.numero.Focus();
            }
        }
		private void numero_LostFocus(object sender, System.EventArgs e)
		{
			if (this.numero.Text != "" && this.numero.Text !="0")
			{
				if(this.Find_Numero(this.numero.Text))
				{
					Mostrar_Datos(this.cmRegister.Position,1);
				}
			}
		}
        private void nombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.nombre.Text == "")
			{
				MessageBox.Show(Global.M_Error[90,Global.idioma].ToString());
				this.nombre.Focus();
			}
		}
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
		{
			switch (this.toolBar1.Items.IndexOf(e.ClickedItem))
			{
				case 0 :  
				{		
					limpiar();
					this.editar_dato=false;
					this.numero.Focus();
				}break;
				case 1 : 
				{
					if (this.numero.Text == "" || this.numero.Text == "0")
					{
						MessageBox.Show(Global.M_Error[89,Global.idioma].ToString());
						this.numero.Focus();
						break;
					}					
					if (this.nombre.Text == "")
					{
						MessageBox.Show(Global.M_Error[90,Global.idioma].ToString());
						this.nombre.Focus();
						break;
					}
                    if (dt.Tables[0].Rows.Count > 5 && !Keylock.IsPresent())
                    {
                        MessageBox.Show(Global.M_Error[147, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.editar_dato = false;
                        IDataReader df = db.getDataReader("SELECT numemp,numero FROM Taras WHERE numemp = " + Global.nempresa + " and numero = '" + this.numero.Text.Trim()+ "'");

                        if (!df.Read())
                        {
                            df.Close();
                            New_Dato();
                        }
                        else
                        {
                            df.Close();
                            Save_Dato();
                        }
                        this.comando(6);
                    }
				}break;
				case 2 :
				{
					DialogResult df = MessageBox.Show(Global.M_Error[100,Global.idioma].ToString(),"",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
					if (df == DialogResult.Yes){Del_Dato();}
				}break;				
				case 3 :
					if (this.Find_Numero(numero.Text))
					{
					   Mostrar_Datos(this.cmRegister.Position,0);
					}
					else
					{					
						this.numero.Focus();
						limpiar();
					}
					break;
				case 4 : // Reg. Anterior
					if (this.editar_dato)
					{
						if (MessageBox.Show(Global.M_Error[303,Global.idioma].ToString(),"",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
						{
							this.comando(1);
						}
						else Mostrar_Datos(Previous(ref cmRegister),0);
					}
					else Mostrar_Datos(Previous(ref cmRegister),0);
					break;
				case 5 :  // Reg. Siguiente
					if (this.editar_dato)
					{
						if (MessageBox.Show(Global.M_Error[303,Global.idioma].ToString(),"",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
						{
							this.comando(1);
						}
						else Mostrar_Datos(Next(ref cmRegister),0);
					}
					else Mostrar_Datos(Next(ref cmRegister),0);
					break;
				case 6  :
				{
					if (this.editar_dato)
					{
						if (MessageBox.Show(Global.M_Error[303,Global.idioma].ToString(),"",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
						{				
							this.comando(1);
						}
						else this.Close();
					}
					else this.Close();
				}break;
			}		
		}
        #endregion





	}			
}

