﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
                aPolicies[i] = new Policy(RandomString(5), RandomString(20), i, randomType());
            }
            GenerateXML();
            return aPolicies;
        }

        private static void GenerateXML()
        {
            DataSet ds = new DataSet("myDataSet");
            string[] type = new string [4] {"hogar", "coche", "laboral", "salud" };
            XmlSerializer ser = new XmlSerializer(typeof(string []));
            FileStream file = File.Create("types.xml");
            ser.Serialize(file, type);
            file.Close();
        }

        private static string randomType()
        {
            
            return "";
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
