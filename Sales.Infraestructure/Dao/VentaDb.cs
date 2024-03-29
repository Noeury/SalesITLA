﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class VentaDb : DaoBase<Venta>, IVentaDb
    {
        private readonly SalesContext context;
        private readonly ILogger<VentaDb> logger;
        private readonly IConfiguration configuration;


        public VentaDb(SalesContext context, ILogger<VentaDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override DataResult Save(Venta entity)
        {
            return base.Save(entity);
        }
    }
}
