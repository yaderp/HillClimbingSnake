namespace TB01_IA.Presentacion
{
    partial class FrmInicio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            this.pictureBoxJugar = new System.Windows.Forms.PictureBox();
            this.panelInicio = new System.Windows.Forms.Panel();
            this.comboBoxVelocidad = new System.Windows.Forms.ComboBox();
            this.timerInicio = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJugar)).BeginInit();
            this.panelInicio.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxJugar
            // 
            this.pictureBoxJugar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxJugar.Image")));
            this.pictureBoxJugar.Location = new System.Drawing.Point(477, 231);
            this.pictureBoxJugar.Name = "pictureBoxJugar";
            this.pictureBoxJugar.Size = new System.Drawing.Size(100, 30);
            this.pictureBoxJugar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxJugar.TabIndex = 1;
            this.pictureBoxJugar.TabStop = false;
            this.pictureBoxJugar.Click += new System.EventHandler(this.pictureBoxJugar_Click);
            // 
            // panelInicio
            // 
            this.panelInicio.BackgroundImage = global::TB01_IA.Properties.Resources.welcome;
            this.panelInicio.Controls.Add(this.comboBoxVelocidad);
            this.panelInicio.Controls.Add(this.pictureBoxJugar);
            this.panelInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInicio.Location = new System.Drawing.Point(0, 0);
            this.panelInicio.Name = "panelInicio";
            this.panelInicio.Size = new System.Drawing.Size(600, 300);
            this.panelInicio.TabIndex = 3;
            // 
            // comboBoxVelocidad
            // 
            this.comboBoxVelocidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.comboBoxVelocidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxVelocidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxVelocidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(115)))));
            this.comboBoxVelocidad.FormattingEnabled = true;
            this.comboBoxVelocidad.Location = new System.Drawing.Point(308, 231);
            this.comboBoxVelocidad.Name = "comboBoxVelocidad";
            this.comboBoxVelocidad.Size = new System.Drawing.Size(114, 24);
            this.comboBoxVelocidad.TabIndex = 3;
            this.comboBoxVelocidad.Text = "- SELEC -";
            // 
            // timerInicio
            // 
            this.timerInicio.Interval = 200;
            this.timerInicio.Tick += new System.EventHandler(this.timerInicio_Tick);
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.panelInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInicio";
            this.Text = "ydR_2020";
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJugar)).EndInit();
            this.panelInicio.ResumeLayout(false);
            this.panelInicio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxJugar;
        private System.Windows.Forms.Panel panelInicio;
        private System.Windows.Forms.Timer timerInicio;
        private System.Windows.Forms.ComboBox comboBoxVelocidad;
    }
}