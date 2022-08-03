using System;
using System.Collections.Generic;
using System.IO;

namespace SectionA
{
    public class Employee
    {
        public string Nric {get; set;}
        public string FullName {get; set;}
        public string Salution {get; set;}
        public DateTime StartDate = new DateTime();
        public string Designation {get; set;}
        public string Department {get; set;}
        public string MobileNo {get; set;}
        public string HireType {get; set;}
        public double Salary {get; set;}
        public double MonthlyPayout {get; set;} = 0.0;

        public void generateInfoForCorpAdmin(string filePath1){
            string filePath2 = @"../CorporateAdmin.txt";
            if (!File.Exists(filePath2)){
                using (StreamWriter streamWriter = File.CreateText(filePath2))
                {
                    foreach (string line in File.ReadAllLines(filePath1)) {
                        var record = line.Split('|');
                        streamWriter.WriteLine("{0},{1},{2}",record[1], record[4], record[5]);
                    }
                }
            }
        }
        public void generateInfoForProcurement(string filePath1) {
            string filePath2 = @"../Procurement.txt";
            if (!File.Exists(filePath2)){
                using (StreamWriter streamWriter = File.CreateText(filePath2))
                {
                    foreach (string line in File.ReadAllLines(filePath1)) {
                        var record = line.Split('|');
                        streamWriter.WriteLine("{0},{1},{2},{3},{4}",record[2], record[1], record[6], record[4], record[5]);
                    }
                }
            }
        }
        public void generateInfoForITDepartment(string filePath1){
            string filePath2 = @"../ITDepartment.txt";
            if (!File.Exists(filePath2)){
                using (StreamWriter streamWriter = File.CreateText(filePath2))
                {
                    foreach (string line in File.ReadAllLines(filePath1)) {
                        var record = line.Split('|');
                        streamWriter.WriteLine("{0},{1},{2},{3},{4}",record[0], record[1], record[3], record[5], record[6]);
                    }
                }
            }
        }
    }
}
