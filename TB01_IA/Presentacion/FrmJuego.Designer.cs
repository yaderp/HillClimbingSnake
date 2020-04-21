namespace TB01_IA
{
    partial class FrmJuego
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJuego));
            this.panelInformacion = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelRecorrido = new System.Windows.Forms.Label();
            this.labelPuntos = new System.Windows.Forms.Label();
            this.labelMaxPunto = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelCuadro = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timerJuego = new System.Windows.Forms.Timer(this.components);
            this.panelInformacion.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInformacion
            // 
            this.panelInformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.panelInformacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelInformacion.BackgroundImage")));
            this.panelInformacion.Controls.Add(this.panel6);
            this.panelInformacion.Controls.Add(this.panel2);
            this.panelInformacion.Controls.Add(this.labelRecorrido);
            this.panelInformacion.Controls.Add(this.labelPuntos);
            this.panelInformacion.Controls.Add(this.labelMaxPunto);
            this.panelInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInformacion.Location = new System.Drawing.Point(0, 0);
            this.panelInformacion.Name = "panelInformacion";
            this.panelInformacion.Size = new System.Drawing.Size(1020, 50);
            this.panelInformacion.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(115)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(4, 46);
            this.panel6.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(115)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 4);
            this.panel2.TabIndex = 0;
            // 
            // labelRecorrido
            // 
            this.labelRecorrido.AutoSize = true;
            this.labelRecorrido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(115)))));
            this.labelRecorrido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecorrido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.labelRecorrido.Location = new System.Drawing.Point(877, 18);
            this.labelRecorrido.Name = "labelRecorrido";
            this.labelRecorrido.Size = new System.Drawing.Size(94, 17);
            this.labelRecorrido.TabIndex = 7;
            this.labelRecorrido.Text = "Recorrido :  0";
            // 
            // labelPuntos
            // 
            this.labelPuntos.AutoSize = true;
            this.labelPuntos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(115)))));
            this.labelPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPuntos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.labelPuntos.Location = new System.Drawing.Point(752, 27);
            this.labelPuntos.Name = "labelPuntos";
            this.labelPuntos.Size = new System.Drawing.Size(76, 17);
            this.labelPuntos.TabIndex = 6;
            this.labelPuntos.Text = "Puntos :  0";
            // 
            // labelMaxPunto
            // 
            this.labelMaxPunto.AutoSize = true;
            this.labelMaxPunto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(115)))));
            this.labelMaxPunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxPunto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.labelMaxPunto.Location = new System.Drawing.Point(723, 8);
            this.labelMaxPunto.Name = "labelMaxPunto";
            this.labelMaxPunto.Size = new System.Drawing.Size(105, 17);
            this.labelMaxPunto.TabIndex = 5;
            this.labelMaxPunto.Text = "Max Puntos :  0";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1010, 50);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 620);
            this.panel5.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel4.Controls.Add(this.panelCuadro);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(10, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1000, 620);
            this.panel4.TabIndex = 7;
            // 
            // panelCuadro
            // 
            this.panelCuadro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelCuadro.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCuadro.Location = new System.Drawing.Point(0, 10);
            this.panelCuadro.Name = "panelCuadro";
            this.panelCuadro.Size = new System.Drawing.Size(1000, 600);
            this.panelCuadro.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 10);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 620);
            this.panel3.TabIndex = 5;
            // 
            // timerJuego
            // 
            this.timerJuego.Enabled = true;
            this.timerJuego.Interval = 50;
            this.timerJuego.Tick += new System.EventHandler(this.timerJuego_Tick);
            // 
            // FrmJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(115)))));
            this.ClientSize = new System.Drawing.Size(1020, 670);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelInformacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmJuego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ydR_2020";
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmInicio_KeyDown);
            this.panelInformacion.ResumeLayout(false);
            this.panelInformacion.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelInformacion;
        private System.Windows.Forms.Label labelPuntos;
        private System.Windows.Forms.Label labelMaxPunto;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timerJuego;
        private System.Windows.Forms.Label labelRecorrido;
        private System.Windows.Forms.Panel panelCuadro;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
    }
}

