using System;
using Abc.Aids;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class TableDtoTests : BaseTests<TableDto>
{
    private Guid id;
    private int tableNumber;
    private int capacity;
    private bool isAvailable;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        tableNumber = GetRandom.Int32();
        capacity = GetRandom.Int32();
        isAvailable = GetRandom.Int32() % 2 == 0;
        obj.Id = id;
        obj.TableNumber = tableNumber;
        obj.Capacity = capacity;
        obj.IsAvailable = isAvailable;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void TableNumberTest() => areEqual(tableNumber, obj.TableNumber);
    [TestMethod] public void CapacityTest() => areEqual(capacity, obj.Capacity);
    [TestMethod] public void IsAvailableTest() => areEqual(isAvailable, obj.IsAvailable);
}
