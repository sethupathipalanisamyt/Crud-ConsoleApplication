using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_ConsoleApplication
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public Decimal Gst { get; set; }
        public Decimal Weight {  get; set; }
        public string Description { get; set; }
    }
}
