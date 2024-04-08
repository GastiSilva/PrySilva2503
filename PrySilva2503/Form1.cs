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
            txtId.Text = "";
            txtNombre.Text = "";
            dgvCorredores.Rows.Clear();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtId.Text != null && txtNombre.Text != null)
            {
                if(c.Agregar(int.Parse(txtId.Text), txtNombre.Text)){
                    ActualizarGrilla();
                    txtId.Text = "";
                    txtNombre.Text = "";
                    MessageBox.Show("agregado correctamente");
                }
                else
                {
                    MessageBox.Show("El id ya se encuentra");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvCorredores.SelectedRows[0].Cells[0].Value.ToString());
            if(MessageBox.Show("Confirma eliminar este corredor?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c.Eliminar(id);
                ActualizarGrilla();
                MessageBox.Show("eliminado correctamente");
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            c.Actualizar(int.Parse(txtId.Text), txtNombre.Text);
            ActualizarGrilla();
            MessageBox.Show("actualizado correctamente");
        }
        private void ActualizarGrilla()
        {
            dgvCorredores.Rows.Clear();
            foreach (DataRow dr in c.dtCorredores.Rows)
            {
                dgvCorredores.Rows.Add(dr["idcorredor"].ToString(), dr["nombre"]);
            }
        }
    }
}
