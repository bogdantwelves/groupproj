using System;
using Abc.Aids;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class UpdateReservationDtoTests : BaseTests<UpdateReservationDto>
{
    private string customerName = string.Empty;
    private DateTime dateTime;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        customerName = GetRandom.String();
        dateTime = GetRandom.DateTime();
        obj.CustomerName = customerName;
        obj.DateTime = dateTime;
    }

    [TestMethod] public void CustomerNameTest() => areEqual(customerName, obj.CustomerName);
    [TestMethod] public void DateTimeTest() => areEqual(dateTime, obj.DateTime);
}
