using Abc.Aids;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class CreateIngredientDtoTests : BaseTests<CreateIngredientDto>
{
    private string name = string.Empty;
    private decimal quantity;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        name = GetRandom.String();
        quantity = GetRandom.Decimal();
        obj.Name = name;
        obj.Quantity = quantity;
    }

    [TestMethod] public void NameTest() => areEqual(name, obj.Name);
    [TestMethod] public void QuantityTest() => areEqual(quantity, obj.Quantity);
}
