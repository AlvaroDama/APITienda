using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using Repository.Model;
using System.Web.Http.Description;
using BaseRepository.Repository;
using Repository.ViewModel;

namespace APITienda.Controllers
{
    public class ProductoController : ApiController
    {

        public IRepository<Producto, ProductoViewModel> repo { get; set; }

        public ProductoController()
        {
            var ctx = new TiendaEntities();
            repo = new RepositoryEntity<Producto, ProductoViewModel>(ctx);
        }

        public ICollection<ProductoViewModel> Get()
        {
            return repo.Get();
        }

        [ResponseType(typeof(ProductoViewModel))]
        public IHttpActionResult Get(String id)
        {
            var data = repo.Get(int.Parse(id));
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        

    }
}
