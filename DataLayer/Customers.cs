using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Domain;

namespace DataLayer
{
    public class Customers
    {
        private static Customers instance = null;

        public static Customers Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Customers();
                }
                return instance;
            }
        }

        SqlConnection sc = new SqlConnection();
        SqlDataAdapter daCustomers = new SqlDataAdapter();
        public DataTable dtCustomers = new DataTable();

        public Customers()
        {
            var nw = ConfigurationManager.ConnectionStrings["TSQL"];
            sc.ConnectionString = nw.ConnectionString;
            sc.Open();

            dtCustomers.Clear();

            var cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [TSQL].[Sales].[Customers]";
            daCustomers.SelectCommand = cmd;
            SqlCommandBuilder cb = new SqlCommandBuilder(daCustomers);

            daCustomers.Fill(dtCustomers);
            daCustomers.UpdateCommand = cb.GetUpdateCommand();
            sc.Close();

        }

        public bool InsertData(string Companyname, string Contactname, string Contacttitle, string Address)
        {
            if (sc.State == ConnectionState.Closed)
            {
                sc.Open();
            }

            using (SqlTransaction tran = sc.BeginTransaction())
            {

                try
                {
                    var cmd = sc.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Sales.Customers (companyname, contactname, contacttitle, address, city, region, postalcode, country, phone, fax) values ('" + Companyname + "', '" + Contactname + "', '" + Contacttitle + "', '" + Address + "', '', '', '', '', '', '', '')";
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    tran.Commit();
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
            daCustomers.Update(dtCustomers);
        }

        public bool Update(Customer cu)
        {
           
                DataRow dr = dtCustomers.Select("custid =" + cu.Custid.ToString())[0];

                dr["custid"] = cu.Custid.ToString();
                dr["companyname"] = cu.Companyname.ToString();
                dr["contactname"] = cu.Contactname.ToString();
                dr["contacttitle"] = cu.Contacttitle.ToString();
                dr["address"] = cu.Address.ToString();
                dr["city"] = cu.City.ToString();
                dr["region"] = cu.Region.ToString();
                dr["postalcode"] = cu.Postcode.ToString();
                dr["country"] = cu.Country.ToString();
                dr["phone"] = cu.Phone.ToString();
                dr["fax"] = cu.Fax.ToString();

                this.Update();
                return true;
           
        }

        public bool Insert(Customer cu)
        {
            DataRow dr = dtCustomers.NewRow();

            dr["custid"] = cu.Custid.ToString();
            dr["companyname"] = cu.Companyname.ToString();
            dr["contactname"] = cu.Contactname.ToString();
            dr["contacttitle"] = cu.Contacttitle.ToString();
            dr["address"] = cu.Address.ToString();
            dr["city"] = cu.City.ToString();
            dr["region"] = cu.Region.ToString();
            dr["postalcode"] = cu.Postcode.ToString();
            dr["country"] = cu.Country.ToString();
            dr["phone"] = cu.Phone.ToString();
            dr["fax"] = cu.Fax.ToString();

            dtCustomers.Rows.Add(dr);

            this.Update();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                dtCustomers.Select("custid = " + id.ToString())[0].Delete();

                Update();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetCustomersTableData()
        {
            return DataHandler.Instance.GetTableData("[TSQL].[Sales].[Customers]");

        }
    }


}
 