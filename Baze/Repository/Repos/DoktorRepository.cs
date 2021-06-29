using Baze.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze.Repository.Repos
{
    public class DoktorRepository : IDoktorRepository
    {

        private Model1Container db;

        public DoktorRepository() 
        {
            db = new Model1Container();
        }

        public void AddDoktor(Doktor doktor)
        {
            db.Zaposlenis.Add(doktor);
            db.SaveChanges();
        }

        public void DeleteDoktor(Doktor doktor)
        {
            db.SaveChanges();
            db.Zaposlenis.Remove(doktor);
            db.SaveChanges();
        }

        public IEnumerable<Doktor> GetDoktor()
        {
            //return db.Zaposlenis as IEnumerable<Doktor>;
            return db.Doktors;
        }

        public Doktor GetDoktorById(decimal id)
        {
            return db.Zaposlenis.Find(id) as Doktor;
        }

        public void UpdateDoktor(Doktor doktor)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DBConcurrencyException ce)
            {
                Trace.TraceInformation(ce.Message);
            }
        }
    }
}
