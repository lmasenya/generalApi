using generalapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace generalapi.Repository
{
    public interface IRepositoryCustomer
    {
        public IList<Customer> getallcustomers();
        public Task<string> setcustomerAsync(Customer customerdata);
        public Task<Customer> GetcustomerAsync(int id);
        public string searchcustomer(string idnumber);
        public Task<string> updatecustomer(Customer customer);
        public Task<string> deletecustomer(int id);


    }
}
