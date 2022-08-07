gethiretype = lambda x: x[7]
getyear = lambda x: int((x[3].split("/"))[2])
changesalary = lambda x, y: int(x[9]) * y

file = open("HRMasterlistB.txt", "r")
lines = file.readlines()
totalsalary = 0
for line in lines:
    record = line.split("|")
    hiretype = gethiretype(record)
    year = getyear(record)
    if year > 1995 and hiretype =="FullTime":
        totalsalary += changesalary(record, 0.85)
    else:
        totalsalary += changesalary(record, 1)
file.close()
print("Total computed salary: ${:.2f}".format(totalsalary))