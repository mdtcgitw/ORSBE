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
        RentalSystemEntities db = new RentalSystemEntities();
        [Route("api/Values/Login")]
        [HttpPost]
        public Response Login(RegisterUserModel registration)
        {
            Response response = new Response();
            RegisterUser registerUser = 
                db.RegisterUsers.FirstOrDefault(x => x.Email == registration.Email && x.Password == registration.Password);
            if (registerUser != null)
            {               
                response.responseCode = 200;
                response.responseMessage = "Logged In";
                response.registerUser = registerUser;
            }
            else
            {
                response.responseCode = 100;
                response.responseMessage = "Login failed";
                response.registerUser = null;
            }
            return response; // JsonConvert.SerializeObject(response);
        }

        [Route("api/Values/SignUp")]
        [HttpPost]
        public Response SignUp(RegisterUserModel registration)
        {
            Response response = new Response();
            RegisterUser registerUser = new RegisterUser();
            registerUser.UserName = registerUser.UserName;
            registerUser.FirstName = registerUser.FirstName;
            registerUser.LastName = registerUser.LastName;            
            registerUser.Type = registerUser.Type;
            registerUser.Password = registerUser.Password;
            registerUser.Email = registerUser.Email;
            try
            {
                if (registerUser != null)
                {
                    db.RegisterUsers.Add(registerUser);
                    db.SaveChanges();                    
                    response.responseCode = 200;
                    response.responseMessage = "Registration successful";                   
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
        public Response AddDeleteProduct(ProductModel productModel)
        {
            Response response = new Response();
            Product product = new Product();
            product.ID = productModel.Id;
            product.Title = productModel.Title;
            product.Subtitle = productModel.Subtitle;
            product.Description = productModel.Description;
            product.Owner = productModel.Owner;
            try
            {
                if (product != null)
                {
                    if (productModel.Type == "Add")
                    {
                        db.Products.Add(product);
                        db.SaveChanges();
                        response.responseCode = 200;
                        response.responseMessage = "Product added successfully";
                    }
                    if (productModel.Type == "Edit")
                    {
                        db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        response.responseCode = 200;
                        response.responseMessage = "Product updated successfully";
                    }
                    if (productModel.Type == "Delete")
                    {
                        db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        response.responseCode = 200;
                        response.responseMessage = "Product deleted successfully";
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
            List<Product> lstProducts = new List<Product>();
            try
            {
                lstProducts = db.Products.ToList();              
                if (lstProducts != null)
                {
                    response.responseCode = 200;
                    response.responseMessage = "Products fetched";
                    response.lstProducts = lstProducts;
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

        [Route("api/Values/GetProductById")]
        [HttpPost]
        public Response GetProductById(ProductModel productModel)
        {
            Response response = new Response();
            Product product = new Product();
            try
            {
                product = db.Products.FirstOrDefault(x => x.ID == productModel.Id);
                if (product != null)
                {
                    response.responseCode = 200;
                    response.responseMessage = "Product fetched";
                    response.product = product;
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
