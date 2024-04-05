using BusinessLoginc;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONETComplete
{
    public partial class IzmeniCustomerForm : Form
    {
        public Customer c;
        public BLECustomer BLcustomer = BLECustomer.Instance;
        public IzmeniCustomerForm()
        {
            InitializeComponent();
        }

        private void IzmeniCustomerForm_Load(object sender, EventArgs e)
        {
            if (this.c.Custid != 0)
            {

                txtCompanyName.Text = this.c.Companyname;
                txtContactName.Text = this.c.Contactname;
                txtContactTitle.Text = this.c.Contacttitle;
                txtAddress.Text = this.c.Address;
                txtCity.Text = this.c.City;
                txtRegion.Text = this.c.Region;
                txtPostCode.Text = this.c.Postcode;
                txtCountry.Text = this.c.Country;
                txtPhone.Text = this.c.Phone;
                txtFax.Text = this.c.Fax;


                btnSave.Text = "Izmeni";
            }
            else
            {
                btnSave.Text = "Sacuvaj";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.c.Companyname = txtCompanyName.Text;
            this.c.Contactname = txtContactName.Text;
            this.c.Contacttitle = txtContactTitle.Text;
            this.c.Address = txtAddress.Text;
            this.c.City = txtCity.Text;
            this.c.Region = txtRegion.Text;
            this.c.Postcode = txtPostCode.Text;
            this.c.Country = txtCountry.Text;
            this.c.Phone = txtPhone.Text;
            this.c.Fax = txtFax.Text;


            if (this.c.Custid != 0)
            {
                try
                {
                    BLcustomer.UpdateCustomer(this.c);
                    MessageBox.Show("Uspesno azuriran red!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske prilikom azuriranja reda, greska: " + ex.Message);
                }

            }
            else
            {

                try
                {
                    BLcustomer.InsertCustomer(this.c);
                    MessageBox.Show("Uspesno unet red");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske prilikom dodavanja reda, greska: " + ex.Message);
                }
            }
            
        }
    }
}
