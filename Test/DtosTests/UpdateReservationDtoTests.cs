using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class UpdateReservationDtoTests : BaseTests<UpdateReservationDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.CustomerName = GetRandom.String();
        obj.DateTime = GetRandom.DateTime();
    }

    [TestMethod] public void CustomerNameTest() => areEqual(obj.CustomerName, obj.CustomerName);
    [TestMethod] public void DateTimeTest() => areEqual(obj.DateTime, obj.DateTime);
}