using System;
using Abc.Aids;
using Data.Restaurant.Entities;
using Data.Restaurant.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Entities;

[TestClass]
public class IngredientTests : BaseTests<Ingredient>
{
    private Guid id;
    private string name = string.Empty;
    private decimal quantity;
    private decimal lowStockThreshold;
    private Guid inventoryId;
    private Inventory? inventory;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        name = GetRandom.String();
        quantity = GetRandom.Decimal();
        lowStockThreshold = GetRandom.Decimal();
        inventoryId = Guid.NewGuid();
        inventory = new Inventory();
        obj.Id = id;
        obj.Name = name;
        obj.Quantity = quantity;
        obj.LowStockThreshold = lowStockThreshold;
        obj.InventoryId = inventoryId;
        obj.Inventory = inventory;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void NameTest() => areEqual(name, obj.Name);
    [TestMethod] public void QuantityTest() => areEqual(quantity, obj.Quantity);
    [TestMethod] public void LowStockThresholdTest() => areEqual(lowStockThreshold, obj.LowStockThreshold);
    [TestMethod] public void InventoryIdTest() => areEqual(inventoryId, obj.InventoryId);
    [TestMethod] public void InventoryTest() => areSame(inventory, obj.Inventory);
}
