using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using BaseRepository;
using BaseRepository.Repository;
using Repository.Model;
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
            container.RegisterType<IRepository<Almacen, AlmacenViewModel>, 
                RepositoryEntity<Almacen, AlmacenViewModel>>();

            container.RegisterType<IRepository<Categoria, CategoriaViewModel>, 
                RepositoryEntity<Categoria, CategoriaViewModel>>();

            container.RegisterType<IRepository<ProductoAlmacen, ProductoAlmacenViewModel>, 
                RepositoryEntity<ProductoAlmacen, ProductoAlmacenViewModel>>();

            container.RegisterType<IRepository<Producto, ProductoViewModel>, 
                RepositoryEntity<Producto, ProductoViewModel>>();

            container.RegisterType<IRepository<Tag, TagViewModel>, 
                RepositoryEntity<Tag, TagViewModel>>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}