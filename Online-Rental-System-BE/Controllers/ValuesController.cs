using Online_Rental_System_BE.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Online_Rental_System_BE.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("api/Values/Login")]
        [HttpPost]
        public Response Login(RegisterUser registration)
        {
            Response response = new Response();
            DAL dal = new DAL();
            DataTable dt = dal.Login(registration);
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.TableName = "RegisterUser";
                response.responseCode = 200;
                response.responseMessage = "Logged In";
                response.lstRegisterUser = dt;
            }
            else
            {
                response.responseCode = 100;
                response.responseMessage = "Login failed";
                response.lstRegisterUser = null;
            }
            return response; // JsonConvert.SerializeObject(response);
        }

        [Route("api/Values/SignUp")]
        [HttpPost]
        public Response SignUp(RegisterUser registration)
        {
            Response response = new Response();
            try
            {
                if (registration != null)
                {
                    DAL dal = new DAL();
                    int i = dal.SignUp(registration);
                    if (i > 0)
                    {
                        response.responseCode = 200;
                        response.responseMessage = "Registration successful";
                    }
                    else
                    {
                        response.responseCode = 100;
                        response.responseMessage = "Some error occured";
                    }
                }
                else
                {
                    response.responseCode = 100;
                    response.responseMessage = "Some error occured. Try later.";
                }
            }
            catch (Exception ex)
            {
                response.responseCode = 100;
                response.responseMessage = "Operation failed" + ex.Message;
            }
            return response; // JsonConvert.SerializeObject(response);
        }

        [Route("api/Values/AddDeleteProduct")]
        [HttpPost]
        public Response AddDeleteProduct(Product product)
        {
            Response response = new Response();
            try
            {
                if (product != null)
                {
                    DAL dal = new DAL();
                    int i = dal.AddDeleteProduct(product);
                    if (i > 0)
                    {
                        response.responseCode = 200;
                        if (product.Type == "Add")
                            response.responseMessage = "Product added successful";
                        if (product.Type == "Delete")
                            response.responseMessage = "Product deleted successful";
                    }
                    else
                    {
                        response.responseCode = 100;
                        response.responseMessage = "Some error occured";
                    }
                }
                else
                {
                    response.responseCode = 100;
                    response.responseMessage = "Some error occured. Try later.";
                }
            }
            catch (Exception ex)
            {
                response.responseCode = 100;
                response.responseMessage = "Operation failed" + ex.Message;
            }
            return response; // JsonConvert.SerializeObject(response);
        }

        [Route("api/Values/GetProducts")]
        [HttpGet]
        public Response GetProducts()
        {
            Response response = new Response();
            try
            {
                DAL dal = new DAL();
                DataTable dt = dal.GetList();
                if (dt != null && dt.Rows.Count > 0)
                {
                    dt.TableName = "Products";
                    response.responseCode = 200;
                    response.responseMessage = "Product added successful";
                    response.lstProducts = dt;
                }
                else
                {
                    response.responseCode = 100;
                    response.responseMessage = "Some error occured. Try later.";
                    response.lstProducts = null;
                }
            }
            catch (Exception ex)
            {
                response.responseCode = 100;
                response.responseMessage = "Operation failed" + ex.Message;
            }
            return response; // JsonConvert.SerializeObject(response);
        }
    }
}
