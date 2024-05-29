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
        internal void Update(ProductModel product)
        {
            try
            {

                if (product.Price != 0 && product.Name.Length != 0)
                {
                    var Gst = product.Price * 10 / 100;

                    var Update = ($"exec Put '{product.Name}',{product.Price},{Gst}");
                    DAL.Open();
                    DAL.Execute(Update);
                    DAL.Close();
                    Showall();
                }
                


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void Delete(ProductModel product)
        {
            try
            {
                if (product.Name != null && product.Name.Length != 0)
                {
                    var Delete = ($"exec Spremove '{product.Name}'");
                    DAL.Open();
                    DAL.Execute(Delete);
                    DAL.Close();
                    Showall();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public IEnumerable<ProductModel> Showall()
        {
            IEnumerable<ProductModel> result = Enumerable.Empty<ProductModel>();

            try
            {
                var showAllQuery = "exec List";
                DAL.Open();
                result = DAL.Query<ProductModel>(showAllQuery);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DAL.Close();
            }

            return result;
        }
    }
}
