using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private bool isDisposed = false;
        private readonly bool disposedContext = false; 
        protected BibliotekContext _context { get; }
        public IExpiditRepository Expiditer { get; private set; }//Ändra dessa
        public IFakturaRepository Fakturor { get; private set; }
        public IBöckerRepository Böckers { get; private set; }
        public IBokningRepository Bokningar { get; private set; }
        public IMedlemRepository Medlemmar { get; private set; }    

        public UnitOfWork() : this(new BibliotekContext()) 
        { 
            disposedContext= true;
        }

        public UnitOfWork(BibliotekContext context)
        {
            _context = context;
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex) 
            { 
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (RetryLimitExceededException ex) 
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (DbUpdateException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch(Exception ex) 
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (isDisposed) 
            {
                return;
            }
            if (disposing) 
            { 
                if(disposedContext) 
                {
                    _context.Dispose();
                }
            }
            isDisposed= true;
        }

        ~UnitOfWork() 
        { 
            Dispose(false); 
        }   

    }
}
