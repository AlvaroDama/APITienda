using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repository.Model;
using System.Web.Http.Description;

namespace APITienda.Controllers
{
    public class ProductoController : ApiController
    {
        private TiendaEntities db;

       

        public ProductoController()
        {
            db = new TiendaEntities();
           
        }

        public IQueryable<Producto> Get()
        {
            return db.Producto;
        }

        [ResponseType(typeof (Producto))]
        public IHttpActionResult Post(Producto producto)
        {
            db.Producto.Add(producto);

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest("Error en el alta");
            }

            return Created("ApiProductos", producto);


        }

        [ResponseType(typeof (Producto))]
        public IHttpActionResult Put(Producto prod)
        {
            db.Entry(prod).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(prod);
        }

        [ResponseType(typeof (void))]
        public IHttpActionResult Delete(string id)
        {

            var prod = db.Producto.Find(id);
            if (prod == null)
                return NotFound();
            db.Producto.Remove(prod);


            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
