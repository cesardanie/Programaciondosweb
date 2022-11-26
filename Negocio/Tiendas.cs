using Datos;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Tiendas
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? NoLocal { get; set; }
        public string? Telefono { get; set; }
        public string? Horario { get; set; }
        public int Categoria { get; set; }
        public string? Imagen { get; set; }
        public string? Descripcion { get; set; }

        public static List<Tiendas> ListarTiendas(long IdCentroComercial)
        {
            var List_Tiendas = new List<Tiendas>();
            using (var db = new AplicacionCCContext())
            {
                var Storesdb = db.ShopingCenterStores.Where(x => x.IdCentroComercial == IdCentroComercial).Select(p => new Tiendas
                {
                    Id = p.IdTiendaNavigation.IdTienda,
                    Name = p.IdTiendaNavigation.Nombre,
                    NoLocal = p.IdTiendaNavigation.NoLocal,
                    Imagen = p.IdTiendaNavigation.Imagen

                }).ToList();

                return Storesdb;
            } 
        }
        public static Tiendas InfoTienda(long IdTienda)
        {
            try
            {
                using (var db = new AplicacionCCContext())
                {
                    var SCdb = db.Stores.FirstOrDefault(x => x.IdTienda == IdTienda);
                    if (SCdb != null)
                    {
                       return new Tiendas()
                       {
                           NoLocal = SCdb.NoLocal,
                           Name = SCdb.Nombre,
                           Telefono = SCdb.Telefono,
                           Horario = SCdb.Horario,
                           Categoria=SCdb.Categoria,
                           Imagen = SCdb.Imagen,
                           Descripcion = SCdb.Descripcion,
                           
                       };
                    }
                    else throw new Exception("No existe la tienda");
                }
            }
            catch (Exception) { return null; }
        }
    }
}
