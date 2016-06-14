namespace TRUCK
{
    public partial class ROtros
    {



        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ROtros));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_fin = new MaskedTextBox.MaskedTextBox();
            this.txt_inicio = new MaskedTextBox.MaskedTextBox();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.crystalRV2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.placa1 = new System.Windows.Forms.TextBox();
            this.cliente1 = new MaskedTextBox.MaskedTextBox();
            this.cliente2 = new MaskedTextBox.MaskedTextBox();
            this.placa2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.placa1);
            this.panel1.Controls.Add(this.cliente1);
            this.panel1.Controls.Add(this.cliente2);
            this.panel1.Controls.Add(this.placa2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_fin);
            this.panel1.Controls.Add(this.txt_inicio);
            this.panel1.Controls.Add(this.date2);
            this.panel1.Controls.Add(this.date1);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // txt_fin
            // 
            this.txt_fin.DateOnly = false;
            this.txt_fin.DecimalOnly = false;
            this.txt_fin.DigitOnly = true;
            this.txt_fin.IPAddrOnly = false;
            resources.ApplyResources(this.txt_fin, "txt_fin");
            this.txt_fin.Name = "txt_fin";
            this.txt_fin.PhoneWithAreaCode = false;
            this.txt_fin.SSNOnly = false;
            // 
            // txt_inicio
            // 
            this.txt_inicio.DateOnly = false;
            this.txt_inicio.DecimalOnly = false;
            this.txt_inicio.DigitOnly = true;
            this.txt_inicio.IPAddrOnly = false;
            resources.ApplyResources(this.txt_inicio, "txt_inicio");
            this.txt_inicio.Name = "txt_inicio";
            this.txt_inicio.PhoneWithAreaCode = false;
            this.txt_inicio.SSNOnly = false;
            // 
            // date2
            // 
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.date2, "date2");
            this.date2.Name = "date2";
            // 
            // date1
            // 
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.date1, "date1");
            this.date1.Name = "date1";
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
            // crystalRV2
            // 
            this.crystalRV2.ActiveViewIndex = -1;
            this.crystalRV2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.crystalRV2, "crystalRV2");
            this.crystalRV2.Name = "crystalRV2";
            this.crystalRV2.SelectionFormula = "";
            this.crystalRV2.ViewTimeSelectionFormula = "";
            // 
            // placa1
            // 
            this.placa1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.placa1, "placa1");
            this.placa1.Name = "placa1";
            // 
            // cliente1
            // 
            this.cliente1.DateOnly = false;
            this.cliente1.DecimalOnly = false;
            this.cliente1.DigitOnly = true;
            this.cliente1.IPAddrOnly = false;
            resources.ApplyResources(this.cliente1, "cliente1");
            this.cliente1.Name = "cliente1";
            this.cliente1.PhoneWithAreaCode = false;
            this.cliente1.SSNOnly = false;
            // 
            // cliente2
            // 
            this.cliente2.DateOnly = false;
            this.cliente2.DecimalOnly = false;
            this.cliente2.DigitOnly = true;
            this.cliente2.IPAddrOnly = false;
            resources.ApplyResources(this.cliente2, "cliente2");
            this.cliente2.Name = "cliente2";
            this.cliente2.PhoneWithAreaCode = false;
            this.cliente2.SSNOnly = false;
            // 
            // placa2
            // 
            this.placa2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.placa2, "placa2");
            this.placa2.Name = "placa2";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // ROtros
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.crystalRV2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ROtros";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalRV2;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.DateTimePicker date1;
        private MaskedTextBox.MaskedTextBox txt_fin;
        private MaskedTextBox.MaskedTextBox txt_inicio;
        private System.Windows.Forms.TextBox placa1;
        private MaskedTextBox.MaskedTextBox cliente1;
        private MaskedTextBox.MaskedTextBox cliente2;
        private System.Windows.Forms.TextBox placa2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}