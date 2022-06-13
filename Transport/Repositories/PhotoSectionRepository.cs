using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class PhotoSectionRepository : IPhotoSectionRepository
    {
        private TransportDbContext _context;

        public PhotoSectionRepository(TransportDbContext context)
        {
            _context = context;
        }

        public List<PhotoSection> GetPhotoSections()
        {
            return _context.PhotoSections.ToList();
        }
    }
}
