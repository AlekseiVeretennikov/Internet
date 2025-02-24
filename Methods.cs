using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Интернет
{
    internal class Methods
    {
        public static string Authorization(string login, string password)
        {
            using (InternetProviderEntities db = new InternetProviderEntities())
            {
                var user = db.User.FirstOrDefault(l => l.Login == login && l.Password == password);
                if (user.Role == "manager")
                {
                    ManagerForm manager = new ManagerForm();
                    manager.Show();
                    return user.Name;
                }
                else
                {
                    Admin admin = new Admin();
                    admin.Show();
                    return "";
                }
            }
        }

        public static void CreateClient(string name, string surname, string patronymic,string address, string gender,  string phone, string email)
        {
            using (InternetProviderEntities db = new InternetProviderEntities())
            {
                Client client = new Client();
                {
                    client.Name = name;
                    client.Surname = surname;
                    client.Patronymic = patronymic;
                    client.Address = address;
                    client.Gender = gender;
                    client.Phone = phone;
                    client.Email = email;
                }
                db.Client.Add(client);
                db.SaveChanges();
            }
        }
        public static void CreateApplication(DateTime date, string desc, Tariff tariff, Client client, Manager manager)
        {
            using (InternetProviderEntities db = new InternetProviderEntities())
            {
                C_Application application = new C_Application();
                {
                    application.Date = date;
                    application.Desc = desc;
                    application.TariffID = tariff.TariffID;
                    application.ClientID = client.ClientID;
                    application.ManagerID = manager.ManagerID;
                }
                db.C_Application.Add(application);
                db.SaveChanges();
            }
        }
        public static void CreateTariff(int amount, Internet internet, Equipment equipment, Sale sale, TV tv) 
        {
            using(InternetProviderEntities db = new InternetProviderEntities())
            {
                Tariff tariff = new Tariff();
                {
                    tariff.Amount = amount;
                    tariff.InternetID = internet.InternetID;
                    tariff.EquipmentID = equipment.EquipmentID;
                    tariff.SaleID = sale.SaleID;
                    tariff.TVID = tv.TVID;
                }
                db.Tariff.Add(tariff);
                db.SaveChanges();
            }
        }
    }
}
