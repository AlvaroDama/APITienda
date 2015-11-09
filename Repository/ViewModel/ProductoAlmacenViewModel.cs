using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Model;

namespace Repository.ViewModel
{
    public class ProductoAlmacenViewModel :IViewModel<ProductoAlmacen>
    {
        public int idProducto { get; set; }
        public int idAlmacen { get; set; }
        public Nullable<int> Existencias { get; set; }

        public ProductoAlmacen ToBaseDatos()
        {
            return new ProductoAlmacen()
            {
                idAlmacen = this.idAlmacen,
                idProducto = this.idProducto,
                Existencias = this.Existencias
            };
        }

        public void FromBaseDatos(ProductoAlmacen modelo)
        {
            this.idProducto = modelo.idProducto;
            this.idAlmacen = modelo.idAlmacen;
            this.Existencias = modelo.Existencias;
        }

        public void UpdateBaseDatos(ProductoAlmacen modelo)
        {
            modelo.idProducto = this.idProducto;
            modelo.idAlmacen = this.idAlmacen;
            modelo.Existencias = this.Existencias;
        }

        public object[] GetKeys()
        {
            return new[] {(object) this.idProducto, this.idAlmacen};
        }
    }
}
