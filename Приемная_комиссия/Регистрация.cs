using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Приемная_комиссия
{
    public partial class Регистрация : Form
    {
        byte[] imageBytes;
        public Регистрация()
        {
            InitializeComponent();
            label7.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                    label7.Text = "Успешно";
                }
                catch 
                {
                    label7.Text = "Ошибка";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && label7.Text == "Успешно")
            {
                using (EntityModelContainer db = new EntityModelContainer())
                { 
                    User user = new User()
                    {
                        Login = textBox1.Text,
                        Password = textBox2.Text,
                        Role = "Абитуриент"
                    };
                    db.UserSet.Add(user);
                    db.SaveChanges();
                    Entrant entrant = new Entrant()
                    {
                        Name = textBox3.Text,
                        Point = int.Parse(textBox5.Text),
                        PersonalyData = textBox4.Text,
                        Photo = this.imageBytes,
                        User = user
                    };
                    db.EntrantSet.Add(entrant);
                    db.SaveChanges();
                }
                MessageBox.Show("Пользователь с логином " + textBox1.Text + " зарегистрировался");
                Form form = new Авторизация();
                form.Visible =  true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form form = new Авторизация();
            form.Visible = true;
            this.Close();
        }
    }
}
