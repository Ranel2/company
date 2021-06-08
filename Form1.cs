using Ranel.ModelBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranel
{
    public partial class Form1 : Form
    {
        ModelBD.Model1 connect = new ModelBD.Model1();
        public Form1()
        {
            InitializeComponent();
            connect.ARM.Load();
            dataGridView1.DataSource = connect.ARM.Local.ToBindingList();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                ModelBD.ARM cliadd = new ARM();
                cliadd.Хранится_На_Складе = form.textBox1.Text;
                cliadd.Компания_Поставщик = form.textBox2.Text;
                cliadd.Поступление_Товара = form.textBox3.Text;
                cliadd.Отправка_Товара = form.textBox4.Text;
                connect.ARM.Add(cliadd);
                connect.SaveChanges();
                MessageBox.Show("Запись добавлена");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form2 formedit = new Form2();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                ARM Clientedit = connect.ARM.Find(id);

                formedit.textBox1.Text = Clientedit.Хранится_На_Складе;
                formedit.textBox2.Text = Clientedit.Компания_Поставщик;
                formedit.textBox3.Text = Clientedit.Поступление_Товара;
                formedit.textBox4.Text = Clientedit.Отправка_Товара;

                DialogResult resultedit = formedit.ShowDialog(this);
                if (resultedit == DialogResult.OK)
                {
                    Clientedit.Хранится_На_Складе = formedit.textBox1.Text;
                    Clientedit.Компания_Поставщик = formedit.textBox2.Text;
                    Clientedit.Поступление_Товара = formedit.textBox3.Text;
                    Clientedit.Отправка_Товара = formedit.textBox4.Text;

                    connect.SaveChanges();
                    MessageBox.Show("Запись обновлена");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == true)
                {
                    ARM Clientdel = connect.ARM.Find(id);
                    connect.ARM.Remove(Clientdel);
                    connect.SaveChanges();
                    string buff = Clientdel.Хранится_На_Складе;
                    MessageBox.Show("запись " + buff + " удалена");
                }
            }
            else
            {
                MessageBox.Show("Запись не выбрана!");
            }
        }
    }
}