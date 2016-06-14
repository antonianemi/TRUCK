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
	public class WPRODUCTO : Form1
    {
        #region VARIABLES
        private DataAccesQuery db;
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
		private System.Windows.Forms.ContextMenu MenuBotton1 = new System.Windows.Forms.ContextMenu();
		public System.Windows.Forms.TextBox textBox1;
		public System.Windows.Forms.TextBox nombre;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		public  MaskedTextBox.MaskedTextBox numero;
		private MaskedTextBox.MaskedTextBox familia;
		private MaskedTextBox.MaskedTextBox tarifa;
        private Label txt_familia;
        #endregion
        #region CONSTRUCTORS
        public WPRODUCTO(int x, int y, int ventana)
        {
            db = new DataAccesQuery();
            InitializeComponent();
            if (Global.aplicacion == 0) this.Text = Global.M_Error[179, Global.idioma].ToString();
            else this.Text = Global.M_Error[178, Global.idioma].ToString();
            this.Location = new System.Drawing.Point(x, y);
            this.TransparencyKey = Color.Empty;
            this.Tag = Global.M_Error[141, Global.idioma].ToString();
            this.numero.LostFocus += new System.EventHandler(this.numero_LostFocus);
            this.numero.Validating += new System.ComponentModel.CancelEventHandler(this.numero_Validating);
            this.numero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numero_KeyDown);
            this.numero.TextChanged += new System.EventHandler(this.editar_TextChanged);
            this.nombre.Validating += new System.ComponentModel.CancelEventHandler(this.nombre_Validating);
            this.nombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nombre_KeyDown);
            this.nombre.TextChanged += new System.EventHandler(this.editar_TextChanged);
            if (Global.aplicacion != 0)
            {
                this.familia.Visible = true;
                this.label4.Visible = true;
                this.txt_familia.Visible = true;
                this.familia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.familia_KeyDown);
                this.familia.Validating += new CancelEventHandler(familia_Validating);
            }
            else
            {
                this.tarifa.Visible = true;
                this.label3.Visible = true;
                this.tarifa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tarifa_KeyDown);
                this.tarifa.Validating += new System.ComponentModel.CancelEventHandler(this.tarifa_Validating);
            }
            this.toolBar1.ItemClicked += new ToolStripItemClickedEventHandler(this.toolBar1_ButtonClick);
            dt = db.getData("SELECT * FROM articulos WHERE (numemp = " + Global.nempresa + " ORDER BY numero)");
            dt.Tables[0].TableName = "articulos";
            cmRegister = (CurrencyManager)this.BindingContext[dt, "articulos"];
            cmRegister.Position = 0;
            dt.Tables[0].PrimaryKey = new DataColumn[] { dt.Tables[0].Columns["numero"] };          
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WPRODUCTO));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_familia = new System.Windows.Forms.Label();
            this.tarifa = new MaskedTextBox.MaskedTextBox();
            this.familia = new MaskedTextBox.MaskedTextBox();
            this.numero = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImage = null;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txt_familia);
            this.panel1.Controls.Add(this.tarifa);
            this.panel1.Controls.Add(this.familia);
            this.panel1.Controls.Add(this.numero);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.nombre);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            this.toolTip1.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // txt_familia
            // 
            this.txt_familia.AccessibleDescription = null;
            this.txt_familia.AccessibleName = null;
            resources.ApplyResources(this.txt_familia, "txt_familia");
            this.txt_familia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txt_familia.Font = null;
            this.txt_familia.Name = "txt_familia";
            this.toolTip1.SetToolTip(this.txt_familia, resources.GetString("txt_familia.ToolTip"));
            // 
            // tarifa
            // 
            this.tarifa.AccessibleDescription = null;
            this.tarifa.AccessibleName = null;
            resources.ApplyResources(this.tarifa, "tarifa");
            this.tarifa.BackgroundImage = null;
            this.tarifa.DateOnly = false;
            this.tarifa.DecimalOnly = true;
            this.tarifa.DigitOnly = false;
            this.tarifa.Font = null;
            this.tarifa.IPAddrOnly = false;
            this.tarifa.Name = "tarifa";
            this.tarifa.PhoneWithAreaCode = false;
            this.tarifa.SSNOnly = false;
            this.toolTip1.SetToolTip(this.tarifa, resources.GetString("tarifa.ToolTip"));
            // 
            // familia
            // 
            this.familia.AccessibleDescription = null;
            this.familia.AccessibleName = null;
            resources.ApplyResources(this.familia, "familia");
            this.familia.BackgroundImage = null;
            this.familia.DateOnly = false;
            this.familia.DecimalOnly = false;
            this.familia.DigitOnly = true;
            this.familia.Font = null;
            this.familia.IPAddrOnly = false;
            this.familia.Name = "familia";
            this.familia.PhoneWithAreaCode = false;
            this.familia.SSNOnly = false;
            this.toolTip1.SetToolTip(this.familia, resources.GetString("familia.ToolTip"));
            // 
            // numero
            // 
            this.numero.AccessibleDescription = null;
            this.numero.AccessibleName = null;
            resources.ApplyResources(this.numero, "numero");
            this.numero.BackColor = System.Drawing.Color.Yellow;
            this.numero.BackgroundImage = null;
            this.numero.DateOnly = false;
            this.numero.DecimalOnly = false;
            this.numero.DigitOnly = true;
            this.numero.Font = null;
            this.numero.IPAddrOnly = false;
            this.numero.Name = "numero";
            this.numero.PhoneWithAreaCode = false;
            this.numero.SSNOnly = false;
            this.toolTip1.SetToolTip(this.numero, resources.GetString("numero.ToolTip"));
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Font = null;
            this.label4.Name = "label4";
            this.toolTip1.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            this.toolTip1.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // textBox1
            // 
            this.textBox1.AccessibleDescription = null;
            this.textBox1.AccessibleName = null;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BackgroundImage = null;
            this.textBox1.Font = null;
            this.textBox1.Name = "textBox1";
            this.toolTip1.SetToolTip(this.textBox1, resources.GetString("textBox1.ToolTip"));
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
            this.toolTip1.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
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
            this.toolTip1.SetToolTip(this.pictureBox2, resources.GetString("pictureBox2.ToolTip"));
            // 
            // nombre
            // 
            this.nombre.AccessibleDescription = null;
            this.nombre.AccessibleName = null;
            resources.ApplyResources(this.nombre, "nombre");
            this.nombre.BackColor = System.Drawing.Color.Yellow;
            this.nombre.BackgroundImage = null;
            this.nombre.Font = null;
            this.nombre.Name = "nombre";
            this.toolTip1.SetToolTip(this.nombre, resources.GetString("nombre.ToolTip"));
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // WPRODUCTO
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.panel1);
            this.Font = null;
            this.Icon = null;
            this.Name = "WPRODUCTO";
            this.Tag = "";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
        private void WPRODUCTO_Close(object sender, CancelEventArgs e)
        {
            //Conec.Desconectar();			
            this.Close();

        }
        private void nombre_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.nombre.Text == "")
                {
                    MessageBox.Show(Global.M_Error[90, Global.idioma].ToString());
                    this.nombre.Focus();
                }
                else this.familia.Focus();
            }
        }
        private void numero_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert) { this.comando(0); }
            if (e.KeyCode == Keys.Left) { this.comando(4); }
            if (e.KeyCode == Keys.Right) { this.comando(5); }
            if (e.KeyCode == Keys.Escape) { this.comando(3); }
            if (e.KeyCode == Keys.Enter)
            {
                this.nombre.Focus();
            }
        }
        private void familia_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tarifa.Focus();
            }
        }
        private void familia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.familia.Text == "" || this.familia.Text == null)
            {
                this.familia.Text = "0";
                this.Focus();
            }
            else
            {

                IDataReader df = db.getDataReader("SELECT familia,descripcion FROM familia WHERE numemp = " + Global.nempresa);

                if (df.Read())
                {
                    if (Convert.ToInt32(this.familia.Text) == df.GetInt32(0))
                    {
                        this.txt_familia.Text = df.GetString(1);
                    }
                }
                else
                {
                    MessageBox.Show(Global.M_Error[86, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txt_familia.Text = "0";
                }
                df.Close();
            }
        }
        private void tarifa_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.tarifa.Text == "" || this.tarifa.Text == null)
            {
                this.tarifa.Text = "0";
                this.Focus();
            }
        }
        private void tarifa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
                //MessageBox.Show(Global.M_Error[90,Global.idioma].ToString());
                this.nombre.Focus();
            }
        }
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            int cod = 0;

            switch (this.toolBar1.Items.IndexOf(e.ClickedItem))
            {
                case 0:   // Nuevo Producto
                    {
                        limpiar();
                        //this.cerrar=false;

                        IDataReader LP = db.getDataReader("SELECT numero FROM " + Conec.NombreTabla + " WHERE (numemp = " + Global.nempresa + ") ORDER BY numero desc");

                        if (LP.Read()) { cod = Convert.ToInt32(LP.GetValue(0)); }

                        LP.Close();

                        this.numero.Text = Convert.ToString(cod + 1);

                        this.editar_dato = false;

                        this.numero.Focus();

                    }

                    break;

                case 1: // Guardar Producto
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
                        if (this.tarifa.Text == "")
                        {
                            this.tarifa.Focus();
                            break;
                        }
                        if (Convert.ToInt32(this.numero.Text) > 5 && !Keylock.IsPresent())
                        {
                            MessageBox.Show(Global.M_Error[147, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            this.editar_dato = false;
                            IDataReader df = db.getDataReader("SELECT numemp, NUMERO FROM Articulos WHERE numemp = " + Global.nempresa + " and NUMERO = " + Convert.ToInt32(this.numero.Text));

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
                    }
                    break;

                case 2:  // Borrar Vendedor
                    {
                        DialogResult df = MessageBox.Show(Global.M_Error[100, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (df == DialogResult.Yes) { Del_Dato(); }
                    }
                    break;

                case 3:  // Cancelar
                    if (this.Find_Numero(numero.Text))
                    {
                        Mostrar_Datos(this.cmRegister.Position, 0);
                    }
                    else
                    {
                        cod = dt.Tables[Conec.NombreTabla].Rows.Count;
                        if (cod < 100)
                        {
                            if (cod != 0) numero.Text = Convert.ToString(Convert.ToInt32(dt.Tables[Conec.NombreTabla].Rows[cod - 1]["numero"].ToString()) + 1);
                            else numero.Text = Convert.ToString(dt.Tables[Conec.NombreTabla].Rows.Count + 1);
                        }
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
                                // this.cerrar = true;
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
                    } break;
            }
        }
        #endregion
        #region FUNCTIOS
        public void comando(int opcion)
        {
            System.Windows.Forms.ToolStripItem bt = this.toolBar1.Items[opcion];
            this.toolBar1_ButtonClick(this.toolBar1, new ToolStripItemClickedEventArgs(bt));
        }
		private void editar_TextChanged(object sender, System.EventArgs e)
		{
			this.editar_dato=true;           
		}		
        private void New_Dato()
		{
            string query = "";

			query= "INSERT INTO articulos (numemp,numero,descripcion,tarifa,familia) VALUES ( " + Global.nempresa + "," + Convert.ToInt32(this.numero.Text) + ",'" + this.nombre.Text + "'," + Convert.ToDecimal(this.tarifa.Text) + "," + Convert.ToInt32(this.familia.Text) + ")";

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
                dt.RejectChanges();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt.RejectChanges();
            }		
		}
		private void Del_Dato()
		{
            string query = "";
			if (numero.Text != "")
			{
                query = "DELETE * FROM articulos WHERE ( numero = " + Convert.ToInt32(this.numero.Text) + " and numemp = " + Global.nempresa + ")";
				if (dt.Tables[0].Rows.Count > 0)
				{
					DataRow[] dr = dt.Tables[0].Select("numero = " + Convert.ToInt32(this.numero.Text) );  //.Rows[cmAgente.Position];

                    if (dr.Length > 0)
                    {
                        dr[0].Delete();

						DataSet DSChanges = dt.GetChanges(DataRowState.Deleted);

						if (DSChanges != null)
						{
							try
							{
                                dt.AcceptChanges();
                                db.ExcetuteQuery(query);
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

            string query = "";
            try
            {          
                query = "UPDATE    SET descripcion = '" + this.nombre.Text + "'," +
                    "tarifa = " + Convert.ToDecimal(this.tarifa.Text) + ", familia = " + Convert.ToInt32(this.familia.Text) + " WHERE (numero = " + Convert.ToInt32(numero.Text) + " and numemp = " + Global.nempresa + ")";
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
			
			DataRow[] dr = dt.Tables[0].Select("numero = "+Convert.ToInt32(codigo));
			if (dr.Length > 0)
			{
				encontro = true;
				cmRegister.Position = buscar_posicion(Convert.ToInt32(codigo),"numero");
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
				cmRegister.Position = buscar_posicion(Convert.ToInt32(dr[0]["numero"]),"numero");
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
			if (dt.Tables[0].Rows.Count > 0 && pos >= 0)
			{
				DataRow dr=dt.Tables[0].Rows[pos];
				numero.Text = dr["numero"].ToString();
				nombre.Text = dr["descripcion"].ToString();
				tarifa.Text = dr["tarifa"].ToString();
				familia.Text = dr["familia"].ToString();
                IDataReader df = db.getDataReader("SELECT familia,descripcion FROM familia WHERE numemp = " + Global.nempresa);
                
                if (df.Read()) if (Convert.ToInt32(this.familia.Text) == df.GetInt32(0)) this.txt_familia.Text = df.GetString(1);
                else this.txt_familia.Text = "";
                df.Close();
				nombre.Focus();
				this.editar_dato=false;
			}
		}		
		private void limpiar()
		{
     		this.nombre.Text = "";
			this.familia.Text="0";
			this.tarifa.Text="0";
			this.editar_dato=false;
            this.nombre.Focus();
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

