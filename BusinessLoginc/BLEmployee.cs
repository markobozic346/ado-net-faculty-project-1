using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataLayer;
using Domain;

namespace BusinessLoginc
{
    public class BLEmployee
    {
        private static BLEmployee instance = null;

        public static BLEmployee Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BLEmployee();
                }
                return instance;
            }
        }

        public Employees e = Employees.Instance;
        private Employee Convert(DataRow dr)
        {
            Employee e = new Employee();
            e.Empid = Int32.Parse(dr["empid"].ToString());
            e.Lastname = dr["lastname"].ToString();
            e.Firstname = dr["firstname"].ToString();
            e.Title = dr["title"].ToString();
            e.Titleofcourtesy = dr["titleofcourtesy"].ToString();
            e.Birthdate = DateTime.Parse(dr["birthdate"].ToString());
            e.Hiredate = DateTime.Parse(dr["hiredate"].ToString());
            e.Address = dr["address"].ToString();
            e.City = dr["city"].ToString();
            e.Region = dr["region"].ToString();
            e.Postalcode = dr["postalcode"].ToString();
            e.Country = dr["country"].ToString();
            e.Phone = dr["phone"].ToString();

            int mgrid;
            int.TryParse(dr["mgrid"].ToString(), out mgrid);
            e.Mgrid = mgrid;

            return e;
        }
        public Employee GetEmployee(int id)
        {
            return Convert(e.dtEmployees.Select("empid = " + id.ToString())[0]);
        }
        public List<Employee> GetEmployees(string search)
        {
            List<Employee> l = new List<Employee>();
            foreach (DataRow dr in e.dtEmployees.Rows)
            {
                if (dr["firstname"].ToString().ToLower().StartsWith(search.ToLower()) ||
                    dr["lastname"].ToString().ToLower().StartsWith(search.ToLower()))
                {
                    l.Add(Convert(dr));
                }
            }

            return l;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> l = new List<Employee>();

            foreach (DataRow dr in e.dtEmployees.Rows)
            {
                l.Add(Convert(dr));
            }

            return l;
        }

        public bool UpdateEmployee(Employee em)
        {
            e.Update(em);
            return true;
        }

        public bool InsertEmployee(Employee em)
        {
            e.Insert(em);
            return true;
        }

        public bool DeleteEmployee(int id)
        {
            e.Delete(id);
            return true;
        }

        public DataTable GetEmployeesTableData()
        {
            return Employees.Instance.GetEmployeeTableData();
        }

    }
}
