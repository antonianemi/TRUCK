using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace TRUCK
{
    public partial class Liquidacion : Form
    {
        #region VARIABLES
        ParameterFields paramFields = new ParameterFields();
        DataAccesQuery db;
        #endregion
        #region CONSTRUCTOR
        public Liquidacion()
        {
            db = new DataAccesQuery();
            InitializeComponent();
            this.date1.Format = DateTimePickerFormat.Custom;
            this.date2.Format = DateTimePickerFormat.Custom;
            this.date1.CustomFormat = Global.F_Fecha;
            this.date2.CustomFormat = Global.F_Fecha;
            this.date1.Text = DateTime.Today.ToShortDateString();
            this.date2.Text = DateTime.Today.ToShortDateString();
            this.empre1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empre1_KeyDown);
            this.empre2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empre2_KeyDown);
            this.empre2.Validating += new System.ComponentModel.CancelEventHandler(this.empre2_Validating);
            this.cliente1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cliente1_KeyDown);
            this.cliente2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cliente2_KeyDown);
            this.cliente2.Validating += new System.ComponentModel.CancelEventHandler(this.cliente2_Validating);
        }
        #endregion
        #region EVENTS
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
        private void empre2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (empre1.Text != "")
            {
                if (empre2.Text == "")
                {
                    MessageBox.Show(this.label1.Text + " " + this.label2.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.empre2.Focus();
                }
                else this.cliente1.Focus();
            }
            else
            {
                if (empre2.Text != "")
                {
                    MessageBox.Show(this.label2.Text + " " + this.label1.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.empre1.Focus();
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
            string condi = "", condi1 = "", condi2 = "";
            string filtro = "", filtro1 = "", filtro2 = "";
            string sele = "";
            int n_reporte = 0;

            if (this.date1.Text.Length > 0 && this.date2.Text.Length > 0)
            {
                filtro = "(CDateTime({historia.fecha1}) >= CDateTime('" + string.Format("{0:" + Global.F_Fecha + "}", this.date1.Value) + "') and CDateTime({historia.fecha1}) <= CDateTime('" + string.Format("{0:" + Global.F_Fecha + "}", this.date2.Value) + "') and {historia.numemp} = " + Global.nempresa + ")";
                condi = "( val(fecha1) >= val('" + this.date1.Text + "') and  val(fecha1) <= val('" + this.date2.Text + "'))";
            }
            if (this.empre1.Text.Length > 0 && this.empre2.Text.Length > 0)
            {
                filtro1 = "({historia.folio} >= " + Convert.ToInt32(this.empre1.Text) + " and {historia.folio} <= " + Convert.ToInt32(this.empre2.Text) + " and {historia.numemp} = " + Global.nempresa + ")";
                condi1 = "(folio >= " + Convert.ToInt32(this.empre1.Text) + ") and (folio <= " + Convert.ToInt32(this.empre2.Text) + ")";
                filtro = filtro + " and " + filtro1;
                condi = condi + " and " + condi1;
            }
            if (this.cliente1.Text.Length > 0 && this.cliente2.Text.Length > 0)
            {
                filtro2 = "({historia.cliente} >= " + Convert.ToInt32(this.cliente1.Text) + " and {historia.cliente} <= " + Convert.ToInt32(this.cliente2.Text) + " and {historia.numemp} = " + Global.nempresa + ")";
                condi2 = "(cliente >= " + Convert.ToInt32(this.cliente1.Text) + ") and (cliente <= " + Convert.ToInt32(this.cliente2.Text) + ")";
                filtro = filtro + " and " + filtro2;
                condi = condi + " and " + condi2;
            }

            nombre_reporte = Global.REPORTES + "\\RLiquidacion.rpt";
            n_reporte = 157;

            sele = "SELECT * FROM historia WHERE (" + condi + " and (numemp = " + Global.nempresa + ")) ORDER BY folio";
            IDataReader dr = db.getDataReader(sele);
            if (dr.Read()) hay = true;
            else hay = false;
            dr.Close();
            Parametros p = new Parametros();
            if (!hay) MessageBox.Show(Global.M_Error[32, Global.idioma]);
            else
            {
                this.button1.Enabled = false;
                p.Liquidacion(n_reporte, this.date1.Text, this.date2.Text, fecha, hora1, this.cliente1.Text, this.cliente2.Text, this.empre1.Text, this.empre2.Text, ref paramFields);
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load(nombre_reporte);
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
