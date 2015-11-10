using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseRepository.ViewModel;
using Repository.Model;

namespace Repository.ViewModel
{
    public class ProductoViewModel : IViewModel<Producto>
    {
        public string Nombre { get; set; }
        public string Fabricante { get; set; }
        public Nullable<double> PrecioVenta { get; set; }
        public double PrecioCoste { get; set; }
        public int ID { get; set; }
        public int Categoria { get; set; }

        public Producto ToBaseDatos()
        {
            return new Producto()
            {
                Nombre = this.Nombre,
                Fabricante = this.Fabricante,
                PrecioVenta = this.PrecioVenta,
                PrecioCoste = this.PrecioCoste,
                ID = this.ID,
                Categoria = this.Categoria
            };
        }

        public void FromBaseDatos(Producto modelo)
        {
            this.ID = modelo.ID;
            this.Categoria = modelo.Categoria;
            this.Fabricante = modelo.Fabricante;
            this.Nombre = modelo.Nombre;
            this.PrecioCoste = modelo.PrecioCoste;
            this.PrecioVenta = modelo.PrecioVenta;
        }

        public void UpdateBaseDatos(Producto modelo)
        {
            modelo.ID = this.ID;
            modelo.Categoria = this.Categoria;
            modelo.Fabricante = this.Fabricante;
            modelo.Nombre = this.Nombre;
            modelo.PrecioCoste = this.PrecioCoste;
            modelo.PrecioVenta = this.PrecioVenta;
            
        }

        public object[] GetKeys()
        {
            return new[] {(object) this.ID};
        }
    }
}
