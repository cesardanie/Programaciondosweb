using System;
using System.Collections.Generic;

namespace Datos
{
    public partial class ShopingCenter
    {
        public ShopingCenter()
        {
            ShopingCenterStores = new HashSet<ShopingCenterStore>();
        }

        public long IdCentroComercial { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public bool Estado { get; set; }
        public string? Imagen { get; set; }

        public virtual ICollection<ShopingCenterStore> ShopingCenterStores { get; set; }
    }
}
