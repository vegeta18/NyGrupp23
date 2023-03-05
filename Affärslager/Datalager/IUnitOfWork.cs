using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Datalager.IRepository;
using Modellager;

namespace Datalager
{
    public interface IUnitOfWork : IDisposable
    {
        IBokningRepository Bokningar { get; }
        IBöckerRepository Böckers { get; }
        IMedlemRepository Medlemmar { get; }
        IFakturaRepository Fakturor { get; }
        IExpiditRepository Expiditer { get; }

        int Save();
    }
}
