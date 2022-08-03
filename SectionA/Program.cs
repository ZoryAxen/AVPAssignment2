using System;
using System.Collections.Generic;
using System.IO;

namespace SectionA
{
    public delegate void Delegate(string i);
    public class Program
    {
        public static List<string> readHRMasterList(string filePath1){
            List<string> employeeNames = new List<string>();
            foreach (string line in File.ReadAllLines(filePath1)) {
                var record = line.Split('|');
                employeeNames.Add(record[1]);
            }
            return employeeNames;
        }
        static void Main(string[] args)
        {
            string mainFile = @"../HRMasterlist.txt";
            Employee c = new Employee();
            List<string> employeeNames = readHRMasterList(mainFile);
            Delegate generateAll = c.generateInfoForCorpAdmin;
            generateAll += c.generateInfoForITDepartment;
            generateAll += c.generateInfoForProcurement;
            generateAll.Invoke(mainFile);
        }
    }
}
