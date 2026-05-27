using System;
using Abc.Aids;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class CreateReservationDtoTests : BaseTests<CreateReservationDto>
{
    private string customerName = string.Empty;
    private string restaurantName = string.Empty;
    private DateTime dateTime;
    private int partySize;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        customerName = GetRandom.String();
        restaurantName = GetRandom.String();
        dateTime = GetRandom.DateTime();
        partySize = GetRandom.Int32();
        obj.CustomerName = customerName;
        obj.RestaurantName = restaurantName;
        obj.DateTime = dateTime;
        obj.PartySize = partySize;
    }

    [TestMethod] public void CustomerNameTest() => areEqual(customerName, obj.CustomerName);
    [TestMethod] public void RestaurantNameTest() => areEqual(restaurantName, obj.RestaurantName);
    [TestMethod] public void DateTimeTest() => areEqual(dateTime, obj.DateTime);
    [TestMethod] public void PartySizeTest() => areEqual(partySize, obj.PartySize);
}
