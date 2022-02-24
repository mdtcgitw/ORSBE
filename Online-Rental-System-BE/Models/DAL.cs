using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Online_Rental_System_BE.Models
{
    public class DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public int SignUp(RegisterUserModel registration)
        {
            int i = 0;
            try
            {
                cmd = new SqlCommand("Insert into RegisterUser(Username,FirstName,LastName,Type, password, Email) " +
                    " values('" + registration.UserName + "','" + registration.FirstName + "'," +
                    "'" + registration.LastName + "','" + registration.Type + "','" + registration.Password + "'," +
                    "'" + registration.Email + "') ", con);
                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }
            return i;
        }
        public int AddDeleteProduct(ProductModel product)
        {
            int i = 0;
            try
            {
                if (product.Type == "Add")
                    cmd = new SqlCommand("Insert into Product(Title,Subtitle,Description,Owner)"+
                    " values('" + product.Title + "','" + product.Subtitle + "'," +
                    "'" + product.Description + "','" + product.Owner +"') ", con);

                if (product.Type == "Delete")
                    cmd = new SqlCommand("DELETE FROM Product WHERE ID = '" + product.Id + "' ", con);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }
            return i;
        }
        public DataTable GetList()
        {
            try
            {
                da = new SqlDataAdapter("Select * FROM Product", con);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    dt = null;
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
        public DataTable Login(RegisterUserModel registration)
        {
            try
            {
                da = new SqlDataAdapter("Select * FROM RegisterUser WHERE Email = '" + registration.Email + "' and " +
                    " Password = '" + registration.Password + "'", con);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    dt = null;
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

    }
}