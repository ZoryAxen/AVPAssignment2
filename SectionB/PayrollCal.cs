using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using SectionA;


namespace SectionB
{
    public delegate void Delegate(string i);
    public enum HireType {
        FullTime = 100,
        PartTime  = 50,
        Hourly = 25
    }
    class Program
    {
        public static List<int> processPayroll(List<string> employees){
            int totalsalary = 0;
            int totalemployees = 0;
            List<int> salaries = new List<int>();
            foreach (string line in File.ReadAllLines(@"../HRMasterlist.txt")) {
                var record = line.Split('|');
                int salary = 0;
                if (record[7] == "FullTime"){
                    salary = Int32.Parse(record[8]) * (int)HireType.FullTime / 100;
                }
                if (record[7] == "PartTime"){
                    salary = Int32.Parse(record[8]) * (int)HireType.PartTime / 100;
                }
                if (record[7] == "Hourly"){
                    salary = Int32.Parse(record[8]) * (int)HireType.Hourly / 100;
                }
                totalsalary += salary;
                totalemployees += 1;
                salaries.Add(salary);
                Console.WriteLine(string.Format("{0} ({1})", record[1], record[0]));
                Console.WriteLine(string.Format("{0}", record[4]));
                Console.WriteLine(string.Format("{0} Payout: {1}", record[7], salary));
                Console.WriteLine(string.Concat(Enumerable.Repeat("-", 30)));
            }
            Console.WriteLine(string.Format("Total Payroll Amout: ${0} to be paid to {1} employees.", totalsalary, totalemployees));
            return salaries;
        }
        public static void updateMonthlyPayoutToMasterlist(List<int> salaries){
            if (!File.Exists(@"../HRMasterlistB.txt")){
                using (StreamWriter streamWriter = File.CreateText(@"../HRMasterlistB.txt"))
                {
                    int counter = 0;
                    foreach (string line in File.ReadAllLines(@"../HRMasterlist.txt")) {
                        streamWriter.WriteLine("{0}|{1}", line, salaries[counter]);
                        counter += 1;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            List<string> employees = SectionA.Program.readHRMasterList(@"../HRMasterlist.txt");
            List<int> salaries = processPayroll(employees);
            updateMonthlyPayoutToMasterlist(salaries);
        }
    }
}

