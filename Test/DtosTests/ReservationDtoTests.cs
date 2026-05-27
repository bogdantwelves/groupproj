using System;
using Abc.Aids;
using Data.Restaurant.DTOs;
using Data.Restaurant.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class ReservationDtoTests : BaseTests<ReservationDto>
{
    private Guid id;
    private string customerName = string.Empty;
    private DateTime dateTime;
    private int? tableNumber;
    private int partySize;
    private ReservationStatus status;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        customerName = GetRandom.String();
        dateTime = GetRandom.DateTime();
        tableNumber = GetRandom.Int32();
        partySize = GetRandom.Int32();
        status = ReservationStatus.Confirmed;
        obj.Id = id;
        obj.CustomerName = customerName;
        obj.DateTime = dateTime;
        obj.TableNumber = tableNumber;
        obj.PartySize = partySize;
        obj.Status = status;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void CustomerNameTest() => areEqual(customerName, obj.CustomerName);
    [TestMethod] public void DateTimeTest() => areEqual(dateTime, obj.DateTime);
    [TestMethod] public void TableNumberTest() => areEqual(tableNumber, obj.TableNumber);
    [TestMethod] public void PartySizeTest() => areEqual(partySize, obj.PartySize);
    [TestMethod] public void StatusTest() => areEqual(status, obj.Status);
}
