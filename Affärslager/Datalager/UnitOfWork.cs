using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Datalager.IRepository;
using Datalager.Repository;
using Modellager;

namespace Datalager
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BibliotekContext _context;
        public IExpiditRepository Expiditer { get; private set; }
        public IFakturaRepository Fakturor { get; private set; }
        public IBöckerRepository Böckers { get; private set; }
        public IBokningRepository Bokningar { get; private set; }
        public IMedlemRepository Medlemmar { get; private set; }    



        public UnitOfWork(BibliotekContext context)
        {
            _context = context;
            Expiditer = new ExpiditRepository(_context);
            Medlemmar = new MedlemRepository(_context);
            Böckers = new BöckerRepository(_context);
            Fakturor = new FakturaRepository(_context);
            Bokningar = new BokningRepository(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
          

    }
}
