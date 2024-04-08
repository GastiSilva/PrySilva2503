using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrySilva2503
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Corredores c = new Corredores();
        private void Form1_Load(object sender, EventArgs e)
        {
            int n = c.dtCorredores.Rows.Count;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            c.Agregar(int.Parse(txtId.Text), txtNombre.Text);
            MessageBox.Show("agregado correctamente");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            c.Eliminar(int.Parse(txtId.Text));
            MessageBox.Show("eliminado correctamente");
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            c.Actualizar(int.Parse(txtId.Text), txtNombre.Text);
            MessageBox.Show("actualizado correctamente");
        }
    }
}
