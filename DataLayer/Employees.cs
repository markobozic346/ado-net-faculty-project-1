using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Transactions;
using Domain;
using System.Net;
using System.Security.Policy;

namespace DataLayer
{
    public class Employees
    {
        private static Employees instance = null;

        public static Employees Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Employees();
                }
                return instance;
            }
        }

        SqlConnection sc = new SqlConnection();
        SqlDataAdapter daEmployees = new SqlDataAdapter();
        public DataTable dtEmployees = new DataTable();

        public Employees()
        {
            var nw = ConfigurationManager.ConnectionStrings["TSQL"];
            sc.ConnectionString = nw.ConnectionString;
            sc.Open();

            dtEmployees.Clear();

            var cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT *  FROM [TSQL].[HR].[Employees]";
            daEmployees.SelectCommand = cmd;
            SqlCommandBuilder cb = new SqlCommandBuilder(daEmployees);

            daEmployees.Fill(dtEmployees);
            daEmployees.UpdateCommand = cb.GetUpdateCommand();
            sc.Close();
        }

        public bool InsertData(string Firstname, string Lastname, string title, string titleofcourtesy, DateTime? birthdate, DateTime? hiredate, string address, string city, string region, string postalcode, string country, string phone)
        {
            if (sc.State == ConnectionState.Closed)
                sc.Open();

            using (SqlTransaction tran = sc.BeginTransaction())
            {
                try
                {
                    var cmd = sc.CreateCommand();
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO HR.Employees (firstname, lastname, title, titleofcourtesy, birthdate, hiredate, address, city, region, postalcode, country, phone) VALUES (@Name, @LastName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address, @City, @Region, @PostalCode, @Country, @Phone)";

                    cmd.Parameters.AddWithValue("@Name", Firstname);
                    cmd.Parameters.AddWithValue("@LastName", Lastname);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@TitleOfCourtesy", titleofcourtesy);
                    cmd.Parameters.AddWithValue("@BirthDate", birthdate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@HireDate", hiredate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@Region", region);
                    cmd.Parameters.AddWithValue("@PostalCode", postalcode);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@Phone", phone);

                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    Update();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }

        void Update()
        {
            daEmployees.Update(dtEmployees);
        }

        public bool Update(Employee em)
        {
            DataRow dr = dtEmployees.Select("empid =" + em.Empid.ToString())[0];
            dr["empid"] = em.Empid.ToString();
            dr["lastname"] = em.Lastname.ToString();
            dr["firstname"] = em.Firstname.ToString();
            dr["title"] = em.Title.ToString();
            dr["titleofcourtesy"] = em.Titleofcourtesy.ToString();
            dr["birthdate"] = em.Birthdate;
            dr["hiredate"] = em.Hiredate;
            dr["address"] = em.Address;
            dr["city"] = em.City;
            dr["region"] = em.Region;
            dr["postalcode"] = em.Postalcode;
            dr["country"] = em.Country;
            dr["phone"] = em.Phone;

            this.Update();
            return true;

        }
        public bool Insert(Employee em)
        {
            instance.InsertData(em.Firstname, em.Lastname, em.Title, em.Titleofcourtesy,em.Birthdate, em.Hiredate, em.Address, em.City, em.Region, em.Postalcode, em.Country, em.Phone);
            return true;
        }
        public bool Delete(int id)
        {
            dtEmployees.Select("empid = " + id.ToString())[0].Delete();

            Update();

            return true;
        }

        public DataTable GetEmployeeTableData()
        {
            return DataHandler.Instance.GetTableData("[TSQL].[HR].[Employees]");
        }
    }
}
