using Datalager.IRepository;
using Modellager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalager.Repository
{
    public class BöckerRepository : Repository<Böcker>, IBöckerRepository
    {
        public BöckerRepository(BibliotekContext context) : base(context)
        {

        }

        public BibliotekContext appDbContext
        {
            get { return Context as BibliotekContext; }
        }
    }
}
