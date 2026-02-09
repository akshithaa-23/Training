using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InsuranceLibrary.Models
{
    public class InsurancePolicy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public string PolicyType { get; set; }
        public decimal PremiumAmount { get; set; }
        public int PolicyTerm { get; set; }
        public bool IsActive { get; set; }

        public InsurancePolicy() {
            IsActive = true;
        }

        public InsurancePolicy(int id, string name,string type, decimal amount,int term, bool active)
        {
            PolicyId = id;
            PolicyHolderName = name;
            PolicyType = type;
            PremiumAmount = amount;
            PolicyTerm = term;
            IsActive = active;

        }

        public override string ToString()
        {
            return $"PolicyId : {PolicyId}\t PolicyHolderName : {PolicyHolderName}\t PolicyType : {PolicyType}\t PremiumAmount : {PremiumAmount}\t PolicyTerm : {PolicyTerm} IsActive : {IsActive} ";
        }

    }
}
