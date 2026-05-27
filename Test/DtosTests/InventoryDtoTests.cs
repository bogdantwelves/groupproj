using System;
using System.Collections.Generic;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class InventoryDtoTests : BaseTests<InventoryDto>
{
    private Guid id;
    private List<IngredientDto> ingredients = new();

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        ingredients = new List<IngredientDto> { new() };
        obj.Id = id;
        obj.Ingredients = ingredients;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void IngredientsTest() => areSame(ingredients, obj.Ingredients);
}
