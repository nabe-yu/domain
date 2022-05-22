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
    }
}