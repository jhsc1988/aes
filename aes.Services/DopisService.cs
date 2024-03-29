﻿using aes.CommonDependecies.ICommonDependencies;
using aes.Models;
using aes.Models.Datatables;
using aes.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aes.Services
{
    public class DopisiService : IDopisiService
    {
        private readonly ICommonDependencies _c;

        public DopisiService(ICommonDependencies c)
        {
            _c = c;
        }

        public async Task<JsonResult> GetList(int predmetId, HttpRequest Request)
        {
            DtParams dTParams = _c.DatatablesGenerator.GetParams(Request);

            IEnumerable<Dopis> DopisList = await _c.UnitOfWork.Dopis.GetDopisiForPredmet(predmetId);

            int totalRows = DopisList.Count();
            if (!string.IsNullOrEmpty(dTParams.SearchValue))
            {
                DopisList = _c.DatatablesSearch.GetDopisiForDatatables(DopisList, dTParams);
            }

            return _c.DatatablesGenerator.SortingPaging(DopisList, dTParams, Request, totalRows, DopisList.Count());
        }

        public async Task<JsonResult> SaveToDB(string predmetId, string urbroj, string datumDopisa)
        {
            Dopis dTemp = new()
            {
                PredmetId = int.Parse(predmetId),
                Urbroj = urbroj,
                Datum = DateTime.Parse(datumDopisa)
            };

            await _c.UnitOfWork.Dopis.Add(dTemp);

            int numOfSaved = await _c.UnitOfWork.Complete();

            return numOfSaved == 0
                ? (new(new { success = false, Message = "Error" }))
                : (new(new { success = true, Message = numOfSaved }));
        }
    }
}
