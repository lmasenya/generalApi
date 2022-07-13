using generalapi.Models;
using generalapi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;


namespace generalapi.Services
{
    public class customerservice : IRepositoryCustomer
    {
        MySqlConnection Conn;

        private string sqlConnectingString = "server=localhost;uid=root;" +
                                            "pwd=;database=reactdb";

        public async Task<string> deletecustomer(int id)
        {
            Conn = new MySqlConnection();
            Conn.ConnectionString = sqlConnectingString;

            string query = "DELETE FROM `customer` WHERE `customerid` = @Id";

            using (var connection = Conn)
            {
                await connection.ExecuteAsync(query, new { Id = id });
                return "item deleted";
            }
        }

        /*
         *  
         * 
         */
        public IList<Customer> getallcustomers()
        {
            List<Customer> CustList = new List<Customer>();
            try
            {
               
                Conn = new MySqlConnection();
                Conn.ConnectionString = sqlConnectingString;
                Conn.Open();
                CustList = Conn.Query<Customer>("SELECT `customerid`, `firstname`, `lastname`, `identitynumber`, `cellphone`, `emailaddress`, `postaladdress`, `gender`, `country` FROM `customer`").ToList();
                Conn.Close();
            }
            catch (MySqlException ex)
            {
               // return ex.Message;
            }

            return CustList;
        }

        public async Task<Customer> GetcustomerAsync(int id)
        {
            Conn = new MySqlConnection();
            Conn.ConnectionString = sqlConnectingString;

            string sqlQuery = "SELECT `customerid`, `firstname`, `lastname`, `identitynumber`, `cellphone`, `emailaddress`, `postaladdress`, `gender`, `country` FROM `customer` WHERE `customerid` = "+id.ToString();
            using (var connection = Conn)
            {
                return await connection.QuerySingleAsync<Customer>(sqlQuery, new { Id = id });
            }
        }

        public string searchcustomer(string idnumber)
        {
            throw new NotImplementedException();
        }

        public async Task<string> setcustomerAsync(Customer customerdata)
        {
            Conn = new MySqlConnection();
            Conn.ConnectionString = sqlConnectingString;

            string sqlQuery = "INSERT into `customer` (`firstname`, `lastname`, `identitynumber`, `cellphone`, `emailaddress`, `postaladdress`, `gender`, `country`) values ( @firstname, @lastname, @identitynumber, @cellphone,@emailaddress,@postaladdress,@gender,@country)";
            var parameters = new DynamicParameters();
            parameters.Add("firstname", customerdata.firstname);
            parameters.Add("lastname", customerdata.lastname);
            parameters.Add("identitynumber", customerdata.identitynumber);
            parameters.Add("cellphone", customerdata.cellphone);
            parameters.Add("emailaddress", customerdata.emailaddress);
            parameters.Add("postaladdress", customerdata.postaladdress);
            parameters.Add("gender", customerdata.gender);
            parameters.Add("country", customerdata.country);
            
            using (var connection = Conn)
            {
                var r = await connection.ExecuteAsync(sqlQuery, parameters);
                return "inserted";
            }
            return "inserted";
        }

        public async Task<string> updatecustomer(Customer customer)
        {
            Conn = new MySqlConnection();
            Conn.ConnectionString = sqlConnectingString;

            string sqlQuery = "UPDATE `customer` SET firstname = @firstname, lastname = @lastname, cellphone = @cellphone,postaladdress = @postaladdress,country = @country WHERE customerid = @customerid";
            var parameters = new DynamicParameters();
            parameters.Add("customerid", customer.customerid);
            parameters.Add("firstname", customer.firstname);
            parameters.Add("lastname", customer.lastname);
            parameters.Add("cellphone", customer.cellphone);
            parameters.Add("postaladdress", customer.postaladdress);
            parameters.Add("country", customer.country);

            using (var connection = Conn)
            {
                var r = await connection.ExecuteAsync(sqlQuery, parameters);
                return "inserted";
            }
            return "inserted";
        }
    }
}
