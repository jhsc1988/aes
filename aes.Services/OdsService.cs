using aes.CommonDependecies.ICommonDependencies;
using aes.Models;
using aes.Models.HEP;
using aes.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace aes.Services
{
    public class OdsService : IOdsService
    {
        private readonly ICommonDependencies _c;

        public OdsService(ICommonDependencies c)
        {
            _c = c;
        }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public async Task<JsonResult> GetStanData(string? sid)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            int idInt;
            if (sid is not null)
            {
                idInt = int.Parse(sid);
            }
            else
            {
                return new JsonResult(
                    new
                    {
                        success = false,
                        Message = "Greška, prazan id"
                    });
            }

            Stan stan = await _c.UnitOfWork.Stan.Get(idInt);
            return new JsonResult(stan);
        }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public async Task<JsonResult> GetStanDataForOmm(string? odsId)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            int odsIdInt;
            if (odsId is not null)
            {
                odsIdInt = int.Parse(odsId);
            }
            else
            {
                return new JsonResult(
                    new
                    {
                        success = false,
                        Message = "Greška, prazan id"
                    });
            }

            Ods ods = await _c.UnitOfWork.Ods.IncludeApartment(await _c.UnitOfWork.Ods.Get(odsIdInt));
            return new JsonResult(ods);
        }
    }
}