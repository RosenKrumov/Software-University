using System;

class PrintCompanyInfo
{
    static void Main()
    {
        string name = Console.ReadLine();
        string adress = Console.ReadLine();
        string phoneNum = Console.ReadLine();
        string faxNum = Console.ReadLine();
        string webSite = Console.ReadLine();
        string managerFirstName = Console.ReadLine();
        string managerLastName = Console.ReadLine();
        string managerAge = Console.ReadLine();
        string managerPhone = Console.ReadLine();
        if (faxNum == "")
        {
            faxNum = "(no fax)";
        }
        Console.WriteLine();
        Console.WriteLine(name);
        Console.WriteLine("Adress: " + adress);
        Console.WriteLine("Tel. " + phoneNum);
        Console.WriteLine("Fax: " + faxNum);
        Console.WriteLine("Web site: " + webSite);
        Console.WriteLine("Manager: " + managerFirstName + " " + managerLastName
                          + " " + "(age: {0}, tel. {1})", managerAge, managerPhone);
        

    }
}