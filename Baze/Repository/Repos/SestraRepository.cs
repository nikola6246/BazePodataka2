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
    public class SestraRepository : ISestraRepository
    {
        private Model1Container db;
        public SestraRepository()
        {
            db = new Model1Container();
        }


        public void AddSestra(Sestra sestra)
        {
            db.Sestras.Add(sestra);
            db.SaveChanges();
        }

        public void DeleteSestra(Sestra sestra)
        {
            db.SaveChanges();
            db.Sestras.Remove(sestra);
            db.SaveChanges();
        }

        public Sestra GetSestraById(int id)
        {
            return db.Zaposlenis.Find(id) as Sestra;
        }

        public IEnumerable<Sestra> GetSestre()
        {
            return db.Sestras;
        }

        public void UpdateSestra(Sestra sestra)
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
