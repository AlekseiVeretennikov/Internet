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

namespace Интернет
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        InternetProviderEntities db = new InternetProviderEntities();

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentTabPage = tabControl1.SelectedIndex;
            string tabText = tabControl1.TabPages[currentTabPage].Text;
            switch(tabText)
            {
                case "Client":
                    {
                        db.Client.Load();
                        dataGridView.DataSource = db.Client.Local.ToBindingList();
                    }
                    break;
                case "Equipment":
                    {
                        db.Equipment.Load();
                        dataGridView.DataSource = db.Equipment.Local.ToBindingList();
                    }
                    break;
                case "Internet":
                    {
                        db.Internet.Load();
                        dataGridView.DataSource = db.Internet.Local.ToBindingList();
                    }
                    break;
                case "Manager":
                    {
                        db.Manager.Load();
                        dataGridView.DataSource = db.Manager.Local.ToBindingList();
                    }
                    break;
                case "Sale":
                    {
                        db.Sale.Load();
                        dataGridView.DataSource = db.Sale.Local.ToBindingList();
                    }
                    break;
                case "Tariff":
                    {
                        db.Tariff.Load();
                        dataGridView.DataSource= db.Equipment.Local.ToBindingList();
                    }
                    break;
                case "TV":
                    {   
                        db.TV.Load();
                        dataGridView.DataSource = db.TV.Local.ToBindingList();
                    }
                    break;
                case "User":
                    {   
                        db.User.Load();
                        dataGridView.DataSource = db.User.Local.ToBindingList();
                    }
                    break;
                case "Application":
                    {
                        db.C_Application.Load();
                        dataGridView.DataSource = db.C_Application.Local.ToBindingList();
                    }
                    break;
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataGridView.EndEdit();
            db.SaveChanges();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthForm authForm = new AuthForm();
            authForm.Show();
        }
    }
}
