using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class CreateReservationDtoTests : BaseTests<CreateReservationDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.CustomerName = GetRandom.String();
        obj.RestaurantName = GetRandom.String();
        obj.DateTime = GetRandom.DateTime();
        obj.PartySize = GetRandom.Int32();
    }

    [TestMethod] public void CustomerNameTest() => areEqual(obj.CustomerName, obj.CustomerName);
    [TestMethod] public void RestaurantNameTest() => areEqual(obj.RestaurantName, obj.RestaurantName);
    [TestMethod] public void DateTimeTest() => areEqual(obj.DateTime, obj.DateTime);
    [TestMethod] public void PartySizeTest() => areEqual(obj.PartySize, obj.PartySize);
}