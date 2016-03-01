using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aseguradora.Utilities
{
    class RandomDataGenerator
    {
        internal static Policy[] CreateRandomPolicies()
        {
            const int maxPolicies = 5;
            Policy[] aPolicies = new Policy[maxPolicies];
            for(int i = 0; i < maxPolicies; i++)
            {
                aPolicies[i] = new Policy(RandomString(5), RandomString(20), i);
            }
            return aPolicies;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
