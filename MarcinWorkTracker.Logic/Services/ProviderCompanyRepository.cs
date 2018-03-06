using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarcinWorkTracker.Logic.Models;
using MarcinWorkTracker.Logic.Data;

namespace MarcinWorkTracker.Logic.Services
{
    public class ProviderCompanyRepository : IProviderCompanyRepository
    {
        private readonly MWTrackerDbContext _context;

        public ProviderCompanyRepository(MWTrackerDbContext context)
        {
            _context = context;
        }

        public IQueryable<ProviderCompany> GetAll()
        {
            return _context.ProviderCompany;
        }

        public ProviderCompany GetOne(int providerCompanyId)
        {
            return _context.ProviderCompany.FirstOrDefault(e => e.ProviderCompanyId == providerCompanyId);
        }

        public ProviderCompany Add(ProviderCompany providerCompany)
        {
            _context.ProviderCompany.Add(providerCompany);
            _context.SaveChanges();
            return providerCompany;
        }
        public ProviderCompany Update(ProviderCompany providerCompany)
        {
            _context.ProviderCompany.Update(providerCompany);
            _context.SaveChanges();
            return providerCompany;
        }
    }
}
