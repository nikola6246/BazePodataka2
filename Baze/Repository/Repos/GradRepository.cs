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
    public class GradRepository : IGradRepository
    {
        private Model1Container db;
        public GradRepository()
        {
            db = new Model1Container();
        }

        public void AddGrad(Grad grad)
        {
            db.Grads.Add(grad);
            try
            {
                
                db.SaveChanges();

            }
            catch (DBConcurrencyException ce)
            {
                Trace.TraceInformation(ce.Message);
            }
            
        }

        public void DeleteGrad(Grad grad)
        {
            db.SaveChanges();
            db.Grads.Remove(grad);
            db.SaveChanges();
        }

        public Grad GetGradById(int id)
        {
            return db.Grads.Find(id) as Grad;
        }

        public IEnumerable<Grad> GetGradovi()
        {
            return db.Grads;
        }

        public void UpdateGrad(Grad grad)
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
