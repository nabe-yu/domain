using Xunit;
using System;

namespace DomainTests;

public class UnitTest1
{
    [Fact]
    public void yyyyMMdd文字列に変換する()
    {
        var birthdate = new Domain.Birthdate("19570426");
        Assert.Equal("19570426", birthdate.ToString());

    }

    [Fact]
    public void 年齢を整数で算出する_前日加算_民法第143条()
    {
        var CalcDate = DateTime.Parse("2022-05-27");
        var isAddPreviousDay = true;

        var birthdate = new Domain.Birthdate("19970528");
        Assert.Equal(25, birthdate.GetAge(CalcDate, isAddPreviousDay));
    }

    [Fact]
    public void 年齢を整数で算出する_当日加算()
    {
        var CalcDate = DateTime.Parse("2022-05-28");
        var isAddPreviousDay = false;

        var birthdate = new Domain.Birthdate("19970528");
        Assert.Equal(25, birthdate.GetAge(CalcDate, isAddPreviousDay));
    }

    [Fact]
    public void 年齢月齢日齢をyyyMMddの文字列に変換する_前日加算_民法第143条()
    {
        var CalcDate = DateTime.Parse("2022-05-22");
        var isAddPreviousDay = true;

        var birthdate = new Domain.Birthdate("19540312");
        Assert.Equal("0680211", birthdate.GetDetailedAge(CalcDate, isAddPreviousDay));
    }

    [Fact]
    public void 年齢月齢日齢をyyyMMddの文字列に変換する_当日加算()
    {
        var CalcDate = DateTime.Parse("2020-02-29");
        var isAddPreviousDay = false;

        var birthdate = new Domain.Birthdate("20200229");
        Assert.Equal("0000000", birthdate.GetDetailedAge(CalcDate, isAddPreviousDay));
    }
}