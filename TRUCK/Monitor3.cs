using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO.Ports;

namespace TRUCK
{
	/// <summary>
	/// Descripción breve de Monitoreo.
	/// </summary>
	public class Monitor3 : System.Windows.Forms.Form
    {
        #region VARIABLES
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Label pto1;
		private System.Windows.Forms.Label pto2;
        private System.Windows.Forms.Label pto3;
        private Button button1;
        private string mensaje1;
        private string mensaje2;
        private string mensaje3;
        private SerialPort serialPort1 = new SerialPort();
        private SerialPort serialPort2 = new SerialPort();
        private SerialPort serialPort3 = new SerialPort();
        private IContainer components = null;
        private Timer timer1;
        delegate void SetTextCallback(string text);
        private Comunica RS232 = new Comunica();
        #endregion
        #region CONSTRUTORS
        public Monitor3()
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();            
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort2_DataReceived);
            this.serialPort3.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort3_DataReceived);
            RS232.inicia(ref this.serialPort1, Global.P_COMM1, Global.Buad1, ref mensaje1);
            RS232.inicia(ref this.serialPort2, Global.P_COMM2, Global.Buad2, ref mensaje2);
            RS232.inicia(ref this.serialPort3, Global.P_COMM3, Global.Buad3, ref mensaje3);
            this.timer1.Interval = 1000;
            this.timer1.Enabled = true;
            this.timer1.Start();
			//
			// TODO: Agregar código de constructor después de llamar a InitializeComponent
			//
		}
        #endregion
        #region EVENTS
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Global.scale == 0) RS232.SendData(ref this.serialPort1, ref mensaje1, "P");
            if (Global.scale == 0) RS232.SendData(ref this.serialPort2, ref mensaje2, "P");
            if (Global.scale == 0) RS232.SendData(ref this.serialPort3, ref mensaje3, "P");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Stop();
                this.timer1.Enabled = false;

                this.serialPort1.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);
                this.serialPort2.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(serialPort2_DataReceived);
                this.serialPort3.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(serialPort3_DataReceived);
                if (this.serialPort1.IsOpen)
                {
                    this.serialPort1.DiscardInBuffer();
                    this.serialPort1.DiscardOutBuffer();
                    RS232.Termino(ref this.serialPort1);
                }
                if (this.serialPort2.IsOpen)
                {
                    this.serialPort2.DiscardInBuffer();
                    this.serialPort2.DiscardOutBuffer();
                    RS232.Termino(ref this.serialPort2);
                }
                if (this.serialPort3.IsOpen)
                {
                    this.serialPort3.DiscardInBuffer();
                    this.serialPort3.DiscardOutBuffer();
                    RS232.Termino(ref this.serialPort3);
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







      
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            mensaje1 += this.serialPort1.ReadExisting();

            if (mensaje1.IndexOf((char)13) > 0)
            {
                if (mensaje1.Length > 0)
                {
                    if (mensaje1.IndexOf("NEG") < 0 && mensaje1.IndexOf("OVER") < 0 && mensaje1.IndexOf("SOBRE") < 0 && mensaje1.IndexOf("&&") < 0) mensaje1 = RS232.obtiene_peso(mensaje1);
                    else mensaje1 = "0";
                    SetText1(mensaje1);
                }
                //if (this.serialPort1.IsOpen) RS232.SendData(ref this.serialPort1, ref mensaje1, "P");
            }
        }
        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            mensaje2 += this.serialPort2.ReadExisting();

            if (mensaje2.IndexOf((char)13) > 0)
            {
                if (mensaje2.Length > 0)
                {
                    if (mensaje2.IndexOf("NEG") < 0 && mensaje2.IndexOf("OVER") < 0 && mensaje2.IndexOf("SOBRE") < 0 && mensaje1.IndexOf("&&") < 0) mensaje2 = RS232.obtiene_peso(mensaje2);
                    else mensaje2 = "0";
                    SetText2(mensaje2);
                }
            }
        }
        private void serialPort3_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            mensaje3 += this.serialPort3.ReadExisting();

            if (mensaje3.IndexOf((char)13) > 0)
            {
                if (mensaje3.Length > 0)
                {
                    if (mensaje3.IndexOf("NEG") < 0 && mensaje3.IndexOf("OVER") < 0 && mensaje3.IndexOf("SOBRE") < 0 && mensaje1.IndexOf("&&") < 0) mensaje3 = RS232.obtiene_peso(mensaje3);
                    else mensaje3 = "0";
                    SetText3(mensaje3);

                }
            }
        }







        #endregion
        #region FUCTIONS
        private void SetText1(string text)
        {

            if (this.pto1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText1);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.pto1.Text = text;
            }
        }
        private void SetText2(string text)
        {

            if (this.pto2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText2);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.pto2.Text = text;
            }
        }
        private void SetText3(string text)
        {

            if (this.pto3.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText3);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.pto3.Text = text;
            }
        }
        #endregion
        #region Windows Form Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor3));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pto1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pto2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pto3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.pto1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // pto1
            // 
            this.pto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pto1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pto1, "pto1");
            this.pto1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pto1.Name = "pto1";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.pto2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // pto2
            // 
            this.pto2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pto2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pto2, "pto2");
            this.pto2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pto2.Name = "pto2";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.pto3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // pto3
            // 
            this.pto3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pto3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pto3, "pto3");
            this.pto3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pto3.Name = "pto3";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Monitor3
            // 
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Monitor3";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
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
