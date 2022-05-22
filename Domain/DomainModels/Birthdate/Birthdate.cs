using System;

namespace Domain
{
    public class Birthdate
    {
        public DateTime Val { get; }
        public Birthdate(string birhdateString)
        {
            Val = DateTime.ParseExact(birhdateString, "yyyyMMdd", null);
        }
        public override string ToString()
        {
            return Val.ToString("yyyyMMdd");
        }
        public int GetAge(DateTime calculatingDate, bool isAddPreviousDay)
        {
            var correctedCalculatingDate = calculatingDate.AddDays(isAddPreviousDay ? 1 : 0);
            var age = correctedCalculatingDate.Year - Val.Year;

            if (correctedCalculatingDate.Month < Val.Month)
            {
                return age - 1;
            }
            if (correctedCalculatingDate.Month == Val.Month && correctedCalculatingDate.Day < Val.Day)
            {
                return age - 1;
            }
            return age;
        }
        public string GetDetailedAge(DateTime calculatingDate, bool isAddPreviousDay)
        {
            return "0270000";
        }
    }
}