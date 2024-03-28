using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;


namespace Sales.Infraestructure.Dao
{
    public class NegocioDb : DaoBase<Negocio>, INegocioDb
    {

        private readonly SalesContext context;

        private readonly ILogger<NegocioDb> logger;
        private readonly IConfiguration configuration;

        public NegocioDb(SalesContext context, ILogger<NegocioDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public List<Negocio> GetNegocioByUserId(int userId)
        {
            return this.context.Negocio.Where(ng => ng.IdUsuarioCreacion == userId).ToList();
        }

        public override DataResult Save(Negocio entity)
        {
            DataResult result = new();

            try
            {
                if (base.Exists(neg => neg.Nombre == entity.Nombre))
                {
                    throw new NegocioException(this.configuration["NegocioMessage:NameDuplicate"]);
                }

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["NegocioMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override DataResult Update(Negocio entity)
        {
            DataResult result = new();
            try
            {
                Negocio negocioToUpdate = base.GetById(entity.Id);

                negocioToUpdate.Nombre = entity.Nombre;
                negocioToUpdate.Correo = entity.Correo;
                negocioToUpdate.Telefono = entity.Telefono;
                negocioToUpdate.NumeroDocumento = entity.NumeroDocumento;
                negocioToUpdate.Direccion = entity.Direccion;
                negocioToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                negocioToUpdate.FechaMod = entity.FechaMod;

                base.Update(negocioToUpdate);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["NegocioMessage:ErrorUpdate"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
