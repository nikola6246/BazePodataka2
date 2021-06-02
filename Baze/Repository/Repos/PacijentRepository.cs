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
    public class PacijentRepository : IPacijent
    {
        private Model1Container db;
        public PacijentRepository()
        {
            db = new Model1Container();
        }
        public void AddPacijent(Pacijent pacijent)
        {
            db.Pacijents.Add(pacijent);
            db.SaveChanges();
        }

        public void DeletePacijent(Pacijent pacijent)
        {
            db.SaveChanges();
            db.Pacijents.Remove(pacijent);
            db.SaveChanges();
        }

        public Pacijent GetPacijentById(int id)
        {
            return db.Pacijents.Find(id);
        }

        public IEnumerable<Pacijent> GetPacijenti()
        {
            return db.Pacijents;
        }

        public void UpdatePacijent(Pacijent pacijent)
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
