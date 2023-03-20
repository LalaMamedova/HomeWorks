using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Serialize;
using System.Windows;

namespace ElectronicsStore_Project_.Service.Classes
{
    internal class CustomerService : ICustomerService
    {
        public static ObservableCollection<Customer> customersList = new();
        public void Add(Customer? customer)
        {
            if (IsNullble(customer))
            {
                if (!IsCustomerExist(customer))
                {
                    if (!IsEmailTaken(customer.Email))
                    {
                        customersList.Add(customer);
                        FileService.Truncate("AllCustomers.json");
  
                        var json = SerializeLibary.Serialize<ObservableCollection<Customer>>(customersList);
                        FileService.Write(json, "AllCustomers.json");

                        IDService.SerializeID(customer.ID, "CustomersID.json");

                    }
                    else
                        MessageBox.Show("Данный Email уже занят, пожалуйста, введите другой");
                }
                else
                    MessageBox.Show("Вы уже зарегестрированы");
            }
            else
                MessageBox.Show("Введите все данные");


        }

        public ObservableCollection<Customer>? AllCustomers()
        {
            string? json = FileService.Read("AllCustomers.json");
            var all = SerializeLibary.Deserialize<ObservableCollection<Customer>>(json);

            if (all != null)
                return all;

            return null;
        }

        public Customer GetCustomer(string username, string password)
        {
            foreach (var customer in customersList)
            {
                if (customer.Login == username && customer.Password == password)
                {
                    return customer;
                    break;
                }
            }
            return null;
        }

        public bool IsCustomerExist(Customer? customer)
        {
            bool checkExist = false;
            foreach (var customers in customersList)
            {
                if (customers.Login == customer.Login && customers.Password == customer.Password)
                {
                    checkExist = true;
                    break;
                }
            }
            
            if (checkExist) return true; return false;
        }

        public bool IsEmailTaken(string? Email)
        {
            bool checkExist = false;
            foreach (var customers in customersList)
            {
                if (customers.Email == Email)
                    checkExist = true;
            }
            if (checkExist) return true; return false;   
        }

        public bool IsNullble(Customer? customer)
        {
            if (!string.IsNullOrEmpty(customer.Email) && !string.IsNullOrEmpty(customer.Login) && !string.IsNullOrEmpty(customer.Password))
                return true;
            return false;
        }
    }
}
