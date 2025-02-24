using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Интернет
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }
        InternetProviderEntities db = new InternetProviderEntities();
            
        private void ManagerForm_Load(object sender, EventArgs e)
        {
            comboBoxEquipment.Text = null;
            comboBoxSale.Text = null;
            comboBoxTV.Text = null;
            List<Internet> internets = (from internet in db.Internet select internet).ToList();
            internets.Insert(0, new Internet
            {
                InternetID = 0,
                Descryption = "Выберите интернет тариф:"
            });
            comboBoxInternet.DataSource = internets;
            comboBoxInternet.DisplayMember = "Descryption";
            comboBoxInternet.ValueMember = "InternetID";

            List<Sale> sales = (from sale in db.Sale select sale).ToList();
            sales.Insert(0, new Sale
            {
                SaleID = 0,
                Desc = "Выберите скидку:"
            });
            comboBoxSale.DataSource = sales;
            comboBoxSale.DisplayMember = "Desc";
            comboBoxSale.ValueMember = "SaleID";

            List<TV> tvs = (from tv in db.TV select tv).ToList();
            tvs.Insert(0, new TV
            {
                TVID = 0,
                Name = "Выберите ТВ-пакет:"
            });
            comboBoxTV.DataSource = tvs;
            comboBoxTV.DisplayMember = "Name";
            comboBoxTV.ValueMember = "TVID";

            List<Equipment> equipments = (from equipment in db.Equipment select equipment).ToList();
            equipments.Insert(0, new Equipment
            {
                EquipmentID = 0,
                Name = "Выберите оборудование"
            });
            comboBoxEquipment.DataSource = equipments;
            comboBoxEquipment.DisplayMember = "Name";
            comboBoxEquipment.ValueMember = "EquipmentID";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string ManagerName = AuthForm.ManagerName;
            var manager = db.Manager.FirstOrDefault(el => el.Name == ManagerName);
            var internet = db.Internet.FirstOrDefault(el => el.Descryption == comboBoxInternet.Text);
            var sale = db.Sale.FirstOrDefault(el => el.Desc == comboBoxSale.Text);
            var tv = db.TV.FirstOrDefault(el => el.Name == comboBoxTV.Text);
            var equipment = db.Equipment.FirstOrDefault(el => el.Name == comboBoxEquipment.Text);
            var Amount = Convert.ToInt32((internet.Price + tv.Price + equipment.Price)*(100 - (sale.Sale1/100)));

            
            try
            {
                Methods.CreateClient(textBoxName.Text, textBoxSurname.Text, textBoxPatronymic.Text, textBoxAddress.Text, " ", textBoxPhone.Text, textBoxEmail.Text);
                var client = db.Client.FirstOrDefault(el => el.Name == textBoxName.Text && el.Surname == textBoxSurname.Text);
                Methods.CreateTariff(Amount, internet, equipment, sale, tv);
                var tariff = db.Tariff.FirstOrDefault(el => el.Amount == Amount);
                Methods.CreateApplication(dateTimePicker1.Value, richTextBoxDesc.Text.Replace("\n", " "), tariff, client, manager);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("alexey1.q@yandex.ru", ManagerName);
                // кому отправляем
                MailAddress to = new MailAddress("staspro2017@yandex.ru");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Заявка на подключение";
                // текст письма
                m.Body = $@"                    ФИО: {textBoxName.Text} {textBoxSurname.Text} {textBoxPatronymic.Text}
                    Телефон клиента: {textBoxPhone.Text}
                    Адрес подключения: {textBoxAddress.Text}
                    Тарифный план: 
                    Интернет {internet.Descryption}
                    Телевидение {tv.Name}
                    Роутер: {equipment.Name}
                    Доп. сведения: {richTextBoxDesc.Text}";
                // письмо представляет код html
                m.IsBodyHtml = false;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
                // логин и пароль
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("alexey1.q@yandex.ru", "oczqipqmvfwwlney");
                smtp.EnableSsl = true;
                smtp.Send(m);
                MessageBox.Show("Файл отправлен");
        }

        private void ManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
