using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Model;

namespace Repository.ViewModel
{
    public class CategoriaViewModel : IViewModel<Categoria>
    {
        public string Nombre { get; set; }
        public int ID { get; set; }

        public Categoria ToBaseDatos()
        {
            return new Categoria()
            {
                ID = this.ID,
                Nombre = this.Nombre
            };
        }

        public void FromBaseDatos(Categoria modelo)
        {
            this.ID = modelo.ID;
            this.Nombre = modelo.Nombre;
        }

        public void UpdateBaseDatos(Categoria modelo)
        {
            modelo.ID = this.ID;
            modelo.Nombre = this.Nombre;
        }

        public object[] GetKeys()
        {
            return new[] {(object) this.ID};
        }

    }
}
