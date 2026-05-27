using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class InventoryDtoTests : BaseTests<InventoryDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.Id = Guid.NewGuid();
        obj.Ingredients = new List<IngredientDto>();
    }

    [TestMethod] public void IdTest() => areEqual(obj.Id, obj.Id);
    [TestMethod] public void IngredientsTest() => areEqual(obj.Ingredients, obj.Ingredients);
}