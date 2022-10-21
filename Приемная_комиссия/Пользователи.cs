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
    public partial class Пользователи : Form
    {
        Администратору администратору;
        public Пользователи(Администратору администратору)
        {
            InitializeComponent();
            this.администратору = администратору;
            using(EntityModelContainer db = new EntityModelContainer())
            {
                foreach(Entrant entrant in db.EntrantSet)
                {
                    listBox1.Items.Add(entrant.Name);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            администратору.Visible = true;
            this.Close();
        }

        private void selected(object sender, EventArgs e)
        {
            using (EntityModelContainer db = new EntityModelContainer())
            {
                Entrant entrant = (from i in db.EntrantSet where i.Name == listBox1.SelectedItem.ToString() select i).First();
                textBox1.Text = entrant.Name;
                textBox2.Text = entrant.Point.ToString();
                textBox3.Text = entrant.PersonalyData;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (EntityModelContainer db = new EntityModelContainer())
            {
                Entrant entrant = (from i in db.EntrantSet where i.Name == listBox1.SelectedItem.ToString() select i).First();
                User user = (from i in db.UserSet where i.Entrant.Name == entrant.Name select i).First();
                db.EntrantSet.Remove(entrant);
                db.SaveChanges();
                db.UserSet.Remove(user);
                db.SaveChanges();
            }
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (EntityModelContainer db = new EntityModelContainer())
            {
                for(int i = 0; i < db.EntrantSet.ToList().Count(); i++)
                {
                    if (db.EntrantSet.ToList()[i].Name == listBox1.SelectedItem.ToString())
                    {
                        db.EntrantSet.ToList()[i].Name = textBox1.Text;
                        db.EntrantSet.ToList()[i].Point = int.Parse(textBox2.Text);
                        db.EntrantSet.ToList()[i].PersonalyData = textBox3.Text;
                        db.SaveChanges();
                        MessageBox.Show("Изменения сохранены");
                        break;
                    }
                }
            }
        }
    }
}
