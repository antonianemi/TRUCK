using System;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;

namespace TRUCK
{
    public partial class ROtros : Form
    {
        #region VARIABLES
        ParameterFields paramFields = new ParameterFields();
        DataAccesQuery db;
        private int tipo_reporte;
        #endregion
        #region CONSTRUCTORS
        public ROtros(int opcion)
        {
            InitializeComponent();
            this.date1.Format = DateTimePickerFormat.Custom;
            this.date2.Format = DateTimePickerFormat.Custom;
            this.date1.CustomFormat = Global.F_Fecha;
            this.date2.CustomFormat = Global.F_Fecha;
            this.date1.Text = DateTime.Today.ToShortDateString();
            this.date2.Text = DateTime.Today.ToShortDateString();
            this.tipo_reporte = opcion;
            this.txt_inicio.KeyDown += new KeyEventHandler(txt_inicio_KeyDown);
            this.txt_fin.KeyDown += new KeyEventHandler(txt_fin_KeyDown);
            this.txt_fin.Validating += new CancelEventHandler(txt_fin_Validating);
            if (opcion == 0)
            {
                this.Text = Global.M_Error[156, Global.idioma];
                this.date1.Enabled = false;
                this.date2.Enabled = false;
                this.placa1.Enabled = false;
                this.placa2.Enabled = false;
                this.cliente1.Enabled = false;
                this.cliente2.Enabled = false;
            }
            if (opcion == 1) this.Text = Global.M_Error[154, Global.idioma];
            if (opcion == 2) this.Text = Global.M_Error[155, Global.idioma];
        }
        #endregion
        #region EVENTS
        void txt_fin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txt_fin.Text != "")
                {
                    if (this.txt_fin.Text == "")
                    {
                        MessageBox.Show(this.label1.Text + " " + this.label2.Text + " " + Global.M_Error[67, Global.idioma]);
                        this.txt_fin.Focus();
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
        void txt_inicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.txt_fin.Focus();
            
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
        }
        void txt_fin_Validating(object sender, CancelEventArgs e)
        {
            if (this.txt_inicio.Text != "")
            {
                if (this.txt_fin.Text == "")
                {
                    MessageBox.Show(this.label1.Text + " " + this.label2.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.txt_fin.Focus();
                }
                else this.button1.Focus();
            }
            else
            {
                if (this.txt_fin.Text != "")
                {
                    MessageBox.Show(this.label2.Text + " " + this.label1.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.txt_inicio.Focus();
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

            bool hay = false;
            
            string condi = "", condi2 = "", condi3 = "";
            string filtro = "", filtro2 = "", filtro3 = "";
            string sele = "";
           // string orden = "";
            int n_reporte = 0;
           
            switch (this.tipo_reporte)
            {
                case 0: // Imventario por familia
                    {
                        nombre_reporte = Global.REPORTES + "\\InvxFam.rpt";
                        if (this.txt_inicio.Text.Length > 0 && this.txt_fin.Text.Length > 0)
                        {
                            filtro = "({articulos.numero} >= " + Convert.ToInt32(this.txt_inicio.Text) + " and {articulos.numero} <= " + Convert.ToInt32(this.txt_fin.Text) + " and {articulos.numemp} = " + Global.nempresa + " )";
                            condi = "(numero >= " + Convert.ToInt32(this.txt_inicio.Text) + ") and (numero <= " + Convert.ToInt32(this.txt_fin.Text) + ")";
                            sele = "SELECT * FROM articulos WHERE (" + condi + " and numemp = " + Global.nempresa + ") order by familia";
                        }
                        else
                        {
                            filtro = "({articulos.numemp} = " + Global.nempresa + ")";
                            sele = "SELECT * FROM articulos WHERE ( numemp = " + Global.nempresa + ") order by familia";
                        }
                        n_reporte = 156;
                    } break;
                case 1:  //Transacciones Pendientes
                    {
                        if (Global.aplicacion == 0) nombre_reporte = Global.REPORTES + "\\RTPed_Can_publico.rpt";
                        else nombre_reporte = Global.REPORTES + "\\RTPed_Can.rpt";
                        filtro = "(val({historia.hora1}) >= val('" + this.date1.Text + "') and val({historia.hora1}) <= val('" + this.date2.Text + "') and {historia.numemp} = " + Global.nempresa + ")  and ({historia.status} = 'P' )";
                        condi = "( val(hora1) >= val('" + this.date1.Text + "')) and  (val(hora1) <= val('" + this.date2.Text + "')) and (status = 'P' )";
                                 
                        n_reporte = 154;
                    } break;
                case 2:  // Transacciones Canceladas
                    {
                        if (Global.aplicacion == 0) nombre_reporte = Global.REPORTES + "\\RTPed_Can_publico.rpt";
                        else nombre_reporte = Global.REPORTES + "\\RTPed_Can.rpt";
                        filtro = "(DateValue({historia.hora2}) >= DateValue('" + this.date1.Text + "') and DateValue({historia.hora2}) <= DateValue('" + this.date2.Text + "') and {historia.numemp} = " + Global.nempresa + ")  and ({historia.status} = 'C' )";
                        condi = "(val(hora2) >= val('" + this.date1.Text + "')) and  (val(hora2) <= val('" + this.date2.Text + "')) and (status = 'C' )";
                        
                        n_reporte = 155;
                    } break;
            }
            if (this.tipo_reporte > 0)
            {
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
                sele = "SELECT * FROM historia WHERE " + condi + " ORDER BY folio";
            }


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

                Global.hora = System.DateTime.Now.Hour;
                Global.minutos = System.DateTime.Now.Minute;
                Global.segundo = System.DateTime.Now.Second;

                DateTime MyDate = new DateTime(Global.year, Global.mes, Global.dia, Global.hora, Global.minutos, Global.segundo);

                string fecha = string.Format("{0:" + Global.F_Fecha + "}", MyDate);
                string hora1 = string.Format("{0:" + Global.F_Hora + "}", MyDate);

                if (this.tipo_reporte == 0) p.Inventarios(n_reporte, fecha, hora1, ref paramFields);
                else p.Transacciones(n_reporte, fecha, hora1, ref paramFields);

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
