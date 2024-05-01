using Infraestrucutre.Core.Context;
using Infraestrucutre.Core.Models;
using Infraestrucutre.Core.Repository;
using Infraestrucutre.Core.Repository.Interface;
using Infraestrucutre.Core.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infraestrucutre.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Attributes
        private readonly GPContext _context;
        private bool disposed = false;
        #endregion Attributes

        #region builder
        public UnitOfWork(GPContext context)
        {
            _context = context;
        }
        #endregion

        #region Properties
        private IRepository<Paciente> pacienteRepository;
        private IRepository<Medicamento> medicamentoRepository;
        private IRepository<EspecialistaModel> especialistaRepository;
        private IRepository<CitaMedica> citaMedicaRepository;
        private IRepository<Estado> estadoRepository;
        private IRepository<Genero> generoRepository;
        private IRepository<HistoriaClinica> historiaClinicaRepository;
        private IRepository<HistoriaMedicamento> historiaMedicamentoRepository;
        private IRepository<Procedimiento> procedimientoRepository;

        #endregion


        #region Members
        public IRepository<Paciente> PacienteRepository
        {
            get
            {
                if (this.pacienteRepository == null)
                    this.pacienteRepository = new Repository<Paciente>(_context);

                return pacienteRepository;
            }
        }

        public IRepository<Medicamento> MedicamentoRepository
        {
            get
            {
                if (this.medicamentoRepository == null)
                    this.medicamentoRepository = new Repository<Medicamento>(_context);

                return medicamentoRepository;
            }
        }

        public IRepository<EspecialistaModel> EspecialistaRepository
        {
            get
            {
                if (this.especialistaRepository == null)
                    this.especialistaRepository = new Repository<EspecialistaModel>(_context);

                return especialistaRepository;
            }
        } 
        
        public IRepository<Estado> EstadoRepository
        {
            get
            {
                if (this.estadoRepository == null)
                    this.estadoRepository = new Repository<Estado>(_context);

                return estadoRepository;
            }
        }  
        
        public IRepository<Genero> GeneroRepository
        {
            get
            {
                if (this.generoRepository == null)
                    this.generoRepository = new Repository<Genero>(_context);

                return generoRepository;
            }
        } 
        
        public IRepository<HistoriaClinica> HistoriaClinicaRepository
        {
            get
            {
                if (this.historiaClinicaRepository == null)
                    this.historiaClinicaRepository = new Repository<HistoriaClinica>(_context);

                return historiaClinicaRepository;
            }
        }
        
        public IRepository<CitaMedica> CitaMedicaRepository
        {
            get
            {
                if (this.citaMedicaRepository == null)
                    this.citaMedicaRepository = new Repository<CitaMedica>(_context);

                return citaMedicaRepository;
            }
        } 
        
        public IRepository<HistoriaMedicamento> HistoriaMedicamentoRepository
        {
            get
            {
                if (this.historiaMedicamentoRepository == null)
                    this.historiaMedicamentoRepository = new Repository<HistoriaMedicamento>(_context);

                return historiaMedicamentoRepository;
            }
        }   
        
        public IRepository<Procedimiento> ProcedimientoRepository
        {
            get
            {
                if (this.procedimientoRepository == null)
                    this.procedimientoRepository = new Repository<Procedimiento>(_context);

                return procedimientoRepository;
            }
        }

        #endregion

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();

    }
}
