using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;


namespace TRUCK
{
    public class Inventario : Form1
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
		private System.Windows.Forms.ContextMenu MenuBotton1 = new System.Windows.Forms.ContextMenu();
		public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox nombre;
		private System.Windows.Forms.Label label4;
		public MaskedTextBox.MaskedTextBox numero;
        private MaskedTextBox.MaskedTextBox on_hand;
        private DataGridView Grid_Inventario;
        public MaskedTextBox.MaskedTextBox familia;
        private Label label3;
		private bool cerrar=false;
        #endregion
        #region CONSTRUCTOR
        public Inventario(int x, int y)
		{
            db = new DataAccesQuery();
			InitializeComponent();
			this.Location = new System.Drawing.Point(x,y);
			this.TransparencyKey = Color.Empty;
            this.toolStripButton1.Enabled = false;
			this.Tag = Global.M_Error[141,Global.idioma].ToString();
            this.Grid_Inventario.CellClick+=new DataGridViewCellEventHandler(Grid_Inventario_CellClick);
            this.numero.LostFocus+=new System.EventHandler(this.numero_LostFocus);
			this.numero.Validating+=new System.ComponentModel.CancelEventHandler(this.numero_Validating);
			this.numero.KeyDown+=new System.Windows.Forms.KeyEventHandler(this.numero_KeyDown);
			this.numero.TextChanged+=new System.EventHandler(this.editar_TextChanged);
			this.nombre.Validating+=new System.ComponentModel.CancelEventHandler(this.nombre_Validating);
			this.nombre.KeyDown+=new System.Windows.Forms.KeyEventHandler(this.nombre_KeyDown);
            this.nombre.TextChanged+=new System.EventHandler(this.editar_TextChanged);
			this.on_hand.KeyDown+=new KeyEventHandler(this.on_hand_KeyDown);
            this.on_hand.Validating+=new CancelEventHandler(on_hand_Validating);
			this.toolBar1.ItemClicked += new ToolStripItemClickedEventHandler(this.toolBar1_ButtonClick);
            dt=db.getData("SELECT * FROM articulos WHERE (numemp = " + Global.nempresa + ")");
            dt.Tables[0].TableName = "articulos";
            this.Grid_Inventario.AutoGenerateColumns = false;
            this.Grid_Inventario.DataSource = dt;
            this.Grid_Inventario.DataMember = "articulos";

            Grid_Existencia();

			cmRegister = (CurrencyManager)this.BindingContext[dt.Tables[0].TableName];
			cmRegister.Position = 0;

            if (cmRegister.Count <= 0)
            {
                MessageBox.Show(Global.M_Error[2, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else this.Mostrar_Datos(cmRegister.Position, 0);
		}
        #endregion
        #region FUNCTIONS
        private void Grid_Existencia()
        {
            try
            {
                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.Width = 100;
                col1.DefaultCellStyle.NullValue = "";
                col1.DataPropertyName = "familia";
                col1.MaxInputLength = 5;
              
                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.Width = 100;
                col2.DefaultCellStyle.NullValue="";
                col2.DataPropertyName = "numero";
                col2.MaxInputLength = 5;

                DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                col3.Width = 300;
                col3.DefaultCellStyle.NullValue="";
                col3.DataPropertyName = "descripcion";
                col3.MaxInputLength = 50;

                DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                col4.Width = 200;
                col4.DefaultCellStyle.NullValue="";
                col4.DataPropertyName = "existencia";
                col4.MaxInputLength = 6;

                col1.HeaderText = Global.M_Error[218, Global.idioma].ToString();
                col2.HeaderText = Global.M_Error[136, Global.idioma].ToString();
                col3.HeaderText = Global.M_Error[216, Global.idioma].ToString();
                col4.HeaderText = Global.M_Error[284, Global.idioma].ToString();
                                
                this.Grid_Inventario.Columns.Add(col1);
                this.Grid_Inventario.Columns.Add(col2);
                this.Grid_Inventario.Columns.Add(col3);
                this.Grid_Inventario.Columns.Add(col4);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void comando(int opcion)
        {
            System.Windows.Forms.ToolStripItem bt = this.toolBar1.Items[opcion];
            this.toolBar1_ButtonClick(this.toolBar1, new ToolStripItemClickedEventArgs(bt));
        }
		private void editar_TextChanged(object sender, System.EventArgs e)
		{
			this.editar_dato=true;
		}
        private void New_Agent()
		{  	
            DataRow dr = dt.Tables[0].NewRow();

			if (this.numero.Text != "" && this.numero.Text != "0")
			{
				dr.BeginEdit();
				dr["numemp"] = Global.nempresa;
				dr["numero"]= Convert.ToInt32(this.numero.Text);
				dr["descripcion"]= this.nombre.Text;
				dr["existencia"]=this.on_hand.Text;
				dr.EndEdit();			
				dt.Tables[0].Rows.Add(dr);
				DataSet DSChanges = dt.GetChanges(DataRowState.Added);
				if (DSChanges != null)
				{
					try
					{
                        db.ExcetuteQuery("INSERT INTO articulos (numemp,familia,descripcion,existencia) VALUES ( " + Global.nempresa + "," + Convert.ToInt32(this.numero.Text) + ",'" + this.nombre.Text + "'," + Convert.ToInt32(this.on_hand.Text) + ")");
						cmRegister.Position++;
						Mostrar_Datos(cmRegister.Position,0);
					}
					catch (Exception ex)
					{				
						MessageBox.Show(ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
					}					
				}
			}
			else
			{
				MessageBox.Show(Global.M_Error[89,Global.idioma].ToString());
			}
		}
		private void Del_Agent()
		{
			if (numero.Text != "")
			{
				if (dt.Tables[0].Rows.Count > 0)
				{
					DataRow[] dr =  dt.Tables[0].Select("numero = " + Convert.ToInt32(this.numero.Text) );  //.Rows[cmAgente.Position];
					if (dr.Length > 0)
					{
						dr[0].Delete();

						DataSet DSChanges = dt.GetChanges(DataRowState.Deleted);

						if (DSChanges != null)
						{
							try
							{
                                db.ExcetuteQuery("DELETE * FROM articulos WHERE ( numero = " + Convert.ToInt32(this.numero.Text) + " and numemp = " + Global.nempresa + ")");
								MessageBox.Show(Global.M_Error[3,Global.idioma].ToString());
							}
							catch (DBConcurrencyException ex)
							{
								string customErrorMessage;

								customErrorMessage = ex.Message.ToString();
								customErrorMessage += ex.Row[0].ToString();
								MessageBox.Show(customErrorMessage.ToString());
										
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
        private void Save_Agent()
        {
            DataRow dr = dt.Tables[0].Rows.Find(Convert.ToInt32(this.numero.Text));
            dr.BeginEdit();
            dr["descripcion"] = this.nombre.Text;
            dr["existencia"] = this.on_hand.Text;
            dr.EndEdit();
            DataSet DSChanges = dt.GetChanges(DataRowState.Modified);

            if (DSChanges != null || dr.RowState == DataRowState.Added)
            {
                try
                {
                    db.ExcetuteQuery("UPDATE articulos SET descripcion = '" + this.nombre.Text + "', existencia = '" + this.on_hand.Text + "' WHERE (numero = " + Convert.ToInt32(numero.Text) + " and numemp = " + Global.nempresa + ")");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Mostrar_Datos(cmRegister.Position, 0);
            }
        }
		private bool Find_Numero(string codigo)
		{
			bool encontro=false;
            cmRegister.Position = 0;
			
			DataRow[] dr =dt.Tables[0].Select("numero = "+Convert.ToInt16(codigo));

            if (dr.Length > 0)
			{
				encontro = true;
				cmRegister.Position = buscar_posicion(Convert.ToInt16(codigo),"numero");
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
				cmRegister.Position = buscar_posicion(Convert.ToInt16(dr[0]["numero"]),"numero");
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
            if (pos >= 0)
            {
                if (dt.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dt.Tables[0].Rows[pos];
                    familia.Text = dr["familia"].ToString();
                    numero.Text = dr["numero"].ToString();
                    nombre.Text = dr["descripcion"].ToString();
                    on_hand.Text = dr["existencia"].ToString();
                    nombre.Focus();
                    this.editar_dato = false;
                }
            }
		}
		private void limpiar()
		{
			this.nombre.Text = "";
			this.on_hand.Text="";
            this.editar_dato=false;
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
        private void nivel_agent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.comando(1);
            }
        }
        private void Grid_Inventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmRegister.Position = e.RowIndex;
            this.Mostrar_Datos(e.RowIndex, 0);
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
                else this.on_hand.Focus();
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
        private void on_hand_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.comando(1);
            }
        }
        private void on_hand_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.on_hand.Text == "" || this.on_hand.Text == null)
            {
                this.on_hand.Text = "0";
                this.Focus();
            }
        }
        private void numero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.numero.Text == "")
            {
                int cod = dt.Tables[0].Rows.Count;
                if (cod != 0) this.numero.Text = Convert.ToString(Convert.ToInt16(dt.Tables[0].Rows[cod - 1]["numero"].ToString()) + 1);
                else this.numero.Text = Convert.ToString(dt.Tables[0].Rows.Count + 1);
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
            int cod;
            switch (this.toolBar1.Items.IndexOf(e.ClickedItem))
            {
                case 0:   // Nuevo Producto
                    {
                        limpiar();
                        this.cerrar = false;
                        cod = dt.Tables[0].Rows.Count;

                        if (cod != 0) this.numero.Text = Convert.ToString(Convert.ToInt16(dt.Tables[0].Rows[cod - 1]["numero"].ToString()) + 1);
                        else this.numero.Text = Convert.ToString(dt.Tables[0].Rows.Count + 1);

                        this.editar_dato = false;
                        this.numero.Focus();
                    } break;
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
                        this.editar_dato = false;
                        DataRow DB = dt.Tables[0].Rows.Find(Convert.ToInt16(this.numero.Text));
                        if (DB == null)
                        {
                            New_Agent();
                            if (cerrar) this.comando(6);
                            else this.comando(0);
                        }
                        else
                        {
                            Save_Agent();
                            if (cerrar) this.comando(6);
                            else this.comando(5);
                        }
                    } break;
                case 2:  // Borrar Vendedor
                    {
                        DialogResult df = MessageBox.Show(Global.M_Error[100, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (df == DialogResult.Yes) { Del_Agent(); }
                    } break;
                case 3:  // Cancelar
                    if (this.Find_Numero(numero.Text))
                    {
                        Mostrar_Datos(this.cmRegister.Position, 0);
                    }
                    else
                    {
                        cod = dt.Tables[0].Rows.Count;
                        if (cod < 100)
                        {
                            if (cod != 0) numero.Text = Convert.ToString(Convert.ToInt16(dt.Tables[0].Rows[cod - 1]["numero"].ToString()) + 1);
                            else numero.Text = Convert.ToString(dt.Tables[0].Rows.Count + 1);
                        }
                        this.numero.Focus();
                        limpiar();
                    }
                   
                    break;
                case 4: // Reg. Anterior
                    if (this.editar_dato)
                    {
                        if (MessageBox.Show(Global.M_Error[303, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.comando(1);
                        }
                        else Mostrar_Datos(Previous(ref cmRegister), 0);
                    }
                    else Mostrar_Datos(Previous(ref cmRegister), 0);
                    break;
                case 5:  // Reg. Siguiente
                    if (this.editar_dato)
                    {
                        if (MessageBox.Show(Global.M_Error[303, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.comando(1);
                        }
                        else Mostrar_Datos(Next(ref cmRegister), 0);
                    }
                    else Mostrar_Datos(Next(ref cmRegister), 0);
                    break;
                case 6:
                    {
                        if (this.editar_dato)
                        {
                            if (MessageBox.Show(Global.M_Error[303, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                this.cerrar = true;
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
        private void WAGENT_Close(object sender, CancelEventArgs e)
        {
            //Conec.Desconectar();			
            this.Close();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.familia = new MaskedTextBox.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.on_hand = new MaskedTextBox.MaskedTextBox();
            this.numero = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Grid_Inventario = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Inventario)).BeginInit();
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
            this.panel1.Controls.Add(this.familia);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.on_hand);
            this.panel1.Controls.Add(this.numero);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.nombre);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            this.toolTip1.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // familia
            // 
            this.familia.AccessibleDescription = null;
            this.familia.AccessibleName = null;
            resources.ApplyResources(this.familia, "familia");
            this.familia.BackColor = System.Drawing.Color.Yellow;
            this.familia.BackgroundImage = null;
            this.familia.DateOnly = false;
            this.familia.DecimalOnly = false;
            this.familia.DigitOnly = true;
            this.familia.Font = null;
            this.familia.IPAddrOnly = false;
            this.familia.Name = "familia";
            this.familia.PhoneWithAreaCode = false;
            this.familia.ReadOnly = true;
            this.familia.SSNOnly = false;
            this.toolTip1.SetToolTip(this.familia, resources.GetString("familia.ToolTip"));
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
            // on_hand
            // 
            this.on_hand.AccessibleDescription = null;
            this.on_hand.AccessibleName = null;
            resources.ApplyResources(this.on_hand, "on_hand");
            this.on_hand.BackgroundImage = null;
            this.on_hand.DateOnly = false;
            this.on_hand.DecimalOnly = false;
            this.on_hand.DigitOnly = true;
            this.on_hand.Font = null;
            this.on_hand.IPAddrOnly = false;
            this.on_hand.Name = "on_hand";
            this.on_hand.PhoneWithAreaCode = false;
            this.on_hand.SSNOnly = false;
            this.toolTip1.SetToolTip(this.on_hand, resources.GetString("on_hand.ToolTip"));
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
            this.numero.ReadOnly = true;
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
            // Grid_Inventario
            // 
            this.Grid_Inventario.AccessibleDescription = null;
            this.Grid_Inventario.AccessibleName = null;
            this.Grid_Inventario.AllowUserToAddRows = false;
            this.Grid_Inventario.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.Grid_Inventario, "Grid_Inventario");
            this.Grid_Inventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Inventario.BackgroundImage = null;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Inventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Inventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Inventario.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_Inventario.Font = null;
            this.Grid_Inventario.MultiSelect = false;
            this.Grid_Inventario.Name = "Grid_Inventario";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Inventario.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grid_Inventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.toolTip1.SetToolTip(this.Grid_Inventario, resources.GetString("Grid_Inventario.ToolTip"));
            // 
            // Inventario
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.Grid_Inventario);
            this.Controls.Add(this.panel1);
            this.Font = null;
            this.Icon = null;
            this.Name = "Inventario";
            this.Tag = "";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.TopMost = false;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.Grid_Inventario, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Inventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

