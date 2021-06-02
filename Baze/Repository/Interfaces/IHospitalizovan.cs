using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze.Repository.Interfaces
{
    public interface IHospitalizovan
    {
        IEnumerable<Grad> GetHospitalizovani();

        Hospitalizovani GetHospitalizovanById(int id);

        void AddHospitalizovan(Hospitalizovani hospitalizovan);

        void UpdateHospitalizovan(Hospitalizovani hospitalizovan);

        void DeleteHospitalizovan(Hospitalizovani hospitalizovan);
    }
}
