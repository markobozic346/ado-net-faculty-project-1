using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer
    {
        private int custid;
        private String companyname;
        private String contacttitle;
        private String contactname;
        private String address;
        private String city;
        private String region;
        private String postcode;
        private String country;
        private String phone;
        private String fax;


        public int Custid { get; set; }
        public String Companyname { get; set; }
        public String Contacttitle { get; set; }
        public String Contactname { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Region { get; set; }
        public String Postcode { get; set; }
        public String Country { get; set; }
        public String Phone { get; set; }
        public String Fax { get; set; }


       
    }
}

