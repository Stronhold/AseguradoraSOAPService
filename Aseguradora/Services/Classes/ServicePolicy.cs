using Aseguradora.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Aseguradora
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ServicePolicy : IServicePolicy
    {
        private static Policy [] aPolicy = new Policy[0];

        public bool AddPolicy(int id, string name, string desc)
        {
            Policy policy = new Policy(name, desc, id);
            var pol = aPolicy.Select(p => p.ID == policy.ID);
            if (pol != null && pol.Count() == 0)
            {
                List<Policy> listPolicy = aPolicy.ToList();
                listPolicy.Add(policy);
                aPolicy = listPolicy.ToArray();
                return true;
            }
            return false;
        }

        public Policy[] GetAllPolicies()
        {
            if(aPolicy.Length <= 0)
            {
                aPolicy = RandomDataGenerator.CreateRandomPolicies();
            }
            return aPolicy;
        }

        public Policy GetData(int id)
        {
            if(aPolicy == null)
            {
                return null;
            }
            else if (aPolicy.Count() < id)
            {
                return null;
            }
            else
            {
                return aPolicy[id];
            }
        }

        public Policy GetDataUsingDataContract(Policy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException("policy");
            }
            return policy;
        }

        public bool RemovePolicy(int id)
        {
            int prev = aPolicy.Count();
            aPolicy.Where(p => id != p.ID);
            if (aPolicy.Count() < prev){
                return true;   
            }
            return false;
        }

        public bool UpdatePolicy(int id, string name, string desc)
        {
            Policy updated = new Policy(name, desc, id);
            var exists = aPolicy.Select(p => updated.ID == p.ID);
            if(exists != null ||exists.Count() > 0)
            {
                for(int i = 0; i < aPolicy.Count(); i++)
                {
                    if(aPolicy[i].ID == updated.ID)
                    {
                        aPolicy[i] = updated;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
