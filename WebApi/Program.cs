
using DepositoLibreria.LogicaAccesoDatos.EF;
using LogicaAplicacion.Articulos;
using LogicaAplicacion.Movimientos;
using LogicaAplicacion.TiposMovimientos;
using LogicaAplicacion.Usuarios;
using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Dtos.TipoMovimientos;
using LogicaNegocio.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfazRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Deposito",
                    Description = "Parte 2 obligatorio Programacion 3",
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                //Agregamos boton de autorize a swagger
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. <br /> <br />
                      Enter 'Bearer' [space] and then your token in the text input below.<br /> <br />
                      Example: 'Bearer 12345abcdef'<br /> <br />",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                   {
                       new OpenApiSecurityScheme
                       {
                        Reference = new OpenApiReference
                        {
                           Type = ReferenceType.SecurityScheme,
                           Id = "Bearer"
                        },
                           Scheme = "oauth2",
                           Name = "Bearer",
                           In = ParameterLocation.Header,
                        },
                        
                        new List<string>()
                      }
                   });


            });

            // configuracion de la autorizacion y el JWT
            
            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";
            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Parametros
            var config = new ConfigurationBuilder()
                    .AddJsonFile("parametros.json", optional: true, reloadOnChange: true)
                    .Build();
            ParametrosGenerales.pageSize = (int)config.GetValue<int>("pageSize");

            //Repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();
            builder.Services.AddScoped<IRepositorioTipoMovimiento, RepositorioTipoMovimiento>();
            builder.Services.AddScoped<IRepositorioMovimiento, RepositorioMovimiento>();

            //Interfaces Usuario
            builder.Services.AddScoped<IAlta<UsuarioDto>, AltaUsuario>();
            builder.Services.AddScoped<IEditar<UsuarioDto>, EditarUsuario>();
            builder.Services.AddScoped<IEliminar<UsuarioDto>, EliminarUsuario>();
            builder.Services.AddScoped<IObtener<UsuarioDto>, ObtenerUsuario>();
            builder.Services.AddScoped<IObtenerTodos<UsuarioDto>, ObtenerUsuarios>();
            builder.Services.AddScoped<IObtenerByEmail, ObtenerUsuarioByEmail>();

            //Interfaces Articulo
            builder.Services.AddScoped<IAlta<ArticuloDto>, AltaArticulo>();
            builder.Services.AddScoped<IEditar<ArticuloDto>, EditarArticulo>();
            builder.Services.AddScoped<IEliminar<ArticuloDto>, EliminarArticulo>();
            builder.Services.AddScoped<IObtener<ArticuloDto>, ObtenerArticulo>();
            builder.Services.AddScoped<IObtenerTodos<ArticuloDto>, ObtenerArticulos>();

            //Interfaces Tipo Movimiento
            builder.Services.AddScoped<IAltaID<TipoMovimientoDto>, AltaTipoMovimiento>();
            builder.Services.AddScoped<IEditar<TipoMovimientoDto>, EditarTipoMovimiento>();
            builder.Services.AddScoped<IEliminar<TipoMovimientoDto>, EliminarTipoMovimiento>();
            builder.Services.AddScoped<IObtener<TipoMovimientoDto>, ObtenerTipoMovimiento>();
            builder.Services.AddScoped<IObtenerTodos<TipoMovimientoDto>, ObtenerTiposMovimientos>();

            //Interfaces Movimiento
            builder.Services.AddScoped<IAltaID<MovimientoCRUDDto>, AltaMovimiento>();
            builder.Services.AddScoped<IEditar<MovimientoCRUDDto>, EditarMovimiento>();
            builder.Services.AddScoped<IEliminar<MovimientoDto>, EliminarMovimiento>();
            builder.Services.AddScoped<IObtener<MovimientoDto>, ObtenerMovimiento>();
            builder.Services.AddScoped<IObtenerTodos<MovimientoDto>, ObtenerMovimientos>();
            builder.Services.AddScoped<IObtenerByNumber<MovimientoDto>, ObtenerMovimientoByPage>();
            builder.Services.AddScoped<ICantidadTotal, ObtenerCantidadMovimiento>();
            builder.Services.AddScoped<IObtenerTodos<string>, ObtenerCantidadMovimientos>();
            builder.Services.AddScoped<IObtenerRangoFecha<Articulo>, ObtenerMovimientosRangoFechas>();
            builder.Services.AddScoped<IObtenerFiltroDobleString<MovimientoDto>, ObtenerMovimientosPorTipoYArt>();

            //Inyectar el contexto
            builder.Services.AddDbContext<LibreriaContext>();

            //Para que me funcione la sesion
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
