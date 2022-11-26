using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Negocio
{
    public class Centros_Comerciales
    {

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Imagen { get; set; }
        
        
        public static List<Centros_Comerciales> Centros_Comerciales_Activos()
        {
            try
            {
                using (var db = new Datos.AplicacionCCContext())
                {
                    var SCdb = db.ShopingCenters.Where(x => x.Estado == true).Select(p => new Centros_Comerciales
                    {
                        Id = p.IdCentroComercial,
                        Name = p.Nombre,
                        Address = p.Direccion,
                        Imagen = "/Imagen/CentrosComerciales/" + p.Nombre.ToString() + ".png"
                    }).ToList();

                    return SCdb;
                }
            }catch(Exception){ return null;}
        }
        public static bool AgregarCentroComercial(Centros_Comerciales centro_Comercial)
        {
            try
            {
                using (var db = new Datos.AplicacionCCContext())
                {
                    var NewCentroComercial = new Datos.ShopingCenter()
                    {
                        Nombre = centro_Comercial.Name,
                        Direccion = centro_Comercial.Address,
                        Imagen = "/Imagen/CentrosComerciales/" + centro_Comercial.Name.ToString() + ".png",
                        Estado = true
                    };
                    db.ShopingCenters.Add(NewCentroComercial);
                    db.SaveChanges();
                }
                return true;
            }catch(Exception){ return false; }
        }
        public static bool ActualizarCentroComercial(Centros_Comerciales centros_Comerciales)
        {
            try
            {
                using (var db = new Datos.AplicacionCCContext())
                {
                    var SCdb = db.ShopingCenters.FirstOrDefault(x => x.IdCentroComercial == centros_Comerciales.Id);
                    if (SCdb != null)
                    {
                        if (centros_Comerciales.Name != null)
                        {
                            SCdb.Nombre = centros_Comerciales.Name;
                            SCdb.Imagen = "/Imagen/CentrosComerciales/" + SCdb.Nombre.ToString() + ".png";
                        }
                        if (centros_Comerciales.Address != null)
                            SCdb.Direccion = centros_Comerciales.Address;
                        db.SaveChanges();
                        return true;
                    }
                    else throw new Exception("Error de actualizacion");
                }
            }catch(Exception){ return false; }
        }
        public static bool EliminarCentroComercial(long IdCentroComercial)
        {
            try
            {
                using (var db = new Datos.AplicacionCCContext())
                {
                    var SCdb = db.ShopingCenters.FirstOrDefault(x => x.IdCentroComercial == IdCentroComercial);
                    if (SCdb != null)
                    {
                        SCdb.Estado = false;
                        db.SaveChanges();
                        return true;
                    }
                    else throw new Exception("Error de eliminacion");
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
