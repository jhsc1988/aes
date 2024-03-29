﻿using aes.Data;
using aes.Models.HEP;
using aes.Repository.IRepository.HEP;
using Microsoft.EntityFrameworkCore;

namespace aes.Repositories.HEP.Elektra
{
    public class ElektraKupacRepository : Repository<ElektraKupac>, IElektraKupacRepository
    {
        public ElektraKupacRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<ElektraKupac>> GetAllCustomers()
        {
            return await Context.ElektraKupac
                .Include(e => e.Ods)
                .Include(e => e.Ods.Stan)
                .Where(e => e.Id != 2002)
                .ToListAsync();
        }

        public async Task<ElektraKupac> IncludeOdsAndStan(ElektraKupac elektraKupac)
        {
            elektraKupac.Ods = await Context.Ods.FirstOrDefaultAsync(e => e.Id == elektraKupac.OdsId);
            elektraKupac.Ods.Stan = await Context.Stan.FirstOrDefaultAsync(e => e.Id == elektraKupac.Ods.StanId);
            return elektraKupac;
        }

        public async Task<ElektraKupac> FindExact(long ugovorniRacun)
        {
            return await Context.ElektraKupac
                .Where(e => e.UgovorniRacun == ugovorniRacun)
                .FirstOrDefaultAsync();
        }

        public async Task<ElektraKupac> FindExactById(int id)
        {
            return await Context.ElektraKupac
                .Include(e => e.Ods)
                .Include(e => e.Ods.Stan)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

    }
}
