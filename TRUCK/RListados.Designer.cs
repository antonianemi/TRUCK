namespace TRUCK
{
    partial class RListados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RListados));
            this.ven1 = new System.Windows.Forms.MaskedTextBox();
            this.ven2 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Listados = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.crystalRV2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ven1
            // 
            this.ven1.AccessibleDescription = null;
            this.ven1.AccessibleName = null;
            resources.ApplyResources(this.ven1, "ven1");
            this.ven1.BackgroundImage = null;
            this.ven1.Font = null;
            this.ven1.Name = "ven1";
            // 
            // ven2
            // 
            this.ven2.AccessibleDescription = null;
            this.ven2.AccessibleName = null;
            resources.ApplyResources(this.ven2, "ven2");
            this.ven2.BackgroundImage = null;
            this.ven2.Font = null;
            this.ven2.Name = "ven2";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Listados);
            this.panel1.Controls.Add(this.ven1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ven2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // Listados
            // 
            this.Listados.AccessibleDescription = null;
            this.Listados.AccessibleName = null;
            resources.ApplyResources(this.Listados, "Listados");
            this.Listados.BackgroundImage = null;
            this.Listados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Listados.Font = null;
            this.Listados.FormattingEnabled = true;
            this.Listados.Name = "Listados";
            this.Listados.SelectedIndexChanged += new System.EventHandler(this.Listados_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
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
            this.button2.UseVisualStyleBackColor = true;
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
            this.crystalRV2.Font = null;
            this.crystalRV2.Name = "crystalRV2";
            this.crystalRV2.SelectionFormula = "";
            this.crystalRV2.ViewTimeSelectionFormula = "";
            // 
            // RListados
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.crystalRV2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Font = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RListados";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox ven1;
        private System.Windows.Forms.MaskedTextBox ven2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Listados;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalRV2;
    }
}