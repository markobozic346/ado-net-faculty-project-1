using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLoginc
{
    public class BLECustomer
    {

        private static BLECustomer instance = null;

        public static BLECustomer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BLECustomer();
                }
                return instance;

            }
        }

        public Customers c = Customers.Instance;

        private Customer Convert(DataRow dr)
        {
            Customer c = new Customer();

            c.Custid = Int32.Parse(dr["custid"].ToString());
            c.Companyname = dr["companyname"].ToString();
            c.Contacttitle = dr["contacttitle"].ToString();
            c.Contactname = dr["contactname"].ToString();
            c.Address = dr["address"].ToString();
            c.City = dr["city"].ToString();
            c.Region = dr["region"].ToString();
            c.Postcode = dr["postalcode"].ToString();
            c.Country = dr["country"].ToString();
            c.Phone = dr["Phone"].ToString();
            c.Fax = dr["Fax"].ToString();

            return c;
        }

        public Customer GetCustomer(int id)
        {
            return Convert(c.dtCustomers.Select("custid = " + id.ToString())[0]);
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> l = new List<Customer>();

            foreach(DataRow dr in c.dtCustomers.Rows)
            {
                l.Add(Convert(dr));
            }

            return l;
        }

        public List<Customer> GetCustomers(string search)
        {
            List<Customer> l = new List<Customer>();

            foreach (DataRow dr in c.dtCustomers.Rows)
            {
                if (dr["contactname"].ToString().ToLower().StartsWith(search.ToLower()) ||
                    dr["companyname"].ToString().ToLower().StartsWith(search.ToLower()) ||
                    dr["contacttitle"].ToString().ToLower().StartsWith(search.ToLower()) ||
                    dr["city"].ToString().ToLower().StartsWith(search.ToLower()))
                {
                    l.Add(Convert(dr));
                }
            }
            return l;
        }

        public bool UpdateCustomer(Customer cu)
        {
            c.Update(cu);
            return true;
        }
        public bool InsertCustomer(Customer cu)
        {
            c.Insert(cu);
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            c.Delete(id);
            return true;
        }

        public DataTable GetCustomersTableData()
        {
            return Customers.Instance.GetCustomersTableData();
        }

    }
}
