using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze.Repository.Interfaces
{
    public interface IGradRepository
    {
        IEnumerable<Grad> GetGradovi();

        Grad GetGradById(int id);

        void AddGrad(Grad grad);

        void UpdateGrad(Grad grad);

        void DeleteGrad(Grad grad);
    }
}
