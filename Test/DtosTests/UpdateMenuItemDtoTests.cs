using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class UpdateMenuItemDtoTests : BaseTests<UpdateMenuItemDto>
{
    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        obj.Name = GetRandom.String();
        obj.Price = GetRandom.Decimal();
    }

    [TestMethod] public void NameTest() => areEqual(obj.Name, obj.Name);
    [TestMethod] public void PriceTest() => areEqual(obj.Price, obj.Price);
}