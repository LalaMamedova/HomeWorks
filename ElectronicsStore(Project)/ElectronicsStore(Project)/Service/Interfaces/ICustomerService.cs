using ElectronicsStore_Project_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Service.Interfaces
{
    public interface ICustomerService
    {
        public void Add(Customer? customer);
        public void Redact(Customer? customer);
        public ObservableCollection<Customer>? AllCustomers();
        public Customer? GetCustomer(string username, string password);
        public bool IsNullble(Customer? customer);
        public bool IsCustomerExist(Customer? customer);
        public bool IsEmailTaken(string? Email);

    }
}
