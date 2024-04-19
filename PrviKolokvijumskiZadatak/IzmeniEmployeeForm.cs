using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using BusinessLoginc;

namespace ADONETComplete
{
    public partial class IzmeniEmployeeForm : Form
    {
        public Employee e;
        public BLEmployee BLemployee = BLEmployee.Instance;
        public IzmeniEmployeeForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (this.e.Empid != 0)
            {
                txtFirstName.Text = this.e.Firstname;
                txtLastName.Text = this.e.Lastname;
                txtTitle.Text = this.e.Title;
                txtTitleOfC.Text = this.e.Titleofcourtesy;
                dpBirthDate.Text = this.e.Birthdate.ToString();
                dpHireDate.Text = this.e.Hiredate.ToString();
                txtAddress.Text = this.e.Address;
                txtCity.Text = this.e.City;
                txtRegion.Text = this.e.Region;
                txtPostalCode.Text = this.e.Postalcode;
                txtCountry.Text = this.e.Country;
                txtPhone.Text = this.e.Phone;
                

                button1.Text = "Izmeni";
            }
            else
            {
                button1.Text = "Sacuvaj";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.e.Firstname = txtFirstName.Text;
            this.e.Lastname = txtLastName.Text;
            this.e.Title = txtTitle.Text;
            this.e.Titleofcourtesy = txtTitleOfC.Text;
            this.e.Birthdate = dpBirthDate.Value;
            this.e.Hiredate = dpBirthDate.Value;
            this.e.Address = txtAddress.Text;
            this.e.City = txtCity.Text;
            this.e.Region = txtRegion.Text;
            this.e.Postalcode = txtPostalCode.Text;
            this.e.Country = txtCountry.Text;
            this.e.Phone = txtPhone.Text;

            if (this.e.Empid != 0)
            {
                try
                {
                    BLemployee.UpdateEmployee(this.e);
                    MessageBox.Show("Usesno azuriran red!");
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Doslo je do greske prilikom azuriranja, greska: " + ex);
                }
            }
            else
            {
                try
                {
                    BLemployee.InsertEmployee(this.e);
                    MessageBox.Show("Usesno unet red!");

                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Doslo je do greske prilikom dodavanja, greska: " + ex);
                }
            }
            
        }
    }
}
