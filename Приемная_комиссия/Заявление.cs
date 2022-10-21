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
    public partial class Заявление : Form
    {
        User user;
        Профиль профиль;
        Specialty s;
        int n = 0;
        bool flag = true;
        public Заявление(User user, Профиль профиль)
        {
            InitializeComponent();
            label3.Text = "";
            this.user = user;
            this.профиль = профиль;
            comboBox2.Items.Add(1);
            comboBox2.Items.Add(2);
            comboBox2.Items.Add(3);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.профиль.Visible = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            if (n == 3)
            {
                label3.Text = "К сожалению, вы можете подать заявление всего на три направления";
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button1.Enabled = false;
            }
            else
            { 
                using (EntityModelContainer db = new EntityModelContainer()) {
                s = (from i in db.SpecialtySet where i.Code == comboBox1.SelectedItem.ToString() select i).FirstOrDefault();
                foreach(List list2 in db.ListSet)
                {
                    if(list2.Specialty.Code == s.Code && list2.Entrant.Name == user.Entrant.Name)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == true)
                {
                    List list = new List() {
                    Point = user.Entrant.Point.ToString(),
                    Prioritet = int.Parse(comboBox2.SelectedItem.ToString()),
                    Entrant = user.Entrant,
                    Specialty = (from i in db.SpecialtySet where i.Code == comboBox1.SelectedItem.ToString() select i).FirstOrDefault()
                    };
                    db.ListSet.Add(list);
                    db.SaveChanges();
                    label3.Text = "Ваше заявление принято";
                    listBox1.Items.Add("Специальность: " + list.Specialty.Name + " ,код: " + list.Specialty.Code + " ,приоритет: " + list.Prioritet);
                    n++;
                    comboBox2.Items.Remove(list.Prioritet);
                }
                else
                {
                    MessageBox.Show("Вы уже подавали заявление на эту специальность");
                }
                
            }
            }
        }

        private void Заявление_Load(object sender, EventArgs e)
        {
            using (EntityModelContainer db = new EntityModelContainer())
            {
                foreach (Specialty sp in db.SpecialtySet)
                {
                    comboBox1.Items.Add(sp.Code);
                }
                foreach (List list in db.ListSet)
                {
                    if (list.Entrant.Name == user.Entrant.Name && list.Prioritet == 1)
                    {
                        listBox1.Items.Add("Специальность: " + list.Specialty.Name + " ,код: " + list.Specialty.Code + " ,приоритет: " + list.Prioritet);
                        comboBox2.Items.Remove(1);
                        n++;
                    }
                    if (list.Entrant.Name == user.Entrant.Name && list.Prioritet == 2)
                    {
                        listBox1.Items.Add("Специальность: " + list.Specialty.Name + " ,код: " + list.Specialty.Code + " ,приоритет: " + list.Prioritet);
                        comboBox2.Items.Remove(2);
                        n++;
                    }
                    if (list.Entrant.Name == user.Entrant.Name && list.Prioritet == 3)
                    {
                        listBox1.Items.Add("Специальность: " + list.Specialty.Name + " ,код: " + list.Specialty.Code + " ,приоритет: " + list.Prioritet);
                        comboBox2.Items.Remove(3);
                        n++;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string data = listBox1.SelectedItem.ToString();
            string[] words = data.Split(' ');
            using (EntityModelContainer db = new EntityModelContainer())
            {
                for(int i = 0; i < db.ListSet.ToList().Count; i++)
                {
                    if(db.ListSet.ToList()[i].Specialty.Code == words[words.Length - 3] && db.ListSet.ToList()[i].Entrant.Name == user.Entrant.Name)
                    {
                        db.ListSet.Remove(db.ListSet.ToList()[i]);
                        db.SaveChanges();
                        listBox1.Items.Remove(listBox1.SelectedItem);
                        n--;
                        comboBox2.Items.Add(words[words.Length - 1]);
                    }
                }
            }
        }
    }
}
