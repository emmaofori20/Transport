﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.ViewModels;

namespace Transport.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly TransportDbTestContext _context;

        public InsuranceRepository(TransportDbTestContext context)
        {
            _context = context;
        }

        public SelectList GetAllInsurance()
        {
            return new SelectList(_context.Insurances
               .Select(s => new { Id = s.InsuranceId, Text = $"{s.InsurancePolicyName}" }), "Id", "Text");
        }
    }
}
