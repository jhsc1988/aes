﻿using aes.Data;
using aes.Models;
using aes.Models.Racuni.Elektra;
using aes.Repositories.HEP.Elektra;
using aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aes.Repositories.RacuniRepositories.Elektra
{
    public class RacuniElektraIzvrsenjeUslugeRepository : ElektraRepository<RacunElektraIzvrsenjeUsluge>,
        IRacuniElektraIzvrsenjeUslugeRepository
    {
        public RacuniElektraIzvrsenjeUslugeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RacunElektraIzvrsenjeUsluge>> GetRacuniElektraIzvrsenjeUslugeWithDopisiAndPredmeti()
        {
            return await Context.RacunElektraIzvrsenjeUsluge
                .Include(e => e.Dopis)
                .Include(e => e.Dopis.Predmet)
                .Where(e => e.IsItTemp == null || e.IsItTemp == false)
                .ToListAsync();
        }

        public async Task<IEnumerable<Dopis>> GetDopisiForPayedRacuniElektraIzvrsenjeUsluge(int predmetId)
        {
            // returns only Dopisi for payed Racuni
            return (await GetRacuniElektraIzvrsenjeUslugeWithDopisiAndPredmeti())
                .Where(e => e.Dopis.PredmetId == predmetId)
                .Select(e => e.Dopis)
                .OrderByDescending(e => e.Datum)
                .Distinct();
        }

#nullable enable
        public async Task<RacunElektraIzvrsenjeUsluge?> IncludeAll(int id)
        {
            return await Context.RacunElektraIzvrsenjeUsluge
                .Include(r => r.ElektraKupac)
                .Include(r => r.ElektraKupac.Ods)
                .Include(r => r.ElektraKupac.Ods.Stan)
                .Include(r => r.Dopis)
                .Include(r => r.Dopis.Predmet)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
#nullable disable

        public async Task<IEnumerable<RacunElektraIzvrsenjeUsluge>> TempList(string userId)
        {
            return await Context.RacunElektraIzvrsenjeUsluge
                .Where(e => e.CreatedByUserId.Equals(userId) && e.IsItTemp == true)
                .Include(r => r.ElektraKupac)
                .Include(r => r.ElektraKupac.Ods)
                .Include(r => r.ElektraKupac.Ods.Stan)
                .Include(r => r.Dopis)
                .Include(r => r.Dopis.Predmet)
                .ToListAsync();
        }

        public async Task<IEnumerable<RacunElektraIzvrsenjeUsluge>> GetRacuniForCustomer(int kupacId)
        {
            return await Context.RacunElektraIzvrsenjeUsluge
                .Include(e => e.ElektraKupac)
                .Where(e => e.ElektraKupacId == kupacId && (e.IsItTemp == null || false))
                .ToListAsync();
        }
    }
}