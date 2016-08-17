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
	public class Monitor1 : Form
    {

        #region VARIABLES
        private GroupBox groupBox1;
        private Label pto1;
        private SerialPort serialPort1 = new SerialPort();
        private string mensaje;
        private Button button1;
        delegate void SetTextCallback(string text);
        private IContainer components = null;
        private Timer timer1;
        private Comunica RS232 = new Comunica();

        #endregion
        #region CONSTRUCTORS
        public Monitor1()
		{
            InitializeComponent();
         
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pto1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
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
            resources.ApplyResources(this.pto1, "pto1");
            this.pto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pto1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pto1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pto1.Name = "pto1";
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
            // Monitor1
            // 
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Monitor1";
            this.Load += new System.EventHandler(this.Monitor1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        #region EVENTS
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            mensaje += this.serialPort1.ReadExisting();

            if (mensaje.IndexOf((char)13) > 0)
            {
                if (mensaje.Length > 0)
                {
                    if (mensaje.IndexOf("NEG") < 0 && mensaje.IndexOf("OVER") < 0 && mensaje.IndexOf("SOBRE") < 0 && mensaje.IndexOf("&&") < 0) mensaje = RS232.obtiene_peso(mensaje);
                    else mensaje = "0";
                    SetText(mensaje);
                }

            }
        }
        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show(e.EventType.ToString());
        }
        private void serialPort1_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            MessageBox.Show(e.EventType.ToString());
        }
        private void SetText(string text)
        {
            if (this.pto1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {                
                this.pto1.Text = text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {       
                this.timer1.Stop();
                this.timer1.Enabled = false;

                if (this.serialPort1.IsOpen)
                {
                    this.serialPort1.DiscardInBuffer();
                    this.serialPort1.DiscardOutBuffer();
                    RS232.Termino(ref this.serialPort1);
                }
                this.serialPort1.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);

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
        private void Monitor1_Load(object sender, EventArgs e)
        {
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);
            this.serialPort1.ErrorReceived += new SerialErrorReceivedEventHandler(serialPort1_ErrorReceived);
            this.serialPort1.PinChanged += new SerialPinChangedEventHandler(serialPort1_PinChanged);
            RS232.inicia(ref this.serialPort1, Global.P_COMM1, Global.Buad1, ref mensaje);
            this.timer1.Interval = 1000;
            this.timer1.Enabled = true;
            this.timer1.Start();
            //RS232.SendData(ref this.serialPort1, ref mensaje, "P");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Global.scale == 0) RS232.SendData(ref this.serialPort1, ref mensaje, "P");
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
