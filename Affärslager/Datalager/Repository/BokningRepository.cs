﻿using Datalager.IRepository;
using Modellager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalager.Repository
{
    public class BokningRepository : Repository<Bokning>, IBokningRepository
    {
        public BokningRepository(BibliotekContext context) : base(context)
        {

        }
    }
}
