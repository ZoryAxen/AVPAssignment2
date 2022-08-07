def gethiretype(record):
    return record[7]
def getyear(record):
    return int((record[3].split("/"))[2])
def changesalary(record, change):
    return int(record[9]) * change

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