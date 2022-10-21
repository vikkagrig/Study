using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Приемная_комиссия
{
    public partial class Специальности : Form
    {
        Профиль профиль;
        public Специальности(Профиль профиль)
        {
            InitializeComponent();
            this.профиль = профиль;
            label2.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            профиль.Visible = true;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "ИАНТЭ")
            {
                dataGridView1.Rows.Clear();
                label2.Text = "Институт авиации, наземного транспорта и энергетики";
                using(EntityModelContainer db = new EntityModelContainer())
                {
                    foreach(Specialty sp in db.SpecialtySet)
                    {
                        if(sp.Faculty.Name == "ИАНТЭ")
                        {
                            dataGridView1.Rows.Add(sp.Code, sp.Name, sp.Place, sp.Faculty.Name);
                        }
                    }
                }
                
            }
            else if(comboBox1.SelectedItem.ToString() == "ФМФ")
            {
                dataGridView1.Rows.Clear();
                label2.Text = "Физико-математический факультет";
                using (EntityModelContainer db = new EntityModelContainer())
                {
                    foreach (Specialty sp in db.SpecialtySet)
                    {
                        if (sp.Faculty.Name == "ФМФ")
                        {
                            dataGridView1.Rows.Add(sp.Code, sp.Name, sp.Place, sp.Faculty.Name);
                        }
                    }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "ИАЭП")
            {
                dataGridView1.Rows.Clear();
                label2.Text = "Институт автоматики и электронного приборостроения";
                using (EntityModelContainer db = new EntityModelContainer())
                {
                    foreach (Specialty sp in db.SpecialtySet)
                    {
                        if (sp.Faculty.Name == "ИАЭП")
                        {
                            dataGridView1.Rows.Add(sp.Code, sp.Name, sp.Place, sp.Faculty.Name);
                        }
                    }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "ИКТЗИ")
            {
                dataGridView1.Rows.Clear();
                label2.Text = "Институт компьютерных технологий и защиты информации";
                using (EntityModelContainer db = new EntityModelContainer())
                {
                    foreach (Specialty sp in db.SpecialtySet)
                    {
                        if (sp.Faculty.Name == "ИКТЗИ")
                        {
                            dataGridView1.Rows.Add(sp.Code, sp.Name, sp.Place, sp.Faculty.Name);
                        }
                    }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "ИРЭФ-ЦТ")
            {
                dataGridView1.Rows.Clear();
                label2.Text = "Институт радиоэлектроники, фотоники и цифровых технологий";
                using (EntityModelContainer db = new EntityModelContainer())
                {
                    foreach (Specialty sp in db.SpecialtySet)
                    {
                        if (sp.Faculty.Name == "ИРЭФ-ЦТ")
                        {
                            dataGridView1.Rows.Add(sp.Code, sp.Name, sp.Place, sp.Faculty.Name);
                        }
                    }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "ИИЭиП")
            {
                dataGridView1.Rows.Clear();
                label2.Text = "Институт инженерной экономики и предпринимательства";
                using (EntityModelContainer db = new EntityModelContainer())
                {
                    foreach (Specialty sp in db.SpecialtySet)
                    {
                        if (sp.Faculty.Name == "ИИЭиП")
                        {
                            dataGridView1.Rows.Add(sp.Code, sp.Name, sp.Place, sp.Faculty.Name);
                        }
                    }
                }
            }
        }
    }
}
