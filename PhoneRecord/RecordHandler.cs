using System.Text.Json;

namespace PhoneRecord;

public class RecordHandler
{
    public static void UpdateRecord(Record record,string newNumber)
    {
        if (IsRecordExist(record))
        {
            record.Number = newNumber;
            return;
        }
        Console.WriteLine("Record not found!");
    }

    public static void DeleteRecord(Record record)
    {
        if (IsRecordExist(record))
        {
            Database.PhoneRecordList.Remove(record);
            Console.WriteLine("Record deleted successfully!");
            return;
        }
        Console.WriteLine("Record not found!");
    }

    public static void AddRecord(Record record)
    {
        if (IsRecordExist(record))
            Console.WriteLine("This number already exists!");
        else
            Database.PhoneRecordList.Add(record);
    }

    public static void ListRecords(bool reverse = false)
    {
        var json = JsonSerializer.Serialize(Database.PhoneRecordList);
        var copyList = JsonSerializer.Deserialize<List<Record>>(json);
        
        if (copyList == null)
            return;
        copyList.Sort((record1,record2) => string.Compare(record1.Name, record2.Name, StringComparison.Ordinal));
        
        if (reverse)
            copyList.Reverse();
        
        foreach (var record in copyList)
        {
            Console.WriteLine($"Name : {record.Name} Surname : {record.Surname} Number : {record.Number} ");
        }
    }

    public static Record? FindRecordByNumber(string number)
    {
        return Database.PhoneRecordList.Find(x => x.Number == number);
    }

    public static Record? FindRecordByNameAndSurname(string name,string surname)
    {
        return Database.PhoneRecordList.Find(x => x.Name == name && x.Surname == surname);
    }

    private static bool IsRecordExist(Record record)
    {
        return Database.PhoneRecordList.Exists(x => x.Number == record.Number);
    }
}