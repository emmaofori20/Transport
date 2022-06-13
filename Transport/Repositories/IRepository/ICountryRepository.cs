﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.Repositories.IRepository
{
    public interface ICountryRepository
    {
        public SelectList GetAllCountries();
    }
}
