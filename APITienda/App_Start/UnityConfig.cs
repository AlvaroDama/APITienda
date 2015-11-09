using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Repository.Model;
using Repository.Repository;
using Repository.ViewModel;
using Unity.WebApi;

namespace APITienda
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //Añadimos el control de la Entidad
            container.RegisterType<DbContext, TiendaEntities>();

            /*Añadimos el control de los repositorios 
            (accediendo al repositorio para cada ViewModel)*/
            container.RegisterType<IRepositorio<Almacen, AlmacenViewModel>, 
                RepositorioTienda<Almacen, AlmacenViewModel>>();

            container.RegisterType<IRepositorio<Categoria, CategoriaViewModel>, 
                RepositorioTienda<Categoria, CategoriaViewModel>>();

            container.RegisterType<IRepositorio<ProductoAlmacen, ProductoAlmacenViewModel>, 
                RepositorioTienda<ProductoAlmacen, ProductoAlmacenViewModel>>();

            container.RegisterType<IRepositorio<Producto, ProductoViewModel>, 
                RepositorioTienda<Producto, ProductoViewModel>>();

            container.RegisterType<IRepositorio<Tag, TagViewModel>, 
                RepositorioTienda<Tag, TagViewModel>>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}