using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DataLayer;
using BusinessLoginc;
using Domain;
using static System.Net.Mime.MediaTypeNames;


namespace ADONETComplete
{
    public partial class TabeleForm : Form
    {
        BLEmployee BLemployee = BLEmployee.Instance;
        BLECustomer BLcustomer = BLECustomer.Instance;
        public TabeleForm()
        {
            InitializeComponent();

            dgwPodaci.DataSource = BLemployee.GetEmployeesTableData();
            dgwPodaci.SelectionChanged += dgwPodaci_SelectionChange;

        }
        private void dgwPodaci_SelectionChange(object sender, EventArgs e)
        {
            if(dgwPodaci.SelectedRows.Count > 0)
            {
                btnIzmeni.Enabled = true;
                btnObrisi.Enabled = true;
            }
            else
            {
                btnObrisi.Enabled = false;
                btnIzmeni.Enabled = false;
            }
        }
        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            string selected = cmbIzborTabele.SelectedItem.ToString();

            string id = dgwPodaci.SelectedRows[0].Cells[0].Value.ToString();
            int i;
            if (Int32.TryParse(id, out i))
            {
                switch (selected)
                {
                    case "Employees":


                        IzmeniEmployeeForm eFrm = new IzmeniEmployeeForm();

                        Employee em = new Employee();
                        em = BLemployee.GetEmployee(i);

                        eFrm.e = em;

                        eFrm.ShowDialog();
                        this.ShowSelectedTable();
                        
                        break;

                    case "Customers":
                        IzmeniCustomerForm cFrm = new IzmeniCustomerForm();
                        
                        Customer cu = new Customer();
                        cu = BLcustomer.GetCustomer(i);
                        cFrm.c = cu;

                        cFrm.ShowDialog();
                        this.ShowSelectedTable();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Izabrani red nije validan");
            }

        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            string selected = cmbIzborTabele.SelectedItem.ToString();

            switch (selected)
            {
                case "Employees":
                    IzmeniEmployeeForm eFrm = new IzmeniEmployeeForm();
                    Employee em = new Employee();
                    eFrm.e = em;

                    eFrm.ShowDialog();
                    this.ShowSelectedTable();
                    break;

                case "Customers":
                    IzmeniCustomerForm cFrm = new IzmeniCustomerForm();
                    Customer cu = new Customer();
                    cFrm.c = cu;

                    cFrm.ShowDialog();
                    this.ShowSelectedTable();
                    break;
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            int i;
            string id = dgwPodaci.SelectedRows[0].Cells[0].Value.ToString();

            string selected = cmbIzborTabele.SelectedItem.ToString();

            if (Int32.TryParse(id, out i))
            {
                switch (selected)
                {
                    case "Employees":
                        BLemployee.DeleteEmployee(i);
                        this.ShowSelectedTable();
                        break;

                    case "Customers":
                        BLcustomer.DeleteCustomer(i);
                        this.ShowSelectedTable();
                        break;
                }
            }
        }

        private void lblIzborTabele_Click(object sender, EventArgs e)
        {

        }

        private void dgwPodaci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbIzborTabele.Items.Add("Employees");
            cmbIzborTabele.Items.Add("Customers");

            cmbIzborTabele.SelectedIndex = 0;
            ShowSelectedTable();
        }

        private void cmbIzborTabele_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedTable();
        }

        private void ShowSelectedTable()
        {
           dgwPodaci.ClearSelection();
           string selected = cmbIzborTabele.SelectedItem.ToString();
            
            switch (selected)
            {
                case "Employees":
                   
                    dgwPodaci.DataSource = BLemployee.GetEmployees();
                    break;

                case "Customers":
                    dgwPodaci.DataSource = BLcustomer.GetCustomers();
                    break;
            }       
          
        }


        private void lblPretraga_Click(object sender, EventArgs e)
        {

        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            string selected = cmbIzborTabele.SelectedItem.ToString();

            switch (selected)
            {
                case "Employees":
                    dgwPodaci.DataSource = BLemployee.GetEmployees(txtPretraga.Text);
                    break;

                case "Customers":
                    dgwPodaci.DataSource = BLcustomer.GetCustomers(txtPretraga.Text);
                    break;
            }
        }
    }
}
