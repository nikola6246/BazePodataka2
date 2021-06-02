using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze.Repository.Interfaces
{
    public interface IPregleda
    {
        IEnumerable<Pregleda> GetPregledani();

        Pregleda GetPregledaById(int id);

        void AddPregleda(Pregleda pregleda);

        void UpdatePregleda(Pregleda pregleda);

        void DeletePregleda(Pregleda pregleda);
    }
}
