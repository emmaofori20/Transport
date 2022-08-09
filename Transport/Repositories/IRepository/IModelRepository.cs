using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface IModelRepository
    {
        //public SelectList GetAllModels();
        public List<ModelViewModel> AllModels();
        public SelectList GetAllModelsByMakeId(int MakeId);
    }
}
