using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class PhoneBook
{
    private List<string> strName = new List<string>();
    private List<string> strPhoneNum = new List<string>();
    private List<string> strSchoolNum = new List<string>();

    public void AddPhone(string name, string number, string school)
    {
        strName.Add(name);
        strPhoneNum.Add(number);
        strSchoolNum.Add(school);
    }

    public void PrintPhoneBook()
    {
        for(int i=0; i < strName.Count; i++)
        {
            Console.WriteLine($"{strName[i]}: {strPhoneNum[i]}: {strSchoolNum}");
        }
    }
    public void ReadCSVFile(string filename, bool hasheader=false)
    {
        var reader = new StreamReader(File.OpenRead(filename));
        if ( hasheader) reader.ReadLine(); // header Line pass
        while (!reader.EndOfStream)
        {
            var strInpute = reader.ReadLine();
            var strArray = strInpute.Split(',');

            AddPhone(strArray[0], strArray[1], strArray[2]);
        }
    }

    public bool FindNameByNumber(string number, out List<string> names)
    {
        names = new List<string>();
        var indexArr = strPhoneNum.Select(num => num.Contains(number)).ToList();

        if (indexArr.Count == 0) return false;
        for (int i = 0; i < indexArr.Count; i++)
        {
            if (indexArr[i]) names.Add(strName[i]);
        }

        return true;
    }

    public string ListUpAll()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < strName.Count; i++)
        {
            sb.Append(strName[i] + " " + strPhoneNum[i] + " " + strSchoolNum[i] + "\r\n");
        }
        return sb.ToString();
    }
}