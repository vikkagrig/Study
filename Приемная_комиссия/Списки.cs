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
    public partial class Списки : Form
    {
        Профиль профиль;
        public Списки(Профиль профиль)
        {
            InitializeComponent();
            this.профиль = профиль;
            using(EntityModelContainer db= new EntityModelContainer())
            {
                foreach(List l in db.ListSet)
                {
                    dataGridView1.Rows.Add(l.Specialty.Code, l.Entrant.User.Id, l.Entrant.Point, l.Prioritet);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            профиль.Visible = true;
            this.Close();
        }
    }
}
