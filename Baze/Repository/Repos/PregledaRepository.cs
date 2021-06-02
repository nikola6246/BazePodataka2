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
    public class PregledaRepository : IPregleda
    {
        private Model1Container db;
        public PregledaRepository()
        {
            db = new Model1Container();
        }

        public void AddPregleda(Pregleda pregleda)
        {
            db.Pregledas.Add(pregleda);
            db.SaveChanges();
        }

        public void DeletePregleda(Pregleda pregleda)
        {
            db.SaveChanges();
            db.Pregledas.Remove(pregleda);
            db.SaveChanges();
        }

        public Pregleda GetPregledaById(int id)
        {
            return db.Pregledas.Find(id);
        }

        public IEnumerable<Pregleda> GetPregledani()
        {
            return db.Pregledas;
        }

        public void UpdatePregleda(Pregleda pregleda)
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
