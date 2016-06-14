using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRUCK
{
    public partial class proceso : Form
    {
        #region VARIABLES
        private System.Windows.Forms.Label Texto;
        private System.Windows.Forms.Label txtavance;
        private System.Windows.Forms.ProgressBar Bar_proceso;
        private System.Windows.Forms.PictureBox pictureBox1;
        #endregion
        #region CONSTRUCTORS
        public proceso(int maximo)
        {
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            LoadComponent();
            this.TransparencyKey = Color.Empty;

            Bar_proceso.Minimum = 0;
            Bar_proceso.Maximum = maximo;
            //Bar_proceso.TabIndex = 0; 
            Bar_proceso.Value = 0;
            //Bar_proceso.Step = 1; 			
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(proceso));
            this.Bar_proceso = new System.Windows.Forms.ProgressBar();
            this.Texto = new System.Windows.Forms.Label();
            this.txtavance = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // Bar_proceso
            // 
            this.Bar_proceso.Location = new System.Drawing.Point(8, 42);
            this.Bar_proceso.Name = "Bar_proceso";
            this.Bar_proceso.Size = new System.Drawing.Size(296, 23);
            this.Bar_proceso.TabIndex = 0;
            // 
            // Texto
            // 
            this.Texto.Location = new System.Drawing.Point(16, 74);
            this.Texto.Name = "Texto";
            this.Texto.Size = new System.Drawing.Size(280, 20);
            this.Texto.TabIndex = 3;
            this.Texto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtavance
            // 
            this.txtavance.Location = new System.Drawing.Point(48, 16);
            this.txtavance.Name = "txtavance";
            this.txtavance.Size = new System.Drawing.Size(40, 16);
            this.txtavance.TabIndex = 4;
            this.txtavance.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // proceso
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(314, 106);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtavance);
            this.Controls.Add(this.Texto);
            this.Controls.Add(this.Bar_proceso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "proceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.ResumeLayout(false);

        }
        #endregion
        #region FUNCTIONS
        public void UpdateProgress(int incremen, string texto)
        {
            try
            {
                double numerator, denominator, completed;

                Bar_proceso.Increment(incremen);

                if (Bar_proceso.Value > Bar_proceso.Maximum) Bar_proceso.Value = Bar_proceso.Maximum;
                else if (Bar_proceso.Value < Bar_proceso.Minimum) Bar_proceso.Value = Bar_proceso.Minimum;

                this.txtavance.Text = Bar_proceso.Value.ToString();
                numerator = Bar_proceso.Value;
                denominator = Bar_proceso.Maximum;
                completed = (numerator / denominator) * 100.0;

                this.txtavance.Text = Math.Round(completed).ToString() + "%";
                this.Texto.Text = texto;
                this.txtavance.Refresh();
                this.Texto.Refresh();
            }
            catch (Exception ex)
            {
                this.Texto.Text = ex.Message.ToString();
            }
        }
        #endregion

    }
}
