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
using BaseAcces;
namespace TRUCK
{	
	public class WVENDOR : Form1
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
		//ADOutil Conec = new ADOutil();
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ContextMenu MenuBotton1 = new System.Windows.Forms.ContextMenu();
		public System.Windows.Forms.TextBox textBox1;
		public System.Windows.Forms.TextBox nombre;
		public MaskedTextBox.MaskedTextBox numero;
        #endregion
        #region CONSTRUCTS
        public WVENDOR(int x, int y,int ventana)
		{
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
            this.toolBar1.ItemClicked += new ToolStripItemClickedEventHandler(this.toolBar1_ButtonClick);
		
			// TODO: agregar cualquier inicialización después de llamar a InitializeComponent
             
			Conec.NombreTabla = "proveedor";
			Conec.Condicion = "( numemp = " +Global.nempresa + ")";
			Conec.CadenaSelect = "SELECT * FROM " + Conec.NombreTabla + " WHERE " + Conec.Condicion + " ORDER BY numero";
			cmRegister = (CurrencyManager)this.BindingContext[Conec.dbDataSet,Conec.NombreTabla];
			cmRegister.Position = 0;
            Conec.dbDataSet.Tables[Conec.NombreTabla].PrimaryKey = new DataColumn[] {Conec.dbDataSet.Tables[Conec.NombreTabla].Columns["numero"]};
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WVENDOR));
            this.panel1 = new System.Windows.Forms.Panel();
            this.numero = new MaskedTextBox.MaskedTextBox();
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
            this.panel1.Controls.Add(this.numero);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.nombre);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Name = "panel1";
            // 
            // numero
            // 
            this.numero.BackColor = System.Drawing.Color.Yellow;
            this.numero.DateOnly = false;
            this.numero.DecimalOnly = false;
            this.numero.DigitOnly = true;
            this.numero.IPAddrOnly = false;
            resources.ApplyResources(this.numero, "numero");
            this.numero.Name = "numero";
            this.numero.PhoneWithAreaCode = false;
            this.numero.SSNOnly = false;
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
            // WVENDOR
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel1);
            this.Name = "WVENDOR";
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
        public void comando(int opcion)
		{
            System.Windows.Forms.ToolStripItem bt = this.toolBar1.Items[opcion];
            this.toolBar1_ButtonClick(this.toolBar1, new ToolStripItemClickedEventArgs(bt));
		}
        private void New_Dato()
        {
            Conec.CadenaSelect = "INSERT INTO " + Conec.NombreTabla + " (numemp,numero,nombre) VALUES ( " + Global.nempresa + "," + Convert.ToInt32(this.numero.Text) + ",'" + this.nombre.Text + "')";
            try
            {
                if (numero.Text != "" && numero.Text != "0")
                {
                    db.ExcetuteQuery(Conec.CadenaSelect);
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
                Conec.dbDataSet.RejectChanges();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Conec.dbDataSet.RejectChanges();
            }
        }
		private void Del_Dato()
		{
			if (numero.Text != "")
			{
				Conec.Condicion = "( numero = " + Convert.ToInt32(this.numero.Text) +" and numemp = " +Global.nempresa + ")";
				Conec.CadenaSelect = "DELETE * FROM "+Conec.NombreTabla+" WHERE " + Conec.Condicion;
				
				if (Conec.dbDataSet.Tables[Conec.NombreTabla].Rows.Count > 0)
				{
					DataRow[] dr =  Conec.dbDataSet.Tables[Conec.NombreTabla].Select("numero = " + Convert.ToInt32(this.numero.Text) );  
					if (dr.Length > 0)
					{
						dr[0].Delete();

						DataSet DSChanges = Conec.dbDataSet.GetChanges(DataRowState.Deleted);

						if (DSChanges != null)
						{
							try
							{
                                db.ExcetuteQuery(Conec.CadenaSelect);
                                Conec.dbDataSet.AcceptChanges();
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
								Conec.dbDataSet.RejectChanges();
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
            Conec.Condicion = "(numero = " + Convert.ToInt32(this.numero.Text) + " and numemp = " + Global.nempresa + ")";
            Conec.CadenaSelect = "UPDATE " + Conec.NombreTabla + " SET nombre = '" + this.nombre.Text + "' WHERE " + Conec.Condicion;
            try
            {
                db.ExcetuteQuery(Conec.CadenaSelect);
            }
            catch (DBConcurrencyException dbcx)
            {
                string customErrorMessage;
                customErrorMessage = dbcx.Message.ToString();
                customErrorMessage += dbcx.Row[0].ToString();
                MessageBox.Show(customErrorMessage.ToString());
                Conec.dbDataSet.RejectChanges();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Conec.dbDataSet.RejectChanges();
            }
        }
		private bool Find_Numero(string codigo)
		{
			bool encontro=false;
            cmRegister.Position = 0;
			
			DataRow[] dr =Conec.dbDataSet.Tables[Conec.NombreTabla].Select("numero = "+Convert.ToInt32(codigo));
			if (dr.Length > 0)
			{
				encontro = true;
				cmRegister.Position = Conec.buscar_posicion(Convert.ToInt32(codigo),"numero");
			}
			return encontro;
		}
		private bool Find_Nombre(string codigo)
		{
			bool encontro=false;
			cmRegister.Position = 0;
			int len = codigo.Length;
			DataRow[] dr =Conec.dbDataSet.Tables[Conec.NombreTabla].Select("SUBSTRING(nombre,1," + len+ ") = '"+codigo+"'");
			if (dr.Length > 0)
			{
				encontro = true;
				cmRegister.Position = Conec.buscar_posicion(Convert.ToInt32(dr[0]["numero"]),"numero");
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
		private void Mostrar_Datos(int pos,int op)
		{	

			if (Conec.dbDataSet.Tables[Conec.NombreTabla].Rows.Count > 0 && pos >= 0)
			{
				DataRow dr=Conec.dbDataSet.Tables[Conec.NombreTabla].Rows[pos];
				numero.Text = dr["numero"].ToString();
				nombre.Text = dr["nombre"].ToString();
				if (op == 0)numero.Focus();
				else nombre.Focus();
				this.editar_dato=false;
			}
		}
		private void limpiar()
		{
			this.nombre.Text = "";
			this.editar_dato=false;
		}
        #endregion

        #region EVENTS
        private void editar_TextChanged(object sender, System.EventArgs e)
        {
            this.editar_dato = true;
        }
        private void WVENDOR_Close(object sender, CancelEventArgs e)
        {
            //Conec.Desconectar();			
            this.Close();

        }
        private void nombre_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.comando(1);
            }
        }
        private void numero_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert) { this.comando(0); }
            if (e.KeyCode == Keys.Left) { this.comando(5); }
            if (e.KeyCode == Keys.Right) { this.comando(6); }
            if (e.KeyCode == Keys.Escape) { this.comando(4); }
            if (e.KeyCode == Keys.Enter)
            {
                this.nombre.Focus();
            }
        }
        private void numero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.numero.Text == "")
            {
                IDataReader LP = db.getDataReader("SELECT numero FROM " + Conec.NombreTabla + " WHERE (numemp = " + Global.nempresa + ") ORDER BY numero desc");
                if (LP.Read()) { this.numero.Text = Convert.ToString(Convert.ToInt32(LP.GetValue(0)) + 1); }
                else { this.numero.Text = "1"; }
                LP.Close();
                this.numero.Focus();
            }
        }
        private void numero_LostFocus(object sender, System.EventArgs e)
        {
            if (this.numero.Text != "" && this.numero.Text != "0")
            {
                if (this.Find_Numero(this.numero.Text))
                {
                    Mostrar_Datos(this.cmRegister.Position, 1);
                }
            }
        }
        private void nombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.nombre.Text == "")
            {
                MessageBox.Show(Global.M_Error[90, Global.idioma].ToString());
                this.nombre.Focus();
            }
        }
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            int cod = 0;

            switch (this.toolBar1.Items.IndexOf(e.ClickedItem))
            {
                case 0:   // Nuevo vendedor
                    {
                        limpiar();
                        //this.cerrar=false;
                        IDataReader LP = db.getDataReader("SELECT numero FROM " + Conec.NombreTabla + " WHERE (numemp = " + Global.nempresa + ") ORDER BY numero desc");
                        if (LP.Read()) { cod = Convert.ToInt32(LP.GetValue(0)); }
                        LP.Close();
                        this.numero.Text = Convert.ToString(cod + 1);
                        this.editar_dato = false;
                        this.numero.Focus();
                    } break;
                case 1: // Guardar Vendedor
                    {
                        if (this.numero.Text == "" || this.numero.Text == "0")
                        {
                            MessageBox.Show(Global.M_Error[89, Global.idioma].ToString());
                            this.numero.Focus();
                            break;
                        }
                        if (this.nombre.Text == "")
                        {
                            MessageBox.Show(Global.M_Error[90, Global.idioma].ToString());
                            this.nombre.Focus();
                            break;
                        }
                        if (Convert.ToInt32(this.numero.Text) > 5 && !Keylock.IsPresent())
                        {
                            MessageBox.Show(Global.M_Error[147, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            this.editar_dato = false;
                            IDataReader df = db.getDataReader("SELECT numemp,numero FROM " + Conec.NombreTabla + " WHERE numemp = " + Global.nempresa + " and numero = " + Convert.ToInt32(this.numero.Text));
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
                    } break;
                case 2:  // Borrar Vendedor
                    {
                        DialogResult df = MessageBox.Show(Global.M_Error[100, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (df == DialogResult.Yes) { Del_Dato(); }
                    } break;
                case 3:  // Cancelar
                    if (this.Find_Numero(this.numero.Text))
                    {
                        Mostrar_Datos(this.cmRegister.Position, 0);
                    }
                    else
                    {
                        cod = Conec.dbDataSet.Tables[Conec.NombreTabla].Rows.Count;

                        if (cod != 0) this.numero.Text = Convert.ToString(Convert.ToInt32(Conec.dbDataSet.Tables[Conec.NombreTabla].Rows[cod - 1]["numero"].ToString()) + 1);
                        else this.numero.Text = Convert.ToString(Conec.dbDataSet.Tables[Conec.NombreTabla].Rows.Count + 1);

                        this.numero.Focus();
                        limpiar();
                    }
                    Conec.Cancel();
                    break;
                case 4: // Reg. Anterior
                    if (this.editar_dato)
                    {
                        if (MessageBox.Show(Global.M_Error[303, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.comando(1);
                        }
                        else Mostrar_Datos(Conec.Previous(ref cmRegister), 0);
                    }
                    else Mostrar_Datos(Conec.Previous(ref cmRegister), 0);
                    break;
                case 5:  // Reg. Siguiente
                    if (this.editar_dato)
                    {
                        if (MessageBox.Show(Global.M_Error[303, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.comando(1);
                        }
                        else Mostrar_Datos(Conec.Next(ref cmRegister), 0);
                    }
                    else Mostrar_Datos(Conec.Next(ref cmRegister), 0);
                    break;
                case 6:
                    {
                        if (this.editar_dato)
                        {
                            if (MessageBox.Show(Global.M_Error[303, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //this.cerrar=true;
                                this.comando(1);
                            }
                            else this.Close();
                        }
                        else this.Close();
                    } break;
            }
        }
        #endregion
    }			
}

