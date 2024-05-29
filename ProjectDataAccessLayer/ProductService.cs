using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProjectDataAccessLayer;

namespace ProjectDataAccessLayer
{
    public class ProductService
    {
        ProductModel product = new ProductModel();
        ProductRepository productRep = new ProductRepository();



        public void MenuRegister()

        {
            int option = 0;
            do
            {
                Console.WriteLine("Choose the below option");
                Console.WriteLine("1.Insert New Product");
                Console.WriteLine("2.Change Product Price");
                Console.WriteLine("3.RemoveProduct");
                Console.WriteLine("4.Show ALL");
               
                option = int.Parse(Console.ReadLine());
                if (option > 5)
                {
                    Console.WriteLine("EXIT OPTION ENTERED");
                    return;
                }

                switch (option)
                {
                    case 1:
                        Insert();
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    


                }


            } while (option != 5);
            
        }
        public void Insert()
        {
            try { 
            Console.WriteLine("Enter Your Product Name");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter Your Product Price");
            product.Price=Convert.ToDecimal(Console.ReadLine());
            var gst = product.Price * 10 / 100;
            product.Gst = gst;
            Console.WriteLine("Enter Your Product Weight");
            product.Weight= Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Your Product Description");
            product.Description = Console.ReadLine();
            productRep.Insert(product);
            }catch (Exception e) 
            {
                Console.WriteLine(e.Message); 
            }
        }
    }
}
