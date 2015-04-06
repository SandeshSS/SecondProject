using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    public class ProfileManager
    {
        
        public void SaveCustomer(Customer customer)
        {            
            SqlConnection con = new SqlConnection("Data Source=VDI01T11HSC-325\\SQLEXPRESS;Initial Catalog=EntityContextGroup1;User ID=user1;password=password@1234");
            SqlCommand com = new SqlCommand("insert into Customers(CustomerName,City,State,Address,PinCode,PhoneNumber,Gender,EmailId) values('" + customer.CustomerName + "','"+customer.City+"','"+customer.State+ "','"+ customer.Address +"','"+customer.PinCode+"','"+customer.PhoneNumber+ "','"+customer.Gender+"','" + customer.EmailId + "')",con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
