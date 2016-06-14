using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TRUCK
{
	/// <summary>
	/// Descripción breve de Form1.
	/// </summary>
	public partial class Form1 : System.Windows.Forms.Form
    {
        #region VARIABLES
        public ToolStrip toolBar1;
        public ToolStripButton toolStripButton1;
        public ToolStripButton toolStripButton2;
        public ToolStripButton toolStripButton3;
        public ToolStripButton toolStripButton4;
        public ToolStripButton toolStripButton5;
        public ToolStripButton toolStripButton6;
        public ToolStripButton toolStripButton7;
        #endregion
        #region CONSTRUCTOR
        public Form1()
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			LoadComponent();
			this.TransparencyKey = Color.Empty;
		
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
		private void LoadComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolBar1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.AccessibleDescription = null;
            this.toolBar1.AccessibleName = null;
            resources.ApplyResources(this.toolBar1, "toolBar1");
            this.toolBar1.BackgroundImage = null;
            this.toolBar1.Font = null;
            this.toolBar1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7});
            this.toolBar1.Name = "toolBar1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AccessibleDescription = null;
            this.toolStripButton1.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.BackgroundImage = null;
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AccessibleDescription = null;
            this.toolStripButton2.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.BackgroundImage = null;
            this.toolStripButton2.Name = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AccessibleDescription = null;
            this.toolStripButton3.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.BackgroundImage = null;
            this.toolStripButton3.Name = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AccessibleDescription = null;
            this.toolStripButton4.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            this.toolStripButton4.BackgroundImage = null;
            this.toolStripButton4.Name = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AccessibleDescription = null;
            this.toolStripButton5.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            this.toolStripButton5.BackgroundImage = null;
            this.toolStripButton5.Name = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AccessibleDescription = null;
            this.toolStripButton6.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton6, "toolStripButton6");
            this.toolStripButton6.BackgroundImage = null;
            this.toolStripButton6.Name = "toolStripButton6";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.AccessibleDescription = null;
            this.toolStripButton7.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton7, "toolStripButton7");
            this.toolStripButton7.BackgroundImage = null;
            this.toolStripButton7.Name = "toolStripButton7";
            // 
            // Form1
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.toolBar1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.toolBar1.ResumeLayout(false);
            this.toolBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	}
}
