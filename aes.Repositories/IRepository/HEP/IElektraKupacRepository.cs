﻿using aes.Models.HEP;
using aes.Repositories.IRepository;

namespace aes.Repository.IRepository.HEP
{
    public interface IElektraKupacRepository : IRepository<ElektraKupac>
    {
        Task<ElektraKupac> FindExact(long ugovorniRacun);
        Task<ElektraKupac> FindExactById(int id);
        Task<IEnumerable<ElektraKupac>> GetAllCustomers();
        Task<ElektraKupac> IncludeOdsAndStan(ElektraKupac elektraKupac);
    }
}