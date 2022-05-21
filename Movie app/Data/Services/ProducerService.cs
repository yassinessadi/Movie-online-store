﻿using Movie_app.Data.Base;
using Movie_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_app.Data.Services
{
    public class ProducerService:EntityBaseRepository<Producer>,IProducerService
    {
        public ProducerService(AppDbConetext Context) : base(Context) { }
    }
}
