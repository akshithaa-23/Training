using InsuranceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceLibrary.Services
{
    public class PolicyService
    {
        public List<InsurancePolicy> ll = new List<InsurancePolicy>();
        public void AddPolicy(InsurancePolicy policy)
        {
            ll.Add(policy);
        }
        public List<InsurancePolicy> GetAllPolicies()
        {
            return ll;
        }

        public InsurancePolicy? GetPolicyById(int id)
        {
            foreach (var l in ll)
            {
                if (l.PolicyId == id)
                {
                    return l;
                }
            }
            return null;
        }

        public bool UpdatePolicy(int id, InsurancePolicy updatedPolicy)//decimal NewPremium, Int NewTerm
        {
            for (int i = 0; i < ll.Count; i++)
            {
                if (ll[i].PolicyId == id)
                {
                    ll[i] = updatedPolicy;
                    return true;
                }
            }
            return false;
        }
        public bool DeletePolicy(int id)
        {
            for (int i = 0; i < ll.Count; i++)
            {
                if (ll[i].PolicyId == id)
                {
                    ll.RemoveAt(i);
                    return true;
                }
            }
            return false;

        }
    }
}
