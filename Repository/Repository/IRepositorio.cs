using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repository.ViewModel;

namespace Repository.Repository
{
    public interface IRepositorio <MyModel, MyViewModel>
        where MyModel:class
        where MyViewModel: IViewModel<MyModel>, new()
    {
        MyViewModel Alta(MyViewModel model);

        int Baja(MyViewModel model);
        int Baja(Expression<Func<MyModel, bool>> query);

        int Modificacion(MyViewModel model);

        ICollection<MyViewModel> Get();
        ICollection<MyViewModel> Get(Expression<Func<MyModel, bool>> query);
        MyViewModel Get(params object[] claves);
    }
}
