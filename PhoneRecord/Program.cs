
using PhoneRecord;

Console.WriteLine("Please select the operation you want to perform: " +
                  "(1) Save New Number " +
                  "(2) Delete Existing Number " +
                  "(3) Update Existing Number " +
                  "(4) List Directory " +
                  "(5) Search in Directory");
var response = int.Parse(Console.ReadLine() ?? string.Empty);
var exit = false;

while (!exit)
{
   if (response is < 6 and > 0)
   {
       switch (response)
       {
           case 1:
               Console.WriteLine("Please enter a name: ");
               var name = Console.ReadLine() ?? string.Empty;
               Console.WriteLine("Please enter a surname: ");
               var surname = Console.ReadLine() ?? string.Empty;
               Console.WriteLine("Please enter a number: ");
               var number = Console.ReadLine() ?? string.Empty;
               RecordHandler.AddRecord(new Record(name,surname,number));
               Console.WriteLine("Successfully added!");
               FinishOrContinue();
               break;
           case 2:
               var option = 0;
               while (option != 1)
               {
                   Console.WriteLine("Please enter the name and surname of the person whose number you want to delete: ");
                   var nameSurname = Console.ReadLine() ?? string.Empty;
                   name = nameSurname.Split(" ")[0];
                   surname = nameSurname.Split(" ")[1];
                   var recordToDelete = RecordHandler.FindRecordByNameAndSurname(name, surname);
                   if (recordToDelete != null)
                   {
                       Console.WriteLine($"The person whose name is {name} is about to be deleted, do you confirm this action?(y/n)");
                       var delete = Console.ReadLine();
                       if (delete == "y")
                       {
                           RecordHandler.DeleteRecord(recordToDelete);
                           option = 1;
                       }
                   }
                   else
                   {
                       Console.WriteLine("Data matching your criteria was not found in the directory. Please make a selection.");
                       Console.WriteLine("*To terminate deletion: (1)");
                       Console.WriteLine("*To try again: (2)");
                       option = int.Parse(Console.ReadLine() ?? string.Empty);
                   }
               }
               FinishOrContinue();
               break;
           case 3:
               var updateOption = 0;
               while (updateOption != 1)
               {
                   Console.WriteLine("Please enter the number you want to update: ");
                   number = Console.ReadLine() ?? string.Empty;
                   var recordToUpdate = RecordHandler.FindRecordByNumber(number);
                   if (recordToUpdate != null)
                   {
                       Console.WriteLine("Please enter the new number: ");
                       var newNumber = Console.ReadLine() ?? string.Empty;
                       RecordHandler.UpdateRecord(recordToUpdate, newNumber);
                       updateOption = 1;
                   }
                   else
                   {
                       Console.WriteLine("Data matching your criteria was not found in the directory. Please make a selection.");
                       Console.WriteLine("*To terminate updating: (1)");
                       Console.WriteLine("*To try again: (2)");
                       updateOption = int.Parse(Console.ReadLine() ?? string.Empty);
                   }
               }
               FinishOrContinue();
               break;
           case 4:
               Console.WriteLine("How would you like to list? A-Z (1) | Z-A (2)");
               var listingOption = Console.ReadLine() ?? string.Empty;
               if(listingOption == "1")
                   RecordHandler.ListRecords();
               else
                   RecordHandler.ListRecords(true);
               FinishOrContinue();
               break;
           case 5:
               Console.WriteLine("To search by name and surname: (1) To search by number: (2)");
               var searchOption = Console.ReadLine() ?? string.Empty;
               switch (searchOption)
               {
                   case "1":
                   {
                       Console.WriteLine("Please enter a name: ");
                       name = Console.ReadLine() ?? string.Empty;
                       Console.WriteLine("Please enter a surname: ");
                       surname = Console.ReadLine() ?? string.Empty;
                       var record = RecordHandler.FindRecordByNameAndSurname(name, surname);
                       Console.WriteLine($"Name : {record.Name} Surname : {record.Surname} Number : {record.Number}");
                       break;
                   }
                   case "2":
                   {
                       Console.WriteLine("Lutfen numarayi giriniz : ");
                       number = Console.ReadLine() ?? string.Empty;
                       var record = RecordHandler.FindRecordByNumber(number);
                       Console.WriteLine($"Name : {record.Name} Surname : {record.Surname} Number : {record.Number}");
                       break;
                   }
               }
               FinishOrContinue();
               break;
       }
   } 
}

return;

void FinishOrContinue()
{
    Console.WriteLine("Would you like to perform another operation? (y/n)");
    var isContinue = Console.ReadLine() ?? string.Empty;
    if (isContinue == "n")
        exit = true;
    else
    {
        Console.WriteLine("Please select the operation you want to perform: " +
                          "(1) Save New Number " +
                          "(2) Delete Existing Number " +
                          "(3) Update Existing Number " +
                          "(4) List Directory " +
                          "(5) Search in Directory");
        response = int.Parse(Console.ReadLine() ?? string.Empty);
    }
}
