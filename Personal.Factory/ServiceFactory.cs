using Microsoft.Extensions.DependencyInjection;
using Personal.AccesoADatos;
using Personal.AccesoADatos.Repositorio;
using Personal.InterfazAccesoADatos;
using Personal.InterfazLogicaDominio;
using Personal.LogicaDominio;
using System;

namespace Personal.Factory
{
    public class ServiceFactory
    {
        private readonly IServiceCollection services;

        public ServiceFactory(IServiceCollection services)
        {
            this.services = services;
        }

        public void AddCustomServices()
        {
            services.AddScoped<IConexionBD, ConexionBD>();

            services.AddScoped<IPersonaRespositorio, PersonaRepositorio>();
            services.AddScoped<ILogicaPersona, LogicaPersona>();

            services.AddScoped<IFichadaRepositorio, FichadaRepositorio>();
            services.AddScoped<ILogicaFichada, LogicaFichada>();

        }
    }
}
