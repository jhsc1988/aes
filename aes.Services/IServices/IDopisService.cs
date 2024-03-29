﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aes.Services.IServices
{
    public interface IDopisiService
    {
        Task<JsonResult> GetList(int predmetId, HttpRequest Request);
        Task<JsonResult> SaveToDB(string predmetId, string urbroj, string datumDopisa);
    }
}