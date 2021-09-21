using Services.Interfaces;
using Services.Services;
using UoW.Interface;
using UoW.SqlServer;
using Microsoft.Extensions.DependencyInjection;


namespace Services.IoC
{
    public static class Servicios
    {
        public static void AplicacionServiciosIoC(this IServiceCollection services)
        {

            services.AddTransient<IUoW, UoWSqlServer>();

            #region "services"
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IFacturaService, FacturaService>();
            services.AddTransient<IDetalleFacturaService, DetalleFacturaService>();
            #endregion
        }

    }
}
