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
	/// Descripción breve de OpenWindows.
	/// </summary>
	public class OpenWindows : System.Windows.Forms.Form
    {
        DataSet dt;
        #region VARIABLES
        DataAccesQuery db;
        private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private int x,y;
        private CurrencyManager cmGridRegister;
		private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.ContextMenu MenuBotton1 = new System.Windows.Forms.ContextMenu();
        private string para1, para2, campo1, campo2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Data.DataSet DataSetMaster = new DataSet();
		private string TablaMaestra;
		private System.Windows.Forms.TreeView TreeFile;
		private System.Windows.Forms.Splitter splitter1;
		public System.Windows.Forms.DataGrid DGrid;
		private string Dato;
        private string usuario;
        private int tipo_opcion = 0;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem codigoToolStripMenuItem;
        private ToolStripMenuItem nombreToolStripMenuItem;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton7;
        private ImageList imageList1;
        private ToolStrip toolMaster;
        private ToolStripButton toolStripButton8;
		public static bool activo=false;
        #endregion
        #region CONSTRUCTOR
        public OpenWindows()
        { 
            db = new DataAccesQuery();
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();
			y = this.Size.Height / 8;
			x = this.Size.Width / 8;
			this.TransparencyKey = Color.Empty;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

			this.DGrid.Click+=new System.EventHandler(this.DGrid_Click);
			this.DGrid.CurrentCellChanged+=new System.EventHandler(this.DGrid_CurrentCell);
            this.TreeFile.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeFile_AfterSelect);

            Global.aplicacion = 2;

            switch (Global.aplicacion)
            {
                case 0://PUBLICO
                    {
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[137, Global.idioma].ToString(), 0, 0));  // Empresa 
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[146, Global.idioma].ToString(), 1, 1));  // Tarifa
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[140, Global.idioma].ToString(), 4, 4));  // Cliente
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[143, Global.idioma].ToUpper(), 0, 0));   // Vehiculo Tara o tara manual
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[142, Global.idioma].ToString(), 6, 6));  // Usuario
                    }
                    break;

                case 1://PRIVADO
                    {
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[137, Global.idioma].ToString(), 0, 0));  // Empresa 
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[138, Global.idioma].ToString(), 1, 1));  // Producto
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[139, Global.idioma].ToString(), 2, 2));  // Proveedor
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[140, Global.idioma].ToString(), 3, 3));  // Cliente
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[141, Global.idioma].ToString(), 4, 4));  // Transportista
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[143, Global.idioma].ToString(), 5, 5));  // Vehiculo Tara
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[218, Global.idioma].ToUpper(), 0, 0));   // Familia
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[142, Global.idioma].ToString(), 6, 6));  // Usuario
                    }
                break;

                case 2://PRIVADO
                    {
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[137, Global.idioma].ToString(), 0, 0));  // Empresa 
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[138, Global.idioma].ToString(), 1, 1));  // Producto
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[139, Global.idioma].ToString(), 2, 2));  // Proveedor
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[140, Global.idioma].ToString(), 3, 3));  // Cliente
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[218, Global.idioma].ToUpper(), 0, 0));   // Familia
                        this.TreeFile.Nodes.Add(new TreeNode(Global.M_Error[142, Global.idioma].ToString(), 6, 6));  // Usuario
                    }
                break;

            }
                        			
            this.codigoToolStripMenuItem.Click +=new EventHandler(codigoToolStripMenuItem_Click);
            this.nombreToolStripMenuItem.Click +=new EventHandler(nombreToolStripMenuItem_Click);   
            IDataReader usua = db.getDataReader("SELECT user FROM Usuarios");
            if (usua.Read()) this.usuario = usua.GetString(0);
            else this.usuario = "Sistemas";
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenWindows));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.TreeFile = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.DGrid = new System.Windows.Forms.DataGrid();
            this.toolMaster = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.codigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.toolMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            resources.ApplyResources(this.mainMenu1, "mainMenu1");
            // 
            // menuItem1
            // 
            resources.ApplyResources(this.menuItem1, "menuItem1");
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem7,
            this.menuItem5,
            this.menuItem10,
            this.menuItem11,
            this.menuItem4});
            this.menuItem1.MergeType = System.Windows.Forms.MenuMerge.Replace;
            // 
            // menuItem2
            // 
            resources.ApplyResources(this.menuItem2, "menuItem2");
            this.menuItem2.Index = 0;
            this.menuItem2.Click += new System.EventHandler(this.ADD);
            // 
            // menuItem3
            // 
            resources.ApplyResources(this.menuItem3, "menuItem3");
            this.menuItem3.Index = 1;
            this.menuItem3.Click += new System.EventHandler(this.EDIT);
            // 
            // menuItem7
            // 
            resources.ApplyResources(this.menuItem7, "menuItem7");
            this.menuItem7.Index = 2;
            this.menuItem7.Click += new System.EventHandler(this.DELETE);
            // 
            // menuItem5
            // 
            resources.ApplyResources(this.menuItem5, "menuItem5");
            this.menuItem5.Index = 3;
            // 
            // menuItem10
            // 
            resources.ApplyResources(this.menuItem10, "menuItem10");
            this.menuItem10.Index = 4;
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            resources.ApplyResources(this.menuItem11, "menuItem11");
            this.menuItem11.Index = 5;
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem4
            // 
            resources.ApplyResources(this.menuItem4, "menuItem4");
            this.menuItem4.Index = 6;
            this.menuItem4.Click += new System.EventHandler(this.OpenDepurar);
            // 
            // TreeFile
            // 
            resources.ApplyResources(this.TreeFile, "TreeFile");
            this.TreeFile.ImageList = this.imageList1;
            this.TreeFile.ItemHeight = 16;
            this.TreeFile.Name = "TreeFile";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "archivos2.png");
            this.imageList1.Images.SetKeyName(1, "archivos2.png");
            this.imageList1.Images.SetKeyName(2, "Agent2.png");
            this.imageList1.Images.SetKeyName(3, "Agent2.png");
            this.imageList1.Images.SetKeyName(4, "transport2.png");
            this.imageList1.Images.SetKeyName(5, "transport2.png");
            this.imageList1.Images.SetKeyName(6, "Manager2.png");
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // DGrid
            // 
            resources.ApplyResources(this.DGrid, "DGrid");
            this.DGrid.BackgroundColor = System.Drawing.Color.White;
            this.DGrid.CaptionVisible = false;
            this.DGrid.DataMember = "";
            this.DGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGrid.Name = "DGrid";
            this.DGrid.ReadOnly = true;
            // 
            // toolMaster
            // 
            resources.ApplyResources(this.toolMaster, "toolMaster");
            this.toolMaster.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSplitButton1,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8});
            this.toolMaster.Name = "toolMaster";
            // 
            // toolStripButton1
            //  
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSplitButton1
            // 
            resources.ApplyResources(this.toolStripSplitButton1, "toolStripSplitButton1");
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codigoToolStripMenuItem,
            this.nombreToolStripMenuItem});
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            // 
            // codigoToolStripMenuItem
            // 
            resources.ApplyResources(this.codigoToolStripMenuItem, "codigoToolStripMenuItem");
            this.codigoToolStripMenuItem.Name = "codigoToolStripMenuItem";
            // 
            // nombreToolStripMenuItem
            // 
            resources.ApplyResources(this.nombreToolStripMenuItem, "nombreToolStripMenuItem");
            this.nombreToolStripMenuItem.Name = "nombreToolStripMenuItem";
            // 
            // toolStripButton4
            // 
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click); 
            // 
            // toolStripButton5
            // 
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            resources.ApplyResources(this.toolStripButton6, "toolStripButton6");
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            resources.ApplyResources(this.toolStripButton7, "toolStripButton7");
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton8
            // 
            resources.ApplyResources(this.toolStripButton8, "toolStripButton8");
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // OpenWindows
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.DGrid);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.TreeFile);
            this.Controls.Add(this.toolMaster);
            this.Menu = this.mainMenu1;
            this.Name = "OpenWindows";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.toolMaster.ResumeLayout(false);
            this.toolMaster.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion
        #region Grids
        private void Grid_usuarios()
        {
            #region DESIGN
            activo = false;
            DataGridTableStyle myGridStyle = new DataGridTableStyle();
            myGridStyle.MappingName = "usuarios";
            DataGridTextBoxColumn colStyle1 = new DataGridTextBoxColumn();
            colStyle1.HeaderText = Global.M_Error[207, Global.idioma].ToString();
            colStyle1.Width = 100;
            colStyle1.MappingName = "user";
            DataGridTextBoxColumn colStyle2 = new DataGridTextBoxColumn();
            colStyle2.HeaderText = Global.M_Error[209, Global.idioma].ToString();
            colStyle2.Width = 100;
            colStyle2.MappingName = "iniciales";
            DataGridTextBoxColumn colStyle3 = new DataGridTextBoxColumn();
            colStyle3.HeaderText = Global.M_Error[216, Global.idioma].ToString();
            colStyle3.Width = 200;
            colStyle3.MappingName = "nombre";
            DataGridTextBoxColumn colStyle4 = new DataGridTextBoxColumn();
            colStyle4.HeaderText = Global.M_Error[295, Global.idioma].ToString();
            colStyle4.Width = 200;
            colStyle4.MappingName = "turno";
            myGridStyle.GridColumnStyles.Add(colStyle1);
            myGridStyle.GridColumnStyles.Add(colStyle2);
            myGridStyle.GridColumnStyles.Add(colStyle3);
            myGridStyle.GridColumnStyles.Add(colStyle4);
            para1 = Global.M_Error[207, Global.idioma].ToString();
            para2 = Global.M_Error[209, Global.idioma].ToString();
            campo1 = "user";
            campo2 = "iniciales";

            #endregion
            #region DATA
            this.Dato = "";
            string CadenaSelect_Maestro = "SELECT * FROM usuarios";
            this.TablaMaestra = "usuarios";
            this.DataSetMaster.Clear();
            DataSetMaster = db.getData(CadenaSelect_Maestro);
            this.DGrid.DataSource = this.DataSetMaster;
            this.DataSetMaster.Tables[0].TableName = TablaMaestra;
            if (!this.DGrid.TableStyles.Contains(TablaMaestra)) this.DGrid.TableStyles.Add(myGridStyle);
            this.DGrid.SetDataBinding(this.DataSetMaster, TablaMaestra);
            cmGridRegister = (CurrencyManager)this.BindingContext[this.DataSetMaster, TablaMaestra];
            cmGridRegister.Position = 0;
            #endregion

            if (cmGridRegister.Count > 0)
            {
                for (int i = 0; i < Global.privilegio.Length; i++)
                {
                    if (Global.privilegio.Substring(i, 1) == "1")
                    {
                        if (i == 3)
                        {
                            this.toolMaster.Items[0].Enabled = true;
                            this.toolMaster.Items[1].Enabled = true;
                            this.toolMaster.Items[2].Enabled = true;
                            this.menuItem2.Enabled = true;
                            this.menuItem3.Enabled = true;
                            this.menuItem7.Enabled = true;
                        }
                        if (i == 11)
                        {
                            this.toolMaster.Items[4].Enabled = true;
                            this.menuItem10.Enabled = true;
                        }
                        if (i == 12)
                        {
                            this.toolMaster.Items[5].Enabled = true;
                            this.menuItem11.Enabled = true;
                        }
                        if (i == 13)
                        {
                            this.toolMaster.Items[6].Enabled = true;
                            this.menuItem4.Enabled = true;
                        }
                    }
                    else
                    {
                        if (i == 3)
                        {
                            this.toolMaster.Items[0].Enabled = false;
                            this.toolMaster.Items[1].Enabled = false;
                            this.toolMaster.Items[2].Enabled = false;
                            this.menuItem2.Enabled = false;
                            this.menuItem3.Enabled = false;
                            this.menuItem7.Enabled = false;
                        }
                        if (i == 11)
                        {
                            this.toolMaster.Items[4].Enabled = false;
                            this.menuItem10.Enabled = false;
                        }
                        if (i == 12)
                        {
                            this.toolMaster.Items[5].Enabled = false;
                            this.menuItem11.Enabled = false;
                        }
                        if (i == 13)
                        {
                            this.toolMaster.Items[6].Enabled = false;
                            this.menuItem4.Enabled = false;
                        }
                    }
                }
                this.toolMaster.Items[4].Enabled = false;
                this.toolMaster.Items[5].Enabled = false;
                this.toolMaster.Items[6].Enabled = false;
                this.toolMaster.Items[3].Enabled = false;
                this.menuItem5.Enabled = true;
            }
            else
            {
                if (Global.privilegio.Substring(3, 1) == "1")
                {
                    this.toolMaster.Items[0].Enabled = true;
                    this.toolMaster.Items[4].Enabled = true;
                    this.menuItem10.Enabled = true;
                    this.menuItem2.Enabled = true;
                }
                else
                {
                    this.toolMaster.Items[0].Enabled = false;
                    this.toolMaster.Items[4].Enabled = false;
                    this.menuItem10.Enabled = false;
                    this.menuItem2.Enabled = false;
                }
                this.toolMaster.Items[1].Enabled = false;
                this.toolMaster.Items[2].Enabled = false;
                this.toolMaster.Items[3].Enabled = false;
                this.toolMaster.Items[5].Enabled = false;
                this.toolMaster.Items[6].Enabled = false;
                this.toolMaster.Items[7].Enabled = false;
                this.menuItem3.Enabled = false;
                this.menuItem7.Enabled = false;
                this.menuItem5.Enabled = false;
                this.menuItem11.Enabled = false;
                this.menuItem4.Enabled = false;
            }

        }
        private void Grid_cliente()
        {
            #region DESIGN
            activo = false;
            Global.Conexion = Global.Motor + Global.DATABASE;
            DataGridTableStyle myGridStyle = new DataGridTableStyle();
            myGridStyle.MappingName = "cliente";
            DataGridTextBoxColumn colStyle1 = new DataGridTextBoxColumn();
            colStyle1.HeaderText = Global.M_Error[215, Global.idioma].ToString();
            colStyle1.Width = 60;
            colStyle1.MappingName = "numero";
            DataGridTextBoxColumn colStyle2 = new DataGridTextBoxColumn();
            colStyle2.HeaderText = Global.M_Error[216, Global.idioma].ToString();
            colStyle2.Width = 200;
            colStyle2.MappingName = "nombre";
            DataGridColumnStyle colStyle3 = new DataGridTextBoxColumn();
            colStyle3.HeaderText = Global.M_Error[218, Global.idioma].ToString();
            colStyle3.Width = 70;
            colStyle3.MappingName = "tipo";
            myGridStyle.GridColumnStyles.Add(colStyle1);
            myGridStyle.GridColumnStyles.Add(colStyle2);
            myGridStyle.GridColumnStyles.Add(colStyle3);
            para1 = Global.M_Error[215, Global.idioma].ToString();
            para2 = Global.M_Error[216, Global.idioma].ToString();
            campo1 = "numero";
            campo2 = "nombre";

            #endregion
            #region DATA
            this.Dato = "";
            string CadenaSelect_Maestro = "SELECT * FROM cliente WHERE numemp = " + Global.nempresa + " ORDER BY numero";
            this.TablaMaestra = "cliente";
            this.DataSetMaster.Clear();
            DataSetMaster = db.getData(CadenaSelect_Maestro);
            this.DGrid.DataSource = this.DataSetMaster;
            this.DataSetMaster.Tables[0].TableName = TablaMaestra;
            if (!this.DGrid.TableStyles.Contains(TablaMaestra)) this.DGrid.TableStyles.Add(myGridStyle);
            this.DGrid.SetDataBinding(this.DataSetMaster, TablaMaestra);
            cmGridRegister = (CurrencyManager)this.BindingContext[this.DataSetMaster, TablaMaestra];
            cmGridRegister.Position = 0;
            #endregion

            if (cmGridRegister.Count > 0)
            {
                for (int i = 0; i < Global.privilegio.Length; i++)
                {
                    if (Global.privilegio.Substring(i, 1) == "1")
                    {
                        if (i == 9)
                        {
                            this.toolMaster.Items[0].Enabled = true;
                            this.toolMaster.Items[1].Enabled = true;
                            this.toolMaster.Items[2].Enabled = true;
                            this.menuItem2.Enabled = true;
                            this.menuItem3.Enabled = true;
                            this.menuItem7.Enabled = true;
                        }
                        if (i == 11)
                        {
                            this.toolMaster.Items[4].Enabled = true;
                            this.menuItem10.Enabled = true;
                        }
                        if (i == 12)
                        {
                            this.toolMaster.Items[5].Enabled = true;
                            this.menuItem11.Enabled = true;
                        }
                        if (i == 13)
                        {
                            this.toolMaster.Items[6].Enabled = true;
                            this.menuItem4.Enabled = true;
                        }
                    }
                    else
                    {
                        if (i == 9)
                        {
                            this.toolMaster.Items[0].Enabled = false;
                            this.toolMaster.Items[1].Enabled = false;
                            this.toolMaster.Items[2].Enabled = false;
                            this.menuItem2.Enabled = false;
                            this.menuItem3.Enabled = false;
                            this.menuItem7.Enabled = false;
                        }
                        if (i == 11)
                        {
                            this.toolMaster.Items[4].Enabled = false;
                            this.menuItem10.Enabled = false;
                        }
                        if (i == 12)
                        {
                            this.toolMaster.Items[5].Enabled = false;
                            this.menuItem11.Enabled = false;
                        }
                        if (i == 13)
                        {
                            this.toolMaster.Items[6].Enabled = false;
                            this.menuItem4.Enabled = false;
                        }
                    }
                }
                this.toolMaster.Items[3].Enabled = true;
                this.toolMaster.Items[7].Enabled = true;
                this.menuItem5.Enabled = true;
            }
            else
            {
                if (Global.privilegio.Substring(9, 1) == "1")
                {
                    this.toolMaster.Items[0].Enabled = true;
                    this.toolMaster.Items[4].Enabled = true;
                    this.menuItem10.Enabled = true;
                    this.menuItem2.Enabled = true;
                }
                else
                {
                    this.toolMaster.Items[0].Enabled = false;
                    this.toolMaster.Items[4].Enabled = false;
                    this.menuItem10.Enabled = false;
                    this.menuItem2.Enabled = false;
                }
                this.toolMaster.Items[1].Enabled = false;
                this.toolMaster.Items[2].Enabled = false;
                this.toolMaster.Items[3].Enabled = false;
                this.toolMaster.Items[5].Enabled = false;
                this.toolMaster.Items[6].Enabled = false;
                this.toolMaster.Items[7].Enabled = false;
                this.menuItem3.Enabled = false;
                this.menuItem7.Enabled = false;
                this.menuItem5.Enabled = false;
                this.menuItem11.Enabled = false;
                this.menuItem4.Enabled = false;
            }


        }
        private void Grid_Empresa()
        {
            #region DESIGN
            DataGridTableStyle myGrid2 = new DataGridTableStyle();
            myGrid2.PreferredRowHeight = 20;
            myGrid2.MappingName = "general";
            DataGridTextBoxColumn colStyle1 = new DataGridTextBoxColumn();
            colStyle1.HeaderText = Global.M_Error[208, Global.idioma].ToString();
            colStyle1.Width = 60;
            colStyle1.NullText = "0";
            colStyle1.Format = "####";
            colStyle1.MappingName = "numemp";
            colStyle1.TextBox.MaxLength = 4;
            DataGridTextBoxColumn colStyle2 = new DataGridTextBoxColumn();
            colStyle2.HeaderText = Global.M_Error[293, Global.idioma].ToString();
            colStyle2.Width = 200;
            colStyle2.NullText = "";
            colStyle2.MappingName = "empresa";
            colStyle2.TextBox.MaxLength = 40;
            DataGridTextBoxColumn colStyle3 = new DataGridTextBoxColumn();
            colStyle3.HeaderText = Global.M_Error[219, Global.idioma].ToString();
            colStyle3.Width = 200;
            colStyle3.NullText = "";
            colStyle3.MappingName = "direccion1";
            colStyle3.TextBox.MaxLength = 40;
            DataGridTextBoxColumn colStyle4 = new DataGridTextBoxColumn();
            colStyle4.HeaderText = Global.M_Error[221, Global.idioma].ToString();
            colStyle4.Width = 200;
            colStyle4.NullText = "";
            colStyle4.MappingName = "direccion2";
            colStyle4.TextBox.MaxLength = 40;
            DataGridTextBoxColumn colStyle5 = new DataGridTextBoxColumn();
            colStyle5.HeaderText = Global.M_Error[220, Global.idioma].ToString();
            colStyle5.Width = 200;
            colStyle5.NullText = "";
            colStyle5.MappingName = "direccion3";
            colStyle5.TextBox.MaxLength = 40;
            DataGridTextBoxColumn colStyle6 = new DataGridTextBoxColumn();
            colStyle6.HeaderText = Global.M_Error[187, Global.idioma].ToString();
            colStyle6.Width = 100;
            colStyle6.NullText = "";
            colStyle6.MappingName = "cp";
            colStyle6.TextBox.MaxLength = 40;
            DataGridTextBoxColumn colStyle7 = new DataGridTextBoxColumn();
            colStyle7.HeaderText = Global.M_Error[210, Global.idioma].ToString();
            colStyle7.Width = 100;
            colStyle7.NullText = "";
            colStyle7.MappingName = "telf";
            colStyle7.TextBox.MaxLength = 40;
            myGrid2.GridColumnStyles.Add(colStyle1);
            myGrid2.GridColumnStyles.Add(colStyle2);
            myGrid2.GridColumnStyles.Add(colStyle3);
            myGrid2.GridColumnStyles.Add(colStyle4);
            myGrid2.GridColumnStyles.Add(colStyle5);
            myGrid2.GridColumnStyles.Add(colStyle6);
            myGrid2.GridColumnStyles.Add(colStyle7);
            para1 = Global.M_Error[208, Global.idioma].ToString();
            para2 = Global.M_Error[293, Global.idioma].ToString();
            campo1 = "numemp";
            campo2 = "empresa";
            this.Dato = "";

            #endregion
            #region DATA
            activo = false;
            string CadenaSelect_Maestro = "SELECT numemp,empresa,direccion1,direccion2,folio,direccion3,cp,telf FROM empresa ORDER BY numemp";
            this.TablaMaestra = "general";
            this.DataSetMaster = new DataSet();
            this.DataSetMaster.Clear();
            this.DataSetMaster = db.getData(CadenaSelect_Maestro);
            this.DGrid.DataSource = this.DataSetMaster;
            this.DataSetMaster.Tables[0].TableName = TablaMaestra;
            if (!this.DGrid.TableStyles.Contains(TablaMaestra)) this.DGrid.TableStyles.Add(myGrid2);
            this.DGrid.SetDataBinding(this.DataSetMaster, TablaMaestra);
            cmGridRegister = (CurrencyManager)this.BindingContext[this.DataSetMaster, TablaMaestra];
            cmGridRegister.Position = 0;
            #endregion

            if (cmGridRegister.Count > 0)
            {
                for (int i = 0; i < Global.privilegio.Length; i++)
                {
                    if (Global.privilegio.Substring(i, 1) == "1")
                    {
                        if (i == 4)
                        {
                            this.toolMaster.Items[0].Enabled = true;
                            this.toolMaster.Items[1].Enabled = true;
                            this.toolMaster.Items[2].Enabled = true;
                            this.menuItem2.Enabled = true;
                            this.menuItem7.Enabled = true;
                            this.menuItem3.Enabled = true;
                        }
                        if (i == 23)
                        {
                            this.menuItem4.Enabled = true;
                            this.toolMaster.Items[6].Enabled = true;
                        }
                    }
                    else
                    {
                        if (i == 4)
                        {
                            this.toolMaster.Items[0].Enabled = false;
                            this.toolMaster.Items[1].Enabled = false;
                            this.toolMaster.Items[2].Enabled = false;
                            this.menuItem2.Enabled = false;
                            this.menuItem7.Enabled = false;
                            this.menuItem3.Enabled = false;
                        }
                        if (i == 23)
                        {
                            this.toolMaster.Items[6].Enabled = false;
                            this.menuItem4.Enabled = false;
                        }
                    }
                }
                this.toolMaster.Items[4].Enabled = false;
                this.toolMaster.Items[5].Enabled = false;
                this.toolMaster.Items[6].Enabled = false;
                this.toolMaster.Items[3].Enabled = true;
                this.toolMaster.Items[7].Enabled = true;
                this.menuItem10.Enabled = false;
                this.menuItem11.Enabled = false;
                this.menuItem5.Enabled = true;
            }
            else
            {
                if (Global.privilegio.Substring(4, 1) == "1")
                {
                    this.toolMaster.Items[0].Enabled = true;
                    this.toolMaster.Items[4].Enabled = true;
                    this.menuItem10.Enabled = true;
                    this.menuItem2.Enabled = true;
                }
                else
                {
                    this.toolMaster.Items[0].Enabled = false;
                    this.toolMaster.Items[4].Enabled = false;
                    this.menuItem10.Enabled = false;
                    this.menuItem2.Enabled = false;
                }
                this.toolMaster.Items[1].Enabled = false;
                this.toolMaster.Items[2].Enabled = false;
                this.toolMaster.Items[3].Enabled = false;
                this.toolMaster.Items[5].Enabled = false;
                this.toolMaster.Items[6].Enabled = false;
                this.toolMaster.Items[7].Enabled = false;
                this.menuItem3.Enabled = false;
                this.menuItem5.Enabled = false;
                this.menuItem4.Enabled = false;
                this.menuItem7.Enabled = false;
                this.menuItem11.Enabled = false;
            }
        }
        private void Grid_tara()
        {
            #region DESIGN
            DataGridTableStyle myGrid = new DataGridTableStyle();
            myGrid.PreferredRowHeight = 20;
            myGrid.MappingName = "Taras";
            DataGridTextBoxColumn col1 = new DataGridTextBoxColumn();
            col1.Width = 60;
            col1.NullText = "";
            col1.MappingName = "numero";
            col1.TextBox.MaxLength = 5;
            DataGridTextBoxColumn col2 = new DataGridTextBoxColumn();
            col2.Width = 200;
            col2.NullText = "";
            col2.MappingName = "descripcion";
            col2.TextBox.MaxLength = 52;
            DataGridTextBoxColumn col3 = new DataGridTextBoxColumn();
            col3.Width = 200;
            col3.NullText = "";
            col3.MappingName = "tara";
            col3.TextBox.MaxLength = 5;
            col1.HeaderText = Global.M_Error[215, Global.idioma].ToString();
            col2.HeaderText = Global.M_Error[216, Global.idioma].ToString();
            col3.HeaderText = Global.M_Error[280, Global.idioma].ToString();
            para1 = Global.M_Error[215, Global.idioma].ToString();
            para2 = Global.M_Error[216, Global.idioma].ToString();
            campo1 = "numero";
            campo2 = "descripcion";
            myGrid.GridColumnStyles.Add(col1);
            myGrid.GridColumnStyles.Add(col2);
            myGrid.GridColumnStyles.Add(col3);


            #endregion
            #region DATA
            activo = true;
            int ff = Global.F_Decimal.Length - 3;
            string formato_precio = Global.F_Decimal.Substring(3, ff - 1);
            string CadenaSelect_Maestro = "SELECT * FROM Tara WHERE numemp = " + Global.nempresa + " ORDER BY numero";
            this.TablaMaestra = "Taras";
            this.DataSetMaster.Clear();
            DataSetMaster = db.getData(CadenaSelect_Maestro);
            this.DGrid.DataSource = this.DataSetMaster;
            this.DataSetMaster.Tables[0].TableName = TablaMaestra;
            this.Dato = "";
            if (!this.DGrid.TableStyles.Contains(TablaMaestra)) this.DGrid.TableStyles.Add(myGrid);
            this.DGrid.SetDataBinding(this.DataSetMaster, TablaMaestra);
            cmGridRegister = (CurrencyManager)this.DGrid.BindingContext[this.DataSetMaster, TablaMaestra];
            cmGridRegister.Position = 0;
            #endregion

            if (cmGridRegister.Count > 0)
            {
                for (int i = 0; i < Global.privilegio.Length; i++)
                {
                    if (Global.privilegio.Substring(i, 1) == "1")
                    {
                        if (i == 14)
                        {
                            this.toolMaster.Items[0].Enabled = true;
                            this.toolMaster.Items[1].Enabled = true;
                            this.toolMaster.Items[2].Enabled = true;
                            this.menuItem2.Enabled = true;
                            this.menuItem7.Enabled = true;
                            this.menuItem3.Enabled = true;
                        }

                        if (i == 11)
                        {
                            this.toolMaster.Items[4].Enabled = true;
                            this.menuItem10.Enabled = true;
                        }
                        if (i == 12)
                        {
                            this.menuItem11.Enabled = true;
                            this.toolMaster.Items[5].Enabled = true;
                        }
                        if (i == 13)
                        {
                            this.menuItem4.Enabled = true;
                            this.toolMaster.Items[6].Enabled = true;
                        }
                    }
                    else
                    {
                        if (i == 14)
                        {
                            this.toolMaster.Items[0].Enabled = false;
                            this.toolMaster.Items[1].Enabled = false;
                            this.toolMaster.Items[2].Enabled = false;
                            this.menuItem2.Enabled = false;
                            this.menuItem7.Enabled = false;
                            this.menuItem3.Enabled = false;
                        }
                        if (i == 11)
                        {
                            this.menuItem10.Enabled = false;
                            this.toolMaster.Items[4].Enabled = false;
                        }
                        if (i == 12)
                        {
                            this.menuItem11.Enabled = false;
                            this.toolMaster.Items[5].Enabled = false;
                        }
                        if (i == 13)
                        {
                            this.menuItem4.Enabled = false;
                            this.toolMaster.Items[6].Enabled = false;
                        }
                    }
                }
                this.toolMaster.Items[3].Enabled = true;
                this.toolMaster.Items[7].Enabled = true;
            }
            else
            {

                if (Global.privilegio.Substring(0, 1) == "1")
                {
                    this.toolMaster.Items[0].Enabled = true;
                    this.toolMaster.Items[4].Enabled = true;
                    this.menuItem10.Enabled = true;
                    this.menuItem2.Enabled = true;
                }
                else
                {
                    this.toolMaster.Items[0].Enabled = false;
                    this.toolMaster.Items[4].Enabled = false;
                    this.menuItem10.Enabled = false;
                    this.menuItem2.Enabled = false;
                }
                this.toolMaster.Items[1].Enabled = false;
                this.toolMaster.Items[2].Enabled = false;
                this.toolMaster.Items[3].Enabled = false;
                this.toolMaster.Items[5].Enabled = false;
                this.toolMaster.Items[6].Enabled = false;
                this.toolMaster.Items[7].Enabled = false;
                this.menuItem3.Enabled = false;
                this.menuItem7.Enabled = false;
                this.menuItem5.Enabled = false;
                this.menuItem4.Enabled = false;
                this.menuItem11.Enabled = false;
            }
        }
        private void Grid_articulo()
        {
            activo = true;
            int ff = Global.F_Decimal.Length - 3;
            string formato_precio = Global.F_Decimal.Substring(3, ff - 1);
            #region DESIGN
            DataGridTableStyle myGrid = new DataGridTableStyle();
            myGrid.PreferredRowHeight = 20;
            myGrid.MappingName = "Articulos";
            DataGridTextBoxColumn col1 = new DataGridTextBoxColumn();
            col1.Width = 60;
            col1.NullText = "0";
            col1.Format = "#####";
            col1.MappingName = "numero";
            col1.TextBox.MaxLength = 5;
            DataGridTextBoxColumn col2 = new DataGridTextBoxColumn();
            col2.Width = 200;
            col2.NullText = "";
            col2.MappingName = "descripcion";
            col2.TextBox.MaxLength = 52;
            col1.HeaderText = Global.M_Error[215, Global.idioma].ToString();
            col2.HeaderText = Global.M_Error[216, Global.idioma].ToString();
            myGrid.GridColumnStyles.Add(col1);
            myGrid.GridColumnStyles.Add(col2);
            if (Global.aplicacion != 0)
            {
                DataGridTextBoxColumn col3 = new DataGridTextBoxColumn();
                col3.Width = 200;
                col3.NullText = "";
                col3.MappingName = "familia";
                col3.TextBox.MaxLength = 5;
                col3.HeaderText = Global.M_Error[218, Global.idioma].ToString();
                myGrid.GridColumnStyles.Add(col3);
            }
            else
            {
                DataGridTextBoxColumn col4 = new DataGridTextBoxColumn();
                col4.Width = 200;
                col4.NullText = "";
                col4.MappingName = "tarifa";
                col4.TextBox.MaxLength = 5;
                col4.HeaderText = Global.M_Error[217, Global.idioma].ToString();
                myGrid.GridColumnStyles.Add(col4);
            }
            para1 = Global.M_Error[215, Global.idioma].ToString();
            para2 = Global.M_Error[216, Global.idioma].ToString();
            campo1 = "numero";
            campo2 = "descripcion";

            #endregion
            #region DATA               
            string CadenaSelect_Maestro = "SELECT * FROM Articulos WHERE numemp = " + Global.nempresa + " ORDER BY numero";
            this.TablaMaestra = "Articulos";
            this.DataSetMaster.Clear();
            DataSetMaster = db.getData(CadenaSelect_Maestro);
            this.DGrid.DataSource = this.DataSetMaster;
            this.DataSetMaster.Tables[0].TableName = TablaMaestra;
            this.Dato = "";
            if (!this.DGrid.TableStyles.Contains(TablaMaestra)) this.DGrid.TableStyles.Add(myGrid);
            this.DGrid.SetDataBinding(this.DataSetMaster, TablaMaestra);
            cmGridRegister = (CurrencyManager)this.DGrid.BindingContext[this.DataSetMaster, TablaMaestra];
            cmGridRegister.Position = 0;
            #endregion

            if (cmGridRegister.Count > 0)
            {
                for (int i = 0; i < Global.privilegio.Length; i++)
                {
                    if (Global.privilegio.Substring(i, 1) == "1")
                    {
                        if (i == 4)
                        {
                            this.toolMaster.Items[0].Enabled = true;  //productos
                            this.toolMaster.Items[1].Enabled = true;
                            this.toolMaster.Items[2].Enabled = true;
                            this.menuItem2.Enabled = true;
                            this.menuItem7.Enabled = true;
                            this.menuItem3.Enabled = true;
                        }
                        if (i == 11)
                        {
                            this.toolMaster.Items[4].Enabled = true;  //importar datos
                            this.menuItem10.Enabled = true;
                        }
                        if (i == 12)
                        {
                            this.menuItem11.Enabled = true;   //exportar datos
                            this.toolMaster.Items[5].Enabled = true;
                        }
                        if (i == 13)
                        {
                            this.menuItem4.Enabled = true;  //depurar datos
                            this.toolMaster.Items[6].Enabled = true;
                        }
                    }
                    else
                    {
                        if (i == 4)
                        {
                            this.toolMaster.Items[0].Enabled = false;
                            this.toolMaster.Items[1].Enabled = false;
                            this.toolMaster.Items[2].Enabled = false;
                            this.menuItem2.Enabled = false;
                            this.menuItem7.Enabled = false;
                            this.menuItem3.Enabled = false;
                        }
                        if (i == 11)
                        {
                            this.menuItem10.Enabled = false;
                            this.toolMaster.Items[4].Enabled = false;
                        }
                        if (i == 12)
                        {
                            this.menuItem11.Enabled = false;
                            this.toolMaster.Items[5].Enabled = false;
                        }
                        if (i == 13)
                        {
                            this.menuItem4.Enabled = false;
                            this.toolMaster.Items[6].Enabled = false;
                        }
                    }
                }
                this.toolMaster.Items[3].Enabled = true;
                this.toolMaster.Items[7].Enabled = true;
            }
            else
            {
                if (Global.privilegio.Substring(4, 1) == "1")
                {
                    this.toolMaster.Items[0].Enabled = true;
                    this.toolMaster.Items[4].Enabled = true;
                    this.menuItem10.Enabled = true;
                    this.menuItem2.Enabled = true;
                }
                else
                {
                    this.toolMaster.Items[0].Enabled = false;
                    this.toolMaster.Items[4].Enabled = false;
                    this.menuItem10.Enabled = false;
                    this.menuItem2.Enabled = false;
                }
                this.toolMaster.Items[1].Enabled = false;
                this.toolMaster.Items[2].Enabled = false;
                this.toolMaster.Items[3].Enabled = false;
                this.toolMaster.Items[5].Enabled = false;
                this.toolMaster.Items[6].Enabled = false;
                this.toolMaster.Items[7].Enabled = false;
                this.menuItem3.Enabled = false;
                this.menuItem7.Enabled = false;
                this.menuItem5.Enabled = false;
                this.menuItem4.Enabled = false;
                this.menuItem11.Enabled = false;
            }
        }
        private void Grid_transportista()
        {
            #region DESIGN
            DataGridTableStyle myGrid3 = new DataGridTableStyle();
            myGrid3.MappingName = "transportista";
            DataGridTextBoxColumn colStyle1 = new DataGridTextBoxColumn();
            colStyle1.HeaderText = Global.M_Error[215, Global.idioma].ToString();
            colStyle1.Width = 60;
            colStyle1.NullText = "0";
            colStyle1.Format = "####";
            colStyle1.MappingName = "numero";
            colStyle1.TextBox.MaxLength = 15;
            DataGridTextBoxColumn colStyle2 = new DataGridTextBoxColumn();
            colStyle2.HeaderText = Global.M_Error[216, Global.idioma].ToString();
            colStyle2.Width = 200;
            colStyle2.NullText = "";
            colStyle2.MappingName = "descripcion";
            colStyle2.TextBox.MaxLength = 255;
            myGrid3.GridColumnStyles.Add(colStyle1);
            myGrid3.GridColumnStyles.Add(colStyle2);
            para1 = Global.M_Error[215, Global.idioma].ToString();
            para2 = Global.M_Error[216, Global.idioma].ToString();
            campo1 = "numero";
            campo2 = "descripcion";

            #endregion
            #region DATA
            activo = false;
            this.Dato = "";
            string CadenaSelect_Maestro = "SELECT numero,descripcion FROM transportistas WHERE numemp = " + Global.nempresa + " ORDER BY numero";
            this.TablaMaestra = "transportista";
            this.DataSetMaster.Clear();
            DataSetMaster = db.getData(CadenaSelect_Maestro);
            this.DGrid.DataSource = this.DataSetMaster;
            DataSetMaster.Tables[0].TableName = TablaMaestra;
            if (!this.DGrid.TableStyles.Contains(TablaMaestra)) this.DGrid.TableStyles.Add(myGrid3);
            this.DGrid.SetDataBinding(this.DataSetMaster, this.TablaMaestra);
            cmGridRegister = (CurrencyManager)this.BindingContext[this.DataSetMaster, TablaMaestra];
            cmGridRegister.Position = 0;
            #endregion

            if (cmGridRegister.Count > 0)
            {
                for (int i = 0; i < Global.privilegio.Length; i++)
                {
                    if (Global.privilegio.Substring(i, 1) == "1")
                    {
                        if (i == 14)
                        {
                            this.toolMaster.Items[0].Enabled = true;
                            this.toolMaster.Items[1].Enabled = true;
                            this.toolMaster.Items[2].Enabled = true;
                            this.menuItem2.Enabled = true;
                            this.menuItem3.Enabled = true;
                            this.menuItem7.Enabled = true;
                        }
                        if (i == 11)
                        {
                            this.toolMaster.Items[4].Enabled = true;
                            this.menuItem10.Enabled = true;
                        }
                        if (i == 12)
                        {
                            this.toolMaster.Items[5].Enabled = true;
                            this.menuItem11.Enabled = true;
                        }
                        if (i == 13)
                        {
                            this.toolMaster.Items[6].Enabled = true;
                            this.menuItem4.Enabled = true;
                        }
                    }
                    else
                    {
                        if (i == 14)
                        {
                            this.toolMaster.Items[0].Enabled = false;
                            this.toolMaster.Items[1].Enabled = false;
                            this.toolMaster.Items[2].Enabled = false;
                            this.menuItem2.Enabled = false;
                            this.menuItem3.Enabled = false;
                            this.menuItem7.Enabled = false;
                        }
                        if (i == 11)
                        {
                            this.toolMaster.Items[4].Enabled = false;
                            this.menuItem10.Enabled = false;
                        }
                        if (i == 12)
                        {
                            this.toolMaster.Items[5].Enabled = false;
                            this.menuItem11.Enabled = false;
                        }
                        if (i == 13)
                        {
                            this.toolMaster.Items[6].Enabled = false;
                            this.menuItem4.Enabled = false;
                        }
                    }
                    this.toolMaster.Items[3].Enabled = true;
                    this.toolMaster.Items[7].Enabled = true;
                    this.menuItem5.Enabled = true;
                }
            }
            else
            {
                if (Global.privilegio.Substring(14, 1) == "1")
                {
                    this.toolMaster.Items[0].Enabled = true;
                    this.toolMaster.Items[4].Enabled = true;
                    this.menuItem10.Enabled = true;
                    this.menuItem2.Enabled = true;
                }
                else
                {
                    this.toolMaster.Items[0].Enabled = false;
                    this.toolMaster.Items[4].Enabled = false;
                    this.menuItem10.Enabled = false;
                    this.menuItem2.Enabled = false;
                }
                this.toolMaster.Items[1].Enabled = false;
                this.toolMaster.Items[2].Enabled = false;
                this.toolMaster.Items[3].Enabled = false;
                this.toolMaster.Items[5].Enabled = false;
                this.toolMaster.Items[6].Enabled = false;
                this.toolMaster.Items[7].Enabled = false;
                this.menuItem3.Enabled = false;
                this.menuItem7.Enabled = false;
                this.menuItem5.Enabled = false;
                this.menuItem11.Enabled = false;
                this.menuItem4.Enabled = false;
            }

        }        
		private void Grid_proveedor()
		{
            #region DESIGN
            activo=false;
			DataGridTableStyle myGridStyle2 =new DataGridTableStyle();
			myGridStyle2.MappingName = "proveedor";
			DataGridTextBoxColumn colStyle1 =	new DataGridTextBoxColumn();
			colStyle1.HeaderText = Global.M_Error[215,Global.idioma].ToString();
			colStyle1.Width = 60;
			colStyle1.MappingName = "numero";
			DataGridTextBoxColumn colStyle2 =	new DataGridTextBoxColumn();
			colStyle2.HeaderText = Global.M_Error[216,Global.idioma].ToString();
			colStyle2.Width = 200;
			colStyle2.MappingName = "nombre";
			myGridStyle2.GridColumnStyles.Add(colStyle1);
			myGridStyle2.GridColumnStyles.Add(colStyle2); 
			para1=Global.M_Error[215,Global.idioma].ToString();
			para2=Global.M_Error[216,Global.idioma].ToString();
            campo1 = "numero";
            campo2 = "nombre";			
			
            #endregion
            #region DATA
            this.Dato = "";
            string CadenaSelect_Maestro = "SELECT * FROM proveedor WHERE numemp = " + Global.nempresa + " ORDER BY numero";
            this.TablaMaestra = "proveedor";
            DataSetMaster = db.getData(CadenaSelect_Maestro);
            this.DGrid.DataSource = this.DataSetMaster;
            this.DataSetMaster.Tables[0].TableName = TablaMaestra;
            if (!this.DGrid.TableStyles.Contains(TablaMaestra)) this.DGrid.TableStyles.Add(myGridStyle2);
            this.DGrid.SetDataBinding(this.DataSetMaster, TablaMaestra);
            cmGridRegister = (CurrencyManager)this.BindingContext[this.DataSetMaster, TablaMaestra];
            cmGridRegister.Position = 0;
            #endregion


            if (cmGridRegister.Count > 0)
            {
                for (int i = 0; i < Global.privilegio.Length; i++)
                {
                    if (Global.privilegio.Substring(i, 1) == "1")
                    {
                        if (i == 9)
                        {
                            this.toolMaster.Items[0].Enabled = true;
                            this.toolMaster.Items[1].Enabled = true;
                            this.toolMaster.Items[2].Enabled = true;
                            this.menuItem2.Enabled = true;
                            this.menuItem3.Enabled = true;
                            this.menuItem7.Enabled = true;
                        }
                        if (i == 11)
                        {
                            this.toolMaster.Items[4].Enabled = true;
                            this.menuItem10.Enabled = true;
                        }
                        if (i == 12)
                        {
                            this.toolMaster.Items[5].Enabled = true;
                            this.menuItem11.Enabled = true;
                        }
                        if (i == 13)
                        {
                            this.toolMaster.Items[6].Enabled = true;
                            this.menuItem4.Enabled = true;
                        }
                    }
                    else
                    {
                        if (i == 9)
                        {
                            this.toolMaster.Items[0].Enabled = false;
                            this.toolMaster.Items[1].Enabled = false;
                            this.toolMaster.Items[2].Enabled = false;
                            this.menuItem2.Enabled = false;
                            this.menuItem3.Enabled = false;
                            this.menuItem7.Enabled = false;
                        }
                        if (i == 11)
                        {
                            this.toolMaster.Items[4].Enabled = false;
                            this.menuItem10.Enabled = false;
                        }
                        if (i == 12)
                        {
                            this.toolMaster.Items[5].Enabled = false;
                            this.menuItem11.Enabled = false;
                        }
                        if (i == 13)
                        {
                            this.toolMaster.Items[6].Enabled = false;
                            this.menuItem4.Enabled = false;
                        }
                    }
                }
                this.toolMaster.Items[3].Enabled = true;
                this.toolMaster.Items[7].Enabled = true;
                this.menuItem5.Enabled = true;
                this.menuItem10.Enabled = false;
                this.menuItem11.Enabled = false;
            }
            else
            {
                if (Global.privilegio.Substring(9, 1) == "1")
                {
                    this.toolMaster.Items[0].Enabled = true;
                    this.toolMaster.Items[4].Enabled = true;
                    this.menuItem10.Enabled = true;
                    this.menuItem2.Enabled = true;
                }
                else
                {
                    this.toolMaster.Items[0].Enabled = false;
                    this.toolMaster.Items[4].Enabled = false;
                    this.menuItem10.Enabled = false;
                    this.menuItem2.Enabled = false;
                }
                this.toolMaster.Items[1].Enabled = false;
                this.toolMaster.Items[2].Enabled = false;
                this.toolMaster.Items[3].Enabled = false;
                this.toolMaster.Items[5].Enabled = false;
                this.toolMaster.Items[6].Enabled = false;
                this.toolMaster.Items[7].Enabled = false;
                this.menuItem3.Enabled = false;
                this.menuItem7.Enabled = false;
                this.menuItem5.Enabled = false;
                this.menuItem11.Enabled = false;
                this.menuItem4.Enabled = false;
            }
        }
        private void Grid_familia()
        {
            #region DESIGN
            activo = false;
            DataGridTableStyle myGridStyle2 = new DataGridTableStyle();
            myGridStyle2.MappingName = "familia";
            DataGridTextBoxColumn colStyle1 = new DataGridTextBoxColumn();
            colStyle1.HeaderText = Global.M_Error[215, Global.idioma].ToString();
            colStyle1.Width = 60;
            colStyle1.MappingName = "familia";
            DataGridTextBoxColumn colStyle2 = new DataGridTextBoxColumn();
            colStyle2.HeaderText = Global.M_Error[216, Global.idioma].ToString();
            colStyle2.Width = 200;
            colStyle2.MappingName = "descripcion";
            myGridStyle2.GridColumnStyles.Add(colStyle1);
            myGridStyle2.GridColumnStyles.Add(colStyle2);
            para1 = Global.M_Error[215, Global.idioma].ToString();
            para2 = Global.M_Error[216, Global.idioma].ToString();
            campo1 = "familia";
            campo2 = "descripcion";
            
            #endregion
            #region DATA
            this.Dato = "";
            string CadenaSelect_Maestro = "SELECT * FROM familia WHERE numemp = " + Global.nempresa + " ORDER BY familia";
            this.TablaMaestra = "familia";
            this.DataSetMaster.Clear();
            DataSetMaster = db.getData(CadenaSelect_Maestro);
            this.DGrid.DataSource = this.DataSetMaster;
            this.DataSetMaster.Tables[0].TableName = TablaMaestra;
            if (!this.DGrid.TableStyles.Contains(TablaMaestra)) this.DGrid.TableStyles.Add(myGridStyle2);
            this.DGrid.SetDataBinding(this.DataSetMaster, TablaMaestra);
            cmGridRegister = (CurrencyManager)this.BindingContext[this.DataSetMaster, TablaMaestra];
            cmGridRegister.Position = 0;
            #endregion 

            if (cmGridRegister.Count > 0)
            {
                for (int i = 0; i < Global.privilegio.Length; i++)
                {
                    if (Global.privilegio.Substring(i, 1) == "1")
                    {
                        if (i == 9)
                        {
                            this.toolMaster.Items[0].Enabled = true;
                            this.toolMaster.Items[1].Enabled = true;
                            this.toolMaster.Items[2].Enabled = true;
                            this.menuItem2.Enabled = true;
                            this.menuItem3.Enabled = true;
                            this.menuItem7.Enabled = true;
                        }
                        if (i == 11)
                        {
                            this.toolMaster.Items[4].Enabled = true;
                            this.menuItem10.Enabled = true;
                        }
                        if (i == 12)
                        {
                            this.toolMaster.Items[5].Enabled = true;
                            this.menuItem11.Enabled = true;
                        }
                        if (i == 13)
                        {
                            this.toolMaster.Items[6].Enabled = true;
                            this.menuItem4.Enabled = true;
                        }
                    }
                    else
                    {
                        if (i == 9)
                        {
                            this.toolMaster.Items[0].Enabled = false;
                            this.toolMaster.Items[1].Enabled = false;
                            this.toolMaster.Items[2].Enabled = false;
                            this.menuItem2.Enabled = false;
                            this.menuItem3.Enabled = false;
                            this.menuItem7.Enabled = false;
                        }
                        if (i == 11)
                        {
                            this.toolMaster.Items[4].Enabled = false;
                            this.menuItem10.Enabled = false;
                        }
                        if (i == 12)
                        {
                            this.toolMaster.Items[5].Enabled = false;
                            this.menuItem11.Enabled = false;
                        }
                        if (i == 13)
                        {
                            this.toolMaster.Items[6].Enabled = false;
                            this.menuItem4.Enabled = false;
                        }
                    }
                }
                this.toolMaster.Items[3].Enabled = true;
                this.toolMaster.Items[7].Enabled = true;
                this.menuItem5.Enabled = true;
                this.menuItem10.Enabled = false;
                this.menuItem11.Enabled = false;
            }
            else
            {
                if (Global.privilegio.Substring(9, 1) == "1")
                {
                    this.toolMaster.Items[0].Enabled = true;
                    this.toolMaster.Items[4].Enabled = true;
                    this.menuItem10.Enabled = true;
                    this.menuItem2.Enabled = true;
                }
                else
                {
                    this.toolMaster.Items[0].Enabled = false;
                    this.toolMaster.Items[4].Enabled = false;
                    this.menuItem10.Enabled = false;
                    this.menuItem2.Enabled = false;
                }
                this.toolMaster.Items[1].Enabled = false;
                this.toolMaster.Items[2].Enabled = false;
                this.toolMaster.Items[3].Enabled = false;
                this.toolMaster.Items[5].Enabled = false;
                this.toolMaster.Items[6].Enabled = false;
                this.toolMaster.Items[7].Enabled = false;
                this.menuItem3.Enabled = false;
                this.menuItem7.Enabled = false;
                this.menuItem5.Enabled = false;
                this.menuItem11.Enabled = false;
                this.menuItem4.Enabled = false;
            }
        }
        #endregion
        #region EVENTS
        private void DGrid_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
			System.Windows.Forms.DataGrid reg = ((System.Windows.Forms.DataGrid)sender);
				
			if (reg.CurrentRowIndex >= 0)
			{
				cmGridRegister.Position = reg.CurrentRowIndex;
				reg.Select(cmGridRegister.Position);
				Dato = reg[cmGridRegister.Position,0].ToString();	
			}			
		}
		private void DGrid_CurrentCell(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
			System.Windows.Forms.DataGrid reg = ((System.Windows.Forms.DataGrid)sender);
			cmGridRegister.Position=reg.CurrentCell.RowNumber;
			reg.Select(cmGridRegister.Position);
			Dato = reg[cmGridRegister.Position,0].ToString();
		}
        
		private void TreeFile_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			System.Windows.Forms.TreeView nodo_file = (System.Windows.Forms.TreeView)sender;
			nodo_file.Select();
			nodo_file.Focus();
            #region Determinar que catalogo se muestra en la aplicacion


            switch (nodo_file.SelectedNode.Index)
			{

				case 0: //CATALOGO DE EMPRESAS
				{  				
					this.Grid_Empresa();//EMPRESAS
                    this.tipo_opcion = 0;
				}
                break;


				case 1:  //CATALOGO DE ARTICULOS
				{	
					this.Grid_articulo();//ARTICULOS
                    this.tipo_opcion = 1;
			    }
                break;


				case 2: //CATALOGO DE CLIENTE O DE PROVEEDOR
                    {
                        if (Global.aplicacion == 0)
                        {
                            this.Grid_cliente();//CLIENTE
                            this.tipo_opcion = 3;
                        }
                        else
                        {
                            this.Grid_proveedor();//PROVEEDOR
                            this.tipo_opcion = 2;
                        }
				}
                break;


				case 3: //CATALOGO DE TARA O DE CLIENTE
				{
                    if (Global.aplicacion == 0)
                    {
                        this.Grid_tara();//TARAS
                        this.tipo_opcion = 5;
                    }
                    else
                    {
                        this.Grid_cliente();//CLIENTES
                        this.tipo_opcion = 3;
                    }
				}
                break;


				case 4: //CATALOGO DE TRANSPORTISTA O DE USUARIOS O DE FAMILIA
				{
                    if (Global.aplicacion == 0)
                    {
                        this.Grid_usuarios();//USUARIOS
                        this.tipo_opcion = 7;
                    }
                    if (Global.aplicacion == 1)
                    {
                        this.Grid_transportista();//TRANSPORTISTAS
                        this.tipo_opcion = 4;
                    }
                    if (Global.aplicacion == 2)
                    {
                        this.Grid_familia();//FAMILIA
                        this.tipo_opcion = 6;
                    }
				}
                break;	


				case 5: //CATALOGO DE TARAS O DE USUARIOS
				{
                    if (Global.aplicacion == 2)
                    {
                        this.Grid_usuarios();//USUARIOS
                        this.tipo_opcion = 7;
                    }
                    else
                    {
                        this.Grid_tara();//TARAS
                        this.tipo_opcion = 5;
                    }
				}
                break;


                case 6: //Catalogo de familia
                    {
                        this.Grid_familia();//FAMILIAS
                        this.tipo_opcion = 6;
                    }
                break;



				case 7: //Catalogo de usuarios
				{	
					this.Grid_usuarios();//USUARIOS
                    this.tipo_opcion = 7;
				}
                break;



			}
            #endregion
        }




		private void ADD(object sender, System.EventArgs e)
		{
			if (this.TreeFile.SelectedNode != null)
			{
				switch (this.tipo_opcion)
				{
                    #region NUEVA COMPAÑIA

                    case 0: // NEW COMPANY
					{ 										
						WEMPRESAS sca = new WEMPRESAS(x,y,3);
                            //Global.clv_aceptada = true;
                            //sca.comando(0);
                            //sca.ShowDialog(this);
                            Global.clv_aceptada = false;
                            clave clv2 = new clave(2);
                            clv2.inicio_user.Text = this.usuario;
                            clv2.ShowDialog(this);
                            if (Global.clv_aceptada && Global.privilegio.Substring(0, 1) == "1")
                        {
                            sca.comando(0);
                            sca.ShowDialog(this);
                        }
                        else { MessageBox.Show(Global.M_Error[51, Global.idioma]); }
                        this.Grid_Empresa();
					}

                    break;
                    #endregion
                    #region NUEVO ARTICULO
                    case 1:  //NEW ARTICLES
					{
                        if (Global.nempresa != 0)
                        {
                            WPRODUCTO art = new WPRODUCTO(x, y, 3);
                            art.comando(0);
                            art.ShowDialog(this);
                            this.Grid_articulo();
                        }
                        else MessageBox.Show(Global.M_Error[48, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
                        break;
                    #endregion
                    #region NUEVO PROVEEDOR
                    case 2: //NEW PROVIDER
					{
                        if (Global.nempresa != 0)
                        {
                            WVENDOR ven = new WVENDOR(x, y, 3);
                            ven.comando(0);
                            ven.ShowDialog(this);
                        }
                        else MessageBox.Show(Global.M_Error[48, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Grid_proveedor();
					}
                        break;
                    #endregion
                    #region NUEVO CLIENTE
                    case 3: // NEW CLIENT
					{
                        if (Global.nempresa != 0)
                        {
                            WCUSTOMER age = new WCUSTOMER(x, y, 3);
                            age.comando(0);
                            age.ShowDialog(this);
                        }
                        else MessageBox.Show(Global.M_Error[48, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Grid_cliente();
					}
                        break;
                    #endregion
                    #region NUEVO TRANSPORTE
                    case 4: //NEW TRANSPORT
					{
                        if (Global.nempresa != 0)
                        {
                            WTRANSPORTE ing = new WTRANSPORTE(x, y, 3);
                            ing.comando(0);
                            ing.ShowDialog(this);
                        }
                        else MessageBox.Show(Global.M_Error[48, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Grid_transportista();
					}
                        break;
                    #endregion
                    #region NUEVA TARA
                    case 5: //NEW TARA
					{
                        if (Global.nempresa != 0)
                        {
                            WTARA tar = new WTARA(x, y, 3);
                            tar.comando(0);
                            tar.ShowDialog(this);

                        }
                        else MessageBox.Show(Global.M_Error[48, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Grid_tara();
					}
                        break;
                    #endregion
                    #region NUEVA FAMILIA
                    case 6: //NEW FAMILY
                        {
                            if (Global.nempresa != 0)
                            {
                                WFAMILIA fam = new WFAMILIA(x, y, 3);
                                fam.comando(0);
                                fam.ShowDialog(this);
                            }
                            else MessageBox.Show(Global.M_Error[48, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Grid_familia();
                        }
                        break;
                    #endregion
                    #region NUEVO USUARIO
                    case 7: //NEW USER
					{	
						WUSER use = new WUSER(x,y,3);
						use.comando(0);
						use.ShowDialog(this);
						this.Grid_usuarios();
					}break;
                        #endregion
                }
			}
		}
		private void EDIT(object sender, System.EventArgs e)
		{
			if (this.Dato != null && this.Dato != "")
			{
				switch (this.tipo_opcion)
				{
                    #region EDITAR EMPRESA
                    case 0: //Editar Empresa
					{  							
						WEMPRESAS sca = new WEMPRESAS(x,y,3);
						sca.id_empresa.Text = this.Dato;
						if (sca.muestra_empresa(this.Dato))
						{
							sca.ShowDialog(this);
							this.Grid_Empresa();
						}
						else MessageBox.Show(Global.M_Error[2,Global.idioma].ToString());
					}
                        break;
                    #endregion
                    #region EDITAR ARTICULOS
                    case 1:  //Editar Articulos
					{	
						WPRODUCTO art = new WPRODUCTO(x,y,3);
						art.numero.Text=this.Dato;
						if (art.muestra_codigo(this.Dato))
						{
							art.ShowDialog(this);
							this.Grid_articulo();
						}
						else MessageBox.Show(Global.M_Error[2,Global.idioma].ToString());
					}
                        break;
                    #endregion
                    #region EDITAR PROVEEDOR
                    case 2: //Editar Proveedor
					{	
						WVENDOR ven = new WVENDOR(x,y,3);
						ven.numero.Text = this.Dato;
						if(ven.muestra_codigo(ven.numero.Text))
						{
							ven.ShowDialog(this);
							this.Grid_proveedor();
						}
						else MessageBox.Show(Global.M_Error[2,Global.idioma].ToString());
					}
                        break;
                    #endregion
                    #region EDITAR CLIENTE
                    case 3: // Editar Cliente
					{	
						WCUSTOMER age = new WCUSTOMER(x,y,3);
						age.numero.Text=this.Dato;
						if(age.muestra_codigo(this.Dato))
						{
							age.ShowDialog(this);
							this.Grid_cliente();
						}
						else MessageBox.Show(Global.M_Error[2,Global.idioma].ToString());
					}
                        break;
                    #endregion
                    #region EDITAR TRANSPORTE
                    case 4: //Editar Transporte
					{	
						WTRANSPORTE ing = new WTRANSPORTE(x,y,3);
						ing.numero.Text = this.Dato;
						if(ing.muestra_codigo(ing.numero.Text))
						{
							ing.ShowDialog(this);
							this.Grid_transportista();
						}
						else MessageBox.Show(Global.M_Error[2,Global.idioma].ToString());
					}
                        break;
                    #endregion
                    #region EDITAR TARA
                    case 5:  //Editar Tara
					{	
						WTARA tar = new WTARA(x,y,3);
						tar.numero.Text=this.Dato;
						if (tar.muestra_codigo(this.Dato))
						{
							tar.ShowDialog(this);
							this.Grid_tara();
						}
						else MessageBox.Show(Global.M_Error[2,Global.idioma].ToString());
					}
                        break;
                    #endregion
                    #region EDITAR FAMILIA
                    case 6: //Editar Familia
                        {
                            WFAMILIA fam = new WFAMILIA(x, y, 3);
                            fam.numero.Text = this.Dato;
                            if (fam.muestra_codigo(fam.numero.Text))
                            {
                                fam.ShowDialog(this);
                                this.Grid_familia();
                            }
                            else MessageBox.Show(Global.M_Error[2, Global.idioma].ToString());
                        }
                        break;
                    #endregion
                    #region EDITAR USUARIOS
                    case 7: //Editar Usuarios
					{	
						WUSER use = new WUSER(x,y,3);
						use.txt_user.Text = this.Dato;
						if(use.muestra_ususario(use.txt_user.Text))
						{
							use.ShowDialog(this);
							this.Grid_usuarios();
						}
						else MessageBox.Show(Global.M_Error[2,Global.idioma].ToString());
					}
                        break;
                    #endregion
                }
			}
			else
			{
				MessageBox.Show(Global.M_Error[305,Global.idioma]);
			}
		}		
		private void DELETE(object sender, System.EventArgs e)
		{
			if (this.Dato != null)
			{
				switch (this.tipo_opcion)
				{

                    #region ELIMINAR EMPRESA
                    case 0: //Borrar Empresa
					{  	
						    WEMPRESAS sca = new WEMPRESAS(x,y,3);
                            Global.clv_aceptada = false;
                            clave clv2 = new clave(2);
                            clv2.inicio_user.Text = this.usuario;
                            clv2.ShowDialog(this);
                            if (Global.clv_aceptada && Global.privilegio.Substring(0, 1) == "1")
                            {
                                sca.id_empresa.Text = this.Dato;
                                sca.comando(2);
                            }
                            else { MessageBox.Show(Global.M_Error[51, Global.idioma]); }
                            this.Grid_Empresa();
					}
                    break;
                    #endregion
                    #region ELIMINAR ARTICULOS
                    case 1:  //Borrar Articulos
					{ 	
						WPRODUCTO art = new WPRODUCTO(x,y,3);
						art.numero.Text=this.Dato;
						art.comando(2);
						this.Grid_articulo();
					}
                    break;
                    #endregion
                    #region ELIMINAR PROVEEDOR
                    case 2: //Borrar proveedor
					{	
						WVENDOR ven = new WVENDOR(x,y,3);
						ven.numero.Text = this.Dato;
						ven.comando(2);
						this.Grid_proveedor();
					}
                    break;
                    #endregion
                    #region ELIMINAR CLIENTES
                    case 3: // Borrar Cliente
					{	
						WCUSTOMER age = new WCUSTOMER(x,y,3);
						age.numero.Text=this.Dato;
						age.comando(2);
						this.Grid_cliente();
					}
                    break;
                    #endregion
                    #region ELIMINAR TRANSPORTE
                    case 4: //Borrar Transporte
					{	
						WTRANSPORTE ing = new WTRANSPORTE(x,y,3);
						ing.numero.Text = this.Dato;
						ing.comando(2);
						this.Grid_transportista();
					}
                    break;
                    #endregion
                    #region ELIMINAR TARA
                    case 5:  //Borrar Tara
					{ 	
						WTARA tara = new WTARA(x,y,3);
						tara.numero.Text=this.Dato;
						tara.comando(2);
						this.Grid_tara();
					}
                    break;
                    #endregion
                    #region ELIMINAR FAMILIA
                    case 6: //Borrar familia
                        {
                            WFAMILIA fam = new WFAMILIA(x, y, 3);
                            fam.numero.Text = this.Dato;
                            fam.comando(2);
                            this.Grid_familia();
                        }
                    break;
                    #endregion
                    #region ELIMINAR USUARIOS
                    case 7: //Borrar usuarios
					{	
						WUSER use = new WUSER(x,y,3);
						use.txt_user.Text = this.Dato;
						use.comando(2);
						this.Grid_usuarios();
					}
                    break;
                        #endregion

                }
			}
			else MessageBox.Show(Global.M_Error[2,Global.idioma].ToString());
		}
		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			if (Global.nempresa != 0)
			{
                switch (this.tipo_opcion)
                {
                    case 1:  //Importar Articulos
                        {
                            importexport entrada = new importexport(1, 1);
                            entrada.importar(1, new TRUCK.Menu().StatusBar);
                            this.Grid_articulo();
                        } break;
                    case 2: // Importar Proveedor y transportista
                        {
                            importexport entrada = new importexport(2, 1);
                            entrada.importar(2, new TRUCK.Menu().StatusBar);
                            this.Grid_proveedor();
                        } break;
                    case 3: // Importar Cliente  o familia
                        {
                            importexport entrada = new importexport(3, 1);
                            entrada.importar(3, new TRUCK.Menu().StatusBar);
                            this.Grid_cliente();
                        } break;
                    case 4: // Importar Transportista
                        {
                            importexport entrada = new importexport(4, 1);
                            entrada.importar(4, new TRUCK.Menu().StatusBar);
                            this.Grid_transportista();
                        } break;
                    case 5: // Importar Vehiculo tara
                        {
                            importexport entrada = new importexport(5, 1);
                            entrada.importar(5, new TRUCK.Menu().StatusBar);
                            this.Grid_tara();
                        } break;
                    case 6: // Importar familia
                        {
                            importexport entrada = new importexport(6, 1);
                            entrada.importar(6, new TRUCK.Menu().StatusBar);
                            this.Grid_familia();
                        } break;
                }
			}
            else MessageBox.Show(Global.M_Error[48, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.Focus();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            if (Global.nempresa != 0)
            {
                switch (this.tipo_opcion)
                {
                    case 1:  //Exportar Producto
                        {
                            importexport entrada = new importexport(1, 2);
                            entrada.exportar(1, new TRUCK.Menu().StatusBar);
                        } break;
                    case 2: // Exportar Proveedor
                        {
                            importexport entrada = new importexport(2, 2);
                            entrada.exportar(2, new TRUCK.Menu().StatusBar);

                        } break;
                    case 3: // Exportar Cliente
                        {
                            importexport entrada = new importexport(3, 2);
                            entrada.exportar(3, new TRUCK.Menu().StatusBar);
                        } break;
                    case 4: // Exportar Transportista
                        {
                            importexport entrada = new importexport(4, 2);
                            entrada.exportar(4, new TRUCK.Menu().StatusBar);
                        } break;
                    case 5: // Exportar Vehiculo Tara
                        {
                            importexport entrada = new importexport(5, 2);
                            entrada.exportar(5, new TRUCK.Menu().StatusBar);
                        } break;
                    case 6: // Exportar familia
                        {
                            importexport entrada = new importexport(6, 2);
                            entrada.exportar(6, new TRUCK.Menu().StatusBar);
                        } break;
                }
            }
            else MessageBox.Show(Global.M_Error[48, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.Focus();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		private void OpenDepurar(object sender, System.EventArgs e)
		{


			if (this.TreeFile.SelectedNode!=null)
			{
                switch (this.tipo_opcion)
                {
                    case 1:  //Depurar Productos
                        {
                            depurar depur = new depurar(2);
                            depur.Text = Global.M_Error[159, Global.idioma].ToString();
                            depur.ShowDialog(this);
                            this.Grid_articulo();

                        } break;
                    case 2: // Depurar Proveedor
                        {
                            depurar depur = new depurar(3);
                            depur.Text = Global.M_Error[160, Global.idioma].ToString();
                            depur.ShowDialog(this);
                            this.Grid_proveedor();
                        } break;
                    case 3: // Depurar Clientes
                        {
                            depurar depur = new depurar(4);
                            depur.Text = Global.M_Error[158, Global.idioma].ToString();
                            depur.ShowDialog(this);
                            this.Grid_cliente();
                        } break;
                    case 4: // Depurar Transportista
                        {
                            depurar depur = new depurar(5);
                            depur.Text = Global.M_Error[161, Global.idioma].ToString();
                            depur.ShowDialog(this);
                            this.Grid_transportista();
                        } break;
                    case 5: // Depurar Vehiculo Tara
                        {
                            depurar depur = new depurar(6);
                            depur.Text = Global.M_Error[291, Global.idioma].ToString();
                            depur.ShowDialog(this);
                            this.Grid_tara();
                        } break;
                    case 6: // Depurar Familia
                        {
                            depurar depur = new depurar(7);
                            depur.Text = Global.M_Error[173, Global.idioma].ToString();
                            depur.ShowDialog(this);
                            this.Grid_familia();
                        } break;
                }
			}
			this.DGrid.Refresh();	
		}		
        private void nombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.cmGridRegister.Count > 0)
            {
                Buscar busca = new Buscar(2, para1, para2); //ingresa el nombre a buscar
                busca.ShowDialog();
                this.Focus();
                if (Buscar.nombre != "" && Buscar.nombre != null)
                {
                    this.DGrid.UnSelect(cmGridRegister.Position);
                    if (this.Find_Descripcion(Buscar.nombre, campo2, campo1))  // busca la descriopcion
                    {
                        this.DGrid.Select(cmGridRegister.Position);
                    }
                    else
                    {
                        MessageBox.Show(Global.M_Error[32, Global.idioma].ToString());
                    }
                }
            }
        }
        private void codigoToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if (this.cmGridRegister.Count > 0)
            {
                Buscar busca = new Buscar(1, para1, para2); //ingresa el codigo a buscar
                busca.ShowDialog();
                this.Focus();
                if (Buscar.codigo != "" && Buscar.codigo != null)
                {
                    this.DGrid.UnSelect(cmGridRegister.Position);
                    if (this.Find_Codigo(Buscar.codigo, campo1)) // busca el codigo
                    {
                        this.DGrid.Select(cmGridRegister.Position);
                    }
                    else
                    {
                        MessageBox.Show(Global.M_Error[32, Global.idioma].ToString());
                    }
                }
            }
            else MessageBox.Show(Global.M_Error[2, Global.idioma].ToString());
		}
		private bool Find_Codigo(string n_codigo,string campo1)
		{	
			bool encontro = false;
		
			this.DataSetMaster.Tables[this.TablaMaestra].PrimaryKey = new System.Data.DataColumn[] {this.DataSetMaster.Tables[this.TablaMaestra].Columns[campo1]};

			System.Data.DataRow dr = this.DataSetMaster.Tables[this.TablaMaestra].Rows.Find(Convert.ToInt32(n_codigo));

			if (dr != null)
			{
				encontro = true;
				cmGridRegister.Position = buscar_posicion(Convert.ToInt32(n_codigo),campo1);
			}
			return encontro;
		}	
		private bool Find_Descripcion(string descrip,string campo2,string campo1)
		{	
			bool encontro = false;
			int len = descrip.Length;

			System.Data.DataRow[] dr = this.DataSetMaster.Tables[this.TablaMaestra].Select("SUBSTRING("+campo2+ ",1," + len+ ") = '" + descrip + "'");
			
			if (dr.Length > 0)
			{ 
				encontro = true;
				cmGridRegister.Position = buscar_posicion(Convert.ToInt32(dr[0][campo1]),campo1);
			}
			return encontro;
		}
        private void menuItem6_Click(object sender, System.EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            switch (this.tipo_opcion)
            {
                case 0: // Listado de Empresa
                    {
                        RListados Listado = new RListados(0);
                        Listado.Text = Global.M_Error[163, Global.idioma].ToString();
                        Listado.Show();
                    } break;
                case 1:  //Listado de Producto
                    {
                        RListados Listado = new RListados(1);
                        Listado.Text = Global.M_Error[164, Global.idioma].ToString();
                        Listado.Show();
                    } break;
                case 2: // Listado de Proveedore y de cliente
                    {
                        RListados Listado = new RListados(2);//proveedor
                        Listado.Text = Global.M_Error[165, Global.idioma].ToString();
                        Listado.Show();
                    } break;
                case 3: // Listado de Cliente y el vehiculo tara
                    {
                        RListados Listado;
                        if (Global.aplicacion == 0) Listado = new RListados(2);//publico
                        else Listado = new RListados(3);//privado
                        Listado.Text = Global.M_Error[166, Global.idioma].ToString();
                        Listado.Show();
                    } break;
                case 4: // Listado de transportista
                    {
                        RListados Listado = new RListados(4);
                        Listado.Text = Global.M_Error[167, Global.idioma].ToString();
                        Listado.Show();
                    } break;
                case 5: // Listado de vehiculo tara
                    {
                        RListados Listado;
                        if (Global.aplicacion == 0) Listado = new RListados(3);//public
                        else Listado = new RListados(5); // privada
                        Listado.Text = Global.M_Error[188, Global.idioma].ToString();
                        Listado.Show();
                    } break;
                case 7: // Listado de Usuarios
                    {
                        RListados Listado = new RListados(6);//public
                        Listado.Text = Global.M_Error[174, Global.idioma].ToString();
                        Listado.Show();
                    } break;
            }
            this.Focus();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
		private int buscar_posicion(int elemento,string clave)
		{
			int desde,hasta,medio,posicion; // desde y hasta indican los límites del array que se está mirando.
			posicion = 0;
			
			for(desde=0,hasta=this.DataSetMaster.Tables[this.TablaMaestra].Rows.Count-1;desde<=hasta;)
			{					
				if(desde==hasta) // si el array sólo tiene un elemento:
				{
					if(Convert.ToInt32(this.DataSetMaster.Tables[this.TablaMaestra].Rows[desde][clave]) == elemento) // si es la solución:
						posicion=desde; // darle el valor.
					else // si no es el valor:
						posicion=-1; // no está en el array.
					break; // Salir del bucle.
				}
				medio=(desde+hasta)/2; // Divide el array en dos.
				if(Convert.ToInt32(this.DataSetMaster.Tables[this.TablaMaestra].Rows[medio][clave])==elemento) // Si coincide con el central:
				{
					posicion=medio; // ese es la solución
					break; // y sale del bucle.
				}
				else if(Convert.ToInt32(this.DataSetMaster.Tables[this.TablaMaestra].Rows[medio][clave])>elemento) // si es menor:
					hasta=medio-1; // elige el array izquierda.
				else // y si es mayor:
					desde=medio+1; // elige el array de la derecha.
			}
			return posicion;
		}
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ADD(null, new System.EventArgs());  // nuevo
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            EDIT(null, new System.EventArgs()); //editar
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DELETE(null, new System.EventArgs()); //borrar
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            menuItem10_Click(null, new System.EventArgs()); // importar
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            menuItem11_Click(null, new System.EventArgs()); //exportar
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            OpenDepurar(null, new System.EventArgs());  //depurar
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            menuItem6_Click(null, new System.EventArgs()); // Listados de maestros
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion
    }
}
