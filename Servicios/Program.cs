using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

var builder = WebApplication.CreateBuilder(args);
string Micors = "Micors";
builder.Services.AddCors(options => {
    options.AddPolicy(name: Micors,
        policy =>
        {
            policy.WithOrigins("*");

        });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
 //string Micors = "Micors";
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(Micors);

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
app.MapPut("/Api/ActualizarCentrocomercial", (long id,string? Nombre, string? direccion) =>
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
