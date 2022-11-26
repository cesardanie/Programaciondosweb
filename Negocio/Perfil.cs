using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Perfil
    {
        public string? Nombre { get; set; } 

        public string? Correo { get; set; }  

        public string? Contraseña { get; set; } 

        public string? Username { get; set; }

        public static int ValidarPerfil(Perfil user)
        {
            try
            {
                using (var db = new AplicacionCCContext())
                {
                    var Usuario = db.Users.FirstOrDefault(x => x.Username == user.Username && x.Contraseña == user.Contraseña);
                    if (Usuario != null)
                    {
                        return 1;
                    }
                    else { throw new Exception("No existe usuario"); }
                }
            }
            catch (Exception e) 
            {
                if(e.ToString() != "No existe usuario") return 2;
                else return 0; 
            } 
        }

        //Este método se encarga de crear un nuevo usuario
        public static int Crearperfil(Perfil usuario)
        {
            try
            {
                using (var db = new Datos.AplicacionCCContext())
                {
                    db.Add(new User()
                    {
                        Username = usuario.Username,
                        Nombre = usuario.Nombre,
                        Correo = usuario.Correo,
                        Contraseña = usuario.Contraseña
                    });   
                    db.SaveChanges();
                }
                return 1;
            }
            catch(Exception){ return 0; }
        }
        public static int ActualizarPerfil(Perfil usuario)
        {
            try
            {
                using (var db = new Datos.AplicacionCCContext())
                {
                    var user = db.Users.FirstOrDefault(x => x.Username == usuario.Username);
                    if(user != null)
                    {
                        user.Nombre = usuario.Nombre;
                        user.Correo = usuario.Correo;
                        db.SaveChanges();
                        return 1;
                    }
                    else throw new Exception("No se encontro el perfil"); 
                }
                
            }
            catch (Exception e)
            {
                if (e.ToString() != "No se encontro el perfil") return 2;
                else return 0;
            }
        }
    }
}
