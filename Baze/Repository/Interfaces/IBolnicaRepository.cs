using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze.Repository.Interfaces
{
    public interface IBolnicaRepository
    {
        IEnumerable<Bolnica> GetBolnice();

        Bolnica GetBolnicaById(int id);

        void AddBolnica(Bolnica bolnica);

        void UpdateBolnica(Bolnica bolnica);

        void DeleteBolnica(Bolnica bolnica);
    }
}
