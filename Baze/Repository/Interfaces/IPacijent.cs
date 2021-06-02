using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze.Repository.Interfaces
{
    public interface IPacijent
    {
        IEnumerable<Pacijent> GetPacijenti();

        Pacijent GetPacijentById(int id);

        void AddPacijent(Pacijent pacijent);

        void UpdatePacijent(Pacijent pacijent);

        void DeletePacijent(Pacijent pacijent);
    }
}
