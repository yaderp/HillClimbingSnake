using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TB01_IA.ViewModel;
using TB01_IA.BL;
namespace TB01_IA.Presentacion
{
    public partial class FrmInicio : Form
    {

        List<DatosViewModel> vmLista = new List<DatosViewModel>();
        int Contador = Variables.TiempoEspera;
        int Velocidad = 50;

        public FrmInicio()
        {
            InitializeComponent();
        }

        private void labelSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxJugar_Click(object sender, EventArgs e)
        {
            Velocidad = Convert.ToInt32(comboBoxVelocidad.SelectedValue);
            timerInicio.Enabled = true;
            Contador = Variables.TiempoEspera;
            panelInicio.BackgroundImage = Properties.Resources.intro;
            comboBoxVelocidad.Visible = false;
            pictureBoxJugar.Visible = false;

        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            Model.Datos datos = new Model.Datos();

            comboBoxVelocidad.ValueMember = "ID";
            comboBoxVelocidad.DisplayMember = "Velocidad";
            comboBoxVelocidad.DataSource = datos.ListaVelocidad();
        }

        private void timerInicio_Tick(object sender, EventArgs e)
        {
            if (Contador == 0) {
                timerInicio.Enabled = false;
                this.Hide();

                FrmJuego frm = new FrmJuego(Velocidad);
                frm.Show();
                frm.FormClosed += Logout;
            }
            Contador--;
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            panelInicio.BackgroundImage = Properties.Resources.welcome;
            comboBoxVelocidad.Visible = true;
            pictureBoxJugar.Visible = true;

            this.Show();
        }
    }
}
