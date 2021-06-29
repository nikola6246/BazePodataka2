using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze.Repository.Interfaces
{
    public interface IZaposleniRepository
    {
        IEnumerable<Zaposleni> GetZaposleni();

        Zaposleni GetZaposlenById(decimal id);

        void AddZaposlen(Zaposleni zaposleni);

        void UpdateZaposlen(Zaposleni zaposleni);

        void DeleteZaposlen(Zaposleni zaposleni);
    }
}
