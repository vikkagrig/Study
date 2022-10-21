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
    public partial class Авторизация : Form
    {
        Профиль профиль;
        Администратору администратору;
        public Авторизация()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form form = new Регистрация();
            form.Visible = true;
            this.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данный элемент еще не реализован");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                using (EntityModelContainer db = new EntityModelContainer())
                {
                    foreach(User user in db.UserSet)
                    { 
                        if(user.Login == textBox1.Text && user.Password == textBox2.Text && user.Role == "Абитуриент")
                        {
                            профиль = new Профиль(this, user);
                            профиль.Text = "Абитуриент " + user.Entrant.Name;
                            профиль.Visible = true;
                            this.Visible = false;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            break;
                        }
                        else if(user.Login == textBox1.Text && user.Password == textBox2.Text && user.Role == "Администратор")
                        {
                            this.администратору = new Администратору(this, user);
                            this.администратору.Visible = true;
                            this.Visible = false;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            break;
                        }
                    }
                    if(this.Visible == true)
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }
            else
                MessageBox.Show("Не все поля заполнены");
        }
    }
}
