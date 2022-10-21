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
    public partial class Администратору : Form
    {
        Авторизация авторизация;
        User user;
        public Администратору(Авторизация авторизация, User user)
        {
            InitializeComponent();
            this.авторизация = авторизация;
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Пользователи пользователи = new Пользователи(this);
            пользователи.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            авторизация.Visible = true;
            this.Close();
        }
    }
}
