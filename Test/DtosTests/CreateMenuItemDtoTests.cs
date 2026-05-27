using Abc.Aids;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class CreateMenuItemDtoTests : BaseTests<CreateMenuItemDto>
{
    private string name = string.Empty;
    private string description = string.Empty;
    private decimal price;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        name = GetRandom.String();
        description = GetRandom.String();
        price = GetRandom.Decimal();
        obj.Name = name;
        obj.Description = description;
        obj.Price = price;
    }

    [TestMethod] public void NameTest() => areEqual(name, obj.Name);
    [TestMethod] public void DescriptionTest() => areEqual(description, obj.Description);
    [TestMethod] public void PriceTest() => areEqual(price, obj.Price);
}
