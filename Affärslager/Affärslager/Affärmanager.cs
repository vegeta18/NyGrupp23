using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modellager;
using Datalager;
using System.Runtime.CompilerServices;

namespace Affärslager
{
    public class Affärmanager
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new BibliotekContext());


        #region Expidit

        public List<Expidit> GetExpiditer() //hämtar alla expiditer i lista, för att man senare ska kunna välja en av de
        {
            return unitOfWork.Expiditer.GetAll().ToList();
        }

        public Expidit GetExpidit(int AnställningsNr) //Hämtar specifik expidit
        {
            return unitOfWork.Expiditer.Get(AnställningsNr);
        }


        #endregion

        #region Medlem
        public Medlem GetMedlem(int MedlemsID) //Hämtar specifik medlem
        {
            return unitOfWork.Medlemmar.Get(MedlemsID);
        }

        public List<Medlem> GetMedlemmar()
        {
            return unitOfWork.Medlemmar.GetAll().ToList();
        }

        #endregion

        #region Bok
        public List<Böcker> GetBöcker()
        {
            return unitOfWork.Böckers.GetAll().ToList();
        }

        public Böcker GetBok(string ISBNnummer)
        {
            return unitOfWork.Böckers.Get(ISBNnummer);
        }

        public void RemoveBok(string ISBNnummer)
        {
            var removeBok = unitOfWork.Böckers.Get(ISBNnummer);
            unitOfWork.Böckers.Remove(removeBok); //Dubbelkolla varför den snear
            unitOfWork.Save();
        }

        //Add funktion


        #endregion
    }
}
