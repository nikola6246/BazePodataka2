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
    public class DirektorRepository : IDirektorRepository
    {

        private Model1Container db;
        public DirektorRepository()
        {
            db = new Model1Container();
        }
        public void AddDirektor(Direktor direktor)
        {
            db.Direktors.Add(direktor);
            db.SaveChanges();
        }

        public void DeleteDirektor(Direktor direktor)
        {
            db.SaveChanges();
            db.Direktors.Remove(direktor);
            db.SaveChanges();
        }

        public Direktor GetDirektorById(int id)
        {
            return db.Direktors.Find(id) as Direktor;
        }

        public IEnumerable<Direktor> GetDirektori()
        {
            return db.Direktors;
        }

        public void UpdateDirektor(Direktor direktor)
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
