﻿using aes.CommonDependecies.ICommonDependencies;
using aes.Models;
using aes.Models.Racuni.Holding;
using aes.Services.RacuniServices.RacuniHoldingService.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aes.Services.RacuniServices.RacuniHoldingService
{
    public class RacuniHoldingTempCreateService : IRacuniHoldingTempCreateService
    {
        private readonly IRacuniCommonDependecies _c;

        public RacuniHoldingTempCreateService(IRacuniCommonDependecies c)
        {
            _c = c;
        }

        public async Task<JsonResult> AddNewTemp(string brojRacuna, string iznos, string datumIzdavanja, string userId)
        {
            if (iznos == null)
            {
                return new JsonResult(new { success = false, Message = "Iznos ne smije biti prazan!" });
            }

            IEnumerable<RacunHolding> tempList = await _c.UnitOfWork.RacuniHolding.TempList(userId);
            if (tempList.Count() >= 500)
            {
                return new JsonResult(new { success = false, Message = "U tablici ne može biti više od 500 računa!" });
            }

            decimal _iznos = decimal.Parse(iznos);
            DateTime? _datumIzdavanja = datumIzdavanja != null ? DateTime.Parse(datumIzdavanja) : null;

            RacunHolding re = new()
            {
                BrojRacuna = brojRacuna,
                Iznos = _iznos,
                DatumIzdavanja = _datumIzdavanja,
                CreatedByUserId = userId,
                IsItTemp = true,
                Stan = await FindStanAsync(brojRacuna)
            };

            await _c.UnitOfWork.RacuniHolding.Add(re);
            return await _c.Service.TrySave(false);
        }

        private async Task<Stan> FindStanAsync(string brojRacuna)
        {
            Stan stan = null;
            if (brojRacuna.Length >= 8)
            {
                int sifraObjekta = int.Parse(brojRacuna[..8]);
                stan = await _c.UnitOfWork.Stan.FindExact(e => e.SifraObjekta == sifraObjekta);
            }
            return stan ?? await _c.UnitOfWork.Stan.FindExact(e => e.Id == 25265);
        }

        public async Task<int> CheckTempTableForRacuniWithouCustomer(string userId)
        {
            IEnumerable<RacunHolding> list = await _c.UnitOfWork.RacuniHolding.TempList(userId);
            return list.Count(e => e.StanId == 25265);
        }

        public async Task<JsonResult> RefreshCustomers(string userId)
        {
            IEnumerable<RacunHolding> tempRacuni = await _c.UnitOfWork.RacuniHolding.TempList(userId);

            if (tempRacuni.Count() is 0)
            {
                return new(new
                {
                    success = false,
                    Message = "U tablici nema podataka"
                });
            }

            foreach (RacunHolding e in tempRacuni)
            {
                if (e.StanId == 25265 && e.BrojRacuna.Length >= 8)
                {
                    e.Stan = await _c.UnitOfWork.RacuniHolding.GetStanBySifraObjekta(int.Parse(e.BrojRacuna[..8]));
                    e.Stan ??= await _c.UnitOfWork.Stan.FindExact(e => e.Id == 25265);
                }
            }

            await RacuniElektraNotesBuild(userId, tempRacuni);
            return new(new { success = true, Message = "Podaci su osvježeni" });
        }

        private async Task RacuniElektraNotesBuild(string userId, IEnumerable<RacunHolding> list)
        {
            foreach (RacunHolding e in list)
            {
                if (e.StanId == 25265)
                {
                    e.Napomena = "kupac ne postoji";
                }
                else
                {
                    IEnumerable<RacunHolding> Racuni = await _c.UnitOfWork.RacuniHolding.GetRacuniForStan(e.StanId);
                    e.Napomena = _c.RacuniCheckService.CheckIfExistsInPayed(e.BrojRacuna, Racuni);
                }

                if (e.Napomena is null)
                {
                    IEnumerable<RacunHolding> tempRacuni = await _c.UnitOfWork.RacuniHolding.Find(item => item.IsItTemp == true && item.CreatedByUserId == userId && item.StanId == e.StanId);
                    e.Napomena = _c.RacuniCheckService.CheckIfExistsInTemp(e.BrojRacuna, tempRacuni);
                }

                _ = await _c.UnitOfWork.RacuniHolding.Update(e);
            }
        }
    }
}