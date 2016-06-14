using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using BaseAcces;

namespace TRUCK
{
	/// <summary>
	/// Descripción breve de FiltroB.
	/// </summary>
    public class Preview : System.Windows.Forms.Form
    {
        #region VARIABLES
        DataAccesQuery db;
        DataSet dt1;
        DataSet dt2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalRV2;
        private Panel panel1;
        private Button button1;
        private Button button2;
        private string filtro;
        private Button button3;
        private int num_folio;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;
        #endregion
        #region CONSTRUCTORS
        public Preview(string n_folio)
        {
            InitializeComponent();
            this.TransparencyKey = Color.Empty;
            num_folio = Convert.ToInt32(n_folio);
            System.Threading.Thread.SpinWait(10500);
            Imprime_Movimiento(num_folio);
        }
        #endregion
        #region FUNCTIONS
        private void Imprime_Movimiento(int inicio)
        {
            try
            {
                filtro = "";
                string nombre_reporte = "";
                string sele = "";
                string nom_empre = "";
                string dire1 = "";
                string dire2 = "";
                string dire3 = "";
                string fecha1 = "";
                string fecha2 = "";
                string hora11 = "";
                string hora22 = "";
                string txtpeso_neto = "";
                string txtpeso_bruto = "";
                object n_placas = "";
                object n_guia = "";
                object n_factura = "";
                object n_embarque = "";
                object observacion = "";
                object n_prove = "";
                object n_produc = "";
                object n_cliente = "";
                object n_transpor = "";
                object movimiento = "";
                bool hay = false;

                this.Text = Global.M_Error[162, Global.idioma].ToString();
                string condi = "";
                if (inicio > 0)
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    switch (Global.tipo_dato)
                    {
                        case 1:
                            {
                                if (Global.aplicacion == 0) nombre_reporte = Global.REPORTES + "\\Movimientos_publico2.rpt";
                                else nombre_reporte = Global.REPORTES + "\\Movimientos2.rpt";
                            }
                            break;
                        case 2:
                            {
                                if (Global.aplicacion == 0) nombre_reporte = Global.REPORTES + "\\Movimientos_publico_3ejes2.rpt";
                                else nombre_reporte = Global.REPORTES + "\\Movimientos_3ejes2.rpt";
                            }
                            break;
                        /*  case 3:
                              {
                                  if (Global.aplicacion == 0) nombre_reporte = Global.REPORTES + "\\Movimientos_publico_2mod.rpt";
                                  else nombre_reporte = Global.REPORTES + "\\Movimientos_2mod.rpt";
                              }
                              break;*/
                    }
                    filtro = "({historia.folio} >= " + inicio + " and {historia.folio} <= " + inicio + " and {historia.numemp} = " + Global.nempresa + ")";
                    condi = "(folio = " + inicio + " and numemp = " + Global.nempresa + ")";

                    IDataReader em = db.getDataReader("SELECT empresa,direccion1,direccion2,cp,telf,direccion3 FROM empresa WHERE numemp = " + Global.nempresa);

                    if (em.Read())
                    {
                        nom_empre = em.GetString(0);
                        dire1 = em.GetString(1);
                        dire2 = em.GetString(5);
                        if (!em.IsDBNull(2))
                            dire3 = em.GetString(2);
                        if (!em.IsDBNull(3))
                            dire3 = dire3 + " " + em.GetString(3);
                        if (!em.IsDBNull(4))
                            dire3 = dire3 + " " + em.GetString(4);
                    }
                    em.Close();
                    if (filtro != "")
                    {
                        sele = "SELECT fecha1,fecha2,hora1,hora2,status, pesoneto,pesobruto,movimiento," +
                               "placas,guia,factura,embarque, observacion,proveedor,cliente,producto,transporte " +
                               "FROM Historia WHERE " + condi;

                        IDataReader dr = db.getDataReader(sele);
                        if (dr.Read())
                        {
                            fecha1 = string.Format("{0:" + Global.F_Fecha + "}", dr.GetValue(0));
                            hora11 = Convert.ToString(dr.GetValue(2));
                            txtpeso_bruto = Convert.ToString(dr.GetValue(6));
                            txtpeso_neto = Convert.ToString(dr.GetValue(5));
                            movimiento = dr.GetValue(7);
                            n_placas = dr.GetValue(8);
                            n_guia = dr.GetValue(9);
                            n_factura = dr.GetValue(10);
                            n_embarque = dr.GetValue(11);
                            observacion = dr.GetValue(12);
                            n_prove = dr.GetValue(13);
                            n_produc = dr.GetValue(15);
                            n_cliente = dr.GetValue(14);
                            n_transpor = dr.GetValue(16);

                            if (dr.GetString(4) == "F")
                            {
                                fecha2 = string.Format("{0:" + Global.F_Fecha + "}", dr.GetValue(1));
                                hora22 = Convert.ToString(dr.GetValue(3));
                            }
                            else
                            {
                                fecha2 = "";
                                hora22 = "";
                            }
                            hay = true;
                        }
                        else hay = false;
                        dr.Close();

                        Parametros p = new Parametros();
                        if (!hay)
                        {
                            MessageBox.Show(Global.M_Error[32, Global.idioma]);
                            Global.realizo_impresion = false;
                        }
                        else
                        {
                            Global.hora = System.DateTime.Now.Hour;
                            Global.minutos = System.DateTime.Now.Minute;
                            Global.segundo = System.DateTime.Now.Second;

                            DateTime MyDate = new DateTime(Global.year, Global.mes, Global.dia, Global.hora, Global.minutos, Global.segundo);

                            string fecha = string.Format("{0:" + Global.F_Fecha + "}", MyDate);
                            string hora1 = string.Format("{0:" + Global.F_Hora + "}", MyDate);

                            ParameterFields paramFields = new ParameterFields();

                            p.Documento_E_S(fecha, hora1, ref paramFields, nom_empre, dire1, dire2, dire3);

                            TableLogOnInfo logOnInfo = new TableLogOnInfo();
                            ConnectionInfo myconect = new ConnectionInfo();
                            myconect.DatabaseName = Global.DATABASE;
                            myconect.ServerName = Global.DATABASE;
                            myconect.Password = "";
                            myconect.UserID = "";

                            ReportDocument oRpt = new ReportDocument();
                            oRpt.Load(nombre_reporte);
                            bool autoSaveData = oRpt.ReportOptions.EnableSaveDataWithReport;
                            if (autoSaveData) oRpt.ReportOptions.EnableSaveDataWithReport = false;
                            oRpt.Refresh();
                            oRpt.RecordSelectionFormula = filtro;
                            foreach (Table table in oRpt.Database.Tables)
                            {
                                logOnInfo = table.LogOnInfo;
                                logOnInfo.ConnectionInfo = myconect;
                                table.ApplyLogOnInfo(logOnInfo);
                            }
                            crystalRV2.ParameterFieldInfo = paramFields;
                            crystalRV2.ReportSource = oRpt;
                            crystalRV2.SelectionFormula = filtro;
                            crystalRV2.LogOnInfo.Add(logOnInfo);
                        }
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                    }
                }
                else
                {
                    MessageBox.Show(Global.M_Error[305, Global.idioma]);
                    Global.realizo_impresion = true;
                }
            }
            catch (CrystalReportsException ex)
            {
                MessageBox.Show(ex.Message);
                Global.realizo_impresion = true;
            }
        }
        #endregion
        #region EVENTS
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Global.realizo_impresion = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            crystalRV2.PrintReport();
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            Global.realizo_impresion = true;
            this.Close();
            this.Dispose();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            crystalRV2.Refresh();
            Imprime_Movimiento(num_folio);
        }
        #endregion
        #region Windows Form Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preview));
            this.crystalRV2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalRV2
            // 
            this.crystalRV2.ActiveViewIndex = -1;
            resources.ApplyResources(this.crystalRV2, "crystalRV2");
            this.crystalRV2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalRV2.Name = "crystalRV2";
            this.crystalRV2.SelectionFormula = "";
            this.crystalRV2.ViewTimeSelectionFormula = "";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.crystalRV2);
            this.panel1.Name = "panel1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Preview
            // 
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Preview";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}
