using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
namespace TRUCK
{
    public partial class RHistoria : Form
    {
        #region VARIABLES
        ParameterFields paramFields = new ParameterFields();
        DataAccesQuery db;
        #endregion
        #region CONSTRUCTS
        public RHistoria()
        {
            db = new DataAccesQuery();
            InitializeComponent();
            this.date1.Format = DateTimePickerFormat.Custom;
            this.date2.Format = DateTimePickerFormat.Custom;
            this.date1.CustomFormat = Global.F_Fecha;
            this.date2.CustomFormat = Global.F_Fecha;
            this.date1.Text = DateTime.Today.ToShortDateString();
            this.date2.Text = DateTime.Today.ToShortDateString();

            if (Global.aplicacion == 0) this.label5.Text = Global.M_Error[217, Global.idioma];
            this.empre1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empre1_KeyDown);
            this.empre2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empre2_KeyDown);
            this.empre2.Validating += new System.ComponentModel.CancelEventHandler(this.empre2_Validating);
            this.placa1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.placa1_KeyDown);
            this.placa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.placa2_KeyDown);
            this.placa2.Validating += new System.ComponentModel.CancelEventHandler(this.placa2_Validating);
            this.cliente1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cliente1_KeyDown);
            this.cliente2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cliente2_KeyDown);
            this.cliente2.Validating += new System.ComponentModel.CancelEventHandler(this.cliente2_Validating);
            switch (Global.aplicacion)
            {
                case 0:
                    {
                        this.Listados.Items.Add(Global.M_Error[148, Global.idioma]);  //Historia por Empresa
                        this.Listados.Items.Add(Global.M_Error[149, Global.idioma]);  //Historia por Fecha
                        this.Listados.Items.Add(Global.M_Error[175, Global.idioma]);  //Historia por Tarifa
                        this.Listados.Items.Add(Global.M_Error[153, Global.idioma]);  //Historia por cliente
                    } break;
                case 1:
                    {
                        this.Listados.Items.Add(Global.M_Error[148, Global.idioma]);  //Historia por Empresa
                        this.Listados.Items.Add(Global.M_Error[149, Global.idioma]);  //Historia por Fecha
                        this.Listados.Items.Add(Global.M_Error[150, Global.idioma]);  //Historia por Productos
                        this.Listados.Items.Add(Global.M_Error[151, Global.idioma]);  //Historia por Proveedores
                        this.Listados.Items.Add(Global.M_Error[153, Global.idioma]);  //Historia por Cliente
                        this.Listados.Items.Add(Global.M_Error[152, Global.idioma]);  //Historia por Transportista
                    } break;
                case 2:
                    {
                        this.Listados.Items.Add(Global.M_Error[148, Global.idioma]);  //Historia por Empresa
                        this.Listados.Items.Add(Global.M_Error[149, Global.idioma]);  //Historia por Fecha
                        this.Listados.Items.Add(Global.M_Error[150, Global.idioma]);  //Historia por Productos
                        this.Listados.Items.Add(Global.M_Error[151, Global.idioma]);  //Historia por Proveedores
                        this.Listados.Items.Add(Global.M_Error[153, Global.idioma]);  //Historia por Cliente
                    } break;
            }
            this.Listados.SelectedIndex = 0;
        }
        #endregion
        #region EVENTOS
        private void empre1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.empre2.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
        }
        private void empre2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.empre1.Text != "")
                {
                    if (this.empre2.Text == "")
                    {
                        MessageBox.Show(this.label1.Text + " " + this.label2.Text + " " + Global.M_Error[67, Global.idioma]);
                        this.empre2.Focus();
                    }
                    else this.placa1.Focus();
                }
                else this.placa1.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
        }
        private void empre2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (empre1.Text != "")
            {
                if (empre2.Text == "")
                {
                    MessageBox.Show(this.label1.Text + " " + this.label2.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.empre2.Focus();
                }
                else this.placa1.Focus();
            }
            else
            {
                if (empre2.Text != "")
                {
                    MessageBox.Show(this.label2.Text + " " + this.label1.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.empre1.Focus();
                }
                else this.placa1.Focus();
            }
        }
        private void placa1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.placa2.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
        }
        private void placa2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.placa1.Text != "")
                {
                    if (this.placa2.Text == "")
                    {
                        MessageBox.Show(this.label1.Text + " " + this.label2.Text + " " + Global.M_Error[67, Global.idioma]);
                        this.placa2.Focus();
                    }
                    else this.cliente1.Focus();
                }
                else this.cliente1.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
        }
        private void placa2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (placa1.Text != "")
            {
                if (placa2.Text == "")
                {
                    MessageBox.Show(this.label1.Text + " " + this.label2.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.placa2.Focus();
                }
                else this.cliente1.Focus();
            }
            else
            {
                if (placa2.Text != "")
                {
                    MessageBox.Show(this.label2.Text + " " + this.label1.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.placa1.Focus();
                }
                else this.cliente1.Focus();
            }
        }
        private void cliente1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cliente2.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
        }
        private void cliente2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.cliente1.Text != "")
                {
                    if (this.cliente2.Text == "")
                    {
                        MessageBox.Show(this.label1.Text + " " + this.label2.Text + " " + Global.M_Error[67, Global.idioma]);
                        this.cliente2.Focus();
                    }
                    else this.button1.Focus();
                }
                else this.button1.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
        }
        private void cliente2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cliente1.Text != "")
            {
                if (cliente2.Text == "")
                {
                    MessageBox.Show(this.label1.Text + " " + this.label2.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.cliente2.Focus();
                }
                else this.button1.Focus();
            }
            else
            {
                if (cliente2.Text != "")
                {
                    MessageBox.Show(this.label2.Text + " " + this.label1.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.cliente1.Focus();
                }
                else this.button1.Focus();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string nombre_reporte = "";

            System.Globalization.DateTimeFormatInfo myCI = new System.Globalization.DateTimeFormatInfo();
            myCI.ShortDatePattern = Global.F_Fecha;
                        
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            
            DateTime MyDate = new DateTime(Global.year, Global.mes, Global.dia, Global.hora, Global.minutos, Global.segundo);
            string fecha = string.Format("{0:" + Global.F_Fecha + "}", MyDate);
            string hora1 = string.Format("{0:" + Global.F_Hora + "}", MyDate);

            bool hay = false;
            string condi = "", condi1 = "", condi2 = "", condi3 = "";
            string filtro = "", filtro1 = "", filtro2 = "", filtro3= "";
            string sele = "";
            string orden = "";
            
            int n_reporte = 0,n_grupo = 0;
            
            if (this.date1.Text.Length > 0 && this.date2.Text.Length > 0)
            {  //SUBSTRING(" + campo2 + ",1," + len + ") = '" + descrip + "'"
                if (this.chk_salida.Checked)
                {
                    filtro = "(DateValue({historia.FECHA2}) in DateValue('" + string.Format("{0:"+Global.F_Fecha+"}", this.date1.Value) + "') to DateValue('" + string.Format("{0:"+Global.F_Fecha+"}", this.date2.Value) + "') and {historia.numemp} = " + Global.nempresa + ")";
                    condi = "(DATEVALUE(FECHA2) >= DateValue('" + string.Format("{0:" +Global.F_Fecha+"}", this.date1.Value) + "')) AND (DATEVALUE(FECHA2) <= DateValue('" + string.Format("{0:"+Global.F_Fecha+"}", this.date2.Value) + "'))";
                }
                else
                {
                    filtro = "(DateValue({historia.FECHA1}) in DateValue('" + string.Format("{0:"+Global.F_Fecha+"}", this.date1.Value) + "') to DateValue('" + string.Format("{0:"+Global.F_Fecha+"}", this.date2.Value) + "') and {historia.numemp} = " + Global.nempresa + ")";
                    condi = "(DATEVALUE(FECHA1) >= DateValue('" + string.Format("{0:"+Global.F_Fecha+"}", this.date1.Value) + "')) AND (DATEVALUE(FECHA1) <= DateValue('" + string.Format("{0:"+Global.F_Fecha+"}", this.date2.Value) + "'))";
                }
            }
            if (this.empre1.Text.Length > 0 && this.empre2.Text.Length > 0)
            {
                filtro1 = "({historia.producto} >= " + Convert.ToInt32(this.empre1.Text) + " and {historia.producto} <= " + Convert.ToInt32(this.empre2.Text) + ")";
                condi1 = "(producto >= " + Convert.ToInt32(this.empre1.Text) + ") and (producto <= " + Convert.ToInt32(this.empre2.Text) + ")";
                filtro = filtro + " and " + filtro1;
                condi = condi + " and " + condi1;
            }
            if (this.cliente1.Text.Length > 0 && this.cliente2.Text.Length > 0)
            {
                filtro2 = "({historia.cliente} >= " + Convert.ToInt32(this.cliente1.Text) + " and {historia.cliente} <= " + Convert.ToInt32(this.cliente2.Text) + ")";
                condi2 = "(cliente >= " + Convert.ToInt32(this.cliente1.Text) + ") and (cliente <= " + Convert.ToInt32(this.cliente2.Text) + ")";
                filtro = filtro + " and " + filtro2;
                condi = condi + " and " + condi2;
            }
            if (this.placa1.Text.Length > 0 && this.placa2.Text.Length > 0)
            {
                filtro3 = "({historia.placas} >= '" + this.placa1.Text + "' and {historia.placas} <= '" + this.placa2.Text + "')";
                condi3 = "(placas >= '" + this.placa1.Text + "') and (placas <= '" + this.placa2.Text + "')";
                filtro = filtro + " and " + filtro3;
                condi = condi + " and " + condi3;
            }
                        
            switch (this.Listados.SelectedIndex)
            {
                case 0: // Reporte de transacciones por empresa
                    {
                        if (Global.aplicacion == 0) nombre_reporte = Global.REPORTES + "\\RTxEmpresa_publico.rpt";
                        else nombre_reporte = Global.REPORTES + "\\RTxEmpresa.rpt";
                        orden = "folio";
                        n_reporte = 148;
                        n_grupo = 131;
                    } break;
                case 1: //Reporte de transacciones por fecha
                    {
                        if (Global.aplicacion == 0) nombre_reporte = Global.REPORTES + "\\RTxFecha_publico.rpt";
                        else nombre_reporte = Global.REPORTES + "\\RTxFecha.rpt";
                        if (this.chk_salida.Checked) orden = "FECHA2";
                        else orden = "FECHA1";
                        n_reporte = 149;
                        n_grupo = 131;
                    } break;                
                case 2:  //Reporte de transacciones por producto y transportitas para el publico
                    {
                        if (Global.aplicacion == 0)
                        {
                            nombre_reporte = Global.REPORTES + "\\RTxProducto_publico.rpt";
                            orden = "transporte";
                            n_reporte = 175;
                            n_grupo = 146;
                        }
                        else
                        {
                            nombre_reporte = Global.REPORTES + "\\RTxProducto.rpt";
                            orden = "producto";
                            n_reporte = 150;
                            n_grupo = 136;
                        }
                    } break;
                case 3:  // Reporte de transacciones por proveedor
                    {
                        if (Global.aplicacion == 0)
                        {
                            nombre_reporte = Global.REPORTES + "\\RTxCliente_publico.rpt";
                            orden = "transporte";
                            n_reporte = 153;
                            n_grupo = 135;
                        }
                        else
                        {
                            nombre_reporte = Global.REPORTES + "\\RTxProveedor.rpt";
                            orden = "proveedor";
                            n_reporte = 151;
                            n_grupo = 132;
                        }
                    } break;
                     
                case 4:  // Reporte de transacciones por cliente
                    {
                        nombre_reporte = Global.REPORTES + "\\RTxCliente.rpt";
                         orden = "cliente";
                        n_reporte = 153;
                        n_grupo = 135;
                    } break;
                case 5:  // Reporte de transacciones por transportista
                    {
                        nombre_reporte = Global.REPORTES + "\\RTxTransporte.rpt";
                        orden = "transporte";
                        n_reporte = 152;
                        n_grupo = 130;
                    } break;            
               
            }

            sele = "SELECT * FROM HISTORIA WHERE (" + condi + " and (numemp = " + Global.nempresa + ")) ORDER BY " + orden;



            IDataReader dr = db.getDataReader(sele);
            if (dr == null) return;
            if (dr.Read()) hay = true;
            else hay = false;
            dr.Close();
            Parametros p = new Parametros();
            if (!hay) MessageBox.Show(Global.M_Error[32, Global.idioma]);
            else
            {
                this.button1.Enabled = false;
                p.Historial_Transacciones(n_reporte, n_grupo, fecha, hora1, ref paramFields);
                ReportDocument oRpt = new ReportDocument();                
                oRpt.Load(nombre_reporte);
                bool autoSaveData = oRpt.ReportOptions.EnableSaveDataWithReport;
                if (autoSaveData) oRpt.ReportOptions.EnableSaveDataWithReport = false;
                oRpt.Refresh();
                //oRpt.VerifyDatabase();
                oRpt.RecordSelectionFormula = filtro;
                
                TableLogOnInfo logOnInfo = new TableLogOnInfo();
                ConnectionInfo myconect = new ConnectionInfo();
                myconect.DatabaseName = Global.DATABASE;
                myconect.ServerName = Global.DATABASE;
                myconect.Password = "";
                myconect.UserID = "";
                
                foreach (Table table in oRpt.Database.Tables)
                {
                    logOnInfo = table.LogOnInfo;
                    logOnInfo.ConnectionInfo = myconect;
                    table.ApplyLogOnInfo(logOnInfo);
                }
                this.WindowState = FormWindowState.Maximized;
                
                crystalRV2.Visible = true;
                crystalRV2.Dock = DockStyle.Fill;
                crystalRV2.ParameterFieldInfo = paramFields;
                crystalRV2.ReportSource = oRpt;
                crystalRV2.SelectionFormula = filtro;                   
                crystalRV2.LogOnInfo.Add(logOnInfo);               
                crystalRV2.Refresh();
            }
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }               
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion
    }
}
