namespace Aplicacion_Centros_Comerciales
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string Micors = "Micors";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(Micors);
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //SOLICITUDES TIPO GET

            //Solicitud para listar Centros comerciales 
            app.MapGet("/Api/CentrosComerciales", () =>
            {
                return Negocio.Centros_Comerciales.Centros_Comerciales_Activos();
            });

            //Solicitud para listar Tiendas 
            app.MapGet("/Api/Tiendas", (long IdCentrocomercial) =>
            {
                return Negocio.Tiendas.ListarTiendas(IdCentrocomercial);
            });

            //Solicitud para Mostrar información de Tienda
            app.MapGet("/Api/Tienda", (long IdTienda) =>
            {
                return Negocio.Tiendas.InfoTienda(IdTienda);
            });

            //SOLICITUDES TIPO POST

            //Solicitud para crear nuevo usuario
            app.MapPost("/Api/NewUser", (string NombreUsuario, string nombre, string correo, string contraseña) =>
            {
                return Negocio.Perfil.Crearperfil(new Negocio.Perfil()
                {
                    Username = NombreUsuario,
                    Nombre = nombre,
                    Correo = correo,
                    Contraseña = contraseña
                });
            });


            //SOLICITUDES TIPO PUT

            //Solicitud para Actualizar el centro comercial especificado 
            app.MapPut("/Api/ActualizarCentrocomercial", (long id, string? Nombre, string? direccion) =>
            {
                return Negocio.Centros_Comerciales.ActualizarCentroComercial(new Negocio.Centros_Comerciales()
                {
                    Id = id,
                    Name = Nombre,
                    Address = direccion
                });
            });

            //Solicitud para actualizar perfil del usuario
            app.MapPut("/Api/ActualizarPerfil", (string nombre, string correo, string contraseña) =>
            {
                return Negocio.Perfil.ActualizarPerfil(new Negocio.Perfil()
                {
                    Nombre = nombre,
                    Correo = correo,
                });
            });


            //SOLICITUDES TIPO DELETE

            //Eliminar Centro Comercial
            app.MapDelete("/Api/EliminarCentroComercial", (long IdCentrocomercial) =>
            {
                return Negocio.Centros_Comerciales.EliminarCentroComercial(IdCentrocomercial);
            });

            app.Run();
        }
    }
}