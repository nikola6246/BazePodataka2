using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze.Repository.Interfaces
{
    public interface ISestraRepository
    {
        IEnumerable<Sestra> GetSestre();

        Sestra GetSestraById(int id);

        void AddSestra(Sestra sestra);

        void UpdateSestra(Sestra sestra);

        void DeleteSestra(Sestra sestra);
    }
}
