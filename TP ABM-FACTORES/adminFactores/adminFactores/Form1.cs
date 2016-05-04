using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adminFactores
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int index = 0;
        int opc = 0;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

                listarFactores();
                
        }

        private proyectosEntities db = new proyectosEntities();

        private void addFactor() 
        {

            try
            {
                nuevosFactores fact = new nuevosFactores()
                {
                    nombre = textBox2.Text,
                    detalle = textBox3.Text,
                };
                db.nuevosFactores.Add(fact);
                db.SaveChanges();
                MessageBox.Show("FACTOR CREADO CORRECTAMENTE!!!");
            }
            catch (Exception ex) {MessageBox.Show("ERROR DE ACCESO A DATOS");}



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text.Length < 3) || (textBox3.Text.Length < 10)) { return; }

            if (opc == 0)
            {
                addFactor();
                


            }
            if (opc==1)
            {
                updateFactor(Convert.ToInt32(textBox1.Text));
                MessageBox.Show("FACTOR ACTUALIZADO CORRECTAMENTE");
                button1.Text = "GRABAR";
                opc = 0;

            }

            vaciarEntradaDatos();
          
            listarFactores();
        }
        private void vaciarEntradaDatos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        
        
        }

        private void listarFactores()
        {
           


            listView1.Items.Clear();
            try
            {
                var query = from p in db.nuevosFactores
                            select p;

                foreach (var item in query)
                {
                    ListViewItem ilst = listView1.Items.Add(item.id_factor.ToString());
                    ilst.SubItems.Add(item.nombre);
                    ilst.SubItems.Add(item.detalle);

                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR DE ACCESO A DATOS"); }
        }
      

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            index = e.Item.Index;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            textBox1.Text = listView1.Items[index].SubItems[0].Text;
            textBox2.Text = listView1.Items[index].SubItems[1].Text;
            textBox3.Text = listView1.Items[index].SubItems[2].Text;

            button1.Text = "ACTUALIZAR";
            opc = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vaciarEntradaDatos();
            button1.Text = "GRABAR";
            opc = 0;


        }
        private void updateFactor(int id)
        {
            try
            {
                nuevosFactores fact = (from p in db.nuevosFactores
                                       where p.id_factor == id
                                       select p).FirstOrDefault();
                fact.nombre = textBox2.Text;
                fact.detalle = textBox3.Text;


                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show("ERROR DE ACCESO A DATOS"); }
        
        }

        private void eliminarFactor(int id)
        {
            
            try
            {
                nuevosFactores fact = (from p in db.nuevosFactores
                                       where p.id_factor == id
                                       select p).FirstOrDefault();


                db.nuevosFactores.Remove(fact);
                db.SaveChanges();
                MessageBox.Show("FACTOR ELIMINADO CORRECTAMENTE");
            }
            catch (Exception ex) { MessageBox.Show("ERROR DE ACCESO A DATOS"); }
                listarFactores();


        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            if (textBox1.Text == "") return;
            eliminarFactor(Convert.ToInt32(textBox1.Text));
            vaciarEntradaDatos();
            button1.Text = "GRABAR";
            opc = 0;
        }

    }
}
