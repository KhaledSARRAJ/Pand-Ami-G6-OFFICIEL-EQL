using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonCatalogueProduit.Service.interfaces
{
    public interface IDemandeService
{
        Demande Save(Demande p);
        IEnumerable<Demande> FindAll();
        IEnumerable<Demande> DemandeParMC(string mc);
        Demande GetOne(int ID);
        void Update(Demande p);
        void Delete(int ID);
    }
}
