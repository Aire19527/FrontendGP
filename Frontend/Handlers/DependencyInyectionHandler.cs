using Domain.Services;
using Domain.Services.Interfaces;
using Infraestrucutre.Core.Repository;
using Infraestrucutre.Core.Repository.Interface;
using Infraestrucutre.Core.UnitOfWork;
using Infraestrucutre.Core.UnitOfWork.Interface;

namespace Frontend.Handlers
{
    public static class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            // Infrastructure
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<ICitaMedicaServices, CitaMedicaServices>();
            services.AddTransient<IMedicamentoServices, MedicamentoServices>();
            services.AddTransient<IPacienteServices, PacienteServices>();
            services.AddTransient<ITransversalServices, TransversalServices>();
            services.AddTransient<IHistoriaClinicaServices, HistoriaClinicaServices>();

        }
    }
}
