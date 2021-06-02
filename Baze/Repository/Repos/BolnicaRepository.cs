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
    public class BolnicaRepository : IBolnicaRepository
    {
        private Model1Container db;
        public BolnicaRepository() 
        {
            db = new Model1Container();
        }

        public void AddBolnica(Bolnica bolnica)
        {
            
            db.Bolnicas.Add(bolnica);
            db.SaveChanges();
        }

        public void DeleteBolnica(Bolnica bolnica)
        {
            db.SaveChanges();
            db.Bolnicas.Remove(bolnica);
            db.SaveChanges();
            
        }

        public Bolnica GetBolnicaById(int id)
        {
            return db.Bolnicas.Find(id) as Bolnica;
        }

        public IEnumerable<Bolnica> GetBolnice()
        {
            return db.Bolnicas;
        }

        public void UpdateBolnica(Bolnica bolnica)
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
