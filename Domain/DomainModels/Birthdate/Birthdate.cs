using System;

namespace Domain
{
    public class Birthdate
    {
        private readonly DateTime _val;

        public Birthdate(string birhdateString)
        {
            _val = DateTime.ParseExact(birhdateString, "yyyyMMdd", null);
        }

        public override string ToString()
        {
            return _val.ToString("yyyyMMdd");
        }

        /// <summary>
        /// 生年月日から年齢を算出します。
        /// </summary>
        /// <param name="CalcDate">計算基準日</param>
        /// <param name="isAddPreviousDay">誕生日の前日に年齢加算するか(民法第143条)</param>
        /// <returns>年齢</returns>
        public int GetAge(DateTime CalcDate, bool isAddPreviousDay)
        {
            var correctedCalcDate = CalcDate.AddDays(isAddPreviousDay ? 1 : 0);
            var age = correctedCalcDate.Year - _val.Year;

            if (correctedCalcDate.Month < _val.Month)
            {
                return age - 1;
            }
            if (correctedCalcDate.Month == _val.Month && correctedCalcDate.Day < _val.Day)
            {
                return age - 1;
            }
            return age;
        }
        /// <summary>
        /// 生年月日から年齢日齢月齢を算出します。
        /// </summary>
        /// <param name="CalcDate">計算基準日</param>
        /// <param name="isAddPreviousDay">誕生日の前日に年齢加算するか(民法第143条)</param>
        /// <returns>年齢(3桁)月齢(2桁)日齢(2桁)</returns>
        public string GetDetailedAge(DateTime CalcDate, bool isAddPreviousDay)
        {
            var correctedCalcDate = CalcDate.AddDays(isAddPreviousDay ? 1 : 0);

            var yearAge = GetAge(CalcDate, isAddPreviousDay);
            var latestYearBirthdate = _val.AddYears(yearAge);

            var monthAge = (correctedCalcDate.Month + (correctedCalcDate.Year - latestYearBirthdate.Year) * 12) - latestYearBirthdate.Month;
            if (correctedCalcDate.Day < latestYearBirthdate.Day)
            {
                monthAge--;
            }

            var latestMonthBirthdate = latestYearBirthdate.AddMonths(monthAge);
            var diff = correctedCalcDate - latestMonthBirthdate;
            var dayAge = (int)diff.TotalDays;

            var yearString = yearAge.ToString().PadLeft(3, '0');
            var monthString = monthAge.ToString().PadLeft(2, '0');
            var dayString = dayAge.ToString().PadLeft(2, '0');
            return $"{yearString}{monthString}{dayString}";
        }
    }
}