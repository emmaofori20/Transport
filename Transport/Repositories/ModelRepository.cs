using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.ViewModels;

namespace Transport.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly TransportDbContext _context;
        public ModelRepository(TransportDbContext context)
        {
            _context = context;
        }


        public List<ModelViewModel> AllModels()
        {
            List<ModelViewModel> allModels = new List<ModelViewModel>();
            allModels = _context.Models.Select(m => new ModelViewModel()
            {
                ModelId = m.ModelId,
                ModelName = m.ModelName,
                MakeId = m.MakeId
            }).ToList();

            return allModels;
        }

        public SelectList GetAllModelsByMakeId(int MakeId)
        {
            List<ModelViewModel> ListOfModelsByMake = new List<ModelViewModel>();
            ListOfModelsByMake = AllModels().Where(m => m.MakeId == MakeId).ToList();
            SelectList listOfMakes = new SelectList(ListOfModelsByMake, "ModelId", "ModelName",0);
            return listOfMakes;

        }
    }
}
