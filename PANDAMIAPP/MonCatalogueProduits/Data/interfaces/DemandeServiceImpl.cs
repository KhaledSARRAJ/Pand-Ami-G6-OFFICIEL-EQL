using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonCatalogueProduit.Service.interfaces
{
     public class DemandeServiceImpl : IDemandeService
    {

        public Dictionary<int,Demande> Demandes = new Dictionary<int,Demande>();

        public DemandeServiceImpl()
        {
            Save(new Demande { Description = "HP 564", NombreDeFois = 4 });
            Save(new Demande { Description = "DELL", NombreDeFois = 7 });
            Save(new Demande { Description = "ASURE", NombreDeFois = 7 });
            Save(new Demande { Description = "Imprimante", NombreDeFois = 1 });
            Save(new Demande { Description = "Sumsung S5", NombreDeFois = 51 });
            Save(new Demande { Description = "Huawei J4", NombreDeFois = 15 });
            Save(new Demande { Description = "NOKIA", NombreDeFois = 11 });
            Save(new Demande { Description = "Sumsung J4", NombreDeFois = 11 });


        }



        public void Delete(int ID)
        {
            Demandes.Remove(ID);
        }

        public IEnumerable<Demande> FindAll()
        {
            return Demandes.Values;
        }

        public Demande GetOne(int ID)
        {
            Demande p;
            Demandes.TryGetValue(ID, out p);
            return p;
            // ou bien tous simplement : return Produits[ID];
        }

        public IEnumerable<Demande> DemandeParMC(string mc)
        {
            return Demandes.Values.Where(p => p.Description.Contains(mc));
           
         }

        public Demande Save(Demande p)
        {
            p.DemandeID = Demandes.Count + 1;
            Demandes[p.DemandeID] = p;
            return p;
           
        }

        public void Update(Demande p)
        {
            Demandes[p.DemandeID] = p;
        }
    }
}
