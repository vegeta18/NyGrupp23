using Datalager.IRepository;
using Modellager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalager.Repository
{
    public class MedlemRepository : Repository<Medlem>, IMedlemRepository
    {
        public MedlemRepository(BibliotekContext context) : base(context)
        {

        }
    }
}
