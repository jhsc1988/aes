﻿using aes.Models.HEP;
using aes.Repositories.IRepository;

namespace aes.Repository.IRepository.HEP
{
    public interface IObracunPotrosnjeRepository : IRepository<ObracunPotrosnje>
    {
        Task<ObracunPotrosnje> GetLastForRacunId(int racunId);
        Task<IEnumerable<ObracunPotrosnje>> GetObracunForUgovorniRacun(long ugovorniRacun);
        Task<IEnumerable<ObracunPotrosnje>> GetObracunPotrosnjeForRacun(int racunId);
    }
}