using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.IO.Ports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace TRUCK
{
	/// <summary>
	/// Descripción breve de Transacciones.
	/// </summary>
    public class Transacciones3m : System.Windows.Forms.Form
    {
        #region VARIABLES
        DataAccesQuery db;
        DataSet dt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txt_um_pn;
        private System.Windows.Forms.Label txt_um_pt;
        private System.Windows.Forms.Label txt_um_pb;
        private System.Windows.Forms.TextBox peso_neto;
        private System.Windows.Forms.TextBox peso_tara;
        private System.Windows.Forms.TextBox peso_bruto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox combo_producto;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ComboBox combo_proveedor;
        private System.Windows.Forms.ComboBox combo_transporte;
        private System.Windows.Forms.ComboBox combo_cliente;
        private ToolStrip toolBar1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton7;
        private Label label16;
        private System.Windows.Forms.TextBox txt_observa;
        private Label label12;
        private TextBox pto3;
        private TextBox pto2;
        private TextBox pto1;
        private Label label17;
        private Label label18;
        private SerialPort serialPort1 = new SerialPort();
        private SerialPort serialPort2 = new SerialPort();
        private SerialPort serialPort3 = new SerialPort();
        private SerialPort serialPort4 = new SerialPort();
        private string mensaje1, mensaje2, mensaje3, mensaje;
        private CurrencyManager cmRegister;
        private string para1, campo;
        delegate void SetTextCallback(string text, string um);
        Comunica RS232 = new Comunica();
        private BindingSource bindingSource1;
        private BindingNavigator bindingNavigator1;
        private ToolStripLabel bindingNavigatorCountItem;
        private ToolStripButton bindingNavigatorMoveFirstItem;
        private ToolStripButton bindingNavigatorMovePreviousItem;
        private ToolStripSeparator bindingNavigatorSeparator;
        private ToolStripTextBox bindingNavigatorPositionItem;
        private ToolStripSeparator bindingNavigatorSeparator1;
        private ToolStripButton bindingNavigatorMoveNextItem;
        private ToolStripButton bindingNavigatorMoveLastItem;
        private ToolStripSeparator bindingNavigatorSeparator2;
        private ToolStripButton toolStripButton5;
        private DataGridView GVTransaccion;
        public bool cancelar_transaccion;
        private int tara_manual = 0;
        private Timer timer1;
        private string nombre_swf1;
        private string nombre_swf2;
        private int band;
        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash1;
        private GroupBox groupBox4;
        private MaskedTextBox.MaskedTextBox txt_guia;
        private MaskedTextBox.MaskedTextBox txt_placa;
        private MaskedTextBox.MaskedTextBox txt_embarque;
        private MaskedTextBox.MaskedTextBox txt_factura;
        private Label label4;
        private Label label15;
        private Label label13;
        private Label label14;
        private Label label6;
        private Label label7;
        private ComboBox tipo_mov;
        private MaskedTextBox.MaskedTextBox txt_folio;
        private ToolStripButton toolStripButton8;
        private Timer timer2;
        #endregion
        #region CONSTRUCTOR
        public Transacciones3m()
        {
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();
            this.cancelar_transaccion = false;
            if (Global.aplicacion == 0) this.label8.Text = Global.M_Error[146, Global.idioma].ToString();
            else this.label8.Text = Global.M_Error[136, Global.idioma].ToString();
            this.GVTransaccion.CellClick += new DataGridViewCellEventHandler(GVTransaccion_CellClick);
            this.tipo_mov.SelectedIndexChanged += new EventHandler(tipo_mov_SelectedIndexChanged);
            this.bindingNavigator1.ItemClicked += new ToolStripItemClickedEventHandler(bindingNavigator1_ItemClicked);
            this.txt_folio.LostFocus += new EventHandler(txt_folio_LostFocus);
            this.txt_guia.KeyDown += new KeyEventHandler(txt_guia_KeyDown);
            this.txt_factura.KeyDown += new KeyEventHandler(txt_factura_KeyDown);
            this.txt_embarque.KeyDown += new KeyEventHandler(txt_embarque_KeyDown);
            this.txt_placa.KeyDown += new KeyEventHandler(txt_placa_KeyDown);
            this.txt_placa.LostFocus += new EventHandler(txt_placa_LostFocus);
            this.txt_observa.KeyDown += new KeyEventHandler(txt_observa_KeyDown);

            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort2_DataReceived);
            this.serialPort3.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort3_DataReceived);

            this.tipo_mov.Items.Add(Global.M_Error[211, Global.idioma].ToString());
            this.tipo_mov.Items.Add(Global.M_Error[212, Global.idioma].ToString());
            this.tipo_mov.SelectedIndex = 0;

            Llenar_Grid();

            switch (Global.aplicacion)
            {
                case 0:
                    {
                        Llenar_Producto(Global.nempresa);
                        Llenar_Clientes(Global.nempresa);
                        this.combo_transporte.Enabled = false;
                        this.combo_proveedor.Enabled = false;
                    } break;
                case 1:
                    {
                        Llenar_Producto(Global.nempresa);
                        Llenar_Proveedor(Global.nempresa);
                        Llenar_Transporte(Global.nempresa);
                        Llenar_Clientes(Global.nempresa);
                    } break;
                case 2:
                    {
                        Llenar_Producto(Global.nempresa);
                        Llenar_Proveedor(Global.nempresa);
                        Llenar_Clientes(Global.nempresa);
                        this.combo_transporte.Enabled = false;

                    } break;
            }
            Grid_Transaccion();
            band = -1;
            if (this.combo_producto.Items.Count <= 0)
            {
                MessageBox.Show(Global.M_Error[63, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cancelar_transaccion = true;
            }

            if (Global.aplicacion == 0)
            {
                if (this.combo_cliente.Items.Count <= 0)
                {
                    MessageBox.Show(Global.M_Error[66, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cancelar_transaccion = true;
                }
            }
            else
            {
                if (Global.aplicacion == 1)
                {
                    if (this.combo_transporte.Items.Count <= 0)
                    {
                        MessageBox.Show(Global.M_Error[66, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cancelar_transaccion = true;
                    }
                }
                if (this.combo_proveedor.Items.Count <= 0)
                {
                    MessageBox.Show(Global.M_Error[64, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cancelar_transaccion = true;
                }
                if (this.combo_cliente.Items.Count <= 0)
                {
                    MessageBox.Show(Global.M_Error[65, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cancelar_transaccion = true;
                }
            }
            if (this.cancelar_transaccion)
            {
                this.toolStripButton6_Click(this.toolStripButton6, new ToolBarButtonClickEventArgs(null));  
                this.Close();
                this.Dispose();
            }
            else Limpiar_Datos();
            //
            // TODO: Agregar código de constructor después de llamar a InitializeComponent
            //
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
        #region Windows Form Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transacciones3m));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pto3 = new System.Windows.Forms.TextBox();
            this.pto2 = new System.Windows.Forms.TextBox();
            this.pto1 = new System.Windows.Forms.TextBox();
            this.txt_um_pb = new System.Windows.Forms.Label();
            this.txt_um_pt = new System.Windows.Forms.Label();
            this.peso_neto = new System.Windows.Forms.TextBox();
            this.peso_tara = new System.Windows.Forms.TextBox();
            this.peso_bruto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_um_pn = new System.Windows.Forms.Label();
            this.txt_observa = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.combo_proveedor = new System.Windows.Forms.ComboBox();
            this.combo_transporte = new System.Windows.Forms.ComboBox();
            this.combo_producto = new System.Windows.Forms.ComboBox();
            this.combo_cliente = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolBar1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.GVTransaccion = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_guia = new MaskedTextBox.MaskedTextBox();
            this.txt_placa = new MaskedTextBox.MaskedTextBox();
            this.txt_embarque = new MaskedTextBox.MaskedTextBox();
            this.txt_factura = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tipo_mov = new System.Windows.Forms.ComboBox();
            this.txt_folio = new MaskedTextBox.MaskedTextBox();
            this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTransaccion)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.pto3);
            this.panel1.Controls.Add(this.pto2);
            this.panel1.Controls.Add(this.pto1);
            this.panel1.Controls.Add(this.txt_um_pb);
            this.panel1.Controls.Add(this.txt_um_pt);
            this.panel1.Controls.Add(this.peso_neto);
            this.panel1.Controls.Add(this.peso_tara);
            this.panel1.Controls.Add(this.peso_bruto);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_um_pn);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label18.Name = "label18";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label17.Name = "label17";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label12.Name = "label12";
            // 
            // pto3
            // 
            this.pto3.BackColor = System.Drawing.Color.Black;
            this.pto3.Cursor = System.Windows.Forms.Cursors.No;
            resources.ApplyResources(this.pto3, "pto3");
            this.pto3.ForeColor = System.Drawing.Color.White;
            this.pto3.Name = "pto3";
            this.pto3.ReadOnly = true;
            // 
            // pto2
            // 
            this.pto2.BackColor = System.Drawing.Color.Black;
            this.pto2.Cursor = System.Windows.Forms.Cursors.No;
            resources.ApplyResources(this.pto2, "pto2");
            this.pto2.ForeColor = System.Drawing.Color.White;
            this.pto2.Name = "pto2";
            this.pto2.ReadOnly = true;
            // 
            // pto1
            // 
            this.pto1.BackColor = System.Drawing.Color.Black;
            this.pto1.Cursor = System.Windows.Forms.Cursors.No;
            resources.ApplyResources(this.pto1, "pto1");
            this.pto1.ForeColor = System.Drawing.Color.White;
            this.pto1.Name = "pto1";
            this.pto1.ReadOnly = true;
            // 
            // txt_um_pb
            // 
            resources.ApplyResources(this.txt_um_pb, "txt_um_pb");
            this.txt_um_pb.ForeColor = System.Drawing.Color.Black;
            this.txt_um_pb.Name = "txt_um_pb";
            // 
            // txt_um_pt
            // 
            resources.ApplyResources(this.txt_um_pt, "txt_um_pt");
            this.txt_um_pt.ForeColor = System.Drawing.Color.Black;
            this.txt_um_pt.Name = "txt_um_pt";
            // 
            // peso_neto
            // 
            this.peso_neto.BackColor = System.Drawing.Color.Black;
            this.peso_neto.Cursor = System.Windows.Forms.Cursors.No;
            resources.ApplyResources(this.peso_neto, "peso_neto");
            this.peso_neto.ForeColor = System.Drawing.Color.Yellow;
            this.peso_neto.HideSelection = false;
            this.peso_neto.Name = "peso_neto";
            this.peso_neto.ReadOnly = true;
            // 
            // peso_tara
            // 
            this.peso_tara.BackColor = System.Drawing.Color.Black;
            this.peso_tara.Cursor = System.Windows.Forms.Cursors.No;
            resources.ApplyResources(this.peso_tara, "peso_tara");
            this.peso_tara.ForeColor = System.Drawing.Color.Yellow;
            this.peso_tara.HideSelection = false;
            this.peso_tara.Name = "peso_tara";
            this.peso_tara.ReadOnly = true;
            // 
            // peso_bruto
            // 
            this.peso_bruto.BackColor = System.Drawing.Color.Black;
            this.peso_bruto.Cursor = System.Windows.Forms.Cursors.No;
            resources.ApplyResources(this.peso_bruto, "peso_bruto");
            this.peso_bruto.ForeColor = System.Drawing.Color.Yellow;
            this.peso_bruto.HideSelection = false;
            this.peso_bruto.Name = "peso_bruto";
            this.peso_bruto.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Name = "label1";
            // 
            // txt_um_pn
            // 
            resources.ApplyResources(this.txt_um_pn, "txt_um_pn");
            this.txt_um_pn.ForeColor = System.Drawing.Color.Black;
            this.txt_um_pn.Name = "txt_um_pn";
            // 
            // txt_observa
            // 
            resources.ApplyResources(this.txt_observa, "txt_observa");
            this.txt_observa.Name = "txt_observa";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // combo_proveedor
            // 
            this.combo_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.combo_proveedor, "combo_proveedor");
            this.combo_proveedor.Name = "combo_proveedor";
            // 
            // combo_transporte
            // 
            this.combo_transporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.combo_transporte, "combo_transporte");
            this.combo_transporte.Name = "combo_transporte";
            // 
            // combo_producto
            // 
            this.combo_producto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.combo_producto, "combo_producto");
            this.combo_producto.Name = "combo_producto";
            // 
            // combo_cliente
            // 
            this.combo_cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.combo_cliente, "combo_cliente");
            this.combo_cliente.Name = "combo_cliente";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.combo_proveedor);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.combo_producto);
            this.groupBox3.Controls.Add(this.combo_transporte);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.combo_cliente);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // toolBar1
            // 
            this.toolBar1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton5,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton6});
            this.toolBar1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            resources.ApplyResources(this.toolBar1, "toolBar1");
            this.toolBar1.Name = "toolBar1";
            // 
            // toolStripButton1
            // 
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton5
            // 
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
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
            // toolStripButton4
            // 
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
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
            // toolStripButton6
            // 
            resources.ApplyResources(this.toolStripButton6, "toolStripButton6");
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "of {0}";
            this.bindingNavigator1.DeleteItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            resources.ApplyResources(this.bindingNavigatorSeparator2, "bindingNavigatorSeparator2");
            // 
            // GVTransaccion
            // 
            this.GVTransaccion.AllowUserToAddRows = false;
            this.GVTransaccion.AllowUserToDeleteRows = false;
            this.GVTransaccion.AutoGenerateColumns = false;
            this.GVTransaccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GVTransaccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVTransaccion.DataSource = this.bindingSource1;
            resources.ApplyResources(this.GVTransaccion, "GVTransaccion");
            this.GVTransaccion.MultiSelect = false;
            this.GVTransaccion.Name = "GVTransaccion";
            this.GVTransaccion.ReadOnly = true;
            this.GVTransaccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_guia);
            this.groupBox4.Controls.Add(this.txt_placa);
            this.groupBox4.Controls.Add(this.txt_embarque);
            this.groupBox4.Controls.Add(this.txt_factura);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tipo_mov);
            this.groupBox4.Controls.Add(this.txt_folio);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // txt_guia
            // 
            this.txt_guia.DateOnly = false;
            this.txt_guia.DecimalOnly = false;
            this.txt_guia.DigitOnly = true;
            this.txt_guia.IPAddrOnly = false;
            resources.ApplyResources(this.txt_guia, "txt_guia");
            this.txt_guia.Name = "txt_guia";
            this.txt_guia.PhoneWithAreaCode = false;
            this.txt_guia.SSNOnly = false;
            // 
            // txt_placa
            // 
            this.txt_placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_placa.DateOnly = false;
            this.txt_placa.DecimalOnly = false;
            this.txt_placa.DigitOnly = false;
            this.txt_placa.IPAddrOnly = false;
            resources.ApplyResources(this.txt_placa, "txt_placa");
            this.txt_placa.Name = "txt_placa";
            this.txt_placa.PhoneWithAreaCode = false;
            this.txt_placa.SSNOnly = false;
            // 
            // txt_embarque
            // 
            this.txt_embarque.DateOnly = false;
            this.txt_embarque.DecimalOnly = false;
            this.txt_embarque.DigitOnly = false;
            this.txt_embarque.IPAddrOnly = false;
            resources.ApplyResources(this.txt_embarque, "txt_embarque");
            this.txt_embarque.Name = "txt_embarque";
            this.txt_embarque.PhoneWithAreaCode = false;
            this.txt_embarque.SSNOnly = false;
            // 
            // txt_factura
            // 
            this.txt_factura.DateOnly = false;
            this.txt_factura.DecimalOnly = false;
            this.txt_factura.DigitOnly = false;
            this.txt_factura.IPAddrOnly = false;
            resources.ApplyResources(this.txt_factura, "txt_factura");
            this.txt_factura.Name = "txt_factura";
            this.txt_factura.PhoneWithAreaCode = false;
            this.txt_factura.SSNOnly = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // tipo_mov
            // 
            this.tipo_mov.Cursor = System.Windows.Forms.Cursors.Default;
            this.tipo_mov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.tipo_mov, "tipo_mov");
            this.tipo_mov.Name = "tipo_mov";
            // 
            // txt_folio
            // 
            this.txt_folio.BackColor = System.Drawing.Color.Yellow;
            this.txt_folio.Cursor = System.Windows.Forms.Cursors.No;
            this.txt_folio.DateOnly = false;
            this.txt_folio.DecimalOnly = false;
            this.txt_folio.DigitOnly = true;
            resources.ApplyResources(this.txt_folio, "txt_folio");
            this.txt_folio.ForeColor = System.Drawing.Color.Navy;
            this.txt_folio.IPAddrOnly = false;
            this.txt_folio.Name = "txt_folio";
            this.txt_folio.PhoneWithAreaCode = false;
            this.txt_folio.ReadOnly = true;
            this.txt_folio.SSNOnly = false;
            // 
            // axShockwaveFlash1
            // 
            resources.ApplyResources(this.axShockwaveFlash1, "axShockwaveFlash1");
            this.axShockwaveFlash1.Name = "axShockwaveFlash1";
            this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Transacciones3m
            // 
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.axShockwaveFlash1);
            this.Controls.Add(this.GVTransaccion);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.txt_observa);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.groupBox3);
            this.Name = "Transacciones3m";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Transacciones3m_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.toolBar1.ResumeLayout(false);
            this.toolBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTransaccion)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private void Transacciones3m_Load(object sender, EventArgs e)
        {
            if (Global.display) RS232.inicia(ref this.serialPort4, Global.P_COMM, Global.Buad, ref mensaje3);
            if (RS232.inicia(ref this.serialPort1, Global.P_COMM1, Global.Buad1, ref mensaje1)) Global.local1 = true;
            else Global.local1 = false;
            if (RS232.inicia(ref this.serialPort2, Global.P_COMM2, Global.Buad2, ref mensaje2)) Global.local2 = true;
            else Global.local2 = false;
            if (RS232.inicia(ref this.serialPort3, Global.P_COMM3, Global.Buad3, ref mensaje3)) Global.local3 = true;
            else Global.local3 = false;
            if (Global.local1 || Global.local2 || Global.local3)
            {
                this.timer1.Interval = 1000;
                this.timer1.Enabled = true;
                this.timer1.Start();
                this.timer2.Interval = 10000;
                this.timer2.Enabled = true;
                this.timer2.Start();
            }
        }
        
        #region FUNCTIONS
        #region Funcion de manejo de Datos en DB
        private void update_existencia(Double p_neto)
        {
            Double t_existencia = 0;
            Double exist_act = 0;
            bool existe = true;
            IDataReader tt = db.getDataReader("SELECT existencia FROM ARTICULOS WHERE numero = " + this.combo_producto.SelectedValue + " and numemp = " + Global.nempresa);
            if (tt.Read())
            {
                existe = true;
                exist_act = tt.GetInt32(0);
            }
            else
            {
                existe = false;
                exist_act = 0;
            }
            tt.Close();

            if (existe)
            {
                Label texto = new Label();
                texto.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                texto.Text = Global.M_Error[182, Global.idioma].ToUpper();
                if (MessageBox.Show(texto.Text, Global.M_Error[183, Global.idioma], MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    t_existencia = exist_act + p_neto;
                    Global.INVENTARIO = Global.M_Error[225, Global.idioma];
                    Conec.CadenaSelect = "UPDATE Historia SET UDM = '1' WHERE (folio = " + Convert.ToInt32(this.txt_folio.Text) + " and numemp = " + Global.nempresa + ")";
                }
                else
                {
                    t_existencia = exist_act - p_neto;
                    Global.INVENTARIO = Global.M_Error[226, Global.idioma];
                    Conec.CadenaSelect = "UPDATE Historia SET UDM = '0' WHERE (folio = " + Convert.ToInt32(this.txt_folio.Text) + " and numemp = " + Global.nempresa + ")";
                }

                db.ExcetuteQuery(Conec.CadenaSelect);


                Conec.Condicion = "(numero = " + this.combo_producto.SelectedValue + " and numemp = " + Global.nempresa + ")";
                Conec.CadenaSelect = "UPDATE Articulos SET existencia = " + t_existencia + " WHERE " + Conec.Condicion;

                db.ExcetuteQuery(Conec.CadenaSelect);
            }
        }

        private int Folio_Nuevo()
        {
            int next_folio = 0;
            int folio_config = 0;
            int cod = 0;

            IDataReader Cfg = db.getDataReader("SELECT folio FROM configuracion");
            if (Cfg.Read()) folio_config = Cfg.GetInt32(0);
            else Cfg.Close();

            IDataReader LP = db.getDataReader("SELECT folio FROM Historia WHERE (numemp = " + Global.nempresa + ") ORDER BY folio desc");
            if (LP.Read()) cod = Convert.ToInt32(LP.GetValue(0));
            LP.Close();

            if (cod > 0)
            {
                if (folio_config <= cod)  //Convert.ToInt32(Conec.dbDataSet.Tables["Historia"].Rows[cod - 1]["folio"].ToString()))
                    next_folio = cod + 1;  //Convert.ToInt32(Conec.dbDataSet.Tables["Historia"].Rows[cod - 1]["folio"].ToString()) + 1;
                else next_folio = folio_config;
            }
            else next_folio = folio_config;

            return next_folio;
        }
        private void New_Historial()
        {

            if (Global.aplicacion == 0)
            {
                Conec.CadenaSelect = "INSERT INTO Historia (numemp,folio,mov,placas, movimiento,guia,factura,embarque,producto,cliente,fecha1,hora1,pesobruto,pesoneto,pesotara,status,eje1a,eje2a,eje3a,inicial,nombre,taramanual,observacion,um) VALUES ( " +
                Global.nempresa + "," + Convert.ToInt32(this.txt_folio.Text) + ",'" + this.tipo_mov.SelectedIndex.ToString() + "','" + this.txt_placa.Text + "','" + this.tipo_mov.SelectedItem + "','" +
                this.txt_guia.Text + "','" + this.txt_factura.Text + "','" + this.txt_embarque.Text + "'," + this.combo_producto.SelectedValue + "," + this.combo_cliente.SelectedValue + ",'" +
                string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "','" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "  " + string.Format("{0:" + Global.F_Hora + "}", DateTime.Now) + "'," + this.peso_bruto.Text + "," + this.peso_neto.Text + "," + this.peso_tara.Text + ",'P','" + this.pto1.Text + "','" + this.pto2.Text + "','" + this.pto3.Text + "','" + Global.user + "','" + Global.Nombre + "'," + this.tara_manual + ",'" + this.txt_observa.Text + "','" + this.txt_um_pt.Text + "')";
            }
            if (Global.aplicacion == 1)
            {
                Conec.CadenaSelect = "INSERT INTO Historia (numemp,folio,mov,placas, movimiento,guia,factura,embarque,producto,transporte,proveedor,cliente,fecha1,hora1,pesobruto,pesoneto,pesotara,status,eje1a,eje2a,eje3a,inicial,nombre,taramanual,observacion,um) VALUES ( " +
                Global.nempresa + "," + Convert.ToInt32(this.txt_folio.Text) + ",'" + this.tipo_mov.SelectedIndex.ToString() + "','" + this.txt_placa.Text + "','" + this.tipo_mov.SelectedItem + "','" +
                this.txt_guia.Text + "','" + this.txt_factura.Text + "','" + this.txt_embarque.Text + "'," +
                this.combo_producto.SelectedValue + "," + this.combo_transporte.SelectedValue + "," + this.combo_proveedor.SelectedValue + "," + this.combo_cliente.SelectedValue + ",'" +
                string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "','" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "  " + string.Format("{0:" + Global.F_Hora + "}", DateTime.Now) + "'," + this.peso_bruto.Text + "," + this.peso_neto.Text + "," + this.peso_tara.Text + ",'P','" + this.pto1.Text + "','" + this.pto2.Text + "','" + this.pto3.Text + "','" + Global.user + "','" + Global.Nombre + "'," + this.tara_manual + ",'" + this.txt_observa.Text + "','" + this.txt_um_pt.Text + "')";
            }
            if (Global.aplicacion == 2)
            {
                Conec.CadenaSelect = "INSERT INTO Historia (numemp,folio,mov,placas, movimiento,guia,factura,embarque,producto,proveedor,cliente,fecha1,hora1,pesobruto,pesoneto,pesotara,status,eje1a,eje2a,eje3a,inicial,nombre,taramanual,observacion,um) VALUES ( " +
                Global.nempresa + "," + Convert.ToInt32(this.txt_folio.Text) + ",'" + this.tipo_mov.SelectedIndex.ToString() + "','" + this.txt_placa.Text + "','" + this.tipo_mov.SelectedItem + "','" +
                this.txt_guia.Text + "','" + this.txt_factura.Text + "','" + this.txt_embarque.Text + "'," +
                this.combo_producto.SelectedValue + "," + this.combo_proveedor.SelectedValue + "," + this.combo_cliente.SelectedValue + ",'" +
                string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "','" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "  " + string.Format("{0:" + Global.F_Hora + "}", DateTime.Now) + "'," + this.peso_bruto.Text + "," + this.peso_neto.Text + "," + this.peso_tara.Text + ",'P','" + this.pto1.Text + "','" + this.pto2.Text + "','" + this.pto3.Text + "','" + Global.user + "','" + Global.Nombre + "'," + this.tara_manual + ",'" + this.txt_observa.Text + "','" + this.txt_um_pt.Text + "')";
            }
            if (this.txt_folio.Text != "" && this.txt_folio.Text != "0")
            {
                db.ExcetuteQuery(Conec.CadenaSelect);
                //Conec.InsertarReader(Conec.CadenaConexion, Conec.CadenaSelect, "Historia");

                dt = db.getData("SELECT * FROM Historia WHERE(numemp = " + Global.nempresa + ") ORDER BY FOLIO");
            }
            else
            {
                MessageBox.Show(Global.M_Error[89, Global.idioma].ToString());
            }
        }
        private void New()
        {

            if (Global.aplicacion == 0)
            {
                Conec.CadenaSelect = "INSERT INTO " + Conec.NombreTabla + " (numemp,folio,mov,placas, movimiento,guia,factura,embarque,producto,cliente,fecha1,hora1,pesobruto,pesoneto,pesotara,taramanual,observacion) VALUES ( " +
                    Global.nempresa + "," + Convert.ToInt32(this.txt_folio.Text) + ",'" + this.tipo_mov.SelectedIndex.ToString() + "','" + this.txt_placa.Text + "','" + this.tipo_mov.SelectedItem + "','" +
                    this.txt_guia.Text + "','" + this.txt_factura.Text + "','" + this.txt_embarque.Text + "'," +
                    this.combo_producto.SelectedValue + "," + this.combo_cliente.SelectedValue + ",'" +
                    string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "','" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "  " + string.Format("{0:" + Global.F_Hora + "}", DateTime.Now) + "'," + this.peso_bruto.Text + "," + this.peso_neto.Text + "," + this.peso_tara.Text + "," + this.tara_manual + ",'" + this.txt_observa.Text + "')";
            }
            if (Global.aplicacion == 1)
            {
                Conec.CadenaSelect = "INSERT INTO " + Conec.NombreTabla + " (numemp,folio,mov,placas, movimiento,guia,factura,embarque,producto,transporte,proveedor,cliente,fecha1,hora1,pesobruto,pesoneto,pesotara,taramanual,observacion) VALUES ( " +
                    Global.nempresa + "," + Convert.ToInt32(this.txt_folio.Text) + ",'" + this.tipo_mov.SelectedIndex.ToString() + "','" + this.txt_placa.Text + "','" + this.tipo_mov.SelectedItem + "','" +
                    this.txt_guia.Text + "','" + this.txt_factura.Text + "','" + this.txt_embarque.Text + "'," +
                    this.combo_producto.SelectedValue + "," + this.combo_transporte.SelectedValue + "," + this.combo_proveedor.SelectedValue + "," + this.combo_cliente.SelectedValue + ",'" +
                    string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "','" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "  " + string.Format("{0:" + Global.F_Hora + "}", DateTime.Now) + "'," + this.peso_bruto.Text + "," + this.peso_neto.Text + "," + this.peso_tara.Text + "," + this.tara_manual + ",'" + this.txt_observa.Text + "')";
            }
            if (Global.aplicacion == 2)
            {
                Conec.CadenaSelect = "INSERT INTO " + Conec.NombreTabla + " (numemp,folio,mov,placas, movimiento,guia,factura,embarque,producto,proveedor,cliente,fecha1,hora1,pesobruto,pesoneto,pesotara,taramanual,observacion) VALUES ( " +
                    Global.nempresa + "," + Convert.ToInt32(this.txt_folio.Text) + ",'" + this.tipo_mov.SelectedIndex.ToString() + "','" + this.txt_placa.Text + "','" + this.tipo_mov.SelectedItem + "','" +
                    this.txt_guia.Text + "','" + this.txt_factura.Text + "','" + this.txt_embarque.Text + "'," +
                    this.combo_producto.SelectedValue + "," + this.combo_proveedor.SelectedValue + "," + this.combo_cliente.SelectedValue + ",'" +
                    string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "','" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "  " + string.Format("{0:" + Global.F_Hora + "}", DateTime.Now) + "'," + this.peso_bruto.Text + "," + this.peso_neto.Text + "," + this.peso_tara.Text + "," + this.tara_manual + ",'" + this.txt_observa.Text + "')";
            }

            if (this.txt_folio.Text != "" && this.txt_folio.Text != "0")
            {
                try
                {
                    IDataReader LP = db.getDataReader("SELECT numemp, folio FROM Historia WHERE (numemp = " + Global.nempresa + " and folio = " + Convert.ToInt32(this.txt_folio.Text) + ")");
                    if (!LP.Read())
                    {
                        LP.Close();
                        db.ExcetuteQuery(Conec.CadenaSelect);
                        New_Historial();
                    }
                    else
                    {
                        LP.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Global.M_Error[89, Global.idioma].ToString());
            }
        }
        private bool Actualiza_Historia()
        {
            try
            {
                object movimiento = this.tipo_mov.SelectedItem;
                int n_movi = this.tipo_mov.SelectedIndex;
                Double p_neto = Convert.ToDouble(this.peso_neto.Text);

                if (Global.aplicacion == 0)
                {
                    Conec.Condicion = "(folio = " + Convert.ToInt32(this.txt_folio.Text) + " and numemp = " + Global.nempresa + " and status = 'P')";
                    Conec.CadenaSelect = "UPDATE Historia SET um = '" + this.txt_um_pn.Text + "', mov = '" + n_movi.ToString() + "', movimiento = '" + movimiento + "', inicial = '" + Global.user +
                        "', guia = '" + this.txt_guia.Text + "', factura = '" + this.txt_factura.Text + "', embarque ='" + this.txt_embarque.Text + "',observacion = '" + this.txt_observa.Text +
                        "', producto = " + this.combo_producto.SelectedValue + ", cliente = " + this.combo_cliente.SelectedValue + ", eje1b = '" + this.pto1.Text + "',eje2b ='" + this.pto2.Text + "',eje3b= '" + this.pto3.Text +
                        "', fecha2 = '" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "', hora2 = '" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + " " + string.Format("{0:" + Global.F_Hora + "}", DateTime.Now) + "', nombre = ' " + Global.Nombre +
                        "', pesobruto = '" + this.peso_bruto.Text + "', pesotara = '" + this.peso_tara.Text + "', pesoneto = '" + this.peso_neto.Text + "', taramanual = " + this.tara_manual + ", status = 'F' WHERE " + Conec.Condicion;
                }
                if (Global.aplicacion == 1)
                {
                    Conec.Condicion = "(folio = " + Convert.ToInt32(this.txt_folio.Text) + " and numemp = " + Global.nempresa + " and status = 'P')";
                    Conec.CadenaSelect = "UPDATE Historia SET um = '" + this.txt_um_pn.Text + "',mov = '" + n_movi.ToString() + "', movimiento = '" + movimiento + "', inicial = '" + Global.user +
                        "', guia = '" + this.txt_guia.Text + "', factura = '" + this.txt_factura.Text + "', embarque ='" + this.txt_embarque.Text + "',observacion = '" + this.txt_observa.Text +
                        "', producto = " + this.combo_producto.SelectedValue + ", transporte = " + this.combo_transporte.SelectedValue + ", proveedor = " + this.combo_proveedor.SelectedValue +
                        ", cliente = " + this.combo_cliente.SelectedValue + ", fecha2 = '" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "', hora2 = '" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "  " + string.Format("{0:" + Global.F_Hora + "}", DateTime.Now) + "', nombre = ' " + Global.Nombre + "', eje1b = '" + this.pto1.Text + "',eje2b ='" + this.pto2.Text + "',eje3b= '" + this.pto3.Text +
                        "', pesobruto = '" + this.peso_bruto.Text + "', pesotara = '" + this.peso_tara.Text + "', pesoneto = '" + this.peso_neto.Text + "', taramanual = " + this.tara_manual + ", status = 'F' WHERE " + Conec.Condicion;
                }
                if (Global.aplicacion == 2)
                {
                    Conec.Condicion = "(folio = " + Convert.ToInt32(this.txt_folio.Text) + " and numemp = " + Global.nempresa + " and status = 'P')";
                    Conec.CadenaSelect = "UPDATE Historia SET um = '" + this.txt_um_pn.Text + "',mov = '" + n_movi.ToString() + "', movimiento = '" + movimiento + "', inicial = '" + Global.user +
                        "',guia = '" + this.txt_guia.Text + "', factura = '" + this.txt_factura.Text + "', embarque ='" + this.txt_embarque.Text + "',observacion = '" + this.txt_observa.Text +
                        "', producto = " + this.combo_producto.SelectedValue + ", proveedor = " + this.combo_proveedor.SelectedValue + ", eje1b = '" + this.pto1.Text + "',eje2b ='" + this.pto2.Text + "',eje3b= '" + this.pto3.Text +
                        "', cliente = " + this.combo_cliente.SelectedValue + ", fecha2 = '" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "', hora2 = '" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + "  " + string.Format("{0:" + Global.F_Hora + "}", DateTime.Now) + "', nombre = ' " + Global.Nombre +
                        "', pesobruto = '" + this.peso_bruto.Text + "', pesotara = '" + this.peso_tara.Text + "', pesoneto = '" + this.peso_neto.Text + "', taramanual = " + this.tara_manual + ", status = 'F' WHERE " + Conec.Condicion;
                }

                db.ExcetuteQuery(Conec.CadenaSelect);

                if (Global.aplicacion == 1) update_existencia(p_neto);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool Cancelar_Historia()
        {
            try
            {
                Conec.Condicion = "(folio = " + Convert.ToInt32(this.txt_folio.Text) + " and numemp = " + Global.nempresa + ")";
                Conec.CadenaSelect = "UPDATE Historia SET fecha2 = '" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) +
                    "', hora2 = '" + string.Format("{0:" + Global.F_Fecha + "}", DateTime.Today) + " " + string.Format("{0:" + Global.F_Hora + "}", DateTime.Now) + "', status = 'C' , observacion = '" + this.txt_observa.Text + "' WHERE " + Conec.Condicion;
                db.ExcetuteQuery(Conec.CadenaSelect);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void Del()
        {
            if (this.txt_folio.Text != "")
            {
                Conec.Condicion = "( folio = " + Convert.ToInt32(this.txt_folio.Text) + " and numemp = " + Global.nempresa + ")";
                Conec.CadenaSelect = "DELETE * FROM " + Conec.NombreTabla + " WHERE " + Conec.Condicion;

                if (dt.Tables[Conec.NombreTabla].Rows.Count > 0)
                {
                    DataRow[] dr = dt.Tables[Conec.NombreTabla].Select("folio = " + Convert.ToInt32(this.txt_folio.Text));  //.Rows[cmAgente.Position];
                    if (dr.Length > 0)
                    {
                        dr[0].Delete();

                        DataSet DSChanges = dt.GetChanges(DataRowState.Deleted);

                        if (DSChanges != null)
                        {
                            try
                            {
                                db.ExcetuteQuery(Conec.CadenaSelect);
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
                                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dt.RejectChanges();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(Global.M_Error[2, Global.idioma].ToString());
                }
            }
            else
            {
                MessageBox.Show(Global.M_Error[305, Global.idioma].ToString());
            }
        }

        private void Mostrar_Datos(int pos, int op)
        {

            if (dt.Tables[Conec.NombreTabla].Rows.Count > 0)
            {
                DataRow dr = dt.Tables[Conec.NombreTabla].Rows[pos];
                this.txt_folio.Text = dr["folio"].ToString();
                if (Convert.ToInt16(dr["mov"].ToString()) == 0) this.tipo_mov.SelectedIndex = 1;
                else this.tipo_mov.SelectedIndex = 0;
                this.txt_placa.Text = dr["placas"].ToString();
                this.txt_guia.Text = dr["guia"].ToString();
                this.txt_factura.Text = dr["factura"].ToString();
                this.txt_embarque.Text = dr["embarque"].ToString();
                this.peso_bruto.Text = dr["pesobruto"].ToString();
                this.peso_tara.Text = dr["pesotara"].ToString();
                this.txt_observa.Text = dr["observacion"].ToString();
                this.tara_manual = Convert.ToInt32(dr["taramanual"].ToString());
                this.combo_producto.SelectedValue = dr["producto"].ToString();
                if (Global.aplicacion == 1) this.combo_transporte.SelectedValue = dr["transporte"].ToString();
                if (Global.aplicacion != 0) this.combo_proveedor.SelectedValue = dr["proveedor"].ToString();
                this.combo_cliente.SelectedValue = dr["cliente"].ToString();
                this.toolStripButton5.Enabled = true;
                this.txt_placa.Focus();
            }
        }
        private void Limpiar_Datos()
        {
            this.tipo_mov.SelectedIndex = 0;
            this.txt_placa.Text = "";
            this.txt_guia.Text = "";
            this.txt_factura.Text = "";
            this.txt_embarque.Text = "";
            this.peso_tara.Text = "";
            this.peso_bruto.Text = "";
            this.tara_manual = 0;
            this.txt_observa.Text = "";
            this.combo_producto.SelectedIndex = 0;
            this.combo_cliente.SelectedIndex = 0;
            Global.INVENTARIO = "";
            if (Global.aplicacion == 1) this.combo_transporte.SelectedIndex = 0;
            if (Global.aplicacion != 0) this.combo_proveedor.SelectedIndex = 0;
            this.GVTransaccion.ClearSelection();
            this.txt_folio.Text = Convert.ToString(Folio_Nuevo());
            this.txt_placa.Focus();
        }
        #endregion
        #region Funciones para llenado de datos grid, combox
        private void Grid_Transaccion()
        {

            para1 = Global.M_Error[206, Global.idioma].ToString();
            campo = "folio";

            DataGridViewTextBoxColumn colStyle1 = new DataGridViewTextBoxColumn();
            colStyle1.HeaderText = Global.M_Error[206, Global.idioma].ToString();
            colStyle1.Width = 60;
            colStyle1.DefaultCellStyle.NullValue = "0";
            colStyle1.DefaultCellStyle.Format = "####";
            colStyle1.DataPropertyName = "folio";
            colStyle1.MaxInputLength = 4;
            DataGridViewTextBoxColumn colStyle2 = new DataGridViewTextBoxColumn();
            colStyle2.HeaderText = Global.M_Error[224, Global.idioma].ToString();
            colStyle2.Width = 250;
            colStyle2.DefaultCellStyle.NullValue = "";
            colStyle2.DataPropertyName = "movimiento";
            colStyle2.MaxInputLength = 40;
            DataGridViewTextBoxColumn colStyle3 = new DataGridViewTextBoxColumn();
            colStyle3.HeaderText = Global.M_Error[213, Global.idioma].ToString();
            colStyle3.Width = 100;
            colStyle3.DefaultCellStyle.NullValue = "";
            colStyle3.DataPropertyName = "placas";
            colStyle3.MaxInputLength = 40;

            DataGridViewTextBoxColumn colStyle7 = new DataGridViewTextBoxColumn();
            colStyle7.HeaderText = Global.M_Error[195, Global.idioma].ToString() + " " + Global.M_Error[196, Global.idioma].ToString();
            colStyle7.Width = 150;
            colStyle7.DefaultCellStyle.NullValue = "";
            colStyle7.DataPropertyName = "hora1";
            colStyle7.MaxInputLength = 100;
            DataGridViewTextBoxColumn colStyle4 = new DataGridViewTextBoxColumn();
            colStyle4.HeaderText = Global.M_Error[121, Global.idioma].ToString();
            colStyle4.Width = 300;
            colStyle4.DefaultCellStyle.NullValue = "";
            colStyle4.DataPropertyName = "observacion";
            colStyle4.MaxInputLength = 250;

            this.GVTransaccion.Columns.Add(colStyle1);
            this.GVTransaccion.Columns.Add(colStyle2);
            this.GVTransaccion.Columns.Add(colStyle3);
            this.GVTransaccion.Columns.Add(colStyle7);
            this.GVTransaccion.Columns.Add(colStyle4);

            cmRegister = (CurrencyManager)this.BindingContext[Conec.dbDataSet, Conec.NombreTabla];
        }
        private void Llenar_Producto(int n_empresa)
        {
            try
            {
                OleDbDataAdapter myDataAdapter4;
                myDataAdapter4 = new OleDbDataAdapter("SELECT numero,descripcion,existencia,tarifa FROM ARTICULOS WHERE (numemp = " + n_empresa + ") ORDER BY numero", Conec.dbConnection);
                myDataAdapter4.Fill(Conec.dbDataSet, "ARTICULOS");
                this.combo_producto.ValueMember = "numero";
                this.combo_producto.DisplayMember = "descripcion";
                this.combo_producto.DataSource = Conec.dbDataSet.Tables["ARTICULOS"];
                if (Conec.dbDataSet.Tables["ARTICULOS"].Rows.Count > 0) this.combo_producto.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Llenar_Proveedor(int n_empresa)
        {
            try
            {
                OleDbDataAdapter myDataAdapter4;
                myDataAdapter4 = new OleDbDataAdapter("SELECT numero,nombre FROM PROVEEDOR WHERE (numemp = " + n_empresa + ") ORDER BY numero", Conec.dbConnection);
                myDataAdapter4.Fill(Conec.dbDataSet, "PROVEEDOR");
                this.combo_proveedor.ValueMember = "numero";
                this.combo_proveedor.DisplayMember = "nombre";
                this.combo_proveedor.DataSource = Conec.dbDataSet.Tables["PROVEEDOR"];
                if (Conec.dbDataSet.Tables["PROVEEDOR"].Rows.Count > 0) this.combo_proveedor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Llenar_Transporte(int n_empresa)
        {
            try
            {
                OleDbDataAdapter myDataAdapter4;
                myDataAdapter4 = new OleDbDataAdapter("SELECT numero,descripcion FROM TRANSPORTISTAS WHERE (numemp = " + n_empresa + ") ORDER BY numero", Conec.dbConnection);
                myDataAdapter4.Fill(Conec.dbDataSet, "TRANSPORTISTAS");
                this.combo_transporte.ValueMember = "numero";
                this.combo_transporte.DisplayMember = "descripcion";
                this.combo_transporte.DataSource = Conec.dbDataSet.Tables["TRANSPORTISTAS"];
                if (Conec.dbDataSet.Tables["TRANSPORTISTAS"].Rows.Count > 0) this.combo_transporte.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Llenar_Clientes(int n_empresa)
        {
            try
            {
                OleDbDataAdapter myDataAdapter4;
                myDataAdapter4 = new OleDbDataAdapter("SELECT numero,nombre FROM CLIENTE WHERE (numemp = " + n_empresa + ") ORDER BY numero", Conec.dbConnection);
                myDataAdapter4.Fill(Conec.dbDataSet, "CLIENTE");
                this.combo_cliente.ValueMember = "numero";
                this.combo_cliente.DisplayMember = "nombre";
                this.combo_cliente.DataSource = Conec.dbDataSet.Tables["CLIENTE"];
                if (Conec.dbDataSet.Tables["CLIENTE"].Rows.Count > 0) this.combo_cliente.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Llenar_Grid()
        {
            Conec.NombreTabla = "transaccion";
            Conec.CadenaSelect = "SELECT * FROM " + Conec.NombreTabla + " WHERE( numemp = " + Global.nempresa + " ) ORDER BY FOLIO";
            //Conec.Conectar(Conec.ArchivoDatos, Conec.CadenaSelect, Conec.NombreTabla);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("SELECT * FROM Historia WHERE(numemp = " + Global.nempresa + ") ORDER BY FOLIO", Conec.dbConnection);
            myDataAdapter.Fill(Conec.dbDataSet, "Historia");
            Conec.dbDataSet.Tables["Historia"].PrimaryKey = new DataColumn[] { Conec.dbDataSet.Tables["Historia"].Columns["folio"] };

            Conec.dbDataSet.Tables[Conec.NombreTabla].PrimaryKey = new DataColumn[] { Conec.dbDataSet.Tables[Conec.NombreTabla].Columns["folio"] };

            this.bindingSource1.DataSource = Conec.dbDataSet;
            this.bindingSource1.DataMember = Conec.NombreTabla;
            this.bindingNavigator1.BindingSource = this.bindingSource1;

            cmRegister = (CurrencyManager)this.BindingContext[Conec.dbDataSet, Conec.NombreTabla];

        }
        #endregion
        private void SetText1(string text, string um)
        {
            try
            {

                if (this.pto1.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText1);
                    this.Invoke(d, new object[] { text, um });
                }
                else
                {
                    this.pto1.Text = text;
                    this.pto1.Tag = um;
                    Peso_Neto();
                }
            }
            catch (System.ObjectDisposedException e)
            {
                System.Console.Write(e.Message);
            }
        }
        private void SetText2(string text, string um)
        {
            try
            {
                if (this.pto2.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText2);
                    this.Invoke(d, new object[] { text, um });
                }
                else
                {
                    this.pto2.Text = text;
                    this.pto2.Tag = um;
                    Peso_Neto();
                }
            }
            catch (System.ObjectDisposedException e)
            {
                System.Console.Write(e.Message);
            }
        }
        private void SetText3(string text, string um)
        {
            try
            {

                if (this.pto3.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText3);
                    this.Invoke(d, new object[] { text, um });
                }
                else
                {
                    this.pto3.Text = text;
                    this.pto3.Tag = um;
                    Peso_Neto();
                }
            }
            catch (System.ObjectDisposedException e)
            {
                System.Console.Write(e.Message);
            }
        }
        private void Peso_Neto()
        {
            string txt_um = "";
            int peso1 = 0, peso2 = 0, peso3 = 0;

            try
            {
                if (this.pto1.Text != "") peso1 = Convert.ToInt32(this.pto1.Text);
                if (this.pto2.Text != "") peso2 = Convert.ToInt32(this.pto2.Text);
                if (this.pto3.Text != "") peso3 = Convert.ToInt32(this.pto3.Text);
                if (this.pto1.Tag != null) txt_um = this.pto1.Tag.ToString();
                if (this.pto2.Tag != null) txt_um = this.pto2.Tag.ToString();
                if (this.pto3.Tag != null) txt_um = this.pto3.Tag.ToString();

                if (this.tipo_mov.SelectedIndex == 0)
                {
                    this.peso_bruto.Text = Convert.ToString(peso1 + peso2 + peso3);
                    this.txt_um_pb.Text = txt_um;
                    this.nombre_swf1 = Global.appPath + "\\llenoSube3.swf";
                    this.nombre_swf2 = Global.appPath + "\\llenoBaja3.swf";
                }
                else
                {
                    this.peso_tara.Text = Convert.ToString(peso1 + peso2 + peso3);
                    this.txt_um_pt.Text = txt_um;
                    this.nombre_swf1 = Global.appPath + "\\vacioSube3.swf";
                    this.nombre_swf2 = Global.appPath + "\\vacioBaja3.swf";
                }
                if (this.peso_bruto.Text == "") this.peso_bruto.Text = "0";
                if (this.peso_tara.Text == "") this.peso_tara.Text = "0";

                if (this.peso_tara.Text != "" && this.peso_bruto.Text != "")
                {
                    this.peso_neto.Text = Convert.ToString(Convert.ToDouble(this.peso_bruto.Text) - Convert.ToDouble(this.peso_tara.Text));
                    this.txt_um_pn.Text = txt_um;
                    mensaje = this.peso_neto.Text;
                    //if (Convert.ToDouble(this.peso_neto.Text) == 0)
                    if (this.peso_neto.Text == "0" || this.peso_neto.Text == "0.0")
                    {
                        if (band >= 0 && band <= 20)
                        {
                            this.nombre_swf1 = this.nombre_swf2;
                            band++;
                        }
                        else this.nombre_swf1 = Global.appPath + "\\baseVacia3.swf";
                    }
                    else band = 0;
                    axShockwaveFlash1.Movie = this.nombre_swf1;
                }
                else axShockwaveFlash1.Movie = Global.appPath + "\\baseVacia3.swf";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        #region EVENTS
        #region Eventos para el IO de puerto serial
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Global.local1 && Global.scale == 0) RS232.SendData(ref this.serialPort3, ref mensaje3, "P");
            if (Global.local2 && Global.scale == 0) RS232.SendData(ref this.serialPort2, ref mensaje2, "P");
            if (Global.local3 && Global.scale == 0) RS232.SendData(ref this.serialPort1, ref mensaje1, "P");
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            Llenar_Grid();
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort S_RS232 = (SerialPort)sender;
            string txt_um = "";
            string cum = "";
            mensaje1 += S_RS232.ReadExisting();

            if (mensaje1.IndexOf((char)13) > 0)
            {
                if (mensaje1.Length > 0)
                {
                    if (mensaje.IndexOf("&&&") < 0 && mensaje1.IndexOf("NEG") < 0 && mensaje1.IndexOf("OVER") < 0 && mensaje1.IndexOf("SOBRE") < 0)
                    {
                        txt_um = RS232.obtiene_um(mensaje1);
                        mensaje1 = RS232.obtiene_peso(mensaje1);
                    }
                    else mensaje1 = "0";
                    SetText1(mensaje1, txt_um);
                    if (Global.display && this.serialPort4.IsOpen)
                    {
                        if (txt_um.Length > 0) cum = txt_um.Substring(0, 1);
                        RS232.SendData(ref this.serialPort4, ref mensaje1, this.mensaje + " " + cum + " N " + (char)13);
                    }
                }
            }
        }
        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort S_RS232 = (SerialPort)sender;
            string txt_um = "";
            string cum = "";
            mensaje2 += S_RS232.ReadExisting();

            if (mensaje2.IndexOf((char)13) > 0)
            {
                if (mensaje2.Length > 0)
                {
                    if (mensaje2.IndexOf("&&&") < 0 && mensaje2.IndexOf("NEG") < 0 && mensaje2.IndexOf("OVER") < 0 && mensaje2.IndexOf("SOBRE") < 0)
                    {
                        txt_um = RS232.obtiene_um(mensaje2);
                        mensaje2 = RS232.obtiene_peso(mensaje2);
                    }
                    else mensaje2 = "0";
                    SetText2(mensaje2, txt_um);
                    if (Global.display && this.serialPort4.IsOpen)
                    {
                        if (txt_um.Length > 0) cum = txt_um.Substring(0, 1);
                        RS232.SendData(ref this.serialPort4, ref mensaje2, this.mensaje + " " + cum + " N " + (char)13);
                    }
                }
            }
        }
        private void serialPort3_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort S_RS232 = (SerialPort)sender;
            string txt_um = "";
            string cum = "";
            mensaje3 += S_RS232.ReadExisting();

            if (mensaje3.IndexOf((char)13) > 0)
            {
                if (mensaje3.Length > 0)
                {
                    if (mensaje3.IndexOf("&&&") < 0 && mensaje3.IndexOf("NEG") < 0 && mensaje3.IndexOf("OVER") < 0 && mensaje3.IndexOf("SOBRE") < 0)
                    {
                        txt_um = RS232.obtiene_um(mensaje3);
                        mensaje3 = RS232.obtiene_peso(mensaje3);
                    }
                    else mensaje3 = "0";
                    SetText3(mensaje3, txt_um);
                    if (Global.display && this.serialPort4.IsOpen)
                    {
                        if (txt_um.Length > 0) cum = txt_um.Substring(0, 1);
                        RS232.SendData(ref this.serialPort4, ref mensaje3, this.mensaje + " " + cum + " N " + (char)13);
                    }
                }
            }
        }
        #endregion
        #region Eventos para captura de datos
        private void bindingNavigator1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.GVTransaccion.ClearSelection();
            switch (this.bindingNavigator1.Items.IndexOf(e.ClickedItem))
            {
                case 0:
                    cmRegister.Position = 0;
                    break;
                case 1:
                    cmRegister.Position = Convert.ToInt32(this.bindingNavigatorPositionItem.Text) - 1;
                    Conec.Previous(ref cmRegister);
                    break;
                case 6:
                    cmRegister.Position = Convert.ToInt32(this.bindingNavigatorPositionItem.Text) - 1;
                    Conec.Next(ref cmRegister);
                    break;
                case 7:
                    cmRegister.Position = cmRegister.Count - 1;
                    break;
            }
            Mostrar_Datos(cmRegister.Position, 0);
        }
        private void tipo_mov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipo_mov.SelectedIndex == 0) this.peso_tara.Text = "";
            else this.peso_bruto.Text = "";
        }
        private void GVTransaccion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Windows.Forms.DataGridView reg = ((System.Windows.Forms.DataGridView)sender);
            cmRegister.Position = e.RowIndex;
            this.bindingNavigatorPositionItem.Text = Convert.ToString(cmRegister.Position + 1);
            if (cmRegister.Position > 0 && cmRegister.Position < cmRegister.Count)
            {
                this.bindingNavigatorMoveFirstItem.Enabled = true;
                this.bindingNavigatorMovePreviousItem.Enabled = true;
                this.bindingNavigatorMoveNextItem.Enabled = true;
                this.bindingNavigatorMoveLastItem.Enabled = true;
            }
            if (cmRegister.Position <= 0)
            {
                this.bindingNavigatorMoveNextItem.Enabled = true;
                this.bindingNavigatorMoveLastItem.Enabled = true;
                this.bindingNavigatorMoveFirstItem.Enabled = false;
                this.bindingNavigatorMovePreviousItem.Enabled = false;
            }
            if (cmRegister.Position >= cmRegister.Count)
            {
                this.bindingNavigatorMoveNextItem.Enabled = false;
                this.bindingNavigatorMoveLastItem.Enabled = false;
                this.bindingNavigatorMoveFirstItem.Enabled = true;
                this.bindingNavigatorMovePreviousItem.Enabled = true;
            }

            reg.Select();
            Mostrar_Datos(e.RowIndex, 0);
        }
        private void txt_folio_LostFocus(object sender, EventArgs e)
        {
            if (this.txt_folio.Text != "" && this.txt_folio.Text != "0")
            {
                cmRegister.Position = Conec.Find_Codigo(this.txt_folio.Text, "folio");
                if (cmRegister.Position >= 0)
                {
                    MessageBox.Show(Global.M_Error[101, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar_Datos();
                }
            }
        }
        private void txt_guia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.txt_factura.Focus();
        }
        private void txt_factura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.txt_embarque.Focus();
        }
        private void txt_embarque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txt_placa.Text != "" && this.txt_placa.Text != null) this.combo_producto.Focus();
            }
        }
        private void txt_observa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.combo_producto.Focus();
        }
        private void txt_placa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.txt_guia.Focus();
        }
        private void txt_placa_LostFocus(object sender, EventArgs e)
        {
            if (this.txt_placa.Text == "" && this.txt_placa.Text == null)
            {
                MessageBox.Show(Global.M_Error[91, Global.idioma]);
                this.txt_placa.Focus();
            }
        }
        #endregion
        #region Eventos para los toolstrip, combox y bottom
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Guardar la transaccion de primera entrada
            if (this.peso_neto.Text != "" && this.peso_neto.Text != "0")
            {
                if (this.txt_placa.Text != "" && this.txt_placa.Text != "0")
                {
                    if (Convert.ToInt32(this.txt_folio.Text) > 50 && !Keylock.IsPresent()) MessageBox.Show(Global.M_Error[147, Global.idioma] + "\n" + Global.M_Error[68, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        IDataReader tm = db.getDataReader("SELECT numero,tara FROM taras WHERE ( numemp = " + Global.nempresa + " AND numero = '" + this.txt_placa.Text.Trim() + "')");
                        if (tm.Read()) this.tara_manual = Convert.ToInt32(tm.GetString(1));
                        else this.tara_manual = 0;
                        tm.Close();
                        if (this.tara_manual != 0 && this.tipo_mov.SelectedIndex == 0)
                        {
                            if (MessageBox.Show(Global.M_Error[34, Global.idioma], "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                this.peso_neto.Text = Convert.ToString(Convert.ToDouble(this.peso_bruto.Text) - Convert.ToDouble(this.tara_manual));
                                if (Convert.ToDouble(this.peso_neto.Text) >= 0)
                                {
                                    New();
                                    this.toolStripButton2_Click(this.toolStripButton2, new EventArgs());
                                }
                            }
                            else
                            {
                                this.tara_manual = 0;
                                New();
                                this.timer1.Stop();
                                //Imprime_Movimiento(1,Convert.ToInt32(this.txt_folio.Text));
                                Preview fo = new Preview(this.txt_folio.Text);
                                fo.ShowDialog();
                                Limpiar_Datos();
                                this.timer1.Start();
                            }
                        }
                        else
                        {
                            this.tara_manual = 0;
                            New();
                            this.timer1.Stop();
                            //Imprime_Movimiento(1, Convert.ToInt32(this.txt_folio.Text));
                            Preview fo = new Preview(this.txt_folio.Text);
                            fo.ShowDialog();
                            Limpiar_Datos();
                            this.timer1.Start();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(Global.M_Error[91, Global.idioma].ToString());
                this.txt_placa.Focus();
            }
            Llenar_Grid();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            // nueva transacion
            this.toolStripButton5.Enabled = false;
            Limpiar_Datos();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Completar la transaccion de regreso 
            if (this.tara_manual > 0) this.peso_neto.Text = Convert.ToString(Convert.ToDouble(this.peso_bruto.Text) - Convert.ToDouble(this.tara_manual));
            if (Convert.ToDouble(this.peso_neto.Text) > 0)
            {
                if (Actualiza_Historia())
                {
                    MessageBox.Show(Global.M_Error[4, Global.idioma].ToString());
                    this.timer1.Stop();
                    Preview fo = new Preview(this.txt_folio.Text);
                    fo.ShowDialog();
                    if (Global.realizo_impresion) Del();
                    else
                    {
                        Conec.Condicion = "(folio = " + Convert.ToInt32(this.txt_folio.Text) + " and numemp = " + Global.nempresa + ")";
                        Conec.CadenaSelect = "UPDATE Historia SET status = 'P' WHERE " + Conec.Condicion;
                        db.ExcetuteQuery(Conec.CadenaSelect);
                    }
                    this.toolStripButton5.Enabled = false;
                    Limpiar_Datos();
                    this.timer1.Start();
                }

            }
            else MessageBox.Show(Global.M_Error[9, Global.idioma].ToString());
            Llenar_Grid();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Busca una transaccion por numero de folio 
            //Llenar_Grid();
            if (this.cmRegister.Count > 0)
            {
                Buscar busca = new Buscar(1, para1, "");
                busca.ShowDialog();
                this.Focus();
                if (Buscar.codigo != "" && Buscar.codigo != null)
                {
                    this.GVTransaccion.ClearSelection();
                    cmRegister.Position = Conec.Find_Codigo(Buscar.codigo, campo);
                    if (cmRegister.Position >= 0)
                    {
                        this.GVTransaccion.Rows[cmRegister.Position].Selected = true;
                        Mostrar_Datos(cmRegister.Position, 0);
                    }
                    else MessageBox.Show(Global.M_Error[32, Global.idioma].ToString());
                }
            }
            else MessageBox.Show(Global.M_Error[2, Global.idioma].ToString());
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            // Elimina una transaccion que esta pendiente de ser completada
            DialogResult df = MessageBox.Show(Global.M_Error[100, Global.idioma].ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (df == DialogResult.Yes)
            {
                if (Cancelar_Historia())
                {
                    Del();
                    MessageBox.Show(Global.M_Error[3, Global.idioma].ToString());
                    this.toolStripButton5.Enabled = false;
                    Limpiar_Datos();
                }
            }
            Llenar_Grid();
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //Reimprime un documento ya almacenado y completado
            Folio fo = new Folio(2, this.txt_folio.Text);
            fo.Show();
            Llenar_Grid();
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            // Cierra esta vnetana
            try
            {
                this.timer1.Stop();
                this.timer1.Enabled = false;
                this.timer2.Stop();

                this.serialPort1.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);
                this.serialPort2.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(serialPort2_DataReceived);
                this.serialPort3.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(serialPort3_DataReceived);

                if (this.serialPort1.IsOpen)
                {
                    this.serialPort1.DiscardOutBuffer();
                    this.serialPort1.DiscardInBuffer();
                    RS232.Termino(ref this.serialPort1);
                }
                if (this.serialPort2.IsOpen)
                {
                    this.serialPort2.DiscardOutBuffer();
                    this.serialPort2.DiscardInBuffer();
                    RS232.Termino(ref this.serialPort2);
                }
                if (this.serialPort3.IsOpen)
                {
                    this.serialPort3.DiscardOutBuffer();
                    this.serialPort3.DiscardInBuffer();
                    RS232.Termino(ref this.serialPort3);
                }
                if (Global.display)
                {
                    if (this.serialPort4.IsOpen)
                    {
                        this.serialPort4.DiscardOutBuffer();
                        RS232.Termino(ref this.serialPort4);
                    }
                }
            }
            catch (System.IO.IOException eio)
            {
                MessageBox.Show(eio.Message);
            }
            catch (System.InvalidOperationException ei)
            {
                MessageBox.Show(ei.Message + " " + Global.M_Error[24, Global.idioma].ToString());
            }
            catch (System.NullReferenceException en)
            {
                MessageBox.Show(en.Message + " " + Global.M_Error[24, Global.idioma].ToString());
            }
            catch (System.ArgumentNullException ea)
            {
                MessageBox.Show(ea.Message + " " + Global.M_Error[24, Global.idioma].ToString());
            }
            this.Close();
            this.Dispose();
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Llenar_Grid();
            Limpiar_Datos();
        }
        #endregion

        #endregion
    }
}
