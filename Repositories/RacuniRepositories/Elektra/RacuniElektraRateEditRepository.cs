﻿using aes.Data;
using aes.Models.Racuni.Elektra;
using aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace aes.Repositories.RacuniRepositories.Elektra
{
    public class RacuniElektraRateEditRepository : Repository<RacunElektraRateEdit>, IRacuniElektraRateEditRepository
    {
        public RacuniElektraRateEditRepository(ApplicationDbContext context) : base(context) { }

#nullable enable
        public async Task<RacunElektraRateEdit?> GetLastRacunElektraRateEdit(string userId)
#nullable disable
        {
            return await Context.RacunElektraRateEdit
                .Include(e => e.RacunElektraRate)
                .Where(e => e.EditingByUserId == userId)
                .OrderByDescending(e => e.EditTime)
                .FirstOrDefaultAsync();
        }
    }
}