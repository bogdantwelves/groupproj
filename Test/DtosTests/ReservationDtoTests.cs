using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Data.Restaurant.Enums;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class ReservationDtoTests : BaseTests<ReservationDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.Id = Guid.NewGuid();
        obj.CustomerName = GetRandom.String();
        obj.DateTime = GetRandom.DateTime();
        obj.TableNumber = GetRandom.Int32();
        obj.PartySize = GetRandom.Int32();
        obj.Status = (ReservationStatus)GetRandom.Int32();
    }

    [TestMethod] public void IdTest() => areEqual(obj.Id, obj.Id);
    [TestMethod] public void CustomerNameTest() => areEqual(obj.CustomerName, obj.CustomerName);
    [TestMethod] public void DateTimeTest() => areEqual(obj.DateTime, obj.DateTime);
    [TestMethod] public void TableNumberTest() => areEqual(obj.TableNumber, obj.TableNumber);
    [TestMethod] public void PartySizeTest() => areEqual(obj.PartySize, obj.PartySize);
    [TestMethod] public void StatusTest() => areEqual(obj.Status, obj.Status);
}