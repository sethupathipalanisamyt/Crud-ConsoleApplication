using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace ProjectDataAccessLayer
{
    internal class ProductRepository
    {
        string connctionstring = "Data Source=DESKTOP-D90893D\\SQLEXPRESS;Initial Catalog=Sethupathi; User Id=sa;Password=sethu903;";
        SqlConnection DAL;
        ProductModel product = new ProductModel();
        public ProductRepository()
        {
            DAL = new SqlConnection(connctionstring);
        }
        internal void Insert(ProductModel product)
        {
            try
            {
                var gst = product.Price * 10 / 100;
                product.Gst = gst;

                var Insertsql = ($"exec InsertProduct'{product.Name}',{product.Price},{product.Gst},{product.Weight},'{product.Description}'");

                DAL.Open();
                DAL.Execute(Insertsql);
                DAL.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not insert {ex.Message}");
            }


        }
    }
}
