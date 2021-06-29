using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze.Repository.Interfaces
{
    public interface IDoktorRepository
    {
        IEnumerable<Doktor> GetDoktor();

        Doktor GetDoktorById(decimal id);

        void AddDoktor(Doktor doktor);

        void UpdateDoktor(Doktor doktor);

        void DeleteDoktor(Doktor doktor);
    }
}
