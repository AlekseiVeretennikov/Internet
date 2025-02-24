using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Интернет
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }
        public static string ManagerName = "";

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text != "" && textBoxPassword.Text != "")
            {
                this.Hide();
                ManagerName = Methods.Authorization(textBoxLogin.Text, textBoxPassword.Text);
            }
            else { MessageBox.Show("Ошибка!", "Заполните все поля!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }
}
