file = open("HRMasterlistB.txt", "r")
totalsalary = 0
for line in file.readlines():
    record = line.split("|")
    hiretype = record[7]
    date = record[3].split("/")
    year = int(date[2])
    if year > 1995 and hiretype =="FullTime":
        totalsalary += int(record[9]) * 0.85
    else:
        totalsalary += int(record[9])
file.close()
print("Total computed salary: ${:.2f}".format(totalsalary))