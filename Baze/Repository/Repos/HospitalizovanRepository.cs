using Baze.CrudOperations;
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
    public class HospitalizovanRepository : IHospitalizovan
    {

        private Model1Container db;
        public HospitalizovanRepository()
        {
            db = new Model1Container();
        }

        public void AddHospitalizovan(Hospitalizovani hospitalizovan)
        {
            Random r = new Random();
            hospitalizovan.Id += r.Next() % 40;

            db.Hospitalizovanis.Add(hospitalizovan);
            db.SaveChanges();
        }

        public void DeleteHospitalizovan(Hospitalizovani hospitalizovan)
        {
            db.SaveChanges();
            db.Hospitalizovanis.Remove(hospitalizovan);
            db.SaveChanges();
        }

        public Hospitalizovani GetHospitalizovanById(int id)
        {
            return db.Hospitalizovanis.Find(id) as Hospitalizovani;
        }

        public IEnumerable<Baze.Hospitalizovani> GetHospitalizovani()
        {
            return db.Hospitalizovanis;
        }

        public void UpdateHospitalizovan(Hospitalizovani hospitalizovan)
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
