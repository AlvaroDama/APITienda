using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseRepository.ViewModel;
using Repository.Model;

namespace Repository.ViewModel
{
    public class AlmacenViewModel : IViewModel<Almacen>
    {
        public string Ciudad { get; set; }
        public int CPostal { get; set; }
        public int ID { get; set; }

        public Almacen ToBaseDatos()
        {
            return new Almacen()
            {
                Ciudad = this.Ciudad,
                CPostal = this.CPostal,
                ID = this.ID
            };
        }

        public void FromBaseDatos(Almacen modelo)
        {
            this.ID = modelo.ID;
            this.Ciudad = modelo.Ciudad;
            this.CPostal = modelo.CPostal;
        }

        public void UpdateBaseDatos(Almacen modelo)
        {
            modelo.ID = this.ID;
            modelo.CPostal = this.CPostal;
            modelo.Ciudad = this.Ciudad;
        }

        public object[] GetKeys()
        {
            return new[] {(object) this.ID};
        }
    }
}
