﻿using System;

namespace aes.Models.Racuni.Elektra
{
    // TODO: remove edit model
    public class RacunElektraRateEdit
    {
        public int Id { get; set; }
        public RacunElektraRate RacunElektraRate { get; set; }
        public int RacunElektraRateId { get; set; }
        public string EditingByUserId { get; set; }
        public DateTime EditTime { get; set; }
    }
}
