using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace TRUCK
{
	/// <summary>
	/// Descripción breve de FiltroB.
	/// </summary>
	public class Folio : System.Windows.Forms.Form
    {
        #region VARIABLES
        DataAccesQuery db;
        DataSet dt1;
        private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Button button1;
        ParameterFields paramFields = new ParameterFields();
		private System.Windows.Forms.Button button2;
        private MaskedTextBox.MaskedTextBox ven2;
        private MaskedTextBox.MaskedTextBox ven1;
        public Label Label6;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalRV2;
        private System.ComponentModel.Container components = null;
        #endregion
        #region CONSTRUCTORS
        public Folio(int opc, string n_folio)
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();
            db = new DataAccesQuery();
			this.TransparencyKey = Color.Empty;
			this.ven1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ven1_KeyDown);
			this.ven2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ven2_KeyDown);
            this.ven2.Text = n_folio;
            this.ven1.Text = n_folio;
           	//
			// TODO: Agregar código de constructor después de llamar a InitializeComponent
			//
		}
        public Folio()
        {
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();
            this.TransparencyKey = Color.Empty;
            this.ven1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ven1_KeyDown);
            this.ven2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ven2_KeyDown);
            //
            // TODO: Agregar código de constructor después de llamar a InitializeComponent
            //
        }
        #endregion
        #region Windows Form Designer generated code
        /// <summary>
		/// Método necesario para admitir el Diseñador, no se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Folio));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ven2 = new MaskedTextBox.MaskedTextBox();
            this.ven1 = new MaskedTextBox.MaskedTextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.crystalRV2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ven2);
            this.panel1.Controls.Add(this.ven1);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.Label6);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // ven2
            // 
            this.ven2.AccessibleDescription = null;
            this.ven2.AccessibleName = null;
            resources.ApplyResources(this.ven2, "ven2");
            this.ven2.BackgroundImage = null;
            this.ven2.DateOnly = false;
            this.ven2.DecimalOnly = false;
            this.ven2.DigitOnly = true;
            this.ven2.Font = null;
            this.ven2.IPAddrOnly = false;
            this.ven2.Name = "ven2";
            this.ven2.PhoneWithAreaCode = false;
            this.ven2.SSNOnly = false;
            // 
            // ven1
            // 
            this.ven1.AccessibleDescription = null;
            this.ven1.AccessibleName = null;
            resources.ApplyResources(this.ven1, "ven1");
            this.ven1.BackgroundImage = null;
            this.ven1.DateOnly = false;
            this.ven1.DecimalOnly = false;
            this.ven1.DigitOnly = true;
            this.ven1.Font = null;
            this.ven1.IPAddrOnly = false;
            this.ven1.Name = "ven1";
            this.ven1.PhoneWithAreaCode = false;
            this.ven1.SSNOnly = false;
            // 
            // Label1
            // 
            this.Label1.AccessibleDescription = null;
            this.Label1.AccessibleName = null;
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = null;
            this.Label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label1.Name = "Label1";
            // 
            // Label2
            // 
            this.Label2.AccessibleDescription = null;
            this.Label2.AccessibleName = null;
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = null;
            this.Label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label2.Name = "Label2";
            // 
            // Label6
            // 
            this.Label6.AccessibleDescription = null;
            this.Label6.AccessibleName = null;
            resources.ApplyResources(this.Label6, "Label6");
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label6.Font = null;
            this.Label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label6.Name = "Label6";
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AccessibleDescription = null;
            this.button2.AccessibleName = null;
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackgroundImage = null;
            this.button2.Font = null;
            this.button2.Name = "button2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // crystalRV2
            // 
            this.crystalRV2.AccessibleDescription = null;
            this.crystalRV2.AccessibleName = null;
            this.crystalRV2.ActiveViewIndex = -1;
            resources.ApplyResources(this.crystalRV2, "crystalRV2");
            this.crystalRV2.BackgroundImage = null;
            this.crystalRV2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalRV2.DisplayStatusBar = false;
            this.crystalRV2.Font = null;
            this.crystalRV2.Name = "crystalRV2";
            this.crystalRV2.SelectionFormula = "";
            this.crystalRV2.ViewTimeSelectionFormula = "";
            // 
            // Folio
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.crystalRV2);
            this.Controls.Add(this.panel1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Folio";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        #region EVENTS
        private void button1_Click(object sender, System.EventArgs e)
        {           
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            this.button1.Enabled = false;
            Imprime_Movimiento(2, Convert.ToInt32(this.ven1.Text), Convert.ToInt32(this.ven2.Text));
        }
        private void Imprime_Movimiento(int opc,int inicio, int final)
        {
            try
            {
                string filtro = "";
                string nombre_reporte;
                string sele = "";
                string nom_empre = "";
                string dire1 = "";
                string dire2 = "";
                string dire3 = "";
                bool hay = false;
                
                this.button1.Enabled = false;
                             
                this.Text = Global.M_Error[162, Global.idioma].ToString();
                string condi = "";
                if (inicio > 0 && final > 0)
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    if (Global.tipo_dato == 1)
                    {
                        if (Global.aplicacion == 0) nombre_reporte = Global.REPORTES + "\\Movimientos_publico2.rpt";
                        else nombre_reporte = Global.REPORTES + "\\Movimientos2.rpt";
                    }
                    else
                    {
                        if (Global.aplicacion == 0) nombre_reporte = Global.REPORTES + "\\Movimientos_publico_3ejes2.rpt";
                        else nombre_reporte = Global.REPORTES + "\\Movimientos_3ejes2.rpt";
                    }
                    filtro = "({historia.folio} >= " + inicio + " and {historia.folio} <= " + final + " and {historia.numemp} = " + Global.nempresa + ")";  // and {historia.status} = 'F')";
                    condi = "(folio >= " + inicio + " and folio <= " + final + " and numemp = " + Global.nempresa + ")";  // and status = 'F')";

                    IDataReader em = db.getDataReader("SELECT empresa,direccion1,direccion2,cp,telf,direccion3 FROM empresa WHERE numemp = " + Global.nempresa);

                    if (em.Read())
                    {
                        nom_empre = em.GetString(0);
                        if (!em.IsDBNull(1))
                            dire1 = em.GetString(1);
                        if (!em.IsDBNull(5))
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
                        sele = "SELECT * FROM Historia WHERE " + condi;
                        IDataReader dr = db.getDataReader(sele);
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

                            p.Documento_E_S(fecha, hora1, ref paramFields, nom_empre, dire1, dire2,dire3);

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
                            oRpt.RecordSelectionFormula = filtro;
                            oRpt.Refresh();
                            
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
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                        }
                    }
                }
                else MessageBox.Show(Global.M_Error[305, Global.idioma]);                
            }
            catch (CrystalReportsException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }		
		private void ven1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.ven2.Focus();
			}
		}
		private void ven2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.button1.Focus();
			}
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
			this.Close();
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
