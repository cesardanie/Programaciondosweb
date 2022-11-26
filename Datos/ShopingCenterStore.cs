using System;
using System.Collections.Generic;

namespace Datos
{
    public partial class ShopingCenterStore
    {
        public long IdTcc { get; set; }
        public long IdCentroComercial { get; set; }
        public long IdTienda { get; set; }

        public virtual ShopingCenter IdCentroComercialNavigation { get; set; } = null!;
        public virtual Store IdTiendaNavigation { get; set; } = null!;
    }
}
