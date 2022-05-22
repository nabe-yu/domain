using System;

var birthdate = new Domain.Birthdate("20001111");

Console.WriteLine(birthdate.GetAge(DateTime.Now, true));
Console.WriteLine(birthdate.GetDetailedAge(DateTime.Now, true));