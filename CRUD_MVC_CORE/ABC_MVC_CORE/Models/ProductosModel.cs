using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_MVC_CORE.Models
{
    public class ProductosModel
    {

        public ProductosModel()
        {

        }

        public  int ProdId{ get; set; }
        public string ProdNombre { get; set; }
        public string ProdDescripcion { get; set; }
        public int ProdPrecio { get; set; }

    }
}
