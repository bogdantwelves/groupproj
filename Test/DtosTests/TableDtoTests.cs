using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class TableDtoTests : BaseTests<TableDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.Id = Guid.NewGuid();
        obj.TableNumber = GetRandom.Int32();
        obj.Capacity = GetRandom.Int32();
        obj.IsAvailable = true;
    }

    [TestMethod] public void IdTest() => areEqual(obj.Id, obj.Id);
    [TestMethod] public void TableNumberTest() => areEqual(obj.TableNumber, obj.TableNumber);
    [TestMethod] public void CapacityTest() => areEqual(obj.Capacity, obj.Capacity);
    [TestMethod] public void IsAvailableTest() => areEqual(obj.IsAvailable, obj.IsAvailable);
}