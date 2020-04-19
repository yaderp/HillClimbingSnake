namespace IA_TB1
{
    partial class FrmSnake
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
            this.panelInformacion = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCuadro = new System.Windows.Forms.Panel();
            this.timerJuego = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxIniciar = new System.Windows.Forms.PictureBox();
            this.labelMaxPunto = new System.Windows.Forms.Label();
            this.labelPuntos = new System.Windows.Forms.Label();
            this.panelInformacion.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIniciar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInformacion
            // 
            this.panelInformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(115)))));
            this.panelInformacion.Controls.Add(this.labelPuntos);
            this.panelInformacion.Controls.Add(this.labelMaxPunto);
            this.panelInformacion.Controls.Add(this.pictureBoxIniciar);
            this.panelInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInformacion.Location = new System.Drawing.Point(0, 0);
            this.panelInformacion.Name = "panelInformacion";
            this.panelInformacion.Size = new System.Drawing.Size(820, 80);
            this.panelInformacion.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(115)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 410);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(115)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(810, 80);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 410);
            this.panel5.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panelCuadro);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(10, 80);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 410);
            this.panel4.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(115)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 10);
            this.panel1.TabIndex = 1;
            // 
            // panelCuadro
            // 
            this.panelCuadro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.panelCuadro.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCuadro.Location = new System.Drawing.Point(0, 0);
            this.panelCuadro.Name = "panelCuadro";
            this.panelCuadro.Size = new System.Drawing.Size(800, 400);
            this.panelCuadro.TabIndex = 0;
            // 
            // timerJuego
            // 
            this.timerJuego.Enabled = true;
            this.timerJuego.Interval = 50;
            this.timerJuego.Tick += new System.EventHandler(this.timerJuego_Tick);
            // 
            // pictureBoxIniciar
            // 
            this.pictureBoxIniciar.Image = global::IA_TB1.Properties.Resources.reinicio;
            this.pictureBoxIniciar.Location = new System.Drawing.Point(12, 25);
            this.pictureBoxIniciar.Name = "pictureBoxIniciar";
            this.pictureBoxIniciar.Size = new System.Drawing.Size(100, 40);
            this.pictureBoxIniciar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIniciar.TabIndex = 4;
            this.pictureBoxIniciar.TabStop = false;
            this.pictureBoxIniciar.Click += new System.EventHandler(this.pictureBoxIniciar_Click);
            // 
            // labelMaxPunto
            // 
            this.labelMaxPunto.AutoSize = true;
            this.labelMaxPunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxPunto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.labelMaxPunto.Location = new System.Drawing.Point(192, 13);
            this.labelMaxPunto.Name = "labelMaxPunto";
            this.labelMaxPunto.Size = new System.Drawing.Size(105, 17);
            this.labelMaxPunto.TabIndex = 5;
            this.labelMaxPunto.Text = "Max Puntos :  0";
            // 
            // labelPuntos
            // 
            this.labelPuntos.AutoSize = true;
            this.labelPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPuntos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.labelPuntos.Location = new System.Drawing.Point(221, 48);
            this.labelPuntos.Name = "labelPuntos";
            this.labelPuntos.Size = new System.Drawing.Size(76, 17);
            this.labelPuntos.TabIndex = 6;
            this.labelPuntos.Text = "Puntos :  0";
            // 
            // FrmSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 490);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelInformacion);
            this.Name = "FrmSnake";
            this.Text = "SNAKE";
            this.Load += new System.EventHandler(this.FrmSnake_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSnake_KeyDown);
            this.panelInformacion.ResumeLayout(false);
            this.panelInformacion.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIniciar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInformacion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelCuadro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxIniciar;
        private System.Windows.Forms.Timer timerJuego;
        private System.Windows.Forms.Label labelPuntos;
        private System.Windows.Forms.Label labelMaxPunto;
    }
}

