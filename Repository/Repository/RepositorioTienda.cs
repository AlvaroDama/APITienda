using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repository.ViewModel;

/*Aunque using(<contexto de BBDD>) se usa para hacer el dispose() 
de la conexión a la BBDD, en ésta práctica no lo usamos ya que 
queremos que sea Unity quien se encargue del control de las conexiones.*/
namespace Repository.Repository
{
    public class RepositorioTienda<MyModel, MyViewModel> : IRepositorio<MyModel, MyViewModel> 
        where MyViewModel : IViewModel<MyModel>, new() 
        where MyModel : class
    {
        private DbContext ctx;

        protected DbSet<MyModel> DbSet => ctx.Set<MyModel>();

        public RepositorioTienda(DbContext context)
        {
            this.ctx = context;
        } 

        public MyViewModel Alta(MyViewModel model)
        {
            
            var m = model.ToBaseDatos();
            DbSet.Add(m);

            try
            {
                ctx.SaveChanges();
                model.FromBaseDatos(m);
                return model;
            }
            catch (Exception)
            {
                return default(MyViewModel);
            }
            
        }

        public int Baja(Expression<Func<MyModel, bool>> query)
        {
            throw new NotImplementedException();
        }

        public int Baja(MyViewModel model)
        {
          
            var o = DbSet.Find(model.GetKeys());
            DbSet.Remove(o);

            try
            {
                return ctx.SaveChanges();
            }
            catch (Exception)
            {
                    
                return 0;
            }
            
        }

        public ICollection<MyViewModel> Get()
        {
            
            var r = new List<MyViewModel>();
            var o = new MyViewModel();

            foreach (var it in DbSet)
            {
                o.FromBaseDatos(it);
                r.Add(o);
            }

            return r;

        }

        public MyViewModel Get(params object[] claves)
        {
            var data = DbSet.Find(claves);
            var r = new MyViewModel();

            r.FromBaseDatos(data);
            return r;
        }

        public ICollection<MyViewModel> Get(Expression<Func<MyModel, bool>> query)
        {
            throw new NotImplementedException();
        }

        public int Modificacion(MyViewModel model)
        {
            
            var data = DbSet.Find(model.GetKeys());
            model.UpdateBaseDatos(data);
            try
            {
                return ctx.SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
            
        }
    }
}
