using System;
using System.Collections.Generic;

namespace Datos
{
    public partial class Store
    {
        public Store()
        {
            ShopingCenterStores = new HashSet<ShopingCenterStore>();
        }

        public long IdTienda { get; set; }
        public string Nombre { get; set; } = null!;
        public string NoLocal { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Horario { get; set; }
        public int Categoria { get; set; }
        public string? Imagen { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<ShopingCenterStore> ShopingCenterStores { get; set; }
    }
}
