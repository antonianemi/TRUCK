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
    public partial class RListados : Form
    {
        #region VARIABLES
        ParameterFields paramFields = new ParameterFields();
        DataAccesQuery db;
        private int opcion;
        #endregion
        #region CONSTRUCTORS
        public RListados(int opc)
        {
            db = new DataAccesQuery();
            InitializeComponent();
            this.ven1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ven1_KeyDown);
            this.ven2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ven2_KeyDown);
            this.ven2.Validating += new System.ComponentModel.CancelEventHandler(this.ven2_Validating);           
            switch (Global.aplicacion)
            {
                case 0:  //Aplicacion para el publico
                    {
                        this.Listados.Items.Add(Global.M_Error[163, Global.idioma]);  //Listado de Empresa
                        this.Listados.Items.Add(Global.M_Error[170, Global.idioma]);  //Listado de Precio
                        this.Listados.Items.Add(Global.M_Error[164, Global.idioma]);  //Listado de Clientes
                        this.Listados.Items.Add(Global.M_Error[188, Global.idioma]);  //Listado de vehiculo tara
                    } break;
                case 1:  // Aplicacion para el privado
                    {
                        this.Listados.Items.Add(Global.M_Error[163, Global.idioma]);  //Listado de Empresa
                        this.Listados.Items.Add(Global.M_Error[165, Global.idioma]);  //Listado de Productos
                        this.Listados.Items.Add(Global.M_Error[166, Global.idioma]);  //Listado de Proveedores
                        this.Listados.Items.Add(Global.M_Error[164, Global.idioma]);  //Listado de Clientes                        
                        this.Listados.Items.Add(Global.M_Error[167, Global.idioma]);  //Listado de Transportista
                        this.Listados.Items.Add(Global.M_Error[188, Global.idioma]);  //Listado de vehiculo tara
                    } break;
                case 2:
                    {
                        this.Listados.Items.Add(Global.M_Error[163, Global.idioma]);  //Listado de Empresa
                        this.Listados.Items.Add(Global.M_Error[165, Global.idioma]);  //Listado de Productos
                        this.Listados.Items.Add(Global.M_Error[166, Global.idioma]);  //Listado de Proveedores
                        this.Listados.Items.Add(Global.M_Error[164, Global.idioma]);  //Listado de Clientes
                    } break;
            }
            this.opcion = opc;
            if (opc == 6) this.button1_Click(this.button1, new EventArgs());
            else this.Listados.SelectedIndex = opc;
        }
        #endregion
        #region EVENTS
        private void ven1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ven2.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
        }
        private void ven2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ven1.Text != "")
                {
                    if (this.ven2.Text == "")
                    {
                        MessageBox.Show(this.label1.Text + " " + this.label2.Text + " " + Global.M_Error[67, Global.idioma]);
                        this.ven2.Focus();
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
        private void ven2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ven1.Text != "")
            {
                if (ven2.Text == "")
                {
                    MessageBox.Show(this.label1.Text + " " + this.label2.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.ven2.Focus();
                }
                else this.button1.Focus();
            }
            else
            {
                if (ven2.Text != "")
                {
                    MessageBox.Show(this.label2.Text + " " + this.label1.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.ven1.Focus();
                }
                else this.button1.Focus();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string nombre_reporte = "";

            System.Globalization.DateTimeFormatInfo myCI = new System.Globalization.DateTimeFormatInfo();
            myCI.ShortDatePattern = Global.F_Fecha;

            if (ven1.Text != "")
            {
                if (ven2.Text == "")
                {
                    MessageBox.Show(this.label1.Text + " " + this.label2.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.ven2.Focus();
                    return;
                }
            }
            else
            {
                if (ven2.Text != "")
                {
                    MessageBox.Show(this.label2.Text + " " + this.label1.Text + " " + Global.M_Error[67, Global.idioma]);
                    this.ven1.Focus();
                    return;
                }
            }

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
           
            DateTime MyDate = new DateTime(Global.year, Global.mes, Global.dia, Global.hora, Global.minutos, Global.segundo);
            string fecha = string.Format("{0:" + Global.F_Fecha + "}", MyDate);
            string hora1 = string.Format("{0:" + Global.F_Hora + "}", MyDate);

            bool hay = false;
            string condi = "";
            string filtro = "";
            string sele = "";
            int inicio = 0, fin = 0, n_reporte = 0;

            if (this.ven1.Text.Length > 0 && this.ven2.Text.Length > 0)
            {
                inicio = Convert.ToInt32(this.ven1.Text);
                fin = Convert.ToInt32(this.ven2.Text);
            }
            if (opcion != 6)
            {
                switch (this.Listados.SelectedIndex)
                {
                    case 0: // Listado de Empresa
                        {
                            nombre_reporte = Global.REPORTES + "\\LEmpresa.rpt";
                            if (inicio != 0 && fin != 0)
                            {
                                filtro = "({empresa.numemp} >= " + inicio + " and {empresa.numemp} <= " + fin + ")";
                                condi = "(numemp >= " + inicio + ") and (numemp <= " + fin + ")";
                                sele = "SELECT * FROM empresa WHERE " + condi;
                            }
                            else
                            {
                                //filtro = "({empresa.numemp} = " + Global.nempresa + ")";
                               // condi = "(numemp = " + Global.nempresa + ")";
                                sele = "SELECT * FROM empresa";
                            }
                           
                            n_reporte = 163;
                        } break;
                    case 1:  // Listado producto para el publico
                        {
                            if (Global.aplicacion == 0)nombre_reporte = Global.REPORTES + "\\LProducto.rpt";
                            else nombre_reporte = Global.REPORTES + "\\LProducto2.rpt";
                            
                            if (inicio != 0 && fin != 0)
                            {
                                filtro = "({articulos.numero} >= " + inicio + " and {articulos.numero} <= " + fin + " and {articulos.numemp} = " + Global.nempresa + ")";
                                condi = "(numero >= " + inicio + ") and (numero <= " + fin + ") and (numemp = " + Global.nempresa + ")";
                            }
                            else
                            {
                                filtro = "({articulos.numemp} = " + Global.nempresa + ")";
                                condi = "(numemp = " + Global.nempresa + ")";
                            }
                            sele = "SELECT * FROM articulos WHERE " + condi;
                            n_reporte = 165;
                        } break;
                    case 2:  //Listado de proveedores y clientes para el publico
                        {
                            if (Global.aplicacion == 0)
                            {
                                nombre_reporte = Global.REPORTES + "\\LCliente.rpt";
                                if (inicio != 0 && fin != 0)
                                {
                                    filtro = "({cliente.numero} >= " + inicio + " and {cliente.numero} <= " + fin + " and {cliente.numemp} = " + Global.nempresa + ")";
                                    condi = "(numero >= " + inicio + ") and (numero <= " + fin + ") and (numemp = " + Global.nempresa + ")";
                                }
                                else
                                {
                                    filtro = "({cliente.numemp} = " + Global.nempresa + ")";
                                    condi = "(numemp = " + Global.nempresa + ")";
                                }
                                sele = "SELECT * FROM cliente WHERE " + condi;
                                n_reporte = 164;
                            }
                            else
                            {
                                nombre_reporte = Global.REPORTES + "\\LProveedor.rpt";
                                if (inicio != 0 && fin != 0)
                                {
                                    filtro = "({proveedor.numero} >= " + inicio + " and {proveedor.numero} <= " + fin + " and {proveedor.numemp} = " + Global.nempresa + ")";
                                    condi = "(numero >= " + inicio + ") and (numero <= " + fin + ") and (numemp = " + Global.nempresa + ")";
                                }
                                else
                                {
                                    filtro = "({proveedor.numemp} = " + Global.nempresa + ")";
                                    condi = "(numemp = " + Global.nempresa + ")";
                                }
                                sele = "SELECT * FROM proveedor WHERE " + condi;
                                n_reporte = 166;
                            }
                        } break;
                    case 3:  // Listado de Cliente y listado de vehiculo tara
                        {
                            if (Global.aplicacion == 0)
                            {
                                nombre_reporte = Global.REPORTES + "\\LVehiculo.rpt";
                                if (inicio != 0 && fin != 0)
                                {
                                    filtro = "({taras.numero} >= " + inicio + " and {taras.numero} <= " + fin + " and {taras.numemp} = " + Global.nempresa + ")";
                                    condi = "(numero >= " + inicio + ") and (numero <= " + fin + ") and (numemp = " + Global.nempresa + ")";
                                }
                                else
                                {
                                    filtro = "({taras.numemp} = " + Global.nempresa + ")";
                                    condi = "(numemp = " + Global.nempresa + ")";
                                }
                                sele = "SELECT * FROM tara WHERE " + condi; 
                                n_reporte = 188;
                            }
                            else
                            {
                                nombre_reporte = Global.REPORTES + "\\LCliente.rpt";
                                if (inicio != 0 && fin != 0)
                                {
                                    filtro = "({cliente.numero} >= " + inicio + " and {cliente.numero} <= " + fin + " and {cliente.numemp} = " + Global.nempresa + ")";
                                    condi = "(numero >= " + inicio + ") and (numero <= " + fin + ") and (numemp = " + Global.nempresa + ")";
                                }
                                else
                                {
                                    filtro = "({cliente.numemp} = " + Global.nempresa + ")";
                                    condi = "(numemp = " + Global.nempresa + ")";
                                }
                                sele = "SELECT * FROM cliente WHERE " + condi;
                                n_reporte = 164;
                            }
                        } break;
                    case 4:  // Listado de Transportista
                        {
                            nombre_reporte = Global.REPORTES + "\\LTransporte.rpt";
                            if (inicio != 0 && fin != 0)
                            {
                                filtro = "({transportistas.numero} >= " + inicio + " and {transportistas.numero} <= " + fin + " and {transportistas.numemp} = " + Global.nempresa + ")";
                                condi = "(numero >= " + inicio + ") and (numero <= " + fin + ") and (numemp = " + Global.nempresa + ")";
                            }
                            else
                            {
                                filtro = "({transportistas.numemp} = " + Global.nempresa + ")";
                                condi = "(numemp = " + Global.nempresa + ")";
                            }
                            sele = "SELECT * FROM transportistas WHERE " + condi;
                            n_reporte = 167;
                        } break;
                    case 5: //Listado de Vehiculo tara
                        {
                            nombre_reporte = Global.REPORTES + "\\LVehiculo.rpt";
                            if (inicio != 0 && fin != 0)
                            {
                                filtro = "({taras.numero} >= " + inicio + " and {taras.numero} <= " + fin + " and {taras.numemp} = " + Global.nempresa + ")";
                                condi = "(numero >= " + inicio + ") and (numero <= " + fin + ") and (numemp = " + Global.nempresa + ")";
                            }
                            else
                            {
                                filtro = "({taras.numemp} = " + Global.nempresa + ")";
                                condi = "(numemp = " + Global.nempresa + ")";
                            }
                            sele = "SELECT * FROM tara WHERE " + condi;
                            n_reporte = 188;
                        } break;
                }
            }
            else
            {
                nombre_reporte = Global.REPORTES + "\\Lusuario.rpt";
                filtro = "";
                sele = "SELECT * FROM usuarios ORDER BY user";
                n_reporte = 174;
            }



            IDataReader dr = db.getDataReader(sele);
            if (dr.Read()) hay = true;
            else hay = false;
            dr.Close();
            Parametros p = new Parametros();
            if (!hay) MessageBox.Show(Global.M_Error[32, Global.idioma]);
            else
            {
                this.button1.Enabled = false;
                p.Listados_Maestros(n_reporte, fecha, hora1, ref paramFields);
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load(nombre_reporte);
                bool autoSaveData = oRpt.ReportOptions.EnableSaveDataWithReport;
                if (autoSaveData) oRpt.ReportOptions.EnableSaveDataWithReport = false;
                oRpt.Refresh();
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
        private void Listados_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.Listados.SelectedIndex)
            {
                case 0:  //Listado de empresa
                    {
                        this.label1.Text = Global.M_Error[197, Global.idioma];
                        this.label2.Text = Global.M_Error[198, Global.idioma];
                    }
                break;

                case 1: //Listado de Tarifa y producto
                    {
                        if (Global.aplicacion == 0)
                        {
                            this.label1.Text = Global.M_Error[171, Global.idioma];
                            this.label2.Text = Global.M_Error[172, Global.idioma];
                        }
                        else
                        {
                            this.label1.Text = Global.M_Error[201, Global.idioma];
                            this.label2.Text = Global.M_Error[202, Global.idioma];
                        }
                    }
                break;

                case 2: //Listado de Cliente para el publico y proveedores para otros
                    {
                        if (Global.aplicacion == 0)
                        {
                            this.label1.Text = Global.M_Error[193, Global.idioma];
                            this.label2.Text = Global.M_Error[194, Global.idioma];
                        }
                        else
                        {
                            this.label1.Text = Global.M_Error[203, Global.idioma];
                            this.label2.Text = Global.M_Error[204, Global.idioma];
                        }
                    }
                break;
                                    
                case 3: //Listado de clientes
                    {
                        this.label1.Text = Global.M_Error[193, Global.idioma];
                        this.label2.Text = Global.M_Error[194, Global.idioma];
                    }
                break;


                case 4: //Listado de Transportista
                    {
                        this.label1.Text = Global.M_Error[296, Global.idioma];
                        this.label2.Text = Global.M_Error[297, Global.idioma];
                    }
                break;

                case 5:  //Listado de Vehiculos tara
                    {
                        this.label1.Text = Global.M_Error[298, Global.idioma];
                        this.label2.Text = Global.M_Error[299, Global.idioma];
                    }
                break;


            }
            this.label1.Refresh();
            this.label2.Refresh();
            this.button1.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion
    }
}
