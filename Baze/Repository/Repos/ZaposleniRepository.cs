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
    public class ZaposleniRepository : IZaposleniRepository
    {
        private Model1Container db;

        public ZaposleniRepository()
        {
            db = new Model1Container();
        }

        public void AddZaposlen(Zaposleni zaposleni)
        {
            db.Zaposlenis.Add(zaposleni);
            db.SaveChanges();
        }

        public void DeleteZaposlen(Zaposleni zaposleni)
        {
            db.SaveChanges();
            db.Zaposlenis.Remove(zaposleni);
            db.SaveChanges();
        }

        public Zaposleni GetZaposlenById(decimal id)
        {
            return db.Zaposlenis.Find(id) as Zaposleni;
        }

        public IEnumerable<Zaposleni> GetZaposleni()
        {
            return db.Zaposlenis;
        }

        public void UpdateZaposlen(Zaposleni zaposleni)
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
