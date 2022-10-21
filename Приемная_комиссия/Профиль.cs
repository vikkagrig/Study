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
    public partial class Профиль : Form
    {
        Авторизация авторизация;
        User user;
        public Профиль(Авторизация авторизация, User user)
        {
            InitializeComponent();
            this.авторизация = авторизация;
            this.user = user;
            label1.Text += user.Entrant.Name;
            label2.Text += user.Entrant.Point;
            label3.Text += user.Entrant.PersonalyData;
            pictureBox1.Image = (Image)((new ImageConverter()).ConvertFrom(user.Entrant.Photo));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.авторизация.Visible = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Специальности специальности = new Специальности(this);
            this.Visible = false;
            специальности.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Заявление заявление = new Заявление(this.user, this);
            this.Visible = false;
            заявление.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Списки списки = new Списки(this);
            this.Visible = false;
            списки.Visible = true;
        }
    }
}
