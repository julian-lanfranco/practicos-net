using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            actualizargrilla();
            
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualizargrilla();

        }

        public void actualizargrilla()
        {

            try
            {
                dataGridView1.DataSource = FactorCN.GetFactores();
            }
            catch { MessageBox.Show("ERROR EN EL ACCESO A LA BASE DE DATOS"); }

        }

        public void vaciarEntradas()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length>6) 
                && (textBox2.Text.Length>5) 
                && (textBox3.Text.Length>6))
            {
            Factor fact = new Factor();
            fact.nombre = textBox1.Text;
            fact.estado = textBox2.Text;
            fact.detalle = textBox3.Text;
            try
            {

                FactorCN.CreateFactor(fact);
                MessageBox.Show("Factor "+fact.nombre+" dado de alta correctamente");
                actualizargrilla();
            }
            catch { MessageBox.Show("ERROR DE ACCESO A BASE DE DATOS"); }

            vaciarEntradas();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length > 6)
               && ((textBox4.Text.Length)>0)
               && (textBox2.Text.Length > 6)
               && (textBox3.Text.Length > 6))
            {
                Factor fact = new Factor();
                fact.nombre = textBox1.Text;
                fact.estado = textBox2.Text;
                fact.detalle = textBox3.Text;
                fact.idFactor = Int32.Parse(textBox4.Text);

                try
                {
                    FactorCN.UpdateFactor(fact);
                    MessageBox.Show("Factor " + fact.nombre + " actualizado correctamente");
                    actualizargrilla();

                }
                catch { MessageBox.Show("ERROR DE ACCESO A LA BASE DE DATOS"); }

                    vaciarEntradas();

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length>0)
            {
                try
                {
                    FactorCN.deleteFactor(Int32.Parse(textBox4.Text));
                    MessageBox.Show("Factor eliminado correctamente");
                    actualizargrilla();
                }
                catch { MessageBox.Show("ERROR EN EL ACCESO A LA BASE DE DATOS"); }

            vaciarEntradas();
            }

        }
    }
}
