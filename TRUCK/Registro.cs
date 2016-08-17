using System;
using System.Windows.Forms;
using System.IO;

namespace TRUCK
{


    /// <summary>
    /// Descripción breve de Registro.
    /// </summary>
    public class Registro : Form
    {
        #region VARIABLES
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox text1;
        private System.Windows.Forms.TextBox text2;
        private System.Windows.Forms.TextBox text3;
        private System.Windows.Forms.TextBox text4;
        private System.Windows.Forms.TextBox text5;
        private System.Windows.Forms.TextBox text6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ntran;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.IContainer components = null;
        #endregion
        #region CONSTRUCTORS
        public Registro()
        {
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();
            this.text1.LostFocus += new EventHandler(text1_LostFocus);
            this.text1.KeyDown += new KeyEventHandler(text1_KeyDown);
            this.text2.LostFocus += new EventHandler(text2_LostFocus);
            this.text2.KeyDown += new KeyEventHandler(text2_KeyDown);
            this.text3.LostFocus += new EventHandler(text3_LostFocus);
            this.text3.KeyDown += new KeyEventHandler(text3_KeyDown);
            this.text4.LostFocus += new EventHandler(text4_LostFocus);
            this.text4.KeyDown += new KeyEventHandler(text4_KeyDown);
            this.text5.LostFocus += new EventHandler(text5_LostFocus);
            this.text5.KeyDown += new KeyEventHandler(text5_KeyDown);
            this.text6.LostFocus += new EventHandler(text6_LostFocus);
            this.text6.KeyDown += new KeyEventHandler(text6_KeyDown);
            if (!File.Exists(Global.appPath + "\\License.txt"))
            {
                File.Create(Global.appPath + "\\License.txt");
            }
            else
            {
                FileStream fp = File.OpenRead(Global.appPath + "\\License.txt");
                StreamReader rf = new StreamReader(fp);
                int pos;
                char cc = (char)9;
                string renglon = rf.ReadLine();

                while (renglon != null && renglon.Length > 0)
                {
                    if (renglon.IndexOf(cc) <= 0)
                    { pos = renglon.Length; }
                    else { pos = renglon.IndexOf(cc); }

                    this.text1.Text = renglon.Substring(0, pos);
                    renglon = renglon.Substring(pos + 1);

                    if (renglon.IndexOf(cc) <= 0)
                    { pos = renglon.Length; }
                    else { pos = renglon.IndexOf(cc); }

                    this.text2.Text = renglon.Substring(0, pos);
                    renglon = renglon.Substring(pos + 1);

                    if (renglon.IndexOf(cc) <= 0)
                    { pos = renglon.Length; }
                    else { pos = renglon.IndexOf(cc); }

                    this.text3.Text = renglon.Substring(0, pos);
                    renglon = renglon.Substring(pos + 1);

                    if (renglon.IndexOf(cc) <= 0)
                    { pos = renglon.Length; }
                    else { pos = renglon.IndexOf(cc); }

                    this.text4.Text = renglon.Substring(0, pos);
                    renglon = renglon.Substring(pos + 1);

                    if (renglon.IndexOf(cc) <= 0)
                    { pos = renglon.Length; }
                    else { pos = renglon.IndexOf(cc); }

                    this.text5.Text = renglon.Substring(0, pos);
                    renglon = renglon.Substring(pos + 1);

                    if (renglon.IndexOf(cc) <= 0)
                    { pos = renglon.Length; }
                    else { pos = renglon.IndexOf(cc); }

                    this.text6.Text = renglon.Substring(0, pos);
                    renglon = "";
                }
                rf.Close();
                fp.Close();
                text1.Text = text1.Text.PadLeft(6, '0');
                text2.Text = text2.Text.PadLeft(6, '0');
                text3.Text = text3.Text.PadLeft(6, '0');
                text4.Text = text4.Text.PadLeft(6, '0');
                text5.Text = text5.Text.PadLeft(6, '0');
                text6.Text = text6.Text.PadLeft(6, '0');
                // Asigna el numero de la licencia al software
                Keylock.ValidateCode1 = Convert.ToUInt16(this.text1.Text.Substring(2), 16);
                Keylock.ValidateCode2 = Convert.ToUInt16(this.text2.Text.Substring(2), 16);
                Keylock.ValidateCode3 = Convert.ToUInt16(this.text3.Text.Substring(2), 16);
                Keylock.ClientIDCode1 = Convert.ToUInt16(this.text4.Text.Substring(2), 16);
                Keylock.ClientIDCode2 = Convert.ToUInt16(this.text5.Text.Substring(2), 16);
                Keylock.ReadCode1 = Convert.ToUInt16(this.text6.Text.Substring(2), 16);
            }
            //
            // TODO: Agregar código de constructor después de llamar a InitializeComponent
            //
        }
        #endregion
        #region EVENTS
        void text1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.text2.Focus();
        }
        void text1_LostFocus(object sender, EventArgs e)
        {
            text1.Text = text1.Text.ToUpper();
            text1.Text = text1.Text.PadLeft(6, '0');
        }
        void text2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.text3.Focus();
        }
        void text2_LostFocus(object sender, EventArgs e)
        {
            text2.Text = text2.Text.ToUpper();
            text2.Text = text2.Text.PadLeft(6, '0');
        }
        void text3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.text4.Focus();
        }
        void text3_LostFocus(object sender, EventArgs e)
        {
            text3.Text = text3.Text.ToUpper();
            text3.Text = text3.Text.PadLeft(6, '0');
        }
        void text4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.text5.Focus();
        }
        void text4_LostFocus(object sender, EventArgs e)
        {
            text4.Text = text4.Text.ToUpper();
            text4.Text = text4.Text.PadLeft(6, '0');
        }
        void text5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.text6.Focus();
        }
        void text5_LostFocus(object sender, EventArgs e)
        {
            text5.Text = text5.Text.ToUpper();
            text5.Text = text5.Text.PadLeft(6, '0');
        }
        void text6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.button1.Focus();
        }
        void text6_LostFocus(object sender, EventArgs e)
        {
            text6.Text = text6.Text.ToUpper();
            text6.Text = text6.Text.PadLeft(6, '0');
        }

        void licencia()
        {
            /**/
            text1.Text = "00F606";
            text2.Text = "00D564";
            text3.Text = "009D62";
            text4.Text = "005EA9";
            text5.Text = "00D3BF";
            text6.Text = "009ACC";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //licencia();
            text1.Text = text1.Text.PadLeft(6, '0');
            text2.Text = text2.Text.PadLeft(6, '0');
            text3.Text = text3.Text.PadLeft(6, '0');
            text4.Text = text4.Text.PadLeft(6, '0');
            text5.Text = text5.Text.PadLeft(6, '0');
            text6.Text = text6.Text.PadLeft(6, '0');

            // Asigna el numero de la licencia al software
            Keylock.ValidateCode1 = Convert.ToUInt16(this.text1.Text.Substring(2), 16);
            Keylock.ValidateCode2 = Convert.ToUInt16(this.text2.Text.Substring(2), 16);
            Keylock.ValidateCode3 = Convert.ToUInt16(this.text3.Text.Substring(2), 16);
            Keylock.ClientIDCode1 = Convert.ToUInt16(this.text4.Text.Substring(2), 16);
            Keylock.ClientIDCode2 = Convert.ToUInt16(this.text5.Text.Substring(2), 16);
            Keylock.ReadCode1     = Convert.ToUInt16(this.text6.Text.Substring(2), 16);

            if (!Keylock.IsPresent())
            {
                MessageBox.Show(Global.M_Error[26, Global.idioma] + "\n" + Global.M_Error[147, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.text1.Focus();
            }
            else
            {
                MessageBox.Show(Global.M_Error[25, Global.idioma], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FileStream fp = File.OpenWrite(Global.appPath + "\\License.txt");
                StreamWriter wf = new StreamWriter(fp);
                wf.WriteLine(this.text1.Text + (char)9 + this.text2.Text + (char)9 + this.text3.Text + (char)9 + this.text4.Text + (char)9 + this.text5.Text + (char)9 + this.text6.Text);
                wf.Close();
                fp.Close();
                this.Close();
                this.Dispose();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }


        #endregion
        #region Windows Form Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.text1 = new TextBox();
            this.text2 = new System.Windows.Forms.TextBox();
            this.text3 = new System.Windows.Forms.TextBox();
            this.text4 = new System.Windows.Forms.TextBox();
            this.text5 = new System.Windows.Forms.TextBox();
            this.text6 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ntran = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            // text1
            // 
            this.text1.AccessibleDescription = null;
            this.text1.AccessibleName = null;
            resources.ApplyResources(this.text1, "text1");
            this.text1.BackgroundImage = null;
            this.text1.Font = null;
            this.text1.Name = "text1";
            // 
            // text2
            // 
            this.text2.AccessibleDescription = null;
            this.text2.AccessibleName = null;
            resources.ApplyResources(this.text2, "text2");
            this.text2.BackgroundImage = null;
            this.text2.Font = null;
            this.text2.Name = "text2";
            // 
            // text3
            // 
            this.text3.AccessibleDescription = null;
            this.text3.AccessibleName = null;
            resources.ApplyResources(this.text3, "text3");
            this.text3.BackgroundImage = null;
            this.text3.Font = null;
            this.text3.Name = "text3";
            // 
            // text4
            // 
            this.text4.AccessibleDescription = null;
            this.text4.AccessibleName = null;
            resources.ApplyResources(this.text4, "text4");
            this.text4.BackgroundImage = null;
            this.text4.Font = null;
            this.text4.Name = "text4";
            // 
            // text5
            // 
            this.text5.AccessibleDescription = null;
            this.text5.AccessibleName = null;
            resources.ApplyResources(this.text5, "text5");
            this.text5.BackgroundImage = null;
            this.text5.Font = null;
            this.text5.Name = "text5";
            // 
            // text6
            // 
            this.text6.AccessibleDescription = null;
            this.text6.AccessibleName = null;
            resources.ApplyResources(this.text6, "text6");
            this.text6.BackgroundImage = null;
            this.text6.Font = null;
            this.text6.Name = "text6";
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Controls.Add(this.text1);
            this.groupBox1.Controls.Add(this.text5);
            this.groupBox1.Controls.Add(this.text3);
            this.groupBox1.Controls.Add(this.text6);
            this.groupBox1.Controls.Add(this.text2);
            this.groupBox1.Controls.Add(this.text4);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = null;
            this.groupBox2.AccessibleName = null;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackgroundImage = null;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ntran);
            this.groupBox2.Font = null;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Name = "label3";
            // 
            // ntran
            // 
            this.ntran.AccessibleDescription = null;
            this.ntran.AccessibleName = null;
            resources.ApplyResources(this.ntran, "ntran");
            this.ntran.ForeColor = System.Drawing.Color.Maroon;
            this.ntran.Name = "ntran";
            // 
            // Registro
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Registro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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