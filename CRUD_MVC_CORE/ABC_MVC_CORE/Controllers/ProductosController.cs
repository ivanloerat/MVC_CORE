using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ABC_MVC_CORE.Controllers
{
    public class ProductosController : Controller
    {

        Datos.ClsConexion cnnbd = new Datos.ClsConexion();
        // GET: Productos
        [HttpGet]
        public ActionResult Index()
        {
            
            return View(cnnbd.ObtenerProductos());
        }

     
        // GET: Productos/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View(new Models.ProductosModel());
        }

        // POST: Productos/Create
        [HttpPost]        
        public ActionResult Create(Models.ProductosModel productosModel)
        {
            cnnbd.InsertarProducto(productosModel.ProdNombre, productosModel.ProdDescripcion, productosModel.ProdPrecio);
            return RedirectToAction("Index");
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            DataTable dt = cnnbd.ObtenerDetalleProducto(id);
            Models.ProductosModel prdModel = new Models.ProductosModel();
            if(dt.Rows.Count == 1)
            {
                prdModel.ProdNombre = dt.Rows[0][1].ToString();
                prdModel.ProdDescripcion = dt.Rows[0][2].ToString();
                prdModel.ProdPrecio = int.Parse(dt.Rows[0][3].ToString());
                return View(prdModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        // POST: Productos/Edit/5
        [HttpPost]        
        public ActionResult Edit(int id, IFormCollection collection)
        {
            cnnbd.ActualizaProducto(id, collection["ProdNombre"], collection["ProdDescripcion"], int.Parse(collection["ProdPrecio"]));
            return RedirectToAction("Index");            
        }

      

        // POST: Productos/Delete/5
            
        public ActionResult Delete(int id)
        {
            // TODO: Add delete logic here
         cnnbd.EliminaProducto(id);
         return RedirectToAction("Index");
        
        }
    }
}