using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarcinWorkTracker.Logic.Models;

namespace MarcinWorkTracker.Logic.Services
{
    public interface IProviderCompanyRepository
    {
        ProviderCompany GetOne(int providerCompanyId);
        IQueryable<ProviderCompany> GetAll();
        ProviderCompany Add(ProviderCompany providerCompany);
        ProviderCompany Update(ProviderCompany providerCompany);
    }
}
