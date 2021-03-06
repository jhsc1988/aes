﻿using aes.Data;
using aes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace aes.Controllers
{
    public class RacuniElektraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RacuniElektraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RacuniElektra
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.RacunElektra.Include(r => r.Dopis).Include(r => r.ElektraKupac);
        //    return View(await applicationDbContext.ToListAsync());
        //}     
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        // GET: RacuniElektra/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racunElektra = await _context.RacunElektra
                .Include(r => r.Dopis)
                .Include(r => r.ElektraKupac)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (racunElektra == null)
            {
                return NotFound();
            }

            return View(racunElektra);
        }

        // GET: RacuniElektra/Create
        [Authorize]
        public async Task<IActionResult> CreateAsync()
        {
            //ViewData["DopisId"] = new SelectList(_context.Dopis, "Id", "Urbroj");
            //ViewData["ElektraKupacId"] = new SelectList(_context.ElektraKupac, "Id", "Id");

            List<RacunElektra> re = new List<RacunElektra>();

            var applicationDbContext = await _context.RacunElektra.ToListAsync();

            return View(applicationDbContext);
        }


        [HttpPost]
        public string getPredmeti()
        {
            List<Predmet> p = new List<Predmet>();
            foreach (Predmet element in _context.Predmet.ToList())
                p.Add(element);

            return JsonConvert.SerializeObject(p);
        }

        public string getDopisi()
        {
            List<Dopis> d = new List<Dopis>();
            foreach (Dopis element in _context.Dopis.ToList())
                d.Add(element);

            return JsonConvert.SerializeObject(d);
        }

        public string getKupci()
        {
            List<ElektraKupac> ek = new List<ElektraKupac>();
            foreach (ElektraKupac element in _context.ElektraKupac.ToList())
                ek.Add(element);

            foreach (ElektraKupac element in ek)
            {
                element.Ods = _context.Ods.FirstOrDefault(o => o.Id == element.OdsId);
            }

            foreach (ElektraKupac element in ek)
                element.Ods.Stan = _context.Stan.FirstOrDefault(o => o.Id == element.Ods.StanId);

            return JsonConvert.SerializeObject(ek);
        }


        // POST: RacuniElektra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(
            [Bind(
                "Id,BrojRacuna,ElektraKupacId,DatumIzdavanja,Iznos,DopisId,RedniBroj,KlasaPlacanja,DatumPotvrde,VrijemeUnosa")]
            RacunElektra racunElektra)
        {
            // ModelState debbuger:
            // var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                racunElektra.VrijemeUnosa = DateTime.Now;
                _context.Add(racunElektra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //ViewData["DopisId"] = new SelectList(_context.Dopis, "Id", "Urbroj", racunElektra.DopisId);
            //ViewData["ElektraKupacId"] = new SelectList(_context.ElektraKupac, "Id", "Id", racunElektra.ElektraKupacId);

            //return View(racunElektra);
            return View();
        }

        //public JsonResult GetPredmeti(int? predmetId, int? dopisId)
        //{
        //    ViewBag.Predmeti = new List<SelectListItem>();
        //    foreach (Predmet elementi in _context.Predmet.ToList())
        //        ViewBag.Predmeti.Add(new SelectListItem { Text = elementi.Klasa, Value = elementi.Id.ToString() });

        //}

        // GET: RacuniElektra/Edit/5

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racunElektra = await _context.RacunElektra.FindAsync(id);
            if (racunElektra == null)
            {
                return NotFound();
            }

            ViewData["DopisId"] = new SelectList(_context.Dopis, "Id", "Urbroj", racunElektra.DopisId);
            ViewData["ElektraKupacId"] = new SelectList(_context.ElektraKupac, "Id", "Id", racunElektra.ElektraKupacId);

            return View(racunElektra);
        }

        // POST: RacuniElektra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id,
            [Bind(
                "Id,BrojRacuna,ElektraKupacId,DatumIzdavanja,Iznos,DopisId,RedniBroj,KlasaPlacanja,DatumPotvrde,VrijemeUnosa")]
            RacunElektra racunElektra)
        {
            if (id != racunElektra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(racunElektra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RacunElektraExists(racunElektra.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["DopisId"] = new SelectList(_context.Dopis, "Id", "Urbroj", racunElektra.DopisId);
            ViewData["ElektraKupacId"] = new SelectList(_context.ElektraKupac, "Id", "Id", racunElektra.ElektraKupacId);

            return View(racunElektra);
        }

        // GET: RacuniElektra/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racunElektra = await _context.RacunElektra
                .Include(r => r.Dopis)
                .Include(r => r.ElektraKupac)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (racunElektra == null)
            {
                return NotFound();
            }

            return View(racunElektra);
        }

        // POST: RacuniElektra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var racunElektra = await _context.RacunElektra.FindAsync(id);
            _context.RacunElektra.Remove(racunElektra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RacunElektraExists(int id)
        {
            return _context.RacunElektra.Any(e => e.Id == id);
        }

        // validation
        [HttpGet]
        public async Task<IActionResult> BrojRacunaValidation(string brojRacuna)
        {
            if (brojRacuna.Length < 19 || brojRacuna.Length > 19)
            {
                return Json($"Broj računa nije ispravan");
            }

            var db = await _context.RacunElektra.FirstOrDefaultAsync(x => x.BrojRacuna.Equals(brojRacuna));
            if (db != null)
            {
                return Json($"Račun {brojRacuna} već postoji.");
            }

            return Json(true);
        }

        /// <summary>
        /// Server side processing - učitavanje, filtriranje, paging, sortiranje podataka iz baze
        /// </summary>
        /// <returns>Vraća listu racuna Elektre u JSON obliku za server side processing</returns>
        [HttpPost]
        public async Task<IActionResult> GetList(string klasa, string urbroj)
        {
            var predmetIdAsInt = klasa is null ? 0 : int.Parse(klasa);
            var dopisIdAsInt = urbroj is null ? 0 : int.Parse(urbroj);

            // server side parameters
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var sortColumnName = Request
                .Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            // async/await - imam overhead, ali proširujem scalability
            List<RacunElektra> racunElektraList = new List<RacunElektra>();

            if (predmetIdAsInt == 0 && dopisIdAsInt == 0)
            {
                racunElektraList = await _context.RacunElektra.ToListAsync<RacunElektra>();
            }

            if (predmetIdAsInt != 0 && dopisIdAsInt == 0)
            {
                racunElektraList = await _context.RacunElektra.Where(x => x.Dopis.Predmet.Id == predmetIdAsInt)
                    .ToListAsync();
            }

            if (predmetIdAsInt != 0 && dopisIdAsInt != 0)
            {
                racunElektraList = await _context.RacunElektra.Where(
                    x => x.Dopis.Predmet.Id == predmetIdAsInt
                         && x.Dopis.Id == dopisIdAsInt).ToListAsync();
            }

            // popunjava podatke za JSON da mogu vezane podatke pregledavati u datatables
            foreach (RacunElektra racunElektra in racunElektraList)
            {
                racunElektra.ElektraKupac =
                    await _context.ElektraKupac.FirstOrDefaultAsync(o => o.Id == racunElektra.ElektraKupacId);
            }

            foreach (RacunElektra racunElektra in racunElektraList)
            {
                racunElektra.Dopis =
                    await _context.Dopis.FirstOrDefaultAsync(o => o.Id == racunElektra.DopisId);
            }

            foreach (RacunElektra re in racunElektraList)
            {
                re.Dopis.Predmet =
                    await _context.Predmet.FirstOrDefaultAsync(o => o.Id == re.Dopis.PredmetId);
            }

            // filter
            int totalRows = racunElektraList.Count;
            if (!string.IsNullOrEmpty(searchValue))
            {
                racunElektraList = await racunElektraList.Where(
                        x => x.BrojRacuna.Contains(searchValue)
                             || x.ElektraKupac.UgovorniRacun.ToString().Contains(searchValue)
                             || x.DatumIzdavanja.ToString("dd.MM.yyyy").Contains(searchValue)
                             || x.Iznos.ToString().Contains(searchValue)
                             || (x.KlasaPlacanja != null && x.KlasaPlacanja.Contains(searchValue))
                             || (x.DatumPotvrde != null &&
                                 x.DatumPotvrde.Value.ToString("dd.MM.yyyy").Contains(searchValue))
                             || (x.Napomena != null && x.Napomena.ToLower().Contains(searchValue.ToLower())))
                    .ToDynamicListAsync<RacunElektra>();
                // x.DatumPotvrde.Value mi treba jer metoda nullable objekta ne prima argument za funkciju ToString
                // sortiranje radi normalno za datume, neovisno o formatu ToString
            }

            int totalRowsAfterFiltering = racunElektraList.Count;

            // trebam System.Linq.Dynamic.Core;
            // sorting
            racunElektraList = racunElektraList.AsQueryable().OrderBy(sortColumnName + " " + sortDirection).ToList();

            // paging
            racunElektraList = racunElektraList.Skip(Convert.ToInt32(start)).Take(Convert.ToInt32(length))
                .ToList<RacunElektra>();

            return Json(new
            {
                data = racunElektraList, draw = Convert.ToInt32(Request.Form["draw"].FirstOrDefault()),
                recordsTotal = totalRows, recordsFiltered = totalRowsAfterFiltering
            });
        }

        [HttpPost]
        public JsonResult SaveToDB([FromBody] List<RacunElektra> racuniList)
        {
            RacunElektra racuni = new RacunElektra();

            {
                int dopisId = 0;
                if (racuniList == null)
                {
                    return Json(new {IsCreated = false, Message = "nije poslan nijedan račun"});
                }
                else
                {
                    dopisId = racuniList[0].DopisId;
                }

                try
                {
                    foreach (RacunElektra r in racuniList)
                    {
                        _context.RacunElektra.Add(r);
                    }

                    _context.SaveChanges();

                    return Json(new {IsCreated = true, Message = "uspjesno"});
                }
                catch (Exception)
                {
                    // brisi sve racune pod tim dopisom ako error
                    var ListOfDataToDelete = _context.RacunElektra.Where(x => x.DopisId == dopisId);
                    _context.RacunElektra.RemoveRange(ListOfDataToDelete);

                    _context.SaveChanges();
                    return Json(new {IsCreated = false, Message = "greska"});
                }

                //int insertedRecords = re.SaveChanges();
                //return Json("uspjes no spremljeno");
            }
        }

        // csv read
        //public void getCSV()
        //{
        //    var reader = new StreamReader(@"C:\Users\jhsc1\Radna površina\testing.csv");

        //    {

        //        List<string> listA = new List<string>();
        //        List<string> listB = new List<string>();
        //        while (!reader.EndOfStream)
        //        {
        //            var line = reader.ReadLine();
        //            var values = line.Split(';');

        //            listA.Add(values[0]);
        //            //listB.Add(values[1]);
        //        }
        //    }
        //}

        // TODO: delete for production  !!!!
        // Area51
        [HttpGet]
        public async Task<IActionResult> GetListJSON()
        {
            List<RacunElektra> RacunElektraList = new List<RacunElektra>();
            RacunElektraList = await _context.RacunElektra.ToListAsync<RacunElektra>();

            var applicationDbContext = _context.RacunElektra.Include(r => r.Dopis).Include(r => r.ElektraKupac)
                .Include(r => r.ElektraKupac.Ods).Include(r => r.ElektraKupac.Ods.Stan);

            foreach (RacunElektra racunElektra in RacunElektraList)
            {
                racunElektra.ElektraKupac =
                    await _context.ElektraKupac.FirstOrDefaultAsync(o => o.Id == racunElektra.ElektraKupacId);
            }

            return Json(applicationDbContext.ToList());
        }

        private List<Predmet> _predmetiForDopisiForFIlter;

        public JsonResult GetPredmetiDataForFilter()
        {
            var racunElektraList = _context.RacunElektra.ToList();
            foreach (var element in racunElektraList)
                element.Dopis = _context.Dopis.FirstOrDefault(x => element.DopisId == x.Id);

            foreach (var element in racunElektraList)
                element.Dopis.Predmet = _context.Predmet.FirstOrDefault(x => element.Dopis.PredmetId == x.Id);

            var predmetList = racunElektraList.Select(element => element.Dopis.Predmet).Distinct().ToList();
            _predmetiForDopisiForFIlter = predmetList;
            return Json(predmetList);
        }


        public JsonResult GetDopisiDataForFilter(int predmetId)
        {
            var dopisList = _context.Dopis.ToList();
            var dopisForFilterList = dopisList.Where(element => element.PredmetId == predmetId).ToList();
            return Json(dopisForFilterList);
        }

        public JsonResult UpdateDbForInline(string id, string klasa, DateTime? datum, string napomena)
        {
            var idInt = int.Parse(id);
            var racunToUpdate = _context.RacunElektra.First(x => x.Id == idInt);

            racunToUpdate.KlasaPlacanja = klasa;
            racunToUpdate.DatumPotvrde = datum;
            racunToUpdate.Napomena = napomena;
            
            if (racunToUpdate.KlasaPlacanja == null && racunToUpdate.DatumPotvrde != null )
            {
                return Json(new {success = false, Message = "Klasa ne može biti prazna!"});
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return Json(new {success = false, Message = "Greška"});
            }
            return Json(new {success = true, Message = "Uspješno upisano"});
        }
    }
}