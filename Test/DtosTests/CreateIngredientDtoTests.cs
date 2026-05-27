using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class CreateIngredientDtoTests : BaseTests<CreateIngredientDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.Name = GetRandom.String();
        obj.Quantity = GetRandom.Decimal();
    }

    [TestMethod] public void NameTest() => areEqual(obj.Name, obj.Name);
    [TestMethod] public void QuantityTest() => areEqual(obj.Quantity, obj.Quantity);
}